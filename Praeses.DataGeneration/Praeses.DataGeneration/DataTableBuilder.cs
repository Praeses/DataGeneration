using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Praeses.DataGeneration
{
    /// <summary>
    /// DataTable Builder class
    /// </summary>
    public class DataTableBuilder
    {
        private readonly IList<DataColumnDefinition> _ColumnDefinitions;
        private int _NumberOfRows;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataTableBuilder" /> class.
        /// </summary>
        public DataTableBuilder()
        {
            _ColumnDefinitions = new List<DataColumnDefinition>();
        }

        /// <summary>
        /// Create a DataTable from the builder
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>The DataTable constructed from the builder</returns>
        public static implicit operator DataTable(DataTableBuilder builder)
        {
            return builder.Build();
        }

        /// <summary>
        /// Builds the DataTable
        /// </summary>
        /// <returns>The DataTable constructed from the builder</returns>
        public DataTable Build()
        {
            var table = new DataTable();

            table.Columns.AddRange(_ColumnDefinitions.Select(c => (DataColumn)c).ToArray());

            for (var rowCount = 0; rowCount < _NumberOfRows; rowCount++)
            {
                var row = table.NewRow();

                foreach (var definition in _ColumnDefinitions.Where(definition => definition.Setter != null))
                {
                    row[definition.Name] = definition.Setter();
                }

                table.Rows.Add(row);
            }

            return table;
        }

        /// <summary>
        /// Add a column to the table
        /// </summary>
        /// <param name="columnDefinitionBuilderAction">The column definition builder action.</param>
        /// <returns>The builder for chaining</returns>
        public DataTableBuilder HavingColumn(Action<DataColumnDefinitionBuilder> columnDefinitionBuilderAction)
        {
            var columnDefinitionBuilder = new DataColumnDefinitionBuilder();

            columnDefinitionBuilderAction(columnDefinitionBuilder);
            _ColumnDefinitions.Add(columnDefinitionBuilder.Build());

            return this;
        }

        /// <summary>
        /// Creates a column with type T and name
        /// </summary>
        /// <typeparam name="T">The type of the column to create</typeparam>
        /// <param name="name">The name of the column.</param>
        /// <returns>The builder for chaining</returns>
        public DataTableBuilder HavingAColumnNamed<T>(string name)
        {
            HavingColumn(column => column.Named(name)
                                         .OfType<T>());

            return this;
        }

        /// <summary>
        /// Creates a column with type T, name, and setter
        /// </summary>
        /// <typeparam name="T">The type of the column</typeparam>
        /// <param name="name">The name of the column.</param>
        /// <param name="setter">The setter used for creating row data for the column.</param>
        /// <returns>The builder for chaining</returns>
        public DataTableBuilder HavingAColumnWithSetterNamed<T>(string name, Func<object> setter)
        {
            HavingColumn(column => column.Named(name)
                                         .OfType<T>()
                                         .SetWith(setter));

            return this;
        }

        /// <summary>
        /// Creates a decimal column with name
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The builder for chaining</returns>
        public DataTableBuilder HavingADecimalColumnNamed(string name)
        {
            return HavingAColumnNamed<decimal>(name);
        }

        /// <summary>
        /// Creates a decimal column with name and setter
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <param name="setter">The setter used for creating row data for the column.</param>
        /// <returns>
        /// The builder for chaining
        /// </returns>
        public DataTableBuilder HavingADecimalColumnWithSetterNamed(string name, Func<object> setter)
        {
            return HavingAColumnWithSetterNamed<decimal>(name, setter);
        }

        /// <summary>
        /// Creates an int column with name and setter
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>
        /// The builder for chaining
        /// </returns>
        public DataTableBuilder HavingAnIntColumnNamed(string name)
        {
            return HavingAColumnNamed<int>(name);
        }

        /// <summary>
        /// Creates an int column with name and setter
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <param name="setter">The setter used for creating row data for the column.</param>
        /// <returns>
        /// The builder for chaining
        /// </returns>
        public DataTableBuilder HavingAnIntColumnWithSetterNamed(string name, Func<object> setter)
        {
            return HavingAColumnWithSetterNamed<int>(name, setter);
        }

        /// <summary>
        /// Creates a string column with name and setter
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>
        /// The builder for chaining
        /// </returns>
        public DataTableBuilder HavingAStringColumnNamed(string name)
        {
            return HavingAColumnNamed<string>(name);
        }

        /// <summary>
        /// Creates a string column with name and setter
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <param name="setter">The setter used for creating row data for the column.</param>
        /// <returns>
        /// The builder for chaining
        /// </returns>
        public DataTableBuilder HavingAStringColumnWithSetterNamed(string name, Func<object> setter)
        {
            return HavingAColumnWithSetterNamed<string>(name, setter);
        }

        /// <summary>
        /// Sets the number of rows of data to create
        /// </summary>
        /// <param name="numberOfRows">The number of rows.</param>
        /// <returns>The builder for chaining</returns>
        public DataTableBuilder WithThisManyRowsOfData(int numberOfRows)
        {
            _NumberOfRows = numberOfRows;

            return this;
        }
    }
}
