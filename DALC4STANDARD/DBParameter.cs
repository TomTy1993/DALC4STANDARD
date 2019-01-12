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
    public class DBParameter
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the parameter.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the direction of the parameter.
        /// </summary>
        public ParameterDirection ParamDirection { get; set; }

        /// <summary>
        /// Gets or sets the type of the parameter.
        /// </summary>
        public DbType Type { get; set; }

        /// <summary>
        /// Gets or sets the value associated with the parameter.
        /// </summary>
        public object Value { get; set; }

        #endregion

        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Default constructor. Parameter name, vale, type and direction needs to be assigned explicitly by using the public properties exposed.
        /// </summary>
        public DBParameter() : this(String.Empty, null, DbType.String, ParameterDirection.Input)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Creates a parameter with the name and value specified. Default data type and direction is String and Input respectively.
        /// </summary>
        /// <param name="name">Parameter name</param>
        /// <param name="value">Value associated with the parameter</param>
        public DBParameter(string name, object value) : this(name, value, DbType.String, ParameterDirection.Input)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Creates a parameter with the name, value and direction specified. Default data type is String.
        /// </summary>
        /// <param name="name">Parameter name</param>
        /// <param name="value">Value associated with the parameter</param>
        /// <param name="paramDirection">Parameter direction</param>
        public DBParameter(string name, object value, ParameterDirection paramDirection) : this(name, value, DbType.String, paramDirection)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Creates a parameter with the name, value and Data type specified. Default direction is Input.
        /// </summary>
        /// <param name="name">Parameter name</param>
        /// <param name="value">Value associated with the parameter</param>
        /// <param name="dbType">Data type</param>
        public DBParameter(string name, object value, DbType dbType) : this(name, value, dbType, ParameterDirection.Input)
        {
        }

        /// <summary>
        /// Creates a parameter with the name, value, data type and direction specified.
        /// </summary>
        /// <param name="name">Parameter name</param>
        /// <param name="value">Value associated with the parameter</param>
        /// <param name="dbType">Data type</param>
        /// <param name="paramDirection">Parameter direction</param>
        public DBParameter(string name, object value, DbType dbType, ParameterDirection paramDirection)
        {
            Name = name;
            Value = value;
            Type = dbType;
            ParamDirection = paramDirection;
        }

        #endregion
    }
}