// ORMo/Metadata/MetadataBuilder.cs
using ORMo.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ORMo.Metadata
{
    public class MetadataBuilder
    {
        private static readonly Dictionary<Type, EntityMetadata> _metadataCache = new Dictionary<Type, EntityMetadata>();

        public EntityMetadata GetMetadata<T>() where T : class
        {
            return GetMetadata(typeof(T));
        }

        public EntityMetadata GetMetadata(Type entityType)
        {
            if (!entityType.IsClass || entityType.IsAbstract)
            {
                throw new ArgumentException($"Type {entityType.Name} must be a non-abstract class");
            }

            if (_metadataCache.TryGetValue(entityType, out var cachedMetadata))
            {
                return cachedMetadata;
            }

            var metadata = BuildMetadata(entityType);
            _metadataCache[entityType] = metadata;

            return metadata;
        }

        private EntityMetadata BuildMetadata(Type entityType)
        {
            var metadata = new EntityMetadata
            {
                EntityType = entityType,
                TableName = GetTableName(entityType)
            };

            // Process all properties
            foreach (var property in entityType.GetProperties())
            {
                var propertyMetadata = BuildPropertyMetadata(property);
                metadata.Properties.Add(propertyMetadata);

                // Check if this is the primary key
                if (propertyMetadata.IsPrimaryKey)
                {
                    if (metadata.PrimaryKey != null)
                    {
                        throw new InvalidOperationException($"Entity {entityType.Name} has multiple properties marked with [Key] attribute");
                    }
                    metadata.PrimaryKey = propertyMetadata;
                }
            }

            // Validate that a primary key was found
            if (metadata.PrimaryKey == null)
            {
                throw new InvalidOperationException($"Entity {entityType.Name} must have at least one property marked with [Key] attribute");
            }

            return metadata;
        }

        private string GetTableName(Type entityType)
        {
            var tableAttribute = entityType.GetCustomAttribute<TableAttribute>();

            if (tableAttribute != null)
            {
                return tableAttribute.Name;
            }

            // Default to class name if no attribute specified
            return entityType.Name;
        }

        private PropertyMetadata BuildPropertyMetadata(PropertyInfo property)
        {
            var columnAttribute = property.GetCustomAttribute<ColumnAttribute>();
            var keyAttribute = property.GetCustomAttribute<KeyAttribute>();

            return new PropertyMetadata
            {
                PropertyName = property.Name,
                ColumnName = columnAttribute?.Name ?? property.Name,
                PropertyType = property.PropertyType,
                IsPrimaryKey = keyAttribute != null
            };
        }

        public void ClearCache()
        {
            _metadataCache.Clear();
        }
    }
}