using GroceryDal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLib
{
    public class OrderService
    {
        static GroceryDbContext _dbContext = new GroceryDbContext();

        public static List<Order> GetAllOrders()
        {
            return _dbContext.Orders.Include(o => o.OrderItems).ToList();
        }

        public static Order GetOrderById(int orderId)
        {
            return _dbContext.Orders.Include(o => o.OrderItems).FirstOrDefault(o => o.OrderId == orderId);
        }

        public static void PlaceOrder(int OrderId, DateTime ODate, int CustID, int Amount, string Address, string status)
        {
            //order.OrderDate = DateTime.Now;
            _dbContext.Orders.Add(new GroceryDal.Order() { OrderId = OrderId, OrderDate = ODate, CustomerId = CustID, TotalAmount = Amount, DeliveryAddress = Address, OrderStatus = status });
            _dbContext.SaveChanges();
        }

        //public static void PlaceOrder(List<Product> products, int cId, int tamt, string Address)
        //{
        //    Order order = new Order
        //    {
        //        Product = products,
        //        CustomerId = cId,
        //        TotalAmount = tamt,
        //        DeliveryAddress = Address
        //    };
        //    _dbContext.Orders.Add(order);
        //}

        public static void UpdateOrder(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public static void DeleteOrder(int orderId)
        {
            var order = _dbContext.Orders.Find(orderId);
            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
        }
    }
}
