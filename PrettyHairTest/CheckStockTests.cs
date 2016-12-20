using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrettyHair;

namespace PrettyHairTest
{
    [TestClass]
    public class CheckStockTests
    {
        private ProductTypeRepository CreateRepository()
        {
            return new ProductTypeRepository();
        }

        [TestMethod]
        public void Create()
        {
            ProductTypeRepository repo = CreateRepository();
            repo.Clear();
            ProductType dryer = repo.CreateProduct(1, 263.00, "Very stronk pink hair dryer!!", 50);
            Assert.AreEqual(1, dryer.Id);
            Assert.AreEqual(263.00, dryer.Price);
            Assert.AreEqual("Very stronk pink hair dryer!!", dryer.Description);
            Assert.AreEqual(50, dryer.Amount);
            Assert.IsTrue(dryer.Id != 0);
        }

        [TestMethod]
        public void Clear()
        {
            ProductTypeRepository repo = CreateRepository();
            repo.Clear();
            Assert.AreEqual(0, repo.CountProducts());
        }

        [TestMethod]
        public void SaveAndCount()
        {
            ProductTypeRepository repo = CreateRepository();
            repo.Clear();
            ProductType dryer = repo.CreateProduct(1, 263.00, "Very stronk pink hair dryer!!", 50);
            Assert.AreEqual(1, repo.CountProducts());
        }

        [TestMethod]
        public void SaveAndLoad()
        {
            ProductTypeRepository repo = CreateRepository();
            repo.Clear();
            ProductType dryer = repo.CreateProduct(1, 263.00, "Very stronk pink hair dryer!!", 50);
            ProductType loadedProduct = repo.Load(dryer.Id);

            Assert.AreEqual(dryer.Id, loadedProduct.Id);
        }

        [TestMethod]
        public void SaveAndLoadTwoProducts()
        {
            ProductTypeRepository repo = CreateRepository();
            repo.Clear();
            ProductType dryer = repo.CreateProduct(1, 263.00, "Very stronk pink hair dryer!!", 50);
            ProductType hairbrush = repo.CreateProduct(2, 39.00, "Very soft purple hair brush", 20);
            ProductType loadedDryer = repo.Load(dryer.Id);
            ProductType loadedBrush = repo.Load(hairbrush.Id);

            Assert.AreEqual(dryer.Id, loadedDryer.Id);
            Assert.AreEqual(hairbrush.Id, loadedBrush.Id);
            Assert.AreNotEqual(loadedDryer.Id, loadedBrush.Id);
        }

        [TestMethod]
        public void SaveAndCountTwoProducts()
        {
            ProductTypeRepository repo = CreateRepository();
            repo.Clear();
            ProductType dryer = repo.CreateProduct(1, 263.00, "Very stronk pink hair dryer!!", 50);
            ProductType hairbrush = repo.CreateProduct(2, 39.00, "Very soft purple hair brush", 20);

            Assert.AreEqual(2, repo.CountProducts());
        }

        [TestMethod]
        public void ChangeProductPrice()
        {
            ProductTypeRepository repo = CreateRepository();
            repo.Clear();
            ProductType dryer = repo.CreateProduct(1, 263.00, "Very stronk pink hair dryer!!", 50);
            repo.ChangePrice(20, 1);

            Assert.AreEqual(20, dryer.Price);
        }

        [TestMethod]
        public void ChangeProductAmount()
        {
            ProductTypeRepository repo = CreateRepository();
            repo.Clear();
            ProductType dryer = repo.CreateProduct(1, 263.00, "Very stronk pink hair dryer!!", 50);
            repo.ChangeAmount(49, 1);

            Assert.AreEqual(49, dryer.Amount);
        }
    }
}
