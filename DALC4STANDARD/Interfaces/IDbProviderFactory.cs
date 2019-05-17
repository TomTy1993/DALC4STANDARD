using System.Data.Common;

namespace DALC4STANDARD.Interfaces
{
    internal interface IDbProviderFactory
    {
        #region Properties

        bool CanCreateDataSourceEnumerator { get; }

        #endregion

        #region Methods

        DbCommand CreateCommand();

        DbCommandBuilder CreateCommandBuilder();

        DbConnection CreateConnection();

        DbConnectionStringBuilder CreateConnectionStringBuilder();

        DbDataAdapter CreateDataAdapter();

        DbDataSourceEnumerator CreateDataSourceEnumerator();

        DbParameter CreateParameter();

        #endregion
    }
}