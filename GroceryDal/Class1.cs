using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GroceryDal
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        //[Required]
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        // Other customer properties...
        public ICollection<Order> Orders { get; set; }
    }

    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        //[Required]
        public string? Name { get; set; }

        //[Required]
        public int PricePerQuntity { get; set; }
        public string? Description { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }

    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? TotalAmount { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? OrderStatus { get; set; }

        
        public ICollection<OrderItem> OrderItems { get; set; }
        public Delivery Delivery { get; set; }
        public List<Product> Product { get; set; }
    }


    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int? Quantity { get; set; }
        public int? PriceAtOrderTime { get; set; }

        
    }



    public class Delivery
    {
        [Key]
        public int DeliveryId { get; set; }
 
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string? DeliveryStatus { get; set; }
       

    }



    public class GroceryDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=GroceryDB2; Trusted_Connection = true");
        }
    }
}