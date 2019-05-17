using DALC4STANDARD.Interfaces;
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
    internal class DbParamBuilder
    {
        #region Fields

        private readonly IDbProviderFactory _dbFactory;

        #endregion

        #region Constructors

        public DbParamBuilder(IDbProviderFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        #endregion

        #region Methods

        public DbParameter GetParameter(DBParameter parameter)
        {
            var dbParam = GetParameter();
            if (parameter.Name != null)
            {
                dbParam.ParameterName = parameter.Name;
            }
            if (parameter.Value != null)
            {
                dbParam.Value = parameter.Value;
            }
            if (parameter.ParamDirection != null)
            {
                dbParam.Direction = parameter.ParamDirection.Value;
            }
            if (parameter.Type != null)
            {
                dbParam.DbType = parameter.Type.Value;
            }

            return dbParam;
        }

        public List<DbParameter> GetParameterCollection(DbParameterCollection parameterCollection)
        {
            var dbParamCollection = new List<DbParameter>();
            foreach (var param in parameterCollection)
            {
                dbParamCollection.Add(GetParameter(param));
            }

            return dbParamCollection;
        }

        private DbParameter GetParameter()
        {
            var dbParam = _dbFactory.CreateParameter();
            return dbParam;
        }

        #endregion
    }
}