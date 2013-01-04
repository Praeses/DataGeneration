using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Praeses.DataGeneration.Tests
{
    [TestClass]
    public class DataTableBuilderTests
    {
        [TestMethod]
        public void Can_create_a_table_with_an_integer_column()
        {
            // arrange
            // act
            DataTable dataTable = new DataTableBuilder()
                .HavingAnIntColumnNamed("SomeNumber");

            // assert
            Assert.IsTrue(dataTable.Columns.Contains("SomeNumber"));
            Assert.IsTrue(dataTable.Columns["SomeNumber"].DataType == typeof(int));
        }

        [TestMethod]
        public void Can_create_a_table_with_a_row_with_integer_data()
        {
            // arrange
            // act
            DataTable dataTable = new DataTableBuilder()
                .WithThisManyRowsOfData(1)
                .HavingAnIntColumnWithSetterNamed("SomeNumber", () => 1);

            // assert
            Assert.AreEqual(1, dataTable.Rows.Count);
            Assert.AreEqual(1, dataTable.Rows[0]["SomeNumber"]);
        }

        [TestMethod]
        public void Can_create_a_table_with_a_string_column()
        {
            // arrange
            // act
            DataTable dataTable = new DataTableBuilder()
                .HavingAStringColumnNamed("SomeString");

            // assert
            Assert.IsTrue(dataTable.Columns.Contains("SomeString"));
            Assert.IsTrue(dataTable.Columns["SomeString"].DataType == typeof(string));
        }

        [TestMethod]
        public void Can_create_a_table_with_a_row_with_string_data()
        {
            // arrange
            // act
            DataTable dataTable = new DataTableBuilder()
                .WithThisManyRowsOfData(1)
                .HavingAStringColumnWithSetterNamed("SomeString", () => "string!");

            // assert
            Assert.AreEqual(1, dataTable.Rows.Count);
            Assert.AreEqual("string!", dataTable.Rows[0]["SomeString"]);
        }

        [TestMethod]
        public void Can_create_a_table_with_a_decimal_column()
        {
            // arrange
            // act
            DataTable dataTable = new DataTableBuilder()
                .HavingADecimalColumnNamed("SomeDecimal");

            // assert
            Assert.IsTrue(dataTable.Columns.Contains("SomeDecimal"));
            Assert.IsTrue(dataTable.Columns["SomeDecimal"].DataType == typeof(decimal));
        }

        [TestMethod]
        public void Can_create_a_table_with_a_row_with_decimal_data()
        {
            // arrange
            // act
            DataTable dataTable = new DataTableBuilder()
                .WithThisManyRowsOfData(1)
                .HavingADecimalColumnWithSetterNamed("SomeDecimal", () => 3.50M);

            // assert
            Assert.AreEqual(1, dataTable.Rows.Count);
            Assert.AreEqual(3.50M, dataTable.Rows[0]["SomeDecimal"]);
        }
    }
}
