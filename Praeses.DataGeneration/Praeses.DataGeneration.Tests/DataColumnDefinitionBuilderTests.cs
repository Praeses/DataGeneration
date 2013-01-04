using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Praeses.DataGeneration.Tests
{
    [TestClass]
    public class DataColumnDefinitionBuilderTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void An_exception_is_thrown_when_DataType_is_not_provided()
        {
            // arrange

            // act
            try
            {
                DataColumnDefinition definition = new DataColumnDefinitionBuilder()
                    .Named("ColumnName");
            }
            catch (InvalidOperationException ex)
            {
                // assert
                Assert.AreEqual("DataType must be provided for the Column definition", ex.Message);

                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void An_exception_is_thrown_when_Name_is_not_provided()
        {
            // arrange

            // act
            try
            {
                DataColumnDefinition definition = new DataColumnDefinitionBuilder()
                    .OfType<string>();
            }
            catch (InvalidOperationException ex)
            {
                // assert
                Assert.AreEqual("Name must be provided for the Column definition", ex.Message);

                throw;
            }
        }

        [TestMethod]
        public void A_valid_DataColumnDefinition_is_created()
        {
            // arrange

            // act
            DataColumnDefinition definition = new DataColumnDefinitionBuilder()
                .Named("ColumnName")
                .OfType<string>()
                .SetWith(() => "ColumnValue");

            // assert
            Assert.AreEqual("ColumnName", definition.Name);
            Assert.AreEqual(typeof(string), definition.DataType);
            Assert.IsNotNull(definition.Setter);
        }
    }
}
