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
    public class DbParameterCollection
    {
        /// <summary>
        /// Adds a DBParameter to the ParameterCollection
        /// </summary>
        /// <param name="parameter">Parameter to be added</param>
        public void Add(DBParameter parameter)
        {
            Parameters.Add(parameter);
        }

        /// <summary>
        /// Removes parameter from the Parameter Collection
        /// </summary>
        /// <param name="parameter">Parameter to be removed</param>
        public void Remove(DBParameter parameter)
        {
            Parameters.Remove(parameter);
        }
        
        /// <summary>
        /// Removes all the parameters from the Parameter Collection
        /// </summary>
        public void RemoveAll()
        {
            Parameters.RemoveRange(0, Parameters.Count - 1);
        }

        /// <summary>
        /// Removes parameter from the specified index.
        /// </summary>
        /// <param name="index">Index from which parameter is supposed to be removed</param>
        public void RemoveAt(int index)
        {
            Parameters.RemoveAt(index);
        }

        /// <summary>
        /// Gets list of parameters
        /// </summary>
        public List<DBParameter> Parameters { get; } = new List<DBParameter>();
    }
}
