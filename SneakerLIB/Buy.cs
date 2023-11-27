
using SneakerDAL;

namespace SneakerLIB
{
    public class Buy
    {
        public int orderedId { get; set; }
        public Shoes shoeId { get; set; }
        public Orders orderId { get; set; }
        public int? Quantity { get; set; }

        static SneakerDbContext dbContext = new SneakerDbContext();
        public class BuyOperations
        {
            public static void Add(int id,int quantity)
            {
                dbContext.Buys.Add(new SneakerDAL.Buy() { orderedId = id,Quantity=quantity });
                dbContext.SaveChanges();
            }
            public static void Update(int id, int NewQuantity)

            {
                var tobeUpdated = dbContext.Buys
                        .ToList()
                        .Where(p => p.orderedId == id)
                        .FirstOrDefault();

                tobeUpdated.Quantity = NewQuantity;

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
