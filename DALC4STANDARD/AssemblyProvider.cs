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

//namespace DALC4STANDARD
//{
//    internal class AssemblyProvider
//    {
//        private static AssemblyProvider _assemblyProvider = null;

//        private readonly string _providerName = string.Empty;

//        public AssemblyProvider()
//        {
//            _providerName = Configuration.GetProviderName(Configuration.DefaultConnection);
//        }

//        public AssemblyProvider(string providerName)
//        {
//            _providerName = providerName;
//        }

//        public DbProviderFactory Factory
//        {
//            get
//            {
//                DbProviderFactory factory = DbProviderFactories.GetFactory(_providerName);
//                return factory;
//            }
//        }
//    }
//}