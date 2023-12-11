using GroceryDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLib
{
    public class DeliveryService
    {
        static GroceryDbContext _dbContext = new GroceryDbContext();
       
        public static void AddDelivery(Delivery d)
        {
            _dbContext.Deliveries.Add(d);
            _dbContext.SaveChanges();
        }
    }
}
