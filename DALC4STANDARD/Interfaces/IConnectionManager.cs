using System.Data;

namespace DALC4STANDARD.Interfaces
{
    internal interface IConnectionManager
    {
        #region Properties

        string ConnectionString { get; }

        #endregion

        #region Methods

        IDbConnection CreateConnectionObject();

        #endregion
    }
}