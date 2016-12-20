using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrettyHair;

namespace PrettyHairTest
{
    [TestClass]
    public class ReceiveProductTests
    {
        private ProductTypeRepository CreateRepositoryPr()
        {
            return new ProductTypeRepository();
        }

        [TestMethod]
        public void CheckIfTheProductExists()
        {
            ProductTypeRepository repoPr = CreateRepositoryPr();
            ProductType scissors = repoPr.CreateProduct(6, 34.51, "Very Sharp scissors", 25);

            Assert.IsTrue(repoPr.CheckIfProductExists(6));
        }

        [TestMethod]
        public void CheckIfTheProductDoesNotExist()
        {
            ProductTypeRepository repoPr = CreateRepositoryPr();
            ProductType scissors = repoPr.CreateProduct(6, 34.51, "Very Sharp scissors", 25);

            Assert.IsFalse(repoPr.CheckIfProductExists(7));
        }

        [TestMethod]
        public void CheckIfCanAddStock()
        {
            ProductTypeRepository repoPr = CreateRepositoryPr();
            ProductType scissors = repoPr.CreateProduct(6, 34.51, "Very Sharp scissors", 25);

            int newAmount = repoPr.AddStock(6, 10);

            Assert.AreEqual(35, scissors.Amount);
            Assert.AreEqual(35, newAmount);
        }

        [TestMethod]
        public void CheckIfReturnsMinusOneWhenPassingAProductThatDoesNotExist()
        {
            ProductTypeRepository repoPr = CreateRepositoryPr();
            ProductType scissors = repoPr.CreateProduct(6, 34.51, "Very Sharp scissors", 25);

            int newAmount = repoPr.AddStock(7, 2);

            Assert.AreEqual(-1, newAmount);
        }

        [TestMethod]
        public void CheckIfReturnsMinusOneWhenPassingANegativeNumber()
        {
            ProductTypeRepository repoPr = CreateRepositoryPr();
            ProductType scissors = repoPr.CreateProduct(6, 34.51, "Very Sharp scissors", 25);

            int newAmount = repoPr.AddStock(6, -15);

            Assert.AreEqual(-1, newAmount);
        }

        [TestMethod]
        public void CheckIfCanReturnDictionary()
        {
            ProductTypeRepository repoPr = CreateRepositoryPr();
            ProductType scissors = repoPr.CreateProduct(6, 34.51, "Very Sharp scissors", 25);
            ProductType shampoo = repoPr.CreateProduct(7, 49.51, "Very foamy shampoo great for the whole famaly", 50);

            Dictionary<int, ProductType> listOfProducts = repoPr.GetProductTypes();

            Assert.AreEqual(2, listOfProducts.Count);
            Assert.AreEqual("Very Sharp scissors", listOfProducts[6].Description);
            Assert.AreEqual(49.51, listOfProducts[7].Price);

        }
    }
}
