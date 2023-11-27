using SneakerDAL;
using System.ComponentModel.DataAnnotations.Schema;

namespace SneakerLIB
{
    public class Orders
    {
        public int orderId { get; set; }
        public string? OrderName { get; set; }
        
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Buy> Buy { get; set; }

        static SneakerDbContext dbContext = new SneakerDbContext();
        public class OrdersOperations
        {
            public static void Add(int id, string orderName)
            {
                dbContext.Orders.Add(new SneakerDAL.Orders() {OrderName=orderName });
                dbContext.SaveChanges();
            }
            public static void Update(int id,string NewOrderName)

            {
                var tobeUpdated = dbContext.Orders
                        .ToList()
                        .Where(p => p.orderId ==id )
                        .FirstOrDefault();

                tobeUpdated.OrderName = NewOrderName;
                
                dbContext.SaveChanges();
            }
            
            public static List<SneakerDAL.Orders> Get()
            {
                return dbContext.Orders.ToList();
            }
            public static void Delete(int dorderId)
            {
                var tobedeleted = dbContext.Orders
                         .ToList()
                         .Where(p => p.orderId == dorderId)
                         .FirstOrDefault();
                dbContext.Orders.Remove(tobedeleted);
                dbContext.SaveChanges();
            }
        }
    }
}
