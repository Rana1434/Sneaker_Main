using SneakerDAL;

namespace SneakerLIB
{
    public class Shoes : Orders, ICart
    {


        private bool _shoeBuy = false;
        private bool _cartView = false;

        public void Buy()
        {
            _shoeBuy = true;
        }

        public void ViewCart()
        {
            _cartView = true;
        }
        public int shoeId { get; set; }
        public string Gender { get; set; }
        public double shoePrice { get; set; }
        public string shoeStyle { get; set; }
        public string shoeName { get; set; }
        public string shoeColor { get; set; }
        public int shoeSize { get; set; }
        public virtual ICollection<Buy> Buys { get; set; }


        static SneakerDbContext dbContext = new SneakerDbContext();
        public class ShoesOperations2
        {
            public static void Add(int shoeId,string gender,float shoeprice, string shoestyle,string shoename,string shoecolor,int shoesize)
            {
                dbContext.Shoes.Add(new SneakerDAL.Shoes() { shoeId = shoeId,Gender=gender,shoePrice=shoeprice,shoeStyle= shoestyle, shoeName = shoename,shoeColor=shoecolor,shoeSize=shoesize });
                dbContext.SaveChanges();
            }
            public static void Update(int shoeid, string Newgender, float Newshoeprice, string Newshoestyle, string Newshoename, string Newshoecolor, int Newshoesize)
           
            {
                var tobeUpdated = dbContext.Shoes
                        .ToList()
                        .Where(p => p.shoeId == shoeid)
                        .FirstOrDefault();

                tobeUpdated.Gender = Newgender; 
                tobeUpdated.shoePrice= Newshoeprice;
                tobeUpdated.shoeStyle = Newshoestyle;
                tobeUpdated.shoeName = Newshoename;
                tobeUpdated.shoeColor = Newshoecolor;
                tobeUpdated.shoeSize = Newshoesize;
                dbContext.SaveChanges();
            }
            public static void Delete(int dshoeId)
            {
                var tobedeleted = dbContext.Shoes
                         .ToList()
                         .Where(p => p.shoeId == dshoeId)
                         .FirstOrDefault();
                dbContext.Shoes.Remove(tobedeleted);
                dbContext.SaveChanges();
            }
            public static List<SneakerDAL.Shoes> Get()
            {
                return dbContext.Shoes.ToList();
            }
        }


    }




    public enum Gender
    {
        Male,
        Female
    }

    public enum shoeStyle
    {
        Sandals,
        Sneakers,
        Boots,
        Heels,
        Flats,
        Sports,
        Elegants
    }

    public enum shoeColor
    {
        Black,
        White,
        Red,
        Green,
        Blue,
        Silver,
        Yellow,
        Gold,
        Pink
    }


}
