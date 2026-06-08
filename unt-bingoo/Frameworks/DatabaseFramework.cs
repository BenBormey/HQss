using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace unt_bingoo.Frameworks
{
    public class DatabaseFramework : Configurations, IDisposable
    {
        private ApplicationFramework App = new ApplicationFramework();
        private SqlConnection Connection;
        private SqlCommand Command;
        private bool disposedValue;

        public DatabaseFramework()
        {
        }

        public DatabaseFramework(ConnectionType Type)
        {
            try
            {
                Connection = new SqlConnection(ConnectionString(Type));
                Connection.Open();
                Connection.Close();
                Connection = null;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The database connection failed! The application will be closed.\n Please check with your support!", "Error database connection", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Environment.Exit(0);
            }
        }
        public DatabaseFramework(ConnectionType Type, bool IsPrefixDatabase)
        {
            try
            {
                Connection = new SqlConnection(ConnectionString(Type, IsPrefixDatabase));
                Connection.Open();
                Connection.Close();
                Connection = null;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The database connection failed! The application will be closed.\n Please check with your support!", "Error database connection", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Environment.Exit(0);
            }
        }

        public DateTime GetCurrentDate(ConnectionType type = ConnectionType.NETWORK)
        {
            DateTime currentDate = DateTime.Now; // Default to local time
            DataTable dtData;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString(type)))
                {
                    using (SqlCommand command = new SqlCommand("SELECT GETDATE()", connection))
                    {
                        connection.Open();

                        dtData = new DataTable();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dtData.Load(reader);
                        }

                        if (dtData.Rows.Count > 0)
                        {
                            // Extract the date from the query result
                            currentDate = dtData.Rows[0].IsNull(0)
                                ? DateTime.Now
                                : Convert.ToDateTime(dtData.Rows[0][0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return currentDate;
        }
        public enum SeparatorList
        {
            Is_And,
            Is_Or
        }


        public long GetIdentCurrent(string tableName, ConnectionType type = ConnectionType.NETWORK)
        {
            bool existed = false;
            long identCurrent = 1;

            // Formatting the table name
            tableName = $"[{PrefixDatabase}{DatabaseName}].[dbo].[{PrefixTable}{tableName}]";

            string commandText = string.Format("SELECT IDENT_CURRENT('{0}')", tableName);

            DataTable dtData;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString(type)))
                {
                    // Check if the table exists by attempting a SELECT
                    using (SqlCommand command = new SqlCommand($"SELECT * FROM {tableName}", connection))
                    {
                        connection.Open();
                        dtData = new DataTable();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dtData.Load(reader);
                        }

                        existed = dtData.Rows.Count > 0;
                    }

                    // Now check the IDENT_CURRENT value
                    using (SqlCommand command = new SqlCommand(commandText, connection))
                    {
                        connection.Open();
                        dtData = new DataTable();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dtData.Load(reader);
                        }

                        if (dtData.Rows.Count > 0)
                        {
                            // Handle the case when IDENT_CURRENT is found
                            var identValue = dtData.Rows[0][0] == DBNull.Value ? 0 : Convert.ToInt64(dtData.Rows[0][0]);
                            if (!existed && identValue == 1)
                            {
                                identCurrent = 1;
                            }
                            else
                            {
                                identCurrent = identValue + 1;
                            }
                        }
                        else
                        {
                            identCurrent = 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return identCurrent;
        }



        public object ExecuteCommand(string commandText, ConnectionType type = ConnectionType.NETWORK)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString(type)))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(commandText, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return "Sql: " + ex.Message;
            }
        }
        public DataTable Selects(string SQLCommand, ConnectionType Type)
        {
            DataTable DtData = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString(Type)))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(SQLCommand, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DtData.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DtData = null;
                // Show error message
                MessageBox.Show(ex.Message, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return DtData;
        }


        public object Selects(
     string TableName,
     ArrayList FieldLists = null,
     Dictionary<string, object> WhereLists = null,
     bool IsConditionIN = false,
     SeparatorList Separator = SeparatorList.Is_And,
     ArrayList GroupByLists = null,
     ArrayList OrderByLists = null,
     ConnectionType Type = ConnectionType.NETWORK)
        {
            TableName = string.Format("[{0}{1}].[dbo].[{2}{3}]", PrefixDatabase, DatabaseName, PrefixTable, TableName);
            DataTable DtData = new DataTable();
            string ConditionWhere = "";
            string FieldList = "";

            if (FieldLists != null)
            {
                foreach (object GroupBy in FieldLists)
                {
                    FieldList += string.Format("{0},", GroupBy);
                }
                if (FieldList.Trim() != "")
                    FieldList = string.Format("{0}", FieldList.Substring(0, FieldList.Length - 1));
            }
            else
            {
                FieldList = "*";
            }

            string CommandText = string.Format("SELECT {0} FROM {1}", FieldList, TableName);
            string RSeparator = Separator == SeparatorList.Is_And ? "AND" : "OR";

            if (WhereLists != null)
            {
                foreach (KeyValuePair<string, object> field in WhereLists)
                {
                    if (!IsConditionIN)
                    {
                        if (string.Compare(field.Value.ToString(), "GETDATE()", StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            ConditionWhere += string.Format("[{0}] = {1} {2} ", field.Key, field.Value, RSeparator);
                        }
                        else if (field.Value is string || field.Value is DateTime)
                        {
                            ConditionWhere += string.Format("[{0}] = '{1}' {2} ", field.Key, field.Value, RSeparator);
                        }
                        else
                        {
                            ConditionWhere += string.Format("[{0}] = {1} {2} ", field.Key, field.Value, RSeparator);
                        }
                    }
                    else
                    {
                        ConditionWhere += string.Format("[{0}] IN ({1}) {2} ", field.Key, field.Value, RSeparator);
                    }
                }

                if (ConditionWhere.Trim() != "")
                    ConditionWhere = ConditionWhere.Substring(0, ConditionWhere.Length - 4);

                CommandText = string.Format("{0} WHERE {1}", CommandText, ConditionWhere);
            }

            string GroupByList = "";
            if (GroupByLists != null)
            {
                foreach (object GroupBy in GroupByLists)
                {
                    GroupByList += string.Format("{0},", GroupBy);
                }

                if (GroupByList.Trim() != "")
                    GroupByList = string.Format("GROUP BY {0}", GroupByList.Substring(0, GroupByList.Length - 1));
            }

            string OrderByList = "";
            if (OrderByLists != null)
            {
                foreach (object Orderby in OrderByLists)
                {
                    OrderByList += string.Format("{0},", Orderby);
                }

                if (OrderByList.Trim() != "")
                    OrderByList = string.Format("ORDER BY {0}", OrderByList.Substring(0, OrderByList.Length - 1));
            }

            CommandText = string.Format("{0} {1} {2}", CommandText, GroupByList, OrderByList);

            try
            {
                Connection = new SqlConnection(ConnectionString(Type));
                Connection.Open();
                Command = new SqlCommand(CommandText, Connection);
                DtData.Load(Command.ExecuteReader());
                Connection.Close();
                Connection = null;
                Command = null;
            }
            catch (Exception ex)
            {
                DtData = null;
                MessageBox.Show(ex.Message, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return DtData;
        }

        public bool Inserts(string tableName, Dictionary<string, object> fieldListsValueLists, ConnectionType type = ConnectionType.NETWORK)
        {
            tableName = string.Format("[{0}{1}].[dbo].[{2}{3}]", PrefixDatabase, DatabaseName, PrefixTable, tableName);
            bool isCompleted = false;
            string fieldList = "";
            string valueList = "";
            var imageList = new Dictionary<string, object>();

            if (fieldListsValueLists != null)
            {
                foreach (var field in fieldListsValueLists)
                {
                    fieldList += string.Format("[{0}],", field.Key);
                    if (field.Value is byte[])
                    {
                        valueList += string.Format("@{0},", field.Key);
                        imageList.Add(field.Key, field.Value);
                    }
                    else if (field.Value.ToString().ToUpper() == "GETDATE()")
                    {
                        valueList += string.Format("{0},", field.Value);
                    }
                    else if (field.Value is string || field.Value is DateTime || field.Value == null)
                    {
                        valueList += string.Format("N'{0}',", field.Value ?? "");
                    }
                    else
                    {
                        valueList += string.Format("{0},", field.Value);
                    }
                }

                if (!string.IsNullOrWhiteSpace(fieldList)) fieldList = fieldList.TrimEnd(',');
                if (!string.IsNullOrWhiteSpace(valueList)) valueList = valueList.TrimEnd(',');
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString(type)))
                {
                    connection.Open();
                    string commandText = string.Format("INSERT INTO {0} ({1}) VALUES ({2})", tableName, fieldList, valueList);
                    using (SqlCommand command = new SqlCommand(commandText, connection))
                    {
                        if (imageList.Count > 0)
                        {
                            foreach (var field in imageList)
                            {
                                if (field.Value is byte[] imageBytes)
                                {
                                    command.Parameters.Add(new SqlParameter($"@{field.Key}", SqlDbType.Image)
                                    {
                                        Value = imageBytes,
                                        Size = imageBytes.Length
                                    });
                                }
                            }
                        }

                        command.ExecuteNonQuery();
                    }
                }

                isCompleted = true;
            }
            catch (SqlException ex)
            {
                isCompleted = false;
                MessageBox.Show(ex.Message, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                isCompleted = false;
                MessageBox.Show(ex.Message, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isCompleted;
        }
        public bool Updates(string tableName, Dictionary<string, object> fieldListsValueLists, Dictionary<string, object> whereLists, SeparatorList separator = SeparatorList.Is_And, ConnectionType type = ConnectionType.NETWORK)
        {
            tableName = string.Format("[{0}{1}].[dbo].[{2}{3}]", PrefixDatabase, DatabaseName, PrefixTable, tableName);
            bool isCompleted = false;
            string fieldListValueList = "";
            var imageList = new Dictionary<string, object>();

            if (fieldListsValueLists != null)
            {
                foreach (var field in fieldListsValueLists)
                {
                    if (field.Value is byte[])
                    {
                        fieldListValueList += string.Format("[{0}] = @{1},", field.Key, field.Key);
                        imageList.Add(field.Key, field.Value);
                    }
                    else if (field.Value.ToString().ToUpper() == "GETDATE()")
                    {
                        fieldListValueList += string.Format("[{0}] = {1},", field.Key, field.Value);
                    }
                    else if (field.Value is string || field.Value is DateTime || field.Value == null)
                    {
                        fieldListValueList += string.Format("[{0}] = N'{1}',", field.Key, field.Value ?? "");
                    }
                    else
                    {
                        fieldListValueList += string.Format("[{0}] = {1},", field.Key, field.Value);
                    }
                }
                if (!string.IsNullOrWhiteSpace(fieldListValueList)) fieldListValueList = fieldListValueList.TrimEnd(',');
            }

            string selectedSeparator = separator == SeparatorList.Is_And ? "AND" : "OR";
            string whereList = "";

            if (whereLists != null)
            {
                foreach (var field in whereLists)
                {
                    if (field.Value is byte[])
                    {
                        whereList += string.Format("[{0}] = {1} {2}", field.Key, field.Value, selectedSeparator);
                    }
                    else if (field.Value.ToString().ToUpper() == "GETDATE()")
                    {
                        whereList += string.Format("[{0}] = {1} {2}", field.Key, field.Value, selectedSeparator);
                    }
                    else if (field.Value is string || field.Value is DateTime || field.Value == null)
                    {
                        whereList += string.Format("[{0}] = '{1}' {2}", field.Key, field.Value ?? "", selectedSeparator);
                    }
                    else
                    {
                        whereList += string.Format("[{0}] = {1} {2}", field.Key, field.Value, selectedSeparator);
                    }
                }
                if (!string.IsNullOrWhiteSpace(whereList)) whereList = whereList.Substring(0, whereList.Length - selectedSeparator.Length);
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString(type)))
                {
                    connection.Open();
                    string commandText = string.Format("UPDATE {0} SET {1} WHERE {2}", tableName, fieldListValueList, whereList);
                    using (SqlCommand command = new SqlCommand(commandText, connection))
                    {
                        if (imageList.Count > 0)
                        {
                            foreach (var field in imageList)
                            {
                                if (field.Value is byte[] imageBytes)
                                {
                                    command.Parameters.Add(new SqlParameter($"@{field.Key}", SqlDbType.Image)
                                    {
                                        Value = imageBytes,
                                        Size = imageBytes.Length
                                    });
                                }
                            }
                        }

                        command.ExecuteNonQuery();
                    }
                }

                isCompleted = true;
            }
            catch (Exception ex)
            {
                isCompleted = false;
                MessageBox.Show(ex.Message, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isCompleted;
        }
        public bool Updates(string tableName, Dictionary<string, object> fieldLists_ValueLists, string whereLists, ConnectionType type = ConnectionType.NETWORK)
        {
            tableName = string.Format("[{0}{1}].[dbo].[{2}{3}]", PrefixDatabase, DatabaseName, PrefixTable, tableName);
            bool isCompleted = false;
            string fieldList_ValueList = "";
            Dictionary<string, object> imageList = new Dictionary<string, object>();

            if (fieldLists_ValueLists != null)
            {
                foreach (var field in fieldLists_ValueLists)
                {
                    if (field.Value is byte[])
                    {
                        fieldList_ValueList += string.Format("[{0}] = @{1},", field.Key, field.Key);
                        imageList.Add(field.Key, field.Value);
                    }
                    else if (field.Value.ToString() == "GETDATE()")
                    {
                        fieldList_ValueList += string.Format("[{0}] = {1},", field.Key, field.Value);
                    }
                    else if (field.Value is string || field.Value is DateTime || field.Value == null)
                    {
                        fieldList_ValueList += string.Format("[{0}] = N'{1}',", field.Key, field.Value ?? "");
                    }
                    else
                    {
                        fieldList_ValueList += string.Format("[{0}] = {1},", field.Key, field.Value);
                    }
                }
                if (fieldList_ValueList.Trim() != "")
                {
                    fieldList_ValueList = fieldList_ValueList.Substring(0, fieldList_ValueList.Length - 1);
                }
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString(type)))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(string.Format("UPDATE {0} SET {1} WHERE {2}", tableName, fieldList_ValueList, whereLists), connection);

                    if (imageList.Count > 0)
                    {
                        foreach (var field in imageList)
                        {
                            if (field.Value is byte[])
                            {
                                byte[] imageBytes = (byte[])field.Value;
                                SqlParameter parameter = new SqlParameter(string.Format("@{0}", field.Key), SqlDbType.Image)
                                {
                                    Value = imageBytes,
                                    Size = imageBytes.Length
                                };
                                command.Parameters.Add(parameter);
                            }
                        }
                    }
                    command.ExecuteNonQuery();
                }

                isCompleted = true;
            }
            catch (Exception ex)
            {
                isCompleted = false;
                MessageBox.Show(ex.Message.ToString(), "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isCompleted;
        }
        public bool Deletes(string tableName, Dictionary<string, object> whereLists, SeparatorList separator = SeparatorList.Is_And, ConnectionType type = ConnectionType.NETWORK)
        {
            tableName = string.Format("[{0}{1}].[dbo].[{2}{3}]", PrefixDatabase, DatabaseName, PrefixTable, tableName);
            bool isCompleted = false;
            string selectedSeparator = (separator == SeparatorList.Is_And) ? "AND" : "OR";
            string whereList = "";

            if (whereLists != null)
            {
                foreach (var field in whereLists)
                {
                    if (field.Value.ToString() == "GETDATE()")
                    {
                        whereList += string.Format("[{0}] = {1} {2}", field.Key, field.Value, selectedSeparator);
                    }
                    else if (field.Value is string || field.Value is DateTime)
                    {
                        whereList += string.Format("[{0}] = N'{1}' {2}", field.Key, field.Value, selectedSeparator);
                    }
                    else
                    {
                        whereList += string.Format("[{0}] = {1} {2}", field.Key, field.Value, selectedSeparator);
                    }
                }

                if (whereList.Trim() != "")
                {
                    whereList = whereList.Substring(0, whereList.Length - selectedSeparator.Length);
                }
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString(type)))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(string.Format("DELETE FROM {0} WHERE {1}", tableName, whereList), connection);
                    command.ExecuteNonQuery();
                }

                isCompleted = true;
            }
            catch (Exception ex)
            {
                isCompleted = false;
                MessageBox.Show(ex.Message.ToString(), "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isCompleted;
        }
        public enum TypeOfCheck
        {
            Database,
            Table,
            Data
        }

        public bool CheckInDatabaseIsExistOrNot(string databaseName, string tableName = "", TypeOfCheck checker = TypeOfCheck.Data, ConnectionType type = ConnectionType.NETWORK)
        {
            databaseName = string.Format("{0}{1}", PrefixDatabase, App.MergeObject(databaseName));
            tableName = string.Format("{0}{1}", PrefixTable, tableName);
            string commandString = "";

            if (checker == TypeOfCheck.Database)
            {
                commandString = "SELECT * FROM master.dbo.sysdatabases WHERE (name = '{0}')";
            }
            else if (checker == TypeOfCheck.Table)
            {
                commandString = "USE {0}; SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE (Table_Name IN('{1}'))";
            }
            else if (checker == TypeOfCheck.Data)
            {
                commandString = "USE {0}; SELECT * FROM [dbo].[{1}]";
            }

            DataTable dtData = new DataTable();
            bool isExisted = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString(type)))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(string.Format(commandString, databaseName, tableName), connection);
                    dtData.Load(command.ExecuteReader());
                }

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    isExisted = true;
                }
                else
                {
                    isExisted = false;
                }
            }
            catch (SqlException)
            {
                dtData = null;
                isExisted = false;
            }
            catch (Exception)
            {
                dtData = null;
                isExisted = false;
            }

            return isExisted;
        }

        public bool CreateDatabase(string databaseName, string path = "", ConnectionType type = ConnectionType.NETWORK)
        {
            string currentDatabaseName = databaseName;
            databaseName = string.Format("{0}{1}", PrefixDatabase, App.MergeObject(databaseName));
            if (string.IsNullOrWhiteSpace(path))
                path = GetCurrentPathSQLServer(type);

            string commandString = "USE [master]; ";
            commandString += "CREATE DATABASE " + databaseName + " ";
            commandString += "ON PRIMARY (NAME = '" + databaseName + "_DATA', FILENAME = N'" +
                             (path.EndsWith("\\") ? path : path + "\\") + databaseName + "_DATA.MDF', SIZE = 20MB, MAXSIZE = UNLIMITED, FILEGROWTH = 10MB) ";
            commandString += "LOG ON (NAME = '" + databaseName + "_LOG', FILENAME = N'" +
                             (path.EndsWith("\\") ? path : path + "\\") + databaseName + "_LOG.LDF', SIZE = 20MB, MAXSIZE = UNLIMITED, FILEGROWTH = 10MB) ";

            bool isCreated = false;
            if (!CheckInDatabaseIsExistOrNot(currentDatabaseName, "", TypeOfCheck.Database, type))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString(type)))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(commandString, connection);
                        command.ExecuteNonQuery();
                    }
                    isCreated = true;
                }
                catch (SqlException)
                {
                    isCreated = false;
                }
                catch (Exception)
                {
                    isCreated = false;
                }
            }

            return isCreated;
        }

        public bool DropDatabase(string databaseName, ConnectionType type = ConnectionType.NETWORK)
        {
            string currentDatabaseName = databaseName;
            databaseName = string.Format("{0}{1}", PrefixDatabase, App.MergeObject(databaseName));

            string commandString = "USE [master]; ";
            commandString += "DROP DATABASE " + databaseName + "; ";

            bool isDropped = false;
            if (CheckInDatabaseIsExistOrNot(currentDatabaseName, "", TypeOfCheck.Database, type))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString(type)))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(commandString, connection);
                        command.ExecuteNonQuery();
                    }
                    isDropped = true;
                }
                catch (SqlException)
                {
                    isDropped = false;
                }
                catch (Exception)
                {
                    isDropped = false;
                }
            }

            return isDropped;
        }
        public string GetCurrentPathSQLServer(ConnectionType type = ConnectionType.NETWORK)
        {
            string path = "";
            string commandString = "USE master; exec sp_helpfile;";
            DataTable dtData = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString(type)))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(commandString, connection))
                    {
                        dtData.Load(command.ExecuteReader());
                    }
                }

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    path = dtData.Rows[0].IsNull(2) ? "C:\\Microsoft SQL Server\\Data\\master.mdf" : dtData.Rows[0][2].ToString().Trim();
                    path = path.Length > 10 ? path.Substring(0, path.Length - 10).Trim() : path; // Removing "master.mdf" or equivalent from the path
                }
                else
                {
                    path = "C:\\Microsoft SQL Server\\Data";
                }
            }
            catch (SqlException)
            {
                path = "";
            }
            catch (Exception)
            {
                path = "";
            }

            return path;
        }
        public DataTable GetAllDatabaseNames(string fieldName = "*", ConnectionType type = ConnectionType.NETWORK)
        {
            if (string.IsNullOrWhiteSpace(fieldName)) fieldName = "*";

            DataTable databaseNameList = null;
            bool isCompleted = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString(type)))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand($"select {fieldName} from sysdatabases", connection))
                    {
                        databaseNameList = new DataTable();
                        databaseNameList.Load(command.ExecuteReader());
                    }
                }

                isCompleted = true;
            }
            catch (Exception ex)
            {
                isCompleted = false;
                databaseNameList = null;
                MessageBox.Show(ex.Message, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return databaseNameList;
        }
        public bool BackupDatabase(string databaseName, string pathName = "", ConnectionType type = ConnectionType.NETWORK)
        {
            string currentDatabaseName = databaseName;
            databaseName = $"{PrefixDatabase}{App.MergeObject(databaseName)}";

            if (string.IsNullOrWhiteSpace(pathName))
                pathName = GetCurrentPathSQLServer(type);

            if (pathName.EndsWith("\\"))
                pathName += $"{databaseName}.BAK";
            else
                if (!pathName.EndsWith(".BAK"))
                pathName += $"\\{databaseName}.BAK";

            bool isCompleted = false;

            if (CheckInDatabaseIsExistOrNot(currentDatabaseName, string.Empty, TypeOfCheck.Database, type))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString(type)))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"BACKUP DATABASE {databaseName} TO DISK='{pathName}'", connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    isCompleted = true;
                }
                catch (SqlException)
                {
                    isCompleted = false;
                }
                catch (Exception)
                {
                    isCompleted = false;
                }
            }
            else
            {
                isCompleted = false;
            }

            return isCompleted;
        }
        public bool RestoreDatabase(string databaseName, string pathName = "", ConnectionType type = ConnectionType.NETWORK)
        {
            string currentDatabaseName = databaseName;
            databaseName = $"{PrefixDatabase}{App.MergeObject(databaseName)}";

            if (string.IsNullOrWhiteSpace(pathName))
                pathName = GetCurrentPathSQLServer(type);

            if (pathName.EndsWith("\\"))
                pathName += $"{databaseName}.BAK";
            else
                if (!pathName.EndsWith(".BAK"))
                pathName += $"\\{databaseName}.BAK";

            bool isCompleted = false;

            if (CheckInDatabaseIsExistOrNot(currentDatabaseName, string.Empty, TypeOfCheck.Database, type))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString(type)))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"RESTORE DATABASE {databaseName} FROM DISK='{pathName}'", connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                    isCompleted = true;
                }
                catch (SqlException)
                {
                    isCompleted = false;
                }
                catch (Exception)
                {
                    isCompleted = false;
                }
            }
            else
            {
                isCompleted = false;
            }

            return isCompleted;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~DatabaseFramework()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

}
