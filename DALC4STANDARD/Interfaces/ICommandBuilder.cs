using System.Data;

namespace DALC4STANDARD.Interfaces
{
    internal interface ICommandBuilder
    {
        #region Methods

        IDbCommand GetCommand(string commandText, IDbConnection connection, CommandType commandType, DbParameterCollection parameterCollection);

        #endregion
    }
}