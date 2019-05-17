using System.Data;

namespace DALC4STANDARD.Interfaces
{
    public interface IDbHelper
    {
        #region Properties

        string ConnectionString { get; }

        string Database { get; }

        #endregion

        #region Methods

        IDbTransaction BeginTransaction();

        void CommitTransaction(IDbTransaction transaction);

        IDbConnection CreateConnectionObject();

        void DisposeCommand(IDbCommand command);

        IDataReader ExecuteDataReader(string commandText, IDbConnection connection, CommandType commandType);

        IDataReader ExecuteDataReader(string commandText, IDbConnection connection);

        IDataReader ExecuteDataReader(string commandText, IDbConnection connection, DBParameter param, CommandType commandType);

        IDataReader ExecuteDataReader(string commandText, IDbConnection connection, DBParameter param);

        IDataReader ExecuteDataReader(string commandText, IDbConnection connection, DbParameterCollection paramCollection);

        IDataReader ExecuteDataReader(string commandText, IDbConnection connection, DbParameterCollection paramCollection, CommandType commandType);

        IDataReader ExecuteDataReader(string commandText, DBParameter param, IDbTransaction transaction);

        IDataReader ExecuteDataReader(string commandText, DBParameter param, IDbTransaction transaction, CommandType commandType);

        IDataReader ExecuteDataReader(string commandText, DbParameterCollection paramCollection, IDbTransaction transaction);

        IDataReader ExecuteDataReader(string commandText, DbParameterCollection paramCollection, IDbTransaction transaction, CommandType commandType);

        DataSet ExecuteDataSet(string commandText, DBParameter param, CommandType commandType);

        DataSet ExecuteDataSet(string commandText, DbParameterCollection paramCollection, CommandType commandType);

        DataSet ExecuteDataSet(string commandText, CommandType commandType);

        DataSet ExecuteDataSet(string commandText);

        DataSet ExecuteDataSet(string commandText, DBParameter param);

        DataSet ExecuteDataSet(string commandText, DbParameterCollection paramCollection);

        DataTable ExecuteDataTable(string commandText, string tableName, DbParameterCollection paramCollection, CommandType commandType);

        DataTable ExecuteDataTable(string commandText, DbParameterCollection paramCollection, CommandType commandType);

        DataTable ExecuteDataTable(string commandText, string tableName, DbParameterCollection paramCollection);

        DataTable ExecuteDataTable(string commandText, DbParameterCollection paramCollection);

        DataTable ExecuteDataTable(string commandText, string tableName, DBParameter param, CommandType commandType);

        DataTable ExecuteDataTable(string commandText, DBParameter param, CommandType commandType);

        DataTable ExecuteDataTable(string commandText, string tableName, DBParameter param);

        DataTable ExecuteDataTable(string commandText, DBParameter param);

        DataTable ExecuteDataTable(string commandText, string tableName, CommandType commandType);

        DataTable ExecuteDataTable(string commandText, CommandType commandType);

        DataTable ExecuteDataTable(string commandText, string tableName);

        DataTable ExecuteDataTable(string commandText);

        int ExecuteNonQuery(string commandText, CommandType commandType);

        int ExecuteNonQuery(string commandText, IDbTransaction transaction, CommandType commandType);

        int ExecuteNonQuery(string commandText, DBParameter param, CommandType commandType);

        int ExecuteNonQuery(string commandText, DBParameter param, IDbTransaction transaction, CommandType commandType);

        int ExecuteNonQuery(string commandText, DbParameterCollection paramCollection, CommandType commandType);

        int ExecuteNonQuery(string commandText, DbParameterCollection paramCollection, IDbTransaction transaction, CommandType commandType);

        int ExecuteNonQuery(string commandText);

        int ExecuteNonQuery(string commandText, IDbTransaction transaction);

        int ExecuteNonQuery(string commandText, DBParameter param);

        int ExecuteNonQuery(string commandText, DBParameter param, IDbTransaction transaction);

        int ExecuteNonQuery(string commandText, DbParameterCollection paramCollection);

        int ExecuteNonQuery(string commandText, DbParameterCollection paramCollection, IDbTransaction transaction);

        object ExecuteScalar(string commandText, CommandType commandType);

        object ExecuteScalar(string commandText, IDbTransaction transaction, CommandType commandType);

        object ExecuteScalar(string commandText, DBParameter param, CommandType commandType);

        object ExecuteScalar(string commandText, DBParameter param, IDbTransaction transaction, CommandType commandType);

        object ExecuteScalar(string commandText, DbParameterCollection paramCollection, CommandType commandType);

        object ExecuteScalar(string commandText, DbParameterCollection paramCollection, IDbTransaction transaction, CommandType commandType);

        object ExecuteScalar(string commandText);

        object ExecuteScalar(string commandText, IDbTransaction transaction);

        object ExecuteScalar(string commandText, DBParameter param);

        object ExecuteScalar(string commandText, DBParameter param, IDbTransaction transaction);

        object ExecuteScalar(string commandText, DbParameterCollection paramCollection);

        object ExecuteScalar(string commandText, DbParameterCollection paramCollection, IDbTransaction transaction);

        IDbCommand GetCommand(string commandText, CommandType commandType);

        IDbCommand GetCommand(string commandText, IDbTransaction transaction, CommandType commandType);

        IDbCommand GetCommand(string commandText);

        IDbCommand GetCommand(string commandText, IDbTransaction transaction);

        IDbCommand GetCommand(string commandText, DBParameter parameter, CommandType commandType);

        IDbCommand GetCommand(string commandText, DBParameter parameter);

        IDbCommand GetCommand(string commandText, DBParameter parameter, IDbTransaction transaction);

        IDbCommand GetCommand(string commandText, DbParameterCollection parameterCollection, CommandType commandType);

        IDbCommand GetCommand(string commandText, DbParameterCollection parameterCollection, IDbTransaction transaction, CommandType commandType);

        IDbCommand GetCommand(string commandText, DbParameterCollection parameterCollection);

        IDbCommand GetCommand(string commandText, DbParameterCollection parameterCollection, IDbTransaction transaction);

        object GetParameterValue(string parameterName, IDbCommand command);

        object GetParameterValue(int index, IDbCommand command);

        void RollbackTransaction(IDbTransaction transaction);

        #endregion
    }
}