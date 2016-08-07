﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Apps72.Dev.Data.Convertor
{
    /// <summary>
    /// DbType Mapping
    /// See https://gist.github.com/abrahamjp
    /// </summary>
    internal static class DbTypeMap
    {
        private static readonly List<DbTypeMapEntry> _dbTypeList = new List<DbTypeMapEntry>();

        /// <summary>
        /// Initialize the DbTypeMap
        /// </summary>
        static DbTypeMap()
        {
            FillDbTypeList();
        }

        /// <summary>
        /// Fill all dbTypeList entries
        /// </summary>
        public static void FillDbTypeList()
        {
            _dbTypeList.Add(new DbTypeMapEntry(typeof(Int16), DbType.Int16));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(Int32), DbType.Int32));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(Int64), DbType.Int64));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(UInt16), DbType.UInt16));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(UInt32), DbType.UInt32));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(UInt64), DbType.UInt64));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(bool), DbType.Boolean));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(byte), DbType.Byte));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(sbyte), DbType.SByte));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(Decimal), DbType.Decimal));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(Decimal), DbType.Single));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(double), DbType.Double));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(decimal), DbType.Currency));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(decimal), DbType.Currency));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(double), DbType.Double));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(double), DbType.VarNumeric));

            _dbTypeList.Add(new DbTypeMapEntry(typeof(string), DbType.String));;
            _dbTypeList.Add(new DbTypeMapEntry(typeof(string), DbType.String));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(string), DbType.String));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(string), DbType.String));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(string), DbType.String));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(string), DbType.String));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(string), DbType.AnsiString));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(string), DbType.AnsiStringFixedLength));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(string), DbType.Xml));

            _dbTypeList.Add(new DbTypeMapEntry(typeof(DateTime), DbType.DateTime));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(DateTime), DbType.Date));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(DateTime), DbType.DateTime2));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(DateTime), DbType.DateTime));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(DateTime), DbType.DateTimeOffset));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(DateTime), DbType.Time));

            _dbTypeList.Add(new DbTypeMapEntry(typeof(Guid), DbType.Guid));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(object), DbType.Object));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(byte[]), DbType.Binary));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(byte[]), DbType.Binary));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(object), DbType.Object));
            _dbTypeList.Add(new DbTypeMapEntry(typeof(object), DbType.Object));
        }

        /// <summary>
        /// Returns the first element in a sequence that satisfies a specified condition.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static DbTypeMapEntry First(Func<DbTypeMapEntry, bool> predicate)
        {
            return _dbTypeList.First(predicate);
        }
    }


    /// <summary>
    /// Mapping type structure to convert C# type to DbType, or to SqlDbType
    /// </summary>
    internal struct DbTypeMapEntry
    {
        public DbTypeMapEntry(Type type, DbType dbType)
        {
            this.Type = type;
            this.DbType = dbType;
        }
        public Type Type;
        public DbType DbType;
    }
}
