using System.Collections.Generic;
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
        private readonly DBParamBuilder _paramBuilder;
        private readonly AssemblyProvider _assemblyProvider;

        public CommandBuilder()
        {
            var providerName = Configuration.GetProviderName(Configuration.DefaultConnection);
            _paramBuilder = new DBParamBuilder(providerName);
            _assemblyProvider = new AssemblyProvider(providerName);
        }

        public CommandBuilder(string providerName)
        {
            _paramBuilder = new DBParamBuilder(providerName);
            _assemblyProvider = new AssemblyProvider(providerName);
        }

        internal IDbCommand GetCommand(string commandText, IDbConnection connection)
        {
            return GetCommand(commandText, connection, CommandType.Text);
        }


        internal IDbCommand GetCommand(string commandText, IDbConnection connection, CommandType commandType)
        {
            IDbCommand command = GetCommand();
            command.CommandText = commandText;
            command.Connection = connection;
            command.CommandType = commandType;
            return command;
        }


        internal IDbCommand GetCommand(string commandText, IDbConnection connection, DBParameter parameter)
        {
            return GetCommand(commandText, connection, parameter, CommandType.Text);
        }

        internal IDbCommand GetCommand(string commandText, IDbConnection connection, DBParameter parameter, CommandType commandType)
        {
            IDataParameter param = _paramBuilder.GetParameter(parameter);
            IDbCommand command = GetCommand(commandText, connection, commandType);
            command.Parameters.Add(param);
            return command;
        }

        internal IDbCommand GetCommand(string commandText, IDbConnection connection, DbParameterCollection parameterCollection)
        {
            return GetCommand(commandText, connection, parameterCollection, CommandType.Text);
        }

        internal IDbCommand GetCommand(string commandText, IDbConnection connection, DbParameterCollection parameterCollection, CommandType commandType)
        {
            List<DbParameter> paramArray = _paramBuilder.GetParameterCollection(parameterCollection);
            IDbCommand command = GetCommand(commandText, connection, commandType);

            foreach (IDataParameter param in paramArray)
                command.Parameters.Add(param);

            return command;
        }

        private IDbCommand GetCommand()
        {          
            IDbCommand command = _assemblyProvider.Factory.CreateCommand();
            return command;
        }
    }
}
