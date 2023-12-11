using GroceryDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLib
{
    public class ProductService
    {
        static GroceryDbContext _dbContext = new GroceryDbContext();

        public static List<GroceryDal.Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public static Product GetProductById(int productId)
        {
            //return _dbContext.Products.Find(productId);
            var result = _dbContext.Products.ToList()
                 .Where(p => p.ProductId == productId)
                 .FirstOrDefault();
            return result as Product;
        }

        public static void AddProduct(int PId, string Name, int price, string Desc)
        {
            _dbContext.Products.Add(new GroceryDal.Product()
            {
                ProductId = PId,
                Name = Name,
                PricePerQuntity = price,
                Description = Desc
            });
            _dbContext.SaveChanges();
        }

        public static void UpdateProduct(int pId, Product p)
        {
            //_dbContext.Entry(product).State = EntityState.Modified;
            //_dbContext.SaveChanges();
            var tobeupdated = _dbContext.Products
              .ToList()
              .Where(p => p.ProductId == pId)
              .FirstOrDefault();

            tobeupdated.Name = p.Name;
            tobeupdated.PricePerQuntity= p.PricePerQuntity;
            tobeupdated.Description = p.Description;
            _dbContext.SaveChanges();
        }

        public static void DeleteProduct(int productId)
        {
            //var product = _dbContext.Products.Find(productId);
            var tobedeleted = _dbContext.Products
                                            .ToList()
                                            .Where((p) => p.ProductId == productId)
                                            .FirstOrDefault();
            _dbContext.Products.Remove(tobedeleted);
            _dbContext.SaveChanges();
        }
    }
}


