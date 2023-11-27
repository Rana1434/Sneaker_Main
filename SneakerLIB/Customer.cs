using SneakerDAL;
using System;


namespace SneakerLIB
{
    public class Customer
    {
        public int custId { get; set; }
        public string custName { get; set; }
        public string custAddress { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }

        static SneakerDbContext dbContext = new SneakerDbContext();
        public class CustomerOperations
        {
            public static void Add(int custId, string custName, string custAddress)
            {
                dbContext.Customer.Add(new SneakerDAL.Customer() { custId = custId, custName = custName, custAddress = custAddress });
                dbContext.SaveChanges();
            }
            public static void Update(int custId, string NewcustName, string NewcustAddress)

            {
                var tobeUpdated = dbContext.Customer
                        .ToList()
                        .Where(p => p.custId ==custId)
                        .FirstOrDefault();

                tobeUpdated.custName = NewcustName;
                tobeUpdated.custAddress = NewcustAddress;
                
                dbContext.SaveChanges();
            }
            public static void Delete(int dcustId)
            {
                var tobedeleted = dbContext.Customer
                         .ToList()
                         .Where(p => p.custId == dcustId)
                         .FirstOrDefault();
                dbContext.Customer.Remove(tobedeleted);
                dbContext.SaveChanges();
            }
            public static List<SneakerDAL.Customer> Get()
            {
                return dbContext.Customer.ToList();
            }
        }
    }

}

