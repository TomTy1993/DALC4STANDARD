using DALC4STANDARD.Interfaces;
using System.Data.Common;

namespace DALC4STANDARD
{
    internal class DbProviderFactoryWrapper : IDbProviderFactory
    {
        #region Fields

        private readonly DbProviderFactory _dbProvider;

        #endregion

        #region Properties

        public bool CanCreateDataSourceEnumerator => _dbProvider.CanCreateDataSourceEnumerator;

        #endregion

        #region Constructors

        public DbProviderFactoryWrapper(DbProviderFactory dbProvider)
        {
            _dbProvider = dbProvider;
        }

        #endregion

        #region Methods

        public DbCommand CreateCommand()
        {
            return _dbProvider.CreateCommand();
        }

        public DbCommandBuilder CreateCommandBuilder()
        {
            return _dbProvider.CreateCommandBuilder();
        }

        public DbConnection CreateConnection()
        {
            return _dbProvider.CreateConnection();
        }

        public DbConnectionStringBuilder CreateConnectionStringBuilder()
        {
            return _dbProvider.CreateConnectionStringBuilder();
        }

        public DbDataAdapter CreateDataAdapter()
        {
            return _dbProvider.CreateDataAdapter();
        }

        public DbDataSourceEnumerator CreateDataSourceEnumerator()
        {
            return _dbProvider.CreateDataSourceEnumerator();
        }

        public DbParameter CreateParameter()
        {
            return _dbProvider.CreateParameter();
        }

        #endregion
    }
}