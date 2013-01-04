using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Praeses.DataGeneration.Tests
{
    [TestClass]
    public class DataSetBuilderTests
    {
        [TestMethod]
        public void Can_create_a_DataSet_with_a_single_table()
        {
            // arrange
            // act
            DataSet dataSet = new DataSetBuilder()
                .HavingTable(table => table.HavingAnIntColumnNamed("SomeNumber"));

            // assert
            Assert.AreEqual(1, dataSet.Tables.Count);
        }

        [TestMethod]
        public void Can_create_a_DataSet_with_two_tables()
        {
            // arrange
            // act
            DataSet dataSet = new DataSetBuilder()
                .HavingTable(table => table.HavingAStringColumnNamed("SomeString"))
                .HavingTable(table => table.HavingAnIntColumnNamed("SomeNumber"));

            // assert
            Assert.AreEqual(2, dataSet.Tables.Count);
        }
    }
}
