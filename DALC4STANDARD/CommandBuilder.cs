using DALC4STANDARD.Interfaces;
using System.Data;

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
    internal class CommandBuilder : ICommandBuilder
    {
        #region Fields

        private readonly IDbProviderFactory _dbFactory;
        private readonly DbParamBuilder _paramBuilder;

        #endregion

        #region Constructors

        public CommandBuilder(IDbProviderFactory dbFactory)
        {
            _dbFactory = dbFactory;
            _paramBuilder = new DbParamBuilder(_dbFactory);
        }

        #endregion

        #region Methods

        public IDbCommand GetCommand(string commandText, IDbConnection connection, CommandType commandType, DbParameterCollection parameterCollection)
        {
            var command = GetCommand();
            command.CommandText = commandText;
            command.Connection = connection;
            command.CommandType = commandType;

            if (parameterCollection != null)
            {
                var paramArray = _paramBuilder.GetParameterCollection(parameterCollection);

                foreach (var param in paramArray)
                    command.Parameters.Add(param);
            }

            return command;
        }

        private IDbCommand GetCommand()
        {
            return _dbFactory.CreateCommand();
        }

        #endregion
    }
}