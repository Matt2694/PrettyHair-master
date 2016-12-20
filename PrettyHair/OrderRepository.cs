using System;
using System.Collections.Generic;

namespace PrettyHair
{
    public class OrderRepository
    {
        Dictionary<int, Order> listOfOrders = new Dictionary<int, Order>();

        public void Clear()
        {
            listOfOrders.Clear();
        }

        public int CountOrders()
        {
            return listOfOrders.Count;
        }

        public int CountOrders(int customerId)
        {
            int countOrders = 0;
            foreach (Order order in listOfOrders.Values)
            {
                if (order.CustomerId == customerId)
                {
                    countOrders++;
                }
            }
            return countOrders;
        }

        public Order InsertOrder(int customerId, DateTime date, DateTime deliveryDate, int orderId, List<int> quantity, List<int> productTypeId, ProductTypeRepository repoPr)
        {
            Order order = new Order(orderId, date, deliveryDate, productTypeId, quantity, customerId);
            listOfOrders.Add(orderId, order);
            return order;
        }

        public Order Load(int orderId)
        {
            return listOfOrders[orderId];
        }

        public void Register(int orderId, ProductTypeRepository repoPr)
        {
            for(int i = 0; i < listOfOrders[orderId].ListOfOrderLines.Count; i++)
            {
                int quantityToRemoveFromStock = listOfOrders[orderId].ListOfOrderLines[i].Quantity;
                repoPr.SubtractToAmount(quantityToRemoveFromStock, listOfOrders[orderId].ListOfOrderLines[i].ProductId);
            }
            listOfOrders[orderId].Registered = true;
        }

        public List<Order> CheckOrders(DateTime date, ProductTypeRepository repoPr)
        {
            List<Order> ordersOfThisDate = new List<Order>();
            foreach (Order ord in listOfOrders.Values)
            {
                if (date.ToString("yyyy-MM-dd") == ord.Date.ToString("yyyy-MM-dd"))
                {
                    if (repoPr.CheckAmountOfProductsInOrder(ord) == true)
                    {
                        ordersOfThisDate.Add(ord);
                    }
                    else
                    {
                        string email = BuildEmail(ord, repoPr);
                    }
                }

            }

            return ordersOfThisDate;
        }

        public string BuildEmail(Order ord, ProductTypeRepository repoPr)
        {
            string text = "Id:" + ord.Id + "\nProducts:";
            for (int i = 0; i < ord.ListOfOrderLines.Count; i++)
            {
                text = text + "\n" + ord.ListOfOrderLines[i].ProductId + " - " + repoPr.GetProductTypes()[ord.ListOfOrderLines[i].ProductId].Description + " - " + ord.ListOfOrderLines[i].Quantity + " - " + repoPr.GetProductTypes()[ord.ListOfOrderLines[i].ProductId].Amount;
            }
            return text;
        }

        public int NewOrderNumber()
        {
            return listOfOrders.Count+1;
        }

        public Dictionary<int,Order> GetListOfOrders()
        {
            return listOfOrders;
        }
    }
}
