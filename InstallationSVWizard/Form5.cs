using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace InstallationSVWizard
{
    public partial class frmDatabase : Form
    {

        private DBProcess db = new DBProcess();
        private string dbDirectory = string.Empty;

        public frmDatabase()
        {
            InitializeComponent();

            SA_Config_Info.Configuration.GetConfigInfo("ConfigInfo.xml");

            db.Server = SA_Config_Info.Configuration.Info.ServerInfo.SQLServer.DataSource;
            db.DbName = SA_Config_Info.Configuration.Info.ServerInfo.SQLServer.Catalog;
            db.UserID = SA_Config_Info.Configuration.Info.ServerInfo.SQLServer.UserID;
            db.Password = SA_Config_Info.Configuration.Info.ServerInfo.SQLServer.Password;

            dbDirectory = Path.Combine(Environment.CurrentDirectory, "Database");
            LoadRestoreDatabase(lsbBackupFiles, dbDirectory, "*.bak");
            LoadCurrentServerNames(cbCurrentServer);
            LoadCurrentDatabaseNames(lsbCurrentDB);

        }

        private void LoadRestoreDatabase(ListBox lsb, string Folder, string FileType)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                lsb.Items.Add(file.Name);
            }
        }

        private void LoadCurrentServerNames(ComboBox cb)
        {
            Dictionary<string, string> listServers = new Dictionary<string, string>();
            listServers = db.LoadServerNames();
            if (listServers != null)
            {
                cb.DataSource = new BindingSource(listServers, null);
                cb.DisplayMember = "Value";
                cb.ValueMember = "Key";
            }
        }

        private void LoadCurrentDatabaseNames(ListBox lsb, string fromServer = "")
        {
            List<string> listDBs = new List<string>();
            listDBs = db.LoadDatabaseNames(fromServer);
            if (listDBs != null)
            {
                lsb.Items.Clear();
                foreach (string item in listDBs)
                {
                    lsb.Items.Add(item);
                }
            }
        }

        private void cbCurrentServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = ((KeyValuePair<string, string>)cbCurrentServer.SelectedItem).Value;
            LoadCurrentDatabaseNames(lsbCurrentDB, value);
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                string backupFile = lsbBackupFiles.SelectedItem.ToString();
                string fromServer = ((KeyValuePair<string, string>)cbCurrentServer.SelectedItem).Value;
                if (!string.IsNullOrEmpty(backupFile) && !string.IsNullOrEmpty(fromServer))
                {
                    string backupFilePath = Path.Combine(dbDirectory, backupFile);
                    string databaseName = (!string.IsNullOrEmpty(txtDatabaseName.Text)?txtDatabaseName.Text : backupFile.ToLower().Replace(".bak", ""));
                    db.RestoreDatabase(databaseName, backupFilePath, fromServer);
                }
            }
            catch
            {

            }
            finally
            {
                MessageBox.Show("Successfully Restore Database!");
            }
        }

        private void lsbBackupFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDatabaseName.Text = lsbBackupFiles.SelectedItem.ToString();
        }
    }

    public class DBProcess
    {
        private string sqlConnectionString = "";
        private SqlConnection conn;
        private ServerConnection sv_conn;
        public string Server;
        public string DbName;
        public string UserID;
        public string Password;

        private void OpenConnection()
        {
            sqlConnectionString = string.Format(@"data source={0};initial catalog={1};persist security info=True;User ID={2};Password={3};",
                                                Server, DbName, UserID, Password);
            conn = new SqlConnection(sqlConnectionString);
            conn.Open();
        }

        private void OpenConnectionGlobal(string fromServer = "")
        {
            if (fromServer == "")
            {
                sqlConnectionString = string.Format(@"data source={0};persist security info=True;User ID={1};Password={2};",
                                                Server, UserID, Password);
            }
            else
            {
                sqlConnectionString = string.Format(@"data source={0};Initial Catalog=master;persist security info=True;User ID={1};Password={2};",
                                                fromServer, UserID, Password);
            }
            
            conn = new SqlConnection(sqlConnectionString);
            conn.Open();
        }

        private void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        private void OpenServerConnection(string fromServer = "")
        {
            sv_conn = new ServerConnection(fromServer, UserID, Password);
        }

        private void CloseServerConnection()
        {
            sv_conn.Disconnect();
        }

        public List<string> LoadDatabaseNames(string fromServer = "")
        {
            try
            {
                OpenConnectionGlobal(fromServer);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                // select * from sys.databases getting all database name from sql server 
                cmd.CommandText = @"select * from sys.databases where name not in ('master', 'tempdb', 'model', 'msdb')";
                cmd.CommandType = CommandType.Text;
                //
                List<string> listData = new List<string>();
                using (SqlDataReader dReader = cmd.ExecuteReader())
                {
                    while (dReader.Read())
                    {
                        listData.Add(dReader[0].ToString());
                    }
                }
                //
                return listData;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        public Dictionary<string, string> LoadServerNames()
        {
            try
            {
                OpenConnectionGlobal();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                // select * from sys.databases getting all database name from sql server 
                cmd.CommandText = @"select *  from sys.servers";
                cmd.CommandType = CommandType.Text;
                //
                Dictionary<string, string> listData = new Dictionary<string, string>();
                using (SqlDataReader dReader = cmd.ExecuteReader())
                {
                    while (dReader.Read())
                    {
                        listData.Add(dReader[0].ToString(), dReader[1].ToString());
                    }
                }
                //
                return listData;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void RestoreDatabase(string databaseName, string backupFilePath, string fromServer = "")
        {
            Cursor.Current = Cursors.WaitCursor;
            OpenServerConnection(fromServer);
            SqlTransaction trans = conn.BeginTransaction();
            try
            {

                Server sqlServer = new Server(sv_conn);
                
                //
                
                //
                trans.Commit();
            }
            catch(Exception ex)
            {
                trans.Rollback();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                CloseServerConnection();
            }
        }
    }


}
