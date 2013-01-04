using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Praeses.DataGeneration
{
    /// <summary>
    /// DataSet Builder class
    /// </summary>
    public class DataSetBuilder
    {
        private readonly IList<DataTableBuilder> _TableBuilders;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataSetBuilder" /> class.
        /// </summary>
        public DataSetBuilder()
        {
            _TableBuilders = new List<DataTableBuilder>();
        }

        /// <summary>
        /// Convert the builder to a DataSet
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>The dataset constructed by the builder</returns>
        public static implicit operator DataSet(DataSetBuilder builder)
        {
            return builder.Build();
        }

        /// <summary>
        /// Build the DataSet
        /// </summary>
        /// <returns>The DataSet constructed by the builder</returns>
        public DataSet Build()
        {
            var dataSet = new DataSet();

            dataSet.Tables.AddRange(_TableBuilders.Select(builder => (DataTable)builder).ToArray());

            return dataSet;
        }

        /// <summary>
        /// Add a table to the builder
        /// </summary>
        /// <param name="tableBuilderAction">The table builder action.</param>
        /// <returns>The builder for chaining</returns>
        public DataSetBuilder HavingTable(Action<DataTableBuilder> tableBuilderAction)
        {
            var tableBuilder = new DataTableBuilder();

            tableBuilderAction(tableBuilder);
            _TableBuilders.Add(tableBuilder);

            return this;
        }
    }
}
