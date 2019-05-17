using System.Data;

namespace DALC4STANDARD.Interfaces
{
    internal interface ICommandBuilder
    {
        #region Methods

        IDbCommand GetCommand(string commandText, IDbConnection connection, CommandType commandType);

        IDbCommand GetCommand(string commandText, IDbConnection connection, CommandType commandType, DBParameter parameter);

        IDbCommand GetCommand(string commandText, IDbConnection connection, CommandType commandType, DbParameterCollection parameterCollection);

        #endregion
    }
}