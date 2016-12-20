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
    public class ProcessOrderTests
    {
        private ProductTypeRepository CreateRepositoryPr()
        {
            return new ProductTypeRepository();
        }
        private OrderRepository CreateRepositoryOr()
        {
            return new OrderRepository();
        }

        [TestMethod]
        public void ShouldRegisterOrder()
        {
            ProductTypeRepository repoPr = CreateRepositoryPr();
            OrderRepository repoOr = CreateRepositoryOr();

            ProductType conditioner = repoPr.CreateProduct(8, 108, "Make your hair great again with this great conditioner!", 16);

            List<int> productsId = new List<int>();
            List<int> productsQuantity = new List<int>();

            productsId.Add(8);
            productsQuantity.Add(5);

            Order newOrder = repoOr.InsertOrder(3, new DateTime(2016, 09, 20), new DateTime(2016, 09, 27), 1, productsQuantity, productsId, repoPr);

            Assert.IsFalse(newOrder.Registered);

            repoOr.Register(1, repoPr);

            Assert.IsTrue(newOrder.Registered);
        }

        [TestMethod]
        public void ShouldGetOrdersFromToday()
        {
            ProductTypeRepository repoPr = CreateRepositoryPr();
            OrderRepository repoOr = CreateRepositoryOr();

            ProductType conditioner = repoPr.CreateProduct(8, 108, "Make your hair great again with this great conditioner!", 16);
            ProductType hairDye = repoPr.CreateProduct(9, 571, "Don't like the disgusting color in your head? Change it now!", 52);

            List<int> productsId = new List<int>();
            List<int> productsQuantity = new List<int>();
            List<int> productsId1 = new List<int>();
            List<int> productsQuantity1 = new List<int>();

            productsId.Add(8);
            productsQuantity.Add(5);
            productsId.Add(9);
            productsQuantity.Add(10);

            productsId1.Add(9);
            productsQuantity1.Add(10);

            Order newOrder = repoOr.InsertOrder(3, new DateTime(2016, 09, 20), new DateTime(2016, 09, 27), 1, productsQuantity, productsId, repoPr);
            Order newOrder1 = repoOr.InsertOrder(4, DateTime.Today, DateTime.Today, 2, productsQuantity1, productsId1, repoPr);

            List<Order> listOfTodaysOrders = repoOr.CheckOrders(DateTime.Today, repoPr);

            Assert.AreEqual(1, listOfTodaysOrders.Count);
        }
        [TestMethod]
        public void RegisteredShouldBeFalseWhenOrderIsCreated()
        {
            ProductTypeRepository repoPr = CreateRepositoryPr();
            OrderRepository repoOr = CreateRepositoryOr();

            ProductType conditioner = repoPr.CreateProduct(8, 108, "Make your hair great again with this great conditioner!", 16);
            ProductType hairDye = repoPr.CreateProduct(9, 571, "Don't like the disgusting color in your head? Change it now!", 52);

            List<int> productsId = new List<int>();
            List<int> productsQuantity = new List<int>();
            List<int> productsId1 = new List<int>();
            List<int> productsQuantity1 = new List<int>();

            productsId.Add(8);
            productsQuantity.Add(5);
            productsId.Add(9);
            productsQuantity.Add(10);

            productsId1.Add(9);
            productsQuantity1.Add(10);

            Order newOrder = repoOr.InsertOrder(3, new DateTime(2016, 09, 20), new DateTime(2016, 09, 27), 1, productsQuantity, productsId, repoPr);
            Order newOrder1 = repoOr.InsertOrder(4, DateTime.Today, DateTime.Today, 2, productsQuantity1, productsId1, repoPr);

            Assert.IsFalse(newOrder.Registered);
            Assert.IsFalse(newOrder1.Registered);
        }

        [TestMethod]
        public void ShouldntBeAbleToProceedOrderIfNotEnoughProduct()
        {
            ProductTypeRepository repoPr = CreateRepositoryPr();
            OrderRepository repoOr = CreateRepositoryOr();

            ProductType conditioner = repoPr.CreateProduct(8, 108, "Make your hair great again with this great conditioner!", 16);
            ProductType hairDye = repoPr.CreateProduct(9, 571, "Don't like the disgusting color in your head? Change it now!", 52);

            List<int> productsId = new List<int>();
            List<int> productsQuantity = new List<int>();
            List<int> productsId1 = new List<int>();
            List<int> productsQuantity1 = new List<int>();

            productsId.Add(8);
            productsQuantity.Add(100);
            productsId.Add(9);
            productsQuantity.Add(10);

            productsId1.Add(8);
            productsQuantity1.Add(520000);

            Order newOrder = repoOr.InsertOrder(3, new DateTime(2016, 09, 20), new DateTime(2016, 09, 27), 1, productsQuantity, productsId, repoPr);
            Order newOrder1 = repoOr.InsertOrder(4, DateTime.Today, DateTime.Today, 2, productsQuantity1, productsId1, repoPr);
            
            List<Order> listOfTodaysOrders = repoOr.CheckOrders(DateTime.Today, repoPr);
            Assert.AreEqual(0, listOfTodaysOrders.Count);
        }

        [TestMethod]
        public void ShouldRemoveFromStockOnRegister()
        {
            ProductTypeRepository repoPr = CreateRepositoryPr();
            OrderRepository repoOr = CreateRepositoryOr();

            ProductType conditioner = repoPr.CreateProduct(8, 108, "Make your hair great again with this great conditioner!", 16);

            List<int> productsId = new List<int>();
            List<int> productsQuantity = new List<int>();

            productsId.Add(8);
            productsQuantity.Add(5);

            Order newOrder = repoOr.InsertOrder(3, new DateTime(2016, 09, 20), new DateTime(2016, 09, 27), 1, productsQuantity, productsId, repoPr);

            Assert.IsFalse(newOrder.Registered);

            repoOr.Register(1,repoPr);

            Assert.IsTrue(newOrder.Registered);
            Assert.AreEqual(11, conditioner.Amount);

        }

    }
}
