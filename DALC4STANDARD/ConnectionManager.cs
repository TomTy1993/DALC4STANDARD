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
    /// <summary>
    /// ConnectionManager takes care of establishing the connection to the database parameters specified into web.config or app.config file.
    /// </summary>
    internal class ConnectionManager
    {

        private string _connectionName = string.Empty;
        private string _connectionString = string.Empty;
        private string _providerName = string.Empty;
        private AssemblyProvider _assemblyProvider = null;

        internal ConnectionManager()
        {
            _connectionName = Configuration.DefaultConnection;
            _connectionString = Configuration.ConnectionString;
            _providerName = Configuration.ProviderName;
            _assemblyProvider = new AssemblyProvider(_providerName);
        }


        internal ConnectionManager(string connectionName)
        {
            _connectionName = connectionName;
            _connectionString = Configuration.GetConnectionString(connectionName);
            _providerName = Configuration.GetProviderName(connectionName);
            _assemblyProvider = new AssemblyProvider(_providerName);
        }

        internal ConnectionManager(string connectionString, string providerName)
        {
            _connectionString = connectionString;
            _providerName = providerName;
            _connectionName = string.Empty;
            _assemblyProvider = new AssemblyProvider(_providerName);
        }

        internal string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }

        internal string ProviderName
        {
            get
            {
                return _providerName;
            }
        }


        /// <summary>
        /// Establish Connection to the database and Return an open connection.
        /// </summary>
        /// <returns>Open connection to the database</returns>
        internal IDbConnection GetConnection()
        {   
            IDbConnection connection = _assemblyProvider.Factory.CreateConnection();
            connection.ConnectionString = _connectionString;

            try
            {
                connection.Open();
            }
            catch (Exception err)
            {
                throw err;
            }

            return connection;
        }      

       
    }
}
