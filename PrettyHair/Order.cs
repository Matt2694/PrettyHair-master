using System;
using System.Collections.Generic;

namespace PrettyHair
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int CustomerId { get; set; }
        public List<OrderLine> ListOfOrderLines { get; set; }
        public bool Registered { get; set; }
        public Order() { }

        public Order(int id, DateTime date, DateTime deliveryDate, List<int> productTypeId, List<int> quantity, int customerId)
        {
            Id = id;
            Date = date;
            DeliveryDate = deliveryDate;
            CustomerId = customerId;
            ListOfOrderLines = new List<OrderLine>();
            for(int i = 0; i<productTypeId.Count; i++)
            {
                OrderLine ol = new OrderLine(productTypeId[i], quantity[i]);
                ListOfOrderLines.Add(ol);
            }
        }
        
    }
}
