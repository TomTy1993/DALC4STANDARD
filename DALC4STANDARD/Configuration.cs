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

using System.Configuration;

namespace DALC4STANDARD
{
    internal static class Configuration
    {
        #region Fields

        private const string DefaultConnectionKey = "defaultConnection";

        #endregion

        #region Properties

        public static string ConnectionString => ConfigurationManager.ConnectionStrings[DefaultConnection].ConnectionString;

        public static string DefaultConnection => ConfigurationManager.AppSettings[DefaultConnectionKey];

        public static string ProviderName => ConfigurationManager.ConnectionStrings[DefaultConnection].ProviderName;

        #endregion

        #region Methods

        public static string GetConnectionString(string connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static string GetProviderName(string connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ProviderName;
        }

        #endregion
    }
}