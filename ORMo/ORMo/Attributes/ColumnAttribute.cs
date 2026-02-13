// ORMo/Attributes/ColumnAttribute.cs
using System;

namespace ORMo.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class ColumnAttribute : Attribute
    {
        public string Name { get; }

        public ColumnAttribute(string name)
        {
            Name = name;
        }
    }
}