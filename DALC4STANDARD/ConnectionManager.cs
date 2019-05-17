using DALC4STANDARD.Interfaces;
using System;
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
    internal class ConnectionManager : IConnectionManager
    {
        #region Fields

        private readonly IDbProviderFactory _dbFactory;

        #endregion

        #region Properties

        public string ConnectionString { get; }

        #endregion

        #region Constructors

        internal ConnectionManager(IDbProviderFactory dbFactory, string connectionString)
        {
            _dbFactory = dbFactory;
            ConnectionString = connectionString;
        }

        #endregion

        #region Methods

        public IDbConnection CreateConnectionObject()
        {
            var connection = _dbFactory.CreateConnection();
            if (connection != null)
            {
                try
                {
                    connection.ConnectionString = ConnectionString;
                    connection.Open();
                }
                catch (Exception)
                {
                    connection.Dispose();
                    throw;
                }
            }
            return connection;
        }

        #endregion
    }
}