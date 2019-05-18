using DALC4STANDARD.Interfaces;
using System;
using System.Data;
using System.Data.Common;

/*****************************************************************************
 * DALC4STANDARD IS AN OPEN SOURCE DATA ACCESS LAYER
 * THIS DOES NOT REQUIRE ANY KIND OF LICENSING
 * USERS ARE FREE TO MODIFY THE SOURCE CODE AS PER REQUIREMENT
 * ANY SUGGESTIONS ARE MOST WELCOME (SEND THE SAME TO tom.ty1993@gmail.com WITH DALC4STANDARD AS SUBJECT LINE
 * ----------------AUTHOR DETAILS--------------
 * NAME     : Tom Taborovski
 * LOCATION : Tel-Aviv (Israel)
 * EMAIL    : tom.ty1993@gmail.com
 ******************************************************************************/

namespace DALC4STANDARD
{
    /// <summary>
    /// DBHelper class enables to execute Sql Objects for the connection parameters specified into web.config or App.config file.
    /// </summary>
    public partial class DbHelper : IDbHelper
    {
        #region Fields

        private readonly ICommandBuilder _commandBuilder;
        private readonly IConnectionManager _connectionManager;
        private readonly IDataAdapterManager _dbAdapterManager;

        #endregion

        #region Properties

        /// <summary>
        /// Gets Connection String
        /// </summary>
        public string ConnectionString => _connectionManager.ConnectionString;

        public string Database
        {
            get
            {
                using (var connection = _connectionManager.CreateConnectionObject())
                {
                    if (connection != null)
                    {
                        return connection.Database;
                    }
                }
                return String.Empty;
            }
        }

        #endregion

        #region Constructors

        public DbHelper(DbProviderFactory dbFactory) : this(dbFactory, Configuration.ConnectionString)
        {
        }

        /// <summary>
        /// Constructor creates instance of the class for the specified connection string and provider name
        /// </summary>
        /// <param name="dbFactory"></param>
        /// <param name="connectionString">Connection String</param>
        public DbHelper(DbProviderFactory dbFactory, string connectionString)
        {
            var dbFactoryWrapper = new DbProviderFactoryWrapper(dbFactory);
            _connectionManager = new ConnectionManager(dbFactoryWrapper, connectionString);
            _commandBuilder = new CommandBuilder(dbFactoryWrapper);
            _dbAdapterManager = new DataAdapterManager(dbFactoryWrapper);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the database transaction
        /// After successful execution of command call CommitTransaction(transaction)
        /// In case of failure call RollbackTransaction(transaction)
        /// </summary>
        public IDbTransaction BeginTransaction()
        {
            return CreateConnectionObject().BeginTransaction();
        }

        /// <summary>
        /// Commits changes to the database
        /// </summary>
        /// <param name="transaction">Database Transaction to be committed</param>
        public void CommitTransaction(IDbTransaction transaction)
        {
            try
            {
                transaction.Commit();
            }
            finally
            {
                transaction.Connection.Dispose();
            }
        }

        /// <summary>
        /// Creates and opens the database connection.
        /// </summary>
        /// <returns>Database connection object in the opened state. </returns>
        public IDbConnection CreateConnectionObject()
        {
            return _connectionManager.CreateConnectionObject();
        }

        /// <summary>
        /// Closes and Disposes the Connection associated and then disposes the command.
        /// </summary>
        /// <param name="command">Command which needs to be closed</param>
        public void DisposeCommand(IDbCommand command)
        {
            if (command == null)
                return;

            if (command.Connection != null)
            {
                command.Connection.Close();
                command.Connection.Dispose();
            }

            command.Dispose();
        }

        /// <summary>
        /// Executes the Sql Command or Stored Procedure and returns the DataReader.
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Procedure Name</param>
        /// <param name="connection">Database Connection object (DBHelper.GetConnObject() may be used)</param>
        /// <param name="paramCollection">Parameter to be associated with the Sql Command or Stored Procedure.</param>
        /// <param name="commandType">Type of command (i.e. Sql Command/ Stored Procedure name/ Table Direct)</param>
        /// <returns>DataReader</returns>
        public IDataReader ExecuteDataReader(string commandText, IDbConnection connection, DbParameterCollection paramCollection, CommandType commandType)
        {
            IDbCommand command = _commandBuilder.GetCommand(commandText, connection, commandType, paramCollection);
            var dataReader = command.ExecuteReader();
            command.Dispose();
            return dataReader;
        }

        /// <summary>
        /// Executes the Sql Command or Stored Procedure and returns the IDataReader. Do remember to Commit or Rollback the transaction
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Proc name</param>
        /// <param name="paramCollection">Database Parameter Collection</param>
        /// <param name="transaction">Database Transaction (Use DBHelper.Transaction property for getting the transaction.)</param>
        /// <param name="commandType">Text/ Stored Procedure</param>
        /// <returns>IDataReader</returns>
        public IDataReader ExecuteDataReader(string commandText, DbParameterCollection paramCollection, IDbTransaction transaction, CommandType commandType)
        {
            var connection = transaction.Connection;
            var command = _commandBuilder.GetCommand(commandText, connection, commandType, paramCollection);
            command.Transaction = transaction;
            var dataReader = command.ExecuteReader();
            command.Dispose();
            return dataReader;
        }

        /// <summary>
        /// Executes the Sql Command or Stored Procedure and return result set in the form of DataSet.
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Procedure name</param>
        /// <param name="paramCollection">Parameter collection to be associated with the command</param>
        /// <param name="commandType">Type of command (i.e. Sql Command/ Stored Procedure name/ Table Direct)</param>
        /// <returns>Result in the form of DataSet</returns>
        public DataSet ExecuteDataSet(string commandText, DbParameterCollection paramCollection, CommandType commandType)
        {
            using (var connection = CreateConnectionObject())
            {
                return _dbAdapterManager.ExecuteDataSet(commandText, connection, paramCollection, commandType);
            }
        }

        /// <summary>
        /// Executes the Sql Command or Stored Procedure and return result set in the form of DataTable.
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Procedure name</param>
        /// <param name="tableName">Table name</param>
        /// <param name="paramCollection">Parameter collection to be associated with the Command or Stored Procedure.</param>
        /// <param name="commandType">Type of command (i.e. Sql Command/ Stored Procedure name/ Table Direct)</param>
        /// <returns>Result in the form of DataTable</returns>
        public DataTable ExecuteDataTable(string commandText, string tableName, DbParameterCollection paramCollection, CommandType commandType)
        {
            using (var connection = CreateConnectionObject())
            {
                return _dbAdapterManager.GetDataTable(commandText, connection, paramCollection, commandType, tableName);
            }
        }

        /// <summary>
        /// Executes Sql Command or Stored procedure and returns number of rows affected.
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Procedure Name</param>
        /// <param name="paramCollection">Parameter Collection to be associated with the command</param>
        /// <param name="transaction">Current Database Transaction (Use Helper.Transaction to get transaction)</param>
        /// <param name="commandType">Type of command (i.e. Sql Command/ Stored Procedure name/ Table Direct)</param>
        /// <returns>Number of rows affected.</returns>
        public int ExecuteNonQuery(string commandText, DbParameterCollection paramCollection, IDbTransaction transaction, CommandType commandType)
        {
            int rowsAffected;
            var connection = transaction != null ? transaction.Connection : _connectionManager.CreateConnectionObject();
            var command = _commandBuilder.GetCommand(commandText, connection, commandType, paramCollection);
            command.Transaction = transaction;

            try
            {
                rowsAffected = command.ExecuteNonQuery();
            }
            finally
            {
                if (transaction == null)
                {
                    if (connection != null)
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
                command.Dispose();
            }
            return rowsAffected;
        }

        /// <summary>
        /// Executes the Sql Command or Stored Procedure and returns result.
        /// </summary>
        /// <param name="commandText">Sql Command or Stored Procedure name</param>
        /// <param name="paramCollection">Database parameter Collection</param>
        /// <param name="transaction">Current Database Transaction (Use Helper.Transaction to get transaction)</param>
        /// <param name="commandType">Text or Stored Procedure</param>
        /// <returns>A single value. (First row's first cell value, if more than one row and column is returned.)</returns>
        public object ExecuteScalar(string commandText, DbParameterCollection paramCollection, IDbTransaction transaction, CommandType commandType)
        {
            object objScalar;
            var connection = transaction != null ? transaction.Connection : _connectionManager.CreateConnectionObject();
            var command = _commandBuilder.GetCommand(commandText, connection, commandType, paramCollection);
            command.Transaction = transaction;
            try
            {
                objScalar = command.ExecuteScalar();
            }
            finally
            {
                if (transaction == null)
                {
                    if (connection != null)
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
                command.Dispose();
            }
            return objScalar;
        }

        /// <summary>
        /// Prepares command for the passed SQL Command or Stored Procedure.
        /// Use DisposeCommand method after use of the command.
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameterCollection"></param>
        /// <param name="transaction"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public IDbCommand GetCommand(string commandText, DbParameterCollection parameterCollection, IDbTransaction transaction, CommandType commandType)
        {
            var connection = transaction != null ? transaction.Connection : CreateConnectionObject();
            var command = _commandBuilder.GetCommand(commandText, connection, commandType, parameterCollection);
            return command;
        }

        /// <summary>
        /// Returns the database parameter value from the specified command
        /// </summary>
        /// <param name="parameterName">Name of the parameter</param>
        /// <param name="command">Command from which value to be retrieved</param>
        /// <returns>Parameter value</returns>
        public object GetParameterValue(string parameterName, IDbCommand command)
        {
            return ((IDataParameter)command.Parameters[parameterName]).Value;
        }

        /// <summary>
        /// Returns the database parameter value from the specified command
        /// </summary>
        /// <param name="index">Index of the parameter</param>
        /// <param name="command">Command from which value to be retrieved</param>
        /// <returns>Parameter value</returns>
        public object GetParameterValue(int index, IDbCommand command)
        {
            return ((IDataParameter)command.Parameters[index]).Value;
        }

        /// <summary>
        /// Rollback changes to the database
        /// </summary>
        /// <param name="transaction">Database Transaction to be rolled back</param>
        public void RollbackTransaction(IDbTransaction transaction)
        {
            try
            {
                transaction.Rollback();
            }
            finally
            {
                transaction.Connection.Dispose();
            }
        }

        #endregion
    }
}