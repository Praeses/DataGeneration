using System;

namespace Praeses.DataGeneration
{
    /// <summary>
    /// DataColumnDefinition Builder class
    /// </summary>
    public class DataColumnDefinitionBuilder
    {
        private Type _DataType;
        private string _Name;
        private Func<object> _Setter;

        /// <summary>
        /// Converts the builder to a DataColumnDefinition
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>The DataColumnDefinition created from the builder</returns>
        public static implicit operator DataColumnDefinition(DataColumnDefinitionBuilder builder)
        {
            return builder.Build();
        }

        /// <summary>
        /// Converts the builder to a DataColumnDefinition
        /// </summary>
        /// <returns>The DataColumnDefinition created from the builder</returns>
        public DataColumnDefinition Build()
        {
            if (_DataType == null)
            {
                throw new InvalidOperationException("DataType must be provided for the Column definition");
            }

            if (string.IsNullOrEmpty(_Name))
            {
                throw new InvalidOperationException("Name must be provided for the Column definition");
            }

            return new DataColumnDefinition
                {
                    DataType = _DataType,
                    Name = _Name,
                    Setter = _Setter
                };
        }

        /// <summary>
        /// Sets the Name property
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The builder for chaining</returns>
        public DataColumnDefinitionBuilder Named(string name)
        {
            _Name = name;

            return this;
        }

        /// <summary>
        /// Sets the type of the column
        /// </summary>
        /// <typeparam name="T">The column type</typeparam>
        /// <returns>The builder for chaining</returns>
        public DataColumnDefinitionBuilder OfType<T>()
        {
            _DataType = typeof(T);

            return this;
        }

        /// <summary>
        /// Sets the setter used for creating column data
        /// </summary>
        /// <param name="setter">The setter.</param>
        /// <returns>The builder for chaining</returns>
        public DataColumnDefinitionBuilder SetWith(Func<object> setter)
        {
            _Setter = setter;

            return this;
        }
    }
}
