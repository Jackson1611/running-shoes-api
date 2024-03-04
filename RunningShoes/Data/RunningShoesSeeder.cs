using System;
using System.Linq;
using RunningShoes.Models;

namespace RunningShoes.Data
{
    public class RunningShoesSeeder
    {
        public static void Seed(RunningShoesDbContext context)
        {
            if (!context.Shoes.Any())
            {
                context.Shoes.AddRange(
                    new Shoe { Brand = "Nike", Name = "Air Zoom Pegasus 39", Type = "Running", Weight = 0.28, Price = 129.99, ReleaseYear = 2023 },
                    new Shoe { Brand = "Brooks", Name = "Ghost 15", Type = "Running", Weight = 0.31, Price = 139.99, ReleaseYear = 2023 },
                    new Shoe { Brand = "Hoka One One", Name = "Speedgoat 5", Type = "Trail", Weight = 0.35, Price = 169.99, ReleaseYear = 2023 },
                    new Shoe { Brand = "Adidas", Name = "Ultraboost 22", Type = "Running", Weight = 0.29, Price = 179.99, ReleaseYear = 2023 },
                    new Shoe { Brand = "New Balance", Name = "Fresh Foam 1080v12", Type = "Running", Weight = 0.32, Price = 149.99, ReleaseYear = 2023 },
                    new Shoe { Brand = "Asics", Name = "Gel-Kayano 28", Type = "Running", Weight = 0.3, Price = 159.99, ReleaseYear = 2023 },
                    new Shoe { Brand = "Salomon", Name = "Speedcross 5", Type = "Trail", Weight = 0.33, Price = 129.99, ReleaseYear = 2023 },
                    new Shoe { Brand = "Saucony", Name = "Kinvara 12", Type = "Running", Weight = 0.27, Price = 109.99, ReleaseYear = 2023 },
                    new Shoe { Brand = "Under Armour", Name = "HOVR Infinite 3", Type = "Running", Weight = 0.3, Price = 119.99, ReleaseYear = 2023 },
                    new Shoe { Brand = "Mizuno", Name = "Wave Rider 25", Type = "Running", Weight = 0.28, Price = 129.99, ReleaseYear = 2023 },
                    new Shoe { Brand = "On Running", Name = "Cloudswift", Type = "Running", Weight = 0.29, Price = 149.99, ReleaseYear = 2023 },
                    new Shoe { Brand = "Merrell", Name = "Moab 2", Type = "Hiking", Weight = 0.37, Price = 109.95, ReleaseYear = 2023 },
                    new Shoe { Brand = "Vibram", Name = "FiveFingers V-Trail", Type = "Trail", Weight = 0.19, Price = 119.95, ReleaseYear = 2023 }
                );
                context.SaveChanges();
            }
        }
    }
}
