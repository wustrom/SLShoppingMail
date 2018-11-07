using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Common.Extend
{
    public static class Copy
    {
        /// <summary>
        /// 复制列
        /// </summary>
        /// <param name="column">列</param>
        /// <returns></returns>
        public static DataColumn CopyTo(this DataColumn column)
        {
            DataColumn Datacolumn = new DataColumn();
            Datacolumn.AllowDBNull = column.AllowDBNull;
            Datacolumn.AutoIncrement = column.AutoIncrement;
            Datacolumn.AutoIncrementSeed = column.AutoIncrementSeed;
            Datacolumn.AutoIncrementStep = column.AutoIncrementStep;
            Datacolumn.Caption = column.Caption;
            Datacolumn.ColumnMapping = column.ColumnMapping;
            Datacolumn.ColumnName = column.ColumnName;
            Datacolumn.DataType = column.DataType;
            Datacolumn.DateTimeMode = column.DateTimeMode;
            Datacolumn.DefaultValue = column.DefaultValue;
            Datacolumn.Expression = column.Expression;
            Datacolumn.MaxLength = column.MaxLength;
            Datacolumn.Namespace = column.Namespace;
            Datacolumn.Prefix = column.Prefix;
            Datacolumn.ReadOnly = column.ReadOnly;
            Datacolumn.Site = column.Site;
            Datacolumn.Unique = column.Unique;
            return Datacolumn;
        }
    }
}
