using GroceryDal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLib
{
    public class CustomerService
    {
        static GroceryDbContext _dbContext = new GroceryDbContext();

        //public object Name { get; set; }

        public static List<GroceryDal.Customer> GetAllCustomers()
        {
            return _dbContext.Customers.ToList();
        }

        //public static GroceryDal.Customer GetCustomerById(int customerId)
        //{
        //    var result = _dbContext.Customers.ToList()
        //         .Where(p => p.CustomerId == customerId)
        //         .FirstOrDefault();
        //    return result as Customer;
        //}

        public static void AddCustomer(int custId, string pName, string pEmail, string pAddress, string pPhone)
        {
            _dbContext.Customers.Add(new GroceryDal.Customer()
            {
                CustomerId = custId,
                Name = pName,
                Email = pEmail,
                Address = pAddress,
                Phone = pPhone
            });
            _dbContext.SaveChanges();
        }

        public static void UpdateCustomer(int CustId, string CName, string Email, string Address, string Phone)
        {
            //_dbContext.Entry(customer).State = EntityState.Modified;
            //_dbContext.SaveChanges();
            var tobeupdated = _dbContext.Customers
              .ToList()
              .Where(p => p.CustomerId == CustId)
              .FirstOrDefault();

            tobeupdated.Name = CName;
            tobeupdated.Email = Email;
            tobeupdated.Address = Address;
            tobeupdated.Phone = Phone;
            _dbContext.SaveChanges();
        }

        public static void DeleteCustomer(int customerId)
        {
            var tobedeleted = _dbContext.Customers
                                            .ToList()
                                            .Where((p) => p.CustomerId == customerId)
                                            .FirstOrDefault();

            _dbContext.Customers.Remove(tobedeleted);
            _dbContext.SaveChanges();

        }
    }
}
