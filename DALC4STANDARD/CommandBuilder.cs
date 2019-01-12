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
    internal class CommandBuilder
    {
        #region Fields

        private readonly DbProviderFactory _dbFactory;
        private readonly DbParamBuilder _paramBuilder;

        #endregion

        #region Constructors

        public CommandBuilder(DbProviderFactory dbFactory)
        {
            _dbFactory = dbFactory;
            _paramBuilder = new DbParamBuilder(_dbFactory);
        }

        #endregion

        #region Methods

        public IDbCommand GetCommand(string commandText, IDbConnection connection, CommandType commandType)
        {
            var command = GetCommand();
            command.CommandText = commandText;
            command.Connection = connection;
            command.CommandType = commandType;
            return command;
        }

        public IDbCommand GetCommand(string commandText, IDbConnection connection, CommandType commandType, DBParameter parameter)
        {
            IDataParameter param = _paramBuilder.GetParameter(parameter);
            var command = GetCommand(commandText, connection, commandType);
            command.Parameters.Add(param);
            return command;
        }

        public IDbCommand GetCommand(string commandText, IDbConnection connection, CommandType commandType, DbParameterCollection parameterCollection)
        {
            var paramArray = _paramBuilder.GetParameterCollection(parameterCollection);
            var command = GetCommand(commandText, connection, commandType);

            foreach (var param in paramArray)
                command.Parameters.Add(param);

            return command;
        }

        private IDbCommand GetCommand()
        {
            return _dbFactory.CreateCommand();
        }

        #endregion
    }
}