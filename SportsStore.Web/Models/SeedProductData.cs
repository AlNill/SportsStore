using Microsoft.EntityFrameworkCore;

namespace SportsStore.Web.Models;

public class SeedProductData
{
    public static Product[] EnsurePopulated()
    {
        return new Product[] {
                new Product
                {
                    ProductID = 1,
                    Name = "Kayak",
                    Description = "A boat for one person",
                    Category = "Watersports",
                    Price = 275
                },
                new Product
                {
                    ProductID = 2,
                    Name = "Lifejacket",
                    Description = "Protective and fashionable",
                    Category = "Watersports",
                    Price = 48.95m
                },
                new Product
                {
                    ProductID = 3,
                    Name = "Soccer Ball",
                    Description = "FIFA-approved size and weight",
                    Category = "Soccer",
                    Price = 19.50m
                },
                new Product
                {
                    ProductID = 4,
                    Name = "Corner Flags",
                    Description = "A boat for one person",
                    Category = "Watersports",
                    Price = 275
                },
                new Product
                {
                    ProductID = 5,
                    Name = "Stadium",
                    Description = "A boat for one person",
                    Category = "Watersports",
                    Price = 275
                },
                new Product
                {
                    ProductID = 6,
                    Name = "Thinking Cap",
                    Description = "A boat for one person",
                    Category = "Watersports",
                    Price = 275
                },
                new Product
                {
                    ProductID = 7,
                    Name = "Unsteady Chair",
                    Description = "A boat for one person",
                    Category = "Watersports",
                    Price = 275
                },
                new Product
                {
                    ProductID = 8,
                    Name = "Human Chess Board",
                    Description = "A fun game for the family",
                    Category = "Chess",
                    Price = 75
                },
                new Product
                {
                    ProductID = 9,
                    Name = "Bling-Bling King",
                    Description = "Gold-plated, diamond-studded King",
                    Category = "Chess",
                    Price = 1200
                }
        };
    }
}
