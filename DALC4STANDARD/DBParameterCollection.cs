using System.Collections;
using System.Collections.Generic;

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
    public class DbParameterCollection : IEnumerable<DBParameter>
    {
        #region Fields

        private readonly List<DBParameter> _parameters;

        #endregion

        #region Properties

        public int Count => _parameters.Count;

        #endregion

        #region Constructors

        public DbParameterCollection()
        {
            _parameters = new List<DBParameter>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a DBParameter to the ParameterCollection
        /// </summary>
        /// <param name="parameter">Parameter to be added</param>
        public void Add(DBParameter parameter)
        {
            _parameters.Add(parameter);
        }

        public IEnumerator<DBParameter> GetEnumerator()
        {
            return _parameters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Removes parameter from the Parameter Collection
        /// </summary>
        /// <param name="parameter">Parameter to be removed</param>
        public void Remove(DBParameter parameter)
        {
            _parameters.Remove(parameter);
        }

        /// <summary>
        /// Removes all the parameters from the Parameter Collection
        /// </summary>
        public void RemoveAll()
        {
            _parameters.Clear();
        }

        /// <summary>
        /// Removes parameter from the specified index.
        /// </summary>
        /// <param name="index">Index from which parameter is supposed to be removed</param>
        public void RemoveAt(int index)
        {
            _parameters.RemoveAt(index);
        }

        #endregion
    }
}