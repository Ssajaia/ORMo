using System;

namespace ORMo.Metadata
{
    public class PropertyMetadata
    {
        public string PropertyName { get; set; }
        public string ColumnName { get; set; }
        public Type PropertyType { get; set; }
        public bool IsPrimaryKey { get; set; }

        public override string ToString()
        {
            return $"Property: {PropertyName} -> Column: {ColumnName} (Type: {PropertyType.Name}, IsPK: {IsPrimaryKey})";
        }
    }
}