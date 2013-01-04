using System;
using System.Data;

namespace Praeses.DataGeneration
{
    /// <summary>
    /// Class used to define data columns
    /// </summary>
    public class DataColumnDefinition
    {
        public Type DataType { get; set; }
        public string Name { get; set; }
        public Func<object> Setter { get; set; }

        /// <summary>
        /// Convert the definition to a DataColumn
        /// </summary>
        /// <param name="definition">The definition.</param>
        /// <returns>The DataColumn created from the definition</returns>
        public static implicit operator DataColumn(DataColumnDefinition definition)
        {
            return new DataColumn(definition.Name, definition.DataType);
        }
    }
}
