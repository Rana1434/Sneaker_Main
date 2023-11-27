using SneakerDAL;
using SneakerLIB;
using System;
using System.ComponentModel.DataAnnotations;

namespace SneakerApp1.Models
{
    public class Shoes
    {
        public int shoeId { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public double shoePrice { get; set; }

        [Required]
        public string shoeStyle { get; set; }

        [Required]
        public string shoeName { get; set; }

        [Required]
        public string shoeColor { get; set; }

        [Required]
        public int shoeSize { get; set; }

        public virtual ICollection<Buys> Buys { get; set; }

        static SneakerDbContext dbContext = new SneakerDbContext();

        public class ShoeOperations
        {
            public static void Add(int shoeId, string gender, double shoePrice, string shoeStyle, string shoeName, string shoeColor, int shoeSize)
            {
                dbContext.Shoes.Add(new SneakerDAL.Shoes()
                {
                    shoeId = shoeId,
                    Gender = gender,
                    shoePrice = shoePrice,
                    shoeStyle = shoeStyle,
                    shoeName = shoeName,
                    shoeColor = shoeColor,
                    shoeSize = shoeSize
                });

                dbContext.SaveChanges();
            }

            public static void Update(int shoeId, string newGender, double newShoePrice, string newShoeStyle, string newShoeName, string newShoeColor, int newShoeSize)
            {
                var tobeUpdated = dbContext.Shoes
                    .ToList()
                    .Where(p => p.shoeId == shoeId)
                    .FirstOrDefault();

                if (tobeUpdated != null)
                {
                    tobeUpdated.Gender = newGender;
                    tobeUpdated.shoePrice = newShoePrice;
                    tobeUpdated.shoeStyle = newShoeStyle;
                    tobeUpdated.shoeName = newShoeName;
                    tobeUpdated.shoeColor = newShoeColor;
                    tobeUpdated.shoeSize = newShoeSize;

                    dbContext.SaveChanges();
                }
            }

            public static void Delete(int dshoeId)
            {
                var tobedeleted = dbContext.Shoes
                    .ToList()
                    .Where(p => p.shoeId == dshoeId)
                    .FirstOrDefault();

                if (tobedeleted != null)
                {
                    dbContext.Shoes.Remove(tobedeleted);
                    dbContext.SaveChanges();
                }
            }

            public static List<SneakerDAL.Shoes> Get()
            {
                return dbContext.Shoes.ToList();
            }
            public static SneakerDAL.Shoes Search(int shoeId)
            {
                return Get().Where(p => p.shoeId == shoeId).FirstOrDefault();
            }


        }
    }
}
