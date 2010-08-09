﻿/* <id name="PandoraDB DBString DBString" />
 * <copyright file="DBDouble.cs"
 *            company="sones GmbH">
 * Copyright (c) sones GmbH. All rights reserved.
 * </copyright>
 * <developer>Stefan Licht</developer>
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sones.GraphDB.Structures.Enums;

using sones.Lib.NewFastSerializer;
using sones.GraphDB.Structures.Operators;

namespace sones.GraphDB.TypeManagement.BasicTypes
{

    /// <summary>
    /// The String.
    /// </summary>
    
    public class DBString : ADBBaseObject
    {
        public static readonly TypeUUID UUID = new TypeUUID(4000);
        public const string Name = DBConstants.DBString;

        #region TypeCode 
        public override UInt32 TypeCode { get { return 410; } }
        #endregion

        #region Data

        private String _Value;

        #endregion

        #region Constructors

        public DBString()
        {
            _Value = String.Empty;
        }
        
        public DBString(DBObjectInitializeType myDBObjectInitializeType)
        {
            SetValue(myDBObjectInitializeType);
        }

        public DBString(Object myValue)
        {
            Value = myValue;
        }

        public DBString(String myValue)
        {
            _Value = myValue;
        }

        #endregion

        #region Overrides

        public override int CompareTo(ADBBaseObject obj)
        {
            return CompareTo(obj.Value);
        }

        public override int CompareTo(object obj)
        {
            String val;
            if (obj is DBString)
                val = (String)((DBString)obj).Value;
            else
                val = obj.ToString();
            return _Value.CompareTo(val);
        }

        public override object Value
        {
            get { return _Value; }
            set
            {
                if (value is DBString)
                {
                    _Value = ((DBString)value)._Value;
                }
                else
                {
                    if (value != null)
                    {
                        _Value = Convert.ToString(value);
                    }
                    else
                    {
                        _Value = String.Empty;
                    }
                }
            }
        }

        #endregion

        #region Operations

        public static DBString operator +(DBString myPandoraObjectA, String myValue)
        {
            myPandoraObjectA.Value = (String)myPandoraObjectA.Value + myValue;
            return myPandoraObjectA;
        }

        [Obsolete("Operator '-' cannot be applied to operands of type 'string' and 'string'")]
        public static DBString operator -(DBString myPandoraObjectA, String myValue)
        {
            return myPandoraObjectA;
        }

        [Obsolete("Operator '*' cannot be applied to operands of type 'string' and 'string'")]
        public static DBString operator *(DBString myPandoraObjectA, String myValue)
        {
            return myPandoraObjectA;
        }

        [Obsolete("Operator '/' cannot be applied to operands of type 'string' and 'string'")]
        public static DBString operator /(DBString myPandoraObjectA, String myValue)
        {
            return myPandoraObjectA;
        }

        public override ADBBaseObject Add(ADBBaseObject myPandoraObjectA, ADBBaseObject myPandoraObjectB)
        {

            String valA = Convert.ToString(myPandoraObjectA.Value);
            String valB = Convert.ToString(myPandoraObjectB.Value);
            return new DBString(valA + valB);
        }

        [Obsolete("Operator '-' cannot be applied to operands of type 'string' and 'string'")]
        public override ADBBaseObject Sub(ADBBaseObject myPandoraObjectA, ADBBaseObject myPandoraObjectB)
        {
            return myPandoraObjectA;
        }

        [Obsolete("Operator '*' cannot be applied to operands of type 'string' and 'string'")]
        public override ADBBaseObject Mul(ADBBaseObject myPandoraObjectA, ADBBaseObject myPandoraObjectB)
        {
            return myPandoraObjectA;
        }

        [Obsolete("Operator '/' cannot be applied to operands of type 'string' and 'string'")]
        public override ADBBaseObject Div(ADBBaseObject myPandoraObjectA, ADBBaseObject myPandoraObjectB)
        {
            return myPandoraObjectA;
        }

        public override void Add(ADBBaseObject myPandoraObject)
        {
            _Value += Convert.ToString(myPandoraObject.Value);
        }

        [Obsolete("Operator '-' cannot be applied to operands of type 'string' and 'string'")]
        public override void Sub(ADBBaseObject myPandoraObject)
        {
        }

        [Obsolete("Operator '*' cannot be applied to operands of type 'string' and 'string'")]
        public override void Mul(ADBBaseObject myPandoraObject)
        {
        }

        [Obsolete("Operator '/' cannot be applied to operands of type 'string' and 'string'")]
        public override void Div(ADBBaseObject myPandoraObject)
        {
        }

        #endregion

        #region IsValid

        /// <summary>
        /// All none values are valid.
        /// </summary>
        /// <param name="myObject"></param>
        /// <returns></returns>
        public static Boolean IsValid(Object myObject)
        {
            if (myObject == null)
                return false;
            //if (myObject is DBString || myObject is String)
              //  return true;

            return true;
        }

        public override bool IsValidValue(Object myValue)
        {
            return DBString.IsValid(myValue);
        }

        #endregion

        #region Clone

        public override ADBBaseObject Clone()
        {
            return new DBString(_Value);
        }

        public override ADBBaseObject Clone(Object myValue)
        {
            return new DBString(myValue);
        }

        #endregion

        public override void SetValue(DBObjectInitializeType myDBObjectInitializeType)
        {
            switch (myDBObjectInitializeType)
            {
                case DBObjectInitializeType.Default:
                case DBObjectInitializeType.MinValue:
                case DBObjectInitializeType.MaxValue:
                default:
                    _Value = String.Empty;
                    break;
            }
        }

        public override void SetValue(object myValue)
        {
            Value = myValue;
        }

        public override TypesOfOperatorResult Type
        {
            get { return TypesOfOperatorResult.Unknown; }
        }


        public override TypeUUID ID
        {
            get { return UUID; }
        }

        public override string ObjectName
        {
            get { return Name; }
        }

        #region IFastSerialize Members

        public override void Serialize(ref SerializationWriter mySerializationWriter)
        {
            Serialize(ref mySerializationWriter, this);
        }

        public override void Deserialize(ref SerializationReader mySerializationReader)
        {
            Deserialize(ref mySerializationReader, this);
        }
        #endregion

        private void Serialize(ref SerializationWriter mySerializationWriter, DBString myValue)
        {
            mySerializationWriter.WriteString((String)myValue.Value);
        }

        private object Deserialize(ref SerializationReader mySerializationReader, DBString myValue)
        {
            myValue._Value = mySerializationReader.ReadString();
            return myValue;
        }

        #region IFastSerializationTypeSurrogate
        public override bool SupportsType(Type type)
        {
            return this.GetType() == type;
        }

        public override void Serialize(SerializationWriter writer, object value)
        {
            Serialize(ref writer, (DBString)value);
        }

        public override object Deserialize(SerializationReader reader, Type type)
        {
            DBString thisObject = (DBString)Activator.CreateInstance(type);
            return Deserialize(ref reader, thisObject);
        }

        #endregion

        #region ToString(IFormatProvider provider)

        public override string ToString(IFormatProvider provider)
        {
            return _Value.ToString(provider);
        }

        #endregion

    }
}