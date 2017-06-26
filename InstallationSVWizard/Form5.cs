using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Data.Sql;

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

            txtUserID.Text = db.UserID;
            txtPassword.Text = db.Password;

            dbDirectory = Path.Combine(Environment.CurrentDirectory, "Database");
            LoadRestoreDatabase(lsbBackupFiles, dbDirectory, "*.bak");
            LoadCurrentServerNames(cbCurrentServer);
            LoadCurrentDatabaseNames(lsbCurrentDB);

        }

        private void LoadRestoreDatabase(ListBox lsb, string Folder, string FileType)
        {
            try
            {
                DirectoryInfo dinfo = new DirectoryInfo(Folder);
                FileInfo[] Files = dinfo.GetFiles(FileType);
                foreach (FileInfo file in Files)
                {
                    lsb.Items.Add(file.Name);
                }
            }
            catch
            {

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
            if (cbCurrentServer.SelectedIndex != -1)
            {
                string value = cbCurrentServer.SelectedValue.ToString();
                LoadCurrentDatabaseNames(lsbCurrentDB, value);
            }
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
                    // db.RestoreDatabase(databaseName, backupFilePath, fromServer);
                    db.RestoreDatabase(databaseName, backupFilePath);
                    MessageBox.Show("Successfully Restore Database!");
                }
            }
            catch
            {

            }
            finally
            {
                
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

        public List<string> LoadDatabaseNames(string fromServer = "")
        {
            try
            {
                OpenConnectionGlobal(fromServer);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                // select * from sys.databases getting all database name from sql server 
                cmd.CommandText = @"select * from sys.databases where name not in ('master', 'tempdb', 'model', 'msdb') and name not like 'ReportServer$%'";
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
                //
                OpenConnectionGlobal();
                Dictionary<string, string> listData = new Dictionary<string, string>();
                //
                SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
                DataTable dTable = instance.GetDataSources();
                foreach (DataRow row in dTable.Rows)
                {
                    foreach (DataColumn col in dTable.Columns)
                    {
                        listData.Add(col.ColumnName.ToString(), row[col].ToString());
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
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                OpenConnectionGlobal(fromServer);
                //
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Alter Database BOQ SET SINGLE_USER WITH ROLLBACK IMMEDIATE; "
                    + "Restore Database " + databaseName + " FROM DISK = '" + backupFilePath + "' WITH REPLACE; ";
                cmd.ExecuteNonQuery();
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
                CloseConnection();
            }
        }
    }


}
