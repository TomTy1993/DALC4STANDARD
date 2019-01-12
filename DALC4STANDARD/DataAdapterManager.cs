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
    internal class DataAdapterManager
    {
        #region Fields

        private readonly CommandBuilder _commandBuilder;
        private readonly DbProviderFactory _dbFactory;

        #endregion

        #region Constructors

        public DataAdapterManager(DbProviderFactory dbFactory)
        {
            _dbFactory = dbFactory;
            _commandBuilder = new CommandBuilder(_dbFactory);
        }

        #endregion

        #region Methods

        public DataSet ExecuteDataSet(string sqlCommand, IDbConnection connection, DbParameterCollection paramCollection, CommandType commandType)
        {
            var dataSet = new DataSet();
            var command = GetCommand(sqlCommand, paramCollection, connection, commandType);
            var adapter = GetDataAdapter(command);
            adapter.Fill(dataSet);
            return dataSet;
        }

        public DataTable GetDataTable(string sqlCommand, IDbConnection connection, DbParameterCollection paramCollection, CommandType commandType, string tableName)
        {
            var dataTable = tableName != string.Empty ? new DataTable(tableName) : new DataTable();
            var command = GetCommand(sqlCommand, paramCollection, connection, commandType);
            var adapter = GetDataAdapter(command);
            adapter.Fill(dataTable);
            return dataTable;
        }

        private IDbCommand GetCommand(string sqlCommand, DbParameterCollection paramCollection, IDbConnection connection, CommandType commandType)
        {
            if (paramCollection != null && paramCollection.Count > 0)
            {
                return _commandBuilder.GetCommand(sqlCommand, connection, commandType, paramCollection);
            }
            return _commandBuilder.GetCommand(sqlCommand, connection, commandType);
        }

        private DbDataAdapter GetDataAdapter(IDbCommand command)
        {
            var adapter = _dbFactory.CreateDataAdapter();
            if (adapter != null)
            {
                adapter.SelectCommand = (DbCommand)command;
            }
            return adapter;
        }

        #endregion
    }
}