using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrettyHair;
using System.Collections.Generic;

namespace PrettyHairTest
{
    [TestClass]
    public class ReceiveOrderTests
    {
        private CustomerRepository CreateRepositoryCu()
        {
            return new CustomerRepository();
        }
        private OrderRepository CreateRepositoryOr()
        {
            return new OrderRepository();
        }

        [TestMethod]
        public void CreateCustomer()
        {
            CustomerRepository repoCu = CreateRepositoryCu();
            repoCu.Clear();
            Assert.AreEqual(0, repoCu.CountCustomers());
            Customer ben = repoCu.Create(1, "Ben Smith Maybe", "Praceta Ribeiro Sanches, nº 89");
            Assert.AreEqual(1, repoCu.CountCustomers());
        }

        [TestMethod]
        public void CreateOrder()
        {
            CustomerRepository repoCu = CreateRepositoryCu();
            repoCu.Clear();
            OrderRepository repoOr = CreateRepositoryOr();
            repoOr.Clear();

            Assert.AreEqual(0, repoCu.CountCustomers());
            Assert.AreEqual(0, repoOr.CountOrders());

            List<int> productsId = new List<int>();
            List<int> productsQuantity = new List<int>();

            ProductTypeRepository repoPr = new ProductTypeRepository();

            ProductType hairSpray = repoPr.CreateProduct(3, 68.00, "Supah stronk hair spray!", 10);
            ProductType hairStraightener = repoPr.CreateProduct(4, 172.62, "Very powerfull straightener for hair!", 30);

            productsId.Add(hairSpray.Id);
            productsQuantity.Add(5);
            productsId.Add(hairStraightener.Id);
            productsQuantity.Add(10);

            repoOr.InsertOrder(1, new DateTime(2015, 6, 10), new DateTime(2015, 7, 10), 1, productsQuantity, productsId, repoPr);
            Assert.AreEqual(1, repoOr.CountOrders());
        }

        [TestMethod]
        public void LoadOrder()
        {
            CustomerRepository repoCu = CreateRepositoryCu();
            repoCu.Clear();
            OrderRepository repoOr = CreateRepositoryOr();
            repoOr.Clear();

            Assert.AreEqual(0, repoCu.CountCustomers());
            Assert.AreEqual(0, repoOr.CountOrders());

            List<int> productsId = new List<int>();
            List<int> productsQuantity = new List<int>();

            ProductTypeRepository repoPr = new ProductTypeRepository();

            ProductType hairSpray = repoPr.CreateProduct(3, 68.00, "Supah stronk hair spray!", 10);
            ProductType hairStraightener = repoPr.CreateProduct(4, 172.62, "Very powerfull straightener for hair!", 30);

            productsId.Add(hairSpray.Id);
            productsQuantity.Add(5);
            productsId.Add(hairStraightener.Id);
            productsQuantity.Add(10);

            repoOr.InsertOrder(1, new DateTime(2015, 6, 10), new DateTime(2015, 7, 10), 1, productsQuantity, productsId, repoPr);

            Order loadedOrder = repoOr.Load(1);

            Assert.AreEqual(4, loadedOrder.ListOfOrderLines[1].ProductId);
        }

        [TestMethod]
        public void LoadCustomer()
        {
            CustomerRepository repoCu = CreateRepositoryCu();
            repoCu.Clear();

            Assert.AreEqual(0, repoCu.CountCustomers());

            Customer ben = repoCu.Create(1, "Ben Smith Maybe", "Praceta Ribeiro Sanches, nº 89");

            Customer loadedCustomer = repoCu.Load(1);
            Assert.AreEqual("Ben Smith Maybe", loadedCustomer.Name);
        }

        [TestMethod]
        public void RemoveCustomer()
        {
            CustomerRepository repoCu = CreateRepositoryCu();
            repoCu.Clear();

            Assert.AreEqual(0, repoCu.CountCustomers());

            Customer ben = repoCu.Create(1, "Ben Smith Maybe", "Praceta Ribeiro Sanches, nº 89");

            Assert.AreEqual(1, repoCu.CountCustomers());

            repoCu.Remove(1);

            Assert.AreEqual(0, repoCu.CountCustomers());
        }

        [TestMethod]
        public void EditAddressCustomer()
        {
            CustomerRepository repoCu = CreateRepositoryCu();
            repoCu.Clear();

            Assert.AreEqual(0, repoCu.CountCustomers());

            Customer ben = repoCu.Create(1, "Ben Smith Maybe", "Praceta Ribeiro Sanches, nº 89");

            repoCu.ChangeAddress("Avenida da Boavista, nº 666", 1);

            Assert.AreEqual("Avenida da Boavista, nº 666", ben.Address);
        }

        [TestMethod]
        public void CountCustomerOrders()
        {

            CustomerRepository repoCu = CreateRepositoryCu();
            repoCu.Clear();
            OrderRepository repoOr = CreateRepositoryOr();
            repoOr.Clear();

            Assert.AreEqual(0, repoCu.CountCustomers());
            Assert.AreEqual(0, repoOr.CountOrders());

            List<int> productsId = new List<int>();
            List<int> productsQuantity = new List<int>();

            ProductTypeRepository repoPr = new ProductTypeRepository();

            ProductType hairSpray = repoPr.CreateProduct(3, 68.00, "Supah stronk hair spray!", 10);
            ProductType hairStraightener = repoPr.CreateProduct(4, 172.62, "Very powerfull straightener for hair!", 30);

            productsId.Add(hairSpray.Id);
            productsQuantity.Add(5);
            productsId.Add(hairStraightener.Id);
            productsQuantity.Add(10);

            repoOr.InsertOrder(1, new DateTime(2015, 6, 10), new DateTime(2015, 7, 10), 1, productsQuantity, productsId, repoPr);
            repoOr.InsertOrder(1, new DateTime(2015, 6, 10), new DateTime(2015, 7, 10), 2, productsQuantity, productsId, repoPr);


            Assert.AreEqual(2, repoOr.CountOrders(1));

        }
    }
}