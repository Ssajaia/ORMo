// ORMo/Metadata/EntityMetadata.cs
using System;
using System.Collections.Generic;

namespace ORMo.Metadata
{
    public class EntityMetadata
    {
        public Type EntityType { get; set; }
        public string TableName { get; set; }
        public PropertyMetadata PrimaryKey { get; set; }
        public List<PropertyMetadata> Properties { get; set; } = new List<PropertyMetadata>();

        public override string ToString()
        {
            return $"Entity: {EntityType.Name} -> Table: {TableName}\n" +
                   $"Primary Key: {PrimaryKey?.PropertyName}\n" +
                   $"Properties: {Properties.Count}";
        }
    }
}