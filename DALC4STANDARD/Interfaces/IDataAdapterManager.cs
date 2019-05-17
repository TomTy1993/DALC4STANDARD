using System.Data;

namespace DALC4STANDARD.Interfaces
{
    internal interface IDataAdapterManager
    {
        #region Methods

        DataSet ExecuteDataSet(string sqlCommand, IDbConnection connection, DbParameterCollection paramCollection, CommandType commandType);

        DataTable GetDataTable(string sqlCommand, IDbConnection connection, DbParameterCollection paramCollection, CommandType commandType, string tableName);

        #endregion
    }
}