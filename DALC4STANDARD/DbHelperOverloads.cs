using System.Data;

namespace DALC4STANDARD
{
    public partial class DbHelper
    {
        #region Methods

        /// <summary>
        /// Executes the Sql Command or Stored Procedure and returns the DataReader.
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Procedure Name</param>
        /// <param name="connection">Database Connection object (DBHelper.GetConnObject() may be used)</param>
        /// <param name="commandType">Type of command (i.e. Sql Command/ Stored Procedure name/ Table Direct)</param>
        /// <returns>DataReader</returns>
        public IDataReader ExecuteDataReader(string commandText, IDbConnection connection, CommandType commandType)
        {
            return ExecuteDataReader(commandText, connection, new DbParameterCollection(), commandType);
        }

        /// <summary>
        /// Executes the Sql Command and returns the DataReader.
        /// </summary>
        /// <param name="commandText">Sql Command</param>
        /// <param name="connection">Database Connection object (DBHelper.GetConnObject() may be used)</param>
        /// <returns>DataReader</returns>
        public IDataReader ExecuteDataReader(string commandText, IDbConnection connection)
        {
            return ExecuteDataReader(commandText, connection, CommandType.Text);
        }

        /// <summary>
        /// Executes the Sql Command or Stored Procedure and returns the DataReader.
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Procedure Name</param>
        /// <param name="connection">Database Connection object (DBHelper.GetConnObject() may be used)</param>
        /// <param name="param">Parameter to be associated with the Sql Command or Stored Procedure.</param>
        /// <param name="commandType">Type of command (i.e. Sql Command/ Stored Procedure name/ Table Direct)</param>
        /// <returns>DataReader</returns>
        public IDataReader ExecuteDataReader(string commandText, IDbConnection connection, DBParameter param, CommandType commandType)
        {
            var paramCollection = new DbParameterCollection { param };
            return ExecuteDataReader(commandText, connection, paramCollection, commandType);
        }

        /// <summary>
        /// Executes the Sql Command and returns the DataReader.
        /// </summary>
        /// <param name="commandText">Sql Command</param>
        /// <param name="connection">Database Connection object (DBHelper.GetConnObject() may be used)</param>
        /// <param name="param">Parameter to be associated with the Sql Command.</param>
        /// <returns>DataReader</returns>
        public IDataReader ExecuteDataReader(string commandText, IDbConnection connection, DBParameter param)
        {
            return ExecuteDataReader(commandText, connection, param, CommandType.Text);
        }

        /// <summary>
        /// Executes the Sql Command and returns the DataReader.
        /// </summary>
        /// <param name="commandText">Sql Command</param>
        /// <param name="connection">Database Connection object (DBHelper.GetConnObject() may be used)</param>
        /// <param name="paramCollection">Parameter to be associated with the Sql Command or Stored Procedure.</param>
        /// <returns>DataReader</returns>
        public IDataReader ExecuteDataReader(string commandText, IDbConnection connection, DbParameterCollection paramCollection)
        {
            return ExecuteDataReader(commandText, connection, paramCollection, CommandType.Text);
        }

        /// <summary>
        /// Executes the Sql Command and returns the IDataReader. Do remember to Commit or Rollback the transaction
        /// </summary>
        /// <param name="commandText">Sql Command</param>
        /// <param name="param">Database Parameter</param>
        /// <param name="transaction">Database Transaction (Use DBHelper.Transaction property for getting the transaction.)</param>
        /// <returns>Data Reader</returns>
        public IDataReader ExecuteDataReader(string commandText, DBParameter param, IDbTransaction transaction)
        {
            return ExecuteDataReader(commandText, param, transaction, CommandType.Text);
        }

        /// <summary>
        /// Executes the Sql Command or Stored Procedure and returns the IDataReader. Do remember to Commit or Rollback the transaction
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Proc Name</param>
        /// <param name="param">Database Parameter</param>
        /// <param name="transaction">Database Transaction (Use DBHelper.Transaction property for getting the transaction.)</param>
        /// <param name="commandType">Text/ Stored Procedure</param>
        /// <returns>IDataReader</returns>
        public IDataReader ExecuteDataReader(string commandText, DBParameter param, IDbTransaction transaction, CommandType commandType)
        {
            var paramCollection = new DbParameterCollection { param };
            return ExecuteDataReader(commandText, paramCollection, transaction, commandType);
        }

        /// <summary>
        /// Executes the Sql Command and returns the IDataReader. Do remember to Commit or Rollback the transaction
        /// </summary>
        /// <param name="commandText">Sql Command </param>
        /// <param name="paramCollection">Database Parameter Collection</param>
        /// <param name="transaction">Database Transaction (Use DBHelper.Transaction property for getting the transaction.)</param>
        /// <returns>IDataReader</returns>
        public IDataReader ExecuteDataReader(string commandText, DbParameterCollection paramCollection, IDbTransaction transaction)
        {
            return ExecuteDataReader(commandText, paramCollection, transaction, CommandType.Text);
        }

        /// <summary>
        /// Executes the Sql Command or Stored Procedure and return result set in the form of DataSet.
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Procedure name</param>
        /// <param name="param">Parameter to be associated with the command</param>
        /// <param name="commandType">Type of command (i.e. Sql Command/ Stored Procedure name/ Table Direct)</param>
        /// <returns>Result in the form of DataSet</returns>
        public DataSet ExecuteDataSet(string commandText, DBParameter param, CommandType commandType)
        {
            var paramCollection = new DbParameterCollection { param };
            return ExecuteDataSet(commandText, paramCollection, commandType);
        }

        /// <summary>
        /// Executes the Sql Command or Stored Procedure and return result set in the form of DataSet.
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Procedure name</param>
        /// <param name="commandType">Type of command (i.e. Sql Command/ Stored Procedure name/ Table Direct)</param>
        /// <returns>Result in the form of DataSet</returns>
        public DataSet ExecuteDataSet(string commandText, CommandType commandType)
        {
            return ExecuteDataSet(commandText, new DbParameterCollection(), commandType);
        }

        /// <summary>
        /// Executes the Sql Command and return result set in the form of DataSet.
        /// </summary>
        /// <param name="commandText">Sql Command </param>
        /// <returns>Result in the form of DataSet</returns>
        public DataSet ExecuteDataSet(string commandText)
        {
            return ExecuteDataSet(commandText, new DbParameterCollection(), CommandType.Text);
        }

        /// <summary>
        /// Executes the Sql Command and return result set in the form of DataSet.
        /// </summary>
        /// <param name="commandText">Sql Command </param>
        /// <param name="param">Parameter to be associated with the command</param>
        /// <returns>Result in the form of DataSet</returns>
        public DataSet ExecuteDataSet(string commandText, DBParameter param)
        {
            var paramCollection = new DbParameterCollection { param };
            return ExecuteDataSet(commandText, paramCollection);
        }

        /// <summary>
        /// Executes the Sql Command and return result set in the form of DataSet.
        /// </summary>
        /// <param name="commandText">Sql Command </param>
        /// <param name="paramCollection">Parameter collection to be associated with the command</param>
        /// <returns>Result in the form of DataSet</returns>
        public DataSet ExecuteDataSet(string commandText, DbParameterCollection paramCollection)
        {
            return ExecuteDataSet(commandText, paramCollection, CommandType.Text);
        }

        /// <summary>
        /// Executes the Sql Command or Stored Procedure and return result set in the form of DataTable.
        /// </summary>
        /// <param name="commandText">Sql Command8 or Stored Procedure name</param>
        /// <param name="paramCollection">Parameter collection to be associated with the Command or Stored Procedure.</param>
        /// <param name="commandType">Type of command (i.e. Sql Command/ Stored Procedure name/ Table Direct)</param>
        /// <returns>Result in the form of DataTable</returns>
        public DataTable ExecuteDataTable(string commandText, DbParameterCollection paramCollection, CommandType commandType)
        {
            return ExecuteDataTable(commandText, string.Empty, paramCollection, commandType);
        }

        /// <summary>
        /// Executes the Sql Command and return result set in the form of DataTable.
        /// </summary>
        /// <param name="commandText">Sql Command</param>
        /// <param name="tableName">Table name</param>
        /// <param name="paramCollection">Parameter collection to be associated with the Command.</param>
        /// <returns>Result in the form of DataTable</returns>
        public DataTable ExecuteDataTable(string commandText, string tableName, DbParameterCollection paramCollection)
        {
            return ExecuteDataTable(commandText, tableName, paramCollection, CommandType.Text);
        }

        /// <summary>
        /// Executes the Sql Command and return result set in the form of DataTable.
        /// </summary>
        /// <param name="commandText">Sql Command</param>
        /// <param name="paramCollection">Parameter collection to be associated with the Command.</param>
        /// <returns>Result in the form of DataTable</returns>
        public DataTable ExecuteDataTable(string commandText, DbParameterCollection paramCollection)
        {
            return ExecuteDataTable(commandText, string.Empty, paramCollection, CommandType.Text);
        }

        /// <summary>
        /// Executes the Sql Command or Stored Procedure and return result set in the form of DataTable.
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Procedure Name</param>
        /// <param name="tableName">Table name</param>
        /// <param name="param">Parameter to be associated with the Command.</param>
        /// <param name="commandType">Type of command (i.e. Sql Command/ Stored Procedure name/ Table Direct)</param>
        /// <returns>Result in the form of DataTable</returns>
        public DataTable ExecuteDataTable(string commandText, string tableName, DBParameter param, CommandType commandType)
        {
            var paramCollection = new DbParameterCollection { param };
            return ExecuteDataTable(commandText, tableName, paramCollection, commandType);
        }

        /// <summary>
        /// Executes the Sql Command or Stored Procedure and return result set in the form of DataTable.
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Procedure Name</param>
        /// <param name="param">Parameter to be associated with the Command.</param>
        /// <param name="commandType">Type of command (i.e. Sql Command/ Stored Procedure name/ Table Direct)</param>
        /// <returns>Result in the form of DataTable</returns>
        public DataTable ExecuteDataTable(string commandText, DBParameter param, CommandType commandType)
        {
            return ExecuteDataTable(commandText, string.Empty, param, commandType);
        }

        /// <summary>
        /// Executes the Sql Command and return result set in the form of DataTable.
        /// </summary>
        /// <param name="commandText">Sql Command</param>
        /// <param name="tableName">Table name</param>
        /// <param name="param">Parameter to be associated with the Command.</param>
        /// <returns>Result in the form of DataTable</returns>
        public DataTable ExecuteDataTable(string commandText, string tableName, DBParameter param)
        {
            return ExecuteDataTable(commandText, tableName, param, CommandType.Text);
        }

        /// <summary>
        /// Executes the Sql Command and return result set in the form of DataTable.
        /// </summary>
        /// <param name="commandText">Sql Command</param>
        /// <param name="param">Parameter to be associated with the Command.</param>
        /// <returns>Result in the form of DataTable</returns>
        public DataTable ExecuteDataTable(string commandText, DBParameter param)
        {
            return ExecuteDataTable(commandText, string.Empty, param, CommandType.Text);
        }

        /// <summary>
        /// Executes the Sql Command or Stored Procedure and return result set in the form of DataTable.
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Procedure Name</param>
        /// <param name="tableName">Table name</param>
        /// <param name="commandType">Type of command (i.e. Sql Command/ Stored Procedure name/ Table Direct)</param>
        /// <returns>Result in the form of DataTable</returns>
        public DataTable ExecuteDataTable(string commandText, string tableName, CommandType commandType)
        {
            return ExecuteDataTable(commandText, tableName, new DbParameterCollection(), commandType);
        }

        /// <summary>
        /// Executes the Sql Command or Stored Procedure and return result set in the form of DataTable.
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Procedure Name</param>
        /// <param name="commandType">Type of command (i.e. Sql Command/ Stored Procedure name/ Table Direct)</param>
        /// <returns>Result in the form of DataTable</returns>
        public DataTable ExecuteDataTable(string commandText, CommandType commandType)
        {
            return ExecuteDataTable(commandText, string.Empty, commandType);
        }

        /// <summary>
        /// Executes the Sql Command and return result set in the form of DataTable.
        /// </summary>
        /// <param name="commandText">Sql Command</param>
        /// <param name="tableName">Table name</param>
        /// <returns>Result in the form of DataTable</returns>
        public DataTable ExecuteDataTable(string commandText, string tableName)
        {
            return ExecuteDataTable(commandText, tableName, CommandType.Text);
        }

        /// <summary>
        /// Executes the Sql Command and return result set in the form of DataTable.
        /// </summary>
        /// <param name="commandText">Sql Command</param>
        /// <returns>Result in the form of DataTable</returns>
        public DataTable ExecuteDataTable(string commandText)
        {
            return ExecuteDataTable(commandText, string.Empty, CommandType.Text);
        }

        /// <summary>
        /// Executes Sql Command or Stored procedure and returns number of rows affected.
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Procedure name</param>
        /// <param name="commandType">Type of command (i.e. Sql Command/ Stored Procedure name/ Table Direct)</param>
        /// <returns>Number of rows affected.</returns>
        public int ExecuteNonQuery(string commandText, CommandType commandType)
        {
            return ExecuteNonQuery(commandText, (IDbTransaction)null, commandType);
        }

        /// <summary>
        /// Executes Sql Command or Stored procedure and returns number of rows affected.
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Procedure name</param>
        /// <param name="transaction">Current Database Transaction (Use Helper.Transaction to get transaction)</param>
        /// <param name="commandType">Type of command (i.e. Sql Command/ Stored Procedure name/ Table Direct)</param>
        /// <returns>Number of rows affected.</returns>
        public int ExecuteNonQuery(string commandText, IDbTransaction transaction, CommandType commandType)
        {
            return ExecuteNonQuery(commandText, new DbParameterCollection(), transaction, commandType);
        }

        /// <summary>
        /// Executes Sql Command or Stored procedure and returns number of rows affected.
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Procedure name</param>
        /// <param name="param">Parameter to be associated with the command</param>
        /// <param name="commandType">Type of command (i.e. Sql Command/ Stored Procedure name/ Table Direct)</param>
        /// <returns>Number of rows affected.</returns>
        public int ExecuteNonQuery(string commandText, DBParameter param, CommandType commandType)
        {
            return ExecuteNonQuery(commandText, param, null, commandType);
        }

        /// <summary>
        /// Executes Sql Command or Stored procedure and returns number of rows affected.
        /// </summary>
        /// <param name="commandText">Sql Command </param>
        /// <param name="param">Parameter to be associated with the command</param>
        /// <param name="transaction">Current Database Transaction (Use Helper.Transaction to get transaction)</param>
        /// <param name="commandType">Type of command (i.e. Sql Command/ Stored Procedure name/ Table Direct)</param>
        /// <returns>Number of rows affected.</returns>
        public int ExecuteNonQuery(string commandText, DBParameter param, IDbTransaction transaction, CommandType commandType)
        {
            var paramCollection = new DbParameterCollection { param };
            return ExecuteNonQuery(commandText, paramCollection, transaction, commandType);
        }

        /// <summary>
        /// Executes Sql Command or Stored procedure and returns number of rows effected.
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Procedure name</param>
        /// <param name="paramCollection">Parameter collection to be associated with the command</param>
        /// <param name="commandType">Type of command (i.e. Sql Command/ Stored Procedure name/ Table Direct)</param>
        /// <returns>Number of rows effected.</returns>
        public int ExecuteNonQuery(string commandText, DbParameterCollection paramCollection, CommandType commandType)
        {
            return ExecuteNonQuery(commandText, paramCollection, null, commandType);
        }

        /// <summary>
        /// Executes Sql Command and returns number of rows effected.
        /// </summary>
        /// <param name="commandText">Sql Command</param>
        /// <returns>Number of rows effected.</returns>
        public int ExecuteNonQuery(string commandText)
        {
            return ExecuteNonQuery(commandText, (IDbTransaction)null);
        }

        /// <summary>
        /// Executes Sql Command and returns number of rows affected.
        /// </summary>
        /// <param name="commandText">Sql Command</param>
        /// <param name="transaction">Current Database Transaction (Use Helper.Transaction to get transaction)</param>
        /// <returns>Number of rows affected.</returns>
        public int ExecuteNonQuery(string commandText, IDbTransaction transaction)
        {
            return ExecuteNonQuery(commandText, transaction, CommandType.Text);
        }

        /// <summary>
        /// Executes Sql Command and returns number of rows effected.
        /// </summary>
        /// <param name="commandText">Sql Command</param>
        /// <param name="param">Parameter to be associated with the command</param>
        /// <returns>Number of rows effected.</returns>
        public int ExecuteNonQuery(string commandText, DBParameter param)
        {
            return ExecuteNonQuery(commandText, param, null);
        }

        /// <summary>
        /// Executes Sql Command or Stored procedure and returns number of rows affected.
        /// </summary>
        /// <param name="commandText">Sql Command</param>
        /// <param name="param">Parameter to be associated with the command</param>
        /// <param name="transaction">Current Database Transaction (Use Helper.Transaction to get transaction)</param>
        /// <returns>Number of rows affected.</returns>
        public int ExecuteNonQuery(string commandText, DBParameter param, IDbTransaction transaction)
        {
            return ExecuteNonQuery(commandText, param, transaction, CommandType.Text);
        }

        /// <summary>
        /// Executes Sql Command and returns number of rows effected.
        /// </summary>
        /// <param name="commandText">Sql Command</param>
        /// <param name="paramCollection">Parameter Collection to be associated with the command</param>
        /// <returns>Number of rows effected.</returns>
        public int ExecuteNonQuery(string commandText, DbParameterCollection paramCollection)
        {
            return ExecuteNonQuery(commandText, paramCollection, null);
        }

        /// <summary>
        /// Executes Sql Command and returns number of rows affected.
        /// </summary>
        /// <param name="commandText">Sql Command</param>
        /// <param name="paramCollection">Parameter Collection to be associated with the command</param>
        /// <param name="transaction">Current Database Transaction (Use Helper.Transaction to get transaction)</param>
        /// <returns>Number of rows affected.</returns>
        public int ExecuteNonQuery(string commandText, DbParameterCollection paramCollection, IDbTransaction transaction)
        {
            return ExecuteNonQuery(commandText, paramCollection, transaction, CommandType.Text);
        }

        /// <summary>
        /// Executes the Sql Command or Stored Procedure and returns result.
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Procedure name</param>
        /// <param name="commandType">Type of command (i.e. Sql Command/ Stored Procedure name/ Table Direct)</param>
        /// <returns>A single value. (First row's first cell value, if more than one row and column is returned.)</returns>
        public object ExecuteScalar(string commandText, CommandType commandType)
        {
            return ExecuteScalar(commandText, (IDbTransaction)null, commandType);
        }

        /// <summary>
        /// Executes the Sql Command or Stored Procedure and returns result.
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Procedure name</param>
        /// <param name="transaction">Current Database Transaction (Use Helper.Transaction to get transaction)</param>
        /// <param name="commandType">Text or Stored Procedure</param>
        /// <returns>A single value. (First row's first cell value, if more than one row and column is returned.)</returns>
        public object ExecuteScalar(string commandText, IDbTransaction transaction, CommandType commandType)
        {
            return ExecuteScalar(commandText, new DbParameterCollection(), transaction, commandType);
        }

        /// <summary>
        /// Executes the Sql Command or Stored Procedure and returns result.
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Procedure name</param>
        /// <param name="param">Parameter to be associated</param>
        /// <param name="commandType">Type of command (i.e. Sql Command/ Stored Procedure name/ Table Direct)</param>
        /// <returns>A single value. (First row's first cell value, if more than one row and column is returned.)</returns>
        public object ExecuteScalar(string commandText, DBParameter param, CommandType commandType)
        {
            return ExecuteScalar(commandText, param, null, commandType);
        }

        /// <summary>
        /// Executes the Sql Command or Stored Procedure and returns result.
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Procedure name</param>
        /// <param name="param">Database parameter</param>
        /// <param name="transaction">Current Database Transaction (Use Helper.Transaction to get transaction)</param>
        /// <param name="commandType">Text or Stored Procedure</param>
        /// <returns>A single value. (First row's first cell value, if more than one row and column is returned.)</returns>
        public object ExecuteScalar(string commandText, DBParameter param, IDbTransaction transaction, CommandType commandType)
        {
            var paramCollection = new DbParameterCollection { param };
            return ExecuteScalar(commandText, paramCollection, transaction, commandType);
        }

        /// <summary>
        /// Executes the Sql Command or Stored Procedure and returns result.
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Procedure name</param>
        /// <param name="paramCollection">Parameter collection to be associated</param>
        /// <param name="commandType">Type of command (i.e. Sql Command/ Stored Procedure name/ Table Direct)</param>
        /// <returns>A single value. (First row's first cell value, if more than one row and column is returned.)</returns>
        public object ExecuteScalar(string commandText, DbParameterCollection paramCollection, CommandType commandType)
        {
            return ExecuteScalar(commandText, paramCollection, null, commandType);
        }

        /// <summary>
        /// Executes the Sql Command and returns result.
        /// </summary>
        /// <param name="commandText">Sql Command</param>
        /// <returns>A single value. (First row's first cell value, if more than one row and column is returned.)</returns>
        public object ExecuteScalar(string commandText)
        {
            return ExecuteScalar(commandText, (IDbTransaction)null);
        }

        /// <summary>
        /// Executes the Sql Command and returns result.
        /// </summary>
        /// <param name="commandText">Sql Command </param>
        /// <param name="transaction">Current Database Transaction (Use Helper.Transaction to get transaction)</param>
        /// <returns>A single value. (First row's first cell value, if more than one row and column is returned.)</returns>
        public object ExecuteScalar(string commandText, IDbTransaction transaction)
        {
            return ExecuteScalar(commandText, transaction, CommandType.Text);
        }

        /// <summary>
        /// Executes the Sql Command and returns result.
        /// </summary>
        /// <param name="commandText">Sql Command</param>
        /// <param name="param">Parameter to be associated</param>
        /// <returns>A single value. (First row's first cell value, if more than one row and column is returned.)</returns>
        public object ExecuteScalar(string commandText, DBParameter param)
        {
            return ExecuteScalar(commandText, param, null);
        }

        /// <summary>
        /// Executes the Sql Command and returns result.
        /// </summary>
        /// <param name="commandText">Sql Command</param>
        /// <param name="param">Parameter to be associated</param>
        /// <param name="transaction">Database Transaction</param>
        /// <returns>A single value. (First row's first cell value, if more than one row and column is returned.)</returns>
        public object ExecuteScalar(string commandText, DBParameter param, IDbTransaction transaction)
        {
            return ExecuteScalar(commandText, param, transaction, CommandType.Text);
        }

        /// <summary>
        /// Executes the Sql Command and returns result.
        /// </summary>
        /// <param name="commandText">Sql Command</param>
        /// <param name="paramCollection">Parameter collection to be associated.</param>
        /// <returns>A single value. (First row's first cell value, if more than one row and column is returned.)</returns>
        public object ExecuteScalar(string commandText, DbParameterCollection paramCollection)
        {
            return ExecuteScalar(commandText, paramCollection, null);
        }

        /// <summary>
        ///  Executes the Sql Command and returns result.
        /// </summary>
        /// <param name="commandText">Sql Command</param>
        /// <param name="paramCollection">Database  Parameter Collection</param>
        /// <param name="transaction">Database Transaction (Use DBHelper.Transaction property.)</param>
        /// <returns></returns>
        public object ExecuteScalar(string commandText, DbParameterCollection paramCollection, IDbTransaction transaction)
        {
            return ExecuteScalar(commandText, paramCollection, transaction, CommandType.Text);
        }

        /// <summary>
        /// Prepares command for the passed SQL Command.
        /// Command is prepared for SQL Command only not for the stored procedures.
        /// Use DisposeCommand method after use of the command.
        /// </summary>
        /// <param name="commandText">SQL Command</param>
        /// <returns>Command ready for execute</returns>
        public IDbCommand GetCommand(string commandText)
        {
            return GetCommand(commandText, CommandType.Text);
        }

        public IDbCommand GetCommand(string commandText, IDbTransaction transaction)
        {
            return GetCommand(commandText, transaction, CommandType.Text);
        }

        /// <summary>
        /// Prepares command for the passed SQL Command or Stored Procedure.
        /// Command is prepared for SQL Command only not for the stored procedures.
        /// Use DisposeCommand method after use of the command.
        /// </summary>
        /// <param name="commandText">SQL Command or Stored Procedure name</param>
        /// <param name="parameter">Database parameter</param>
        /// <param name="commandType">Type of Command i.e. Text or Stored Procedure</param>
        /// <returns>Command ready for execute</returns>
        public IDbCommand GetCommand(string commandText, DBParameter parameter, CommandType commandType)
        {
            var paramCollection = new DbParameterCollection { parameter };
            return GetCommand(commandText, paramCollection, commandType);
        }

        /// <summary>
        /// Prepares command for the passed SQL Command.
        /// Command is prepared for SQL Command only not for the stored procedures.
        /// Use DisposeCommand method after use of the command.
        /// </summary>
        /// <param name="commandText">SQL Command</param>
        /// <param name="parameter">Database parameter</param>
        /// <returns>Command ready for execute</returns>
        public IDbCommand GetCommand(string commandText, DBParameter parameter)
        {
            return GetCommand(commandText, parameter, CommandType.Text);
        }

        public IDbCommand GetCommand(string commandText, IDbTransaction transaction, CommandType commandType)
        {
            return GetCommand(commandText, null, transaction, commandType);
        }

        public IDbCommand GetCommand(string commandText, DBParameter parameter, IDbTransaction transaction)
        {
            var paramCollection = new DbParameterCollection { parameter };
            return GetCommand(commandText, paramCollection, transaction, CommandType.Text);
        }

        /// <summary>
        /// Prepares command for the passed SQL Command Or Stored Procedure.
        /// Use DisposeCommand method after use of the command.
        /// </summary>
        /// <param name="commandText">SQL Command or Stored Procedure name</param>
        /// <param name="commandType">Type of Command i.e. Text or Stored Procedure</param>
        /// <returns>Command ready for execute</returns>
        public IDbCommand GetCommand(string commandText, CommandType commandType)
        {
            return GetCommand(commandText, null, null, commandType);
        }

        /// <summary>
        /// Prepares command for the passed SQL Command or Stored Procedure.
        /// Command is prepared for SQL Command only not for the stored procedures.
        /// Use DisposeCommand method after use of the command.
        /// </summary>
        /// <param name="commandText">SQL Command or Stored Procedure name</param>
        /// <param name="parameterCollection">Database parameter collection</param>
        /// <param name="commandType">Type of Command i.e. Text or Stored Procedure</param>
        /// <returns>Command ready for execute</returns>
        public IDbCommand GetCommand(string commandText, DbParameterCollection parameterCollection, CommandType commandType)
        {
            return GetCommand(commandText, parameterCollection, null, commandType);
        }

        /// <summary>
        /// Prepares command for the passed SQL Command.
        /// Command is prepared for SQL Command only not for the stored procedures.
        /// Use DisposeCommand method after use of the command.
        /// </summary>
        /// <param name="commandText">SQL Command</param>
        /// <param name="parameterCollection">Database parameter collection</param>
        /// <returns>Command ready for execute</returns>
        public IDbCommand GetCommand(string commandText, DbParameterCollection parameterCollection)
        {
            return GetCommand(commandText, parameterCollection, CommandType.Text);
        }

        public IDbCommand GetCommand(string commandText, DbParameterCollection parameterCollection, IDbTransaction transaction)
        {
            return GetCommand(commandText, parameterCollection, transaction, CommandType.Text);
        }

        #endregion
    }
}