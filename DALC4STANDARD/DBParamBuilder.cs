using System.Collections.Generic;
using System.Data.Common;

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
    internal class DBParamBuilder
    {
        #region Fields

        private readonly DbProviderFactory _dbFactory;

        #endregion

        #region Constructors

        public DBParamBuilder(DbProviderFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        #endregion

        #region Methods

        public DbParameter GetParameter(DBParameter parameter)
        {
            var dbParam = GetParameter();
            dbParam.ParameterName = parameter.Name;
            dbParam.Value = parameter.Value;
            dbParam.Direction = parameter.ParamDirection;
            dbParam.DbType = parameter.Type;

            return dbParam;
        }

        public DbParameter GetParameter()
        {
            var dbParam = _dbFactory.CreateParameter();
            return dbParam;
        }

        public List<DbParameter> GetParameterCollection(DbParameterCollection parameterCollection)
        {
            var dbParamCollection = new List<DbParameter>();
            foreach (var param in parameterCollection.Parameters)
            {
                var dbParam = GetParameter(param);
                dbParamCollection.Add(dbParam);
            }

            return dbParamCollection;
        }

        #endregion
    }
}