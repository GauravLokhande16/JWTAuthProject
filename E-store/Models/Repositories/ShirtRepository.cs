 namespace E_store.Models.Repositories
{
    public static class ShirtRepository
    {
        private static List<Shirt> shirts = new List<Shirt>()
        {
            new Shirt {ShirtId = 1, Brand= "My brand", Color="Blue", Gender= "men", Price= 30, Size=10},
            new Shirt {ShirtId = 2, Brand= "My brand", Color="Green", Gender= "Women", Price= 90, Size=3},
            new Shirt {ShirtId = 3, Brand= "Your brand", Color="Pink", Gender= "men", Price= 120, Size=10},
            new Shirt {ShirtId = 4, Brand= "Tata", Color="Red", Gender= "eomen", Price= 40, Size=12},
        };

        public static bool ShirtExists(int id)
        {
            return shirts.Any(x => x.ShirtId == id);
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.ShirtId == id);
        }
    }
}
