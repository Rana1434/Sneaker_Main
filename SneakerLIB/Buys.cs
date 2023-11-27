using SneakerDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerLIB
{
    public class Buys
    {
        [Key]
        public int orderedId { get; set; }
        public Shoes shoeId { get; set; }

        [ForeignKey("orderId")]
        public int orderId { get; set; }
        public virtual Orders Order { get; set; }
        public int? Quantity { get; set; }

        static SneakerDbContext dbContext = new SneakerDbContext();
        public class BuyOperations
        {
            public static void Add(int orderId, int quantity)
            {
                dbContext.Buys.Add(new SneakerDAL.Buy() { orderId = orderId, Quantity = quantity });
                dbContext.SaveChanges();
            }
            public static void Update(int id, int newQuantity, int newOrderId)
            {
                var tobeUpdated = dbContext.Buys
                    .ToList()
                    .Where(p => p.orderedId == id)
                    .FirstOrDefault();

                tobeUpdated.Quantity = newQuantity;
                tobeUpdated.orderId = newOrderId;

                dbContext.SaveChanges();
            }


            public static List<SneakerDAL.Buy> Get()
            {
                return dbContext.Buys.ToList();
            }
            public static void Delete(int dorderedId)
            {
                var tobedeleted = dbContext.Buys
                    .ToList()
                         .Where(p => p.orderedId == dorderedId)
                         .FirstOrDefault();
                dbContext.Buys.Remove(tobedeleted);
                dbContext.SaveChanges();
            }
        }
    }
}
