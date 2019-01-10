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
    internal static class Configuration
    {
        const string DEFAULT_CONNECTION_KEY = "defaultConnection";

        public static string DefaultConnection
        {
            get
            {
                return ConfigurationManager.AppSettings[DEFAULT_CONNECTION_KEY];
            }
        }

        public static string ProviderName
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[DefaultConnection].ProviderName;
            }
        }

        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[DefaultConnection].ConnectionString;
            }
        }

        public static string GetConnectionString(string connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static string GetProviderName(string connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ProviderName;
        }

    }
}
