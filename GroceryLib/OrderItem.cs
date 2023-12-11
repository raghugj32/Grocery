using GroceryDal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLib
{
    public class OrderItemService
    {
        static GroceryDbContext _dbContext = new GroceryDbContext();
        public static List<OrderItem> GetOrderItemsByOrderId(int orderId)
        {
            return _dbContext.OrderItems.Where(oi => oi.OrderItemId == orderId).ToList();
        }

        public static void AddOrderItem(OrderItem orderItem)
        {
            _dbContext.OrderItems.Add(orderItem);
            _dbContext.SaveChanges();
        }

        public static void UpdateOrderItem(OrderItem orderItem)
        {
            _dbContext.Entry(orderItem).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public static void DeleteOrderItem(int orderItemId)
        {
            var orderItem = _dbContext.OrderItems.Find(orderItemId);
            _dbContext.OrderItems.Remove(orderItem);
            _dbContext.SaveChanges();
        }
    }
}
