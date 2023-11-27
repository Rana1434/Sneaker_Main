using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SneakerDAL
{
    public class Customer
    {
        [Key]
        public int custId { get; set; }
        public string? custName { get; set; }
        public string? custAddress { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }

    public class Orders
    {
        [Key]
        public int? orderId { get; set; }
        public string? OrderName { get; set; }
        public virtual ICollection<Buy> Buys { get; set; }
    }

    public class Buy
    {
        [Key]
        public int orderedId { get; set; }
        public Shoes shoeId { get; set; }
        [ForeignKey("orderId")]
        public int orderId { get; set; }
        public virtual Orders Order { get; set; }

        public int? Quantity { get; set; }

    }

    public class Shoes
    {
        [Key]
        public int shoeId { get; set; }
        public string? Gender { get; set; }
        public double? shoePrice { get; set; }
        public string? shoeStyle { get; set; }
        public string? shoeName { get; set; }
        public string? shoeColor { get; set; }
        public int? shoeSize { get; set; }
        public virtual ICollection<Buy> Buys { get; set; }
    }



    public class SneakerDbContext : DbContext
    {
        public DbSet<Shoes> Shoes { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Buy> Buys { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SneakerDb;Trusted_Connection=true");
        }
    }
}