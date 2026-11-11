using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp_Team_14_15_16
{
    class Restaurant
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Rating { get; set; }
    }

    internal class Program
    {
        static List<Restaurant> restaurants = new List<Restaurant>
    {
        new Restaurant { Name = "McDonal's", Type = "Fast Food", Rating = 4.2 },
        new Restaurant { Name = "Tee Noi", Type = "Suki", Rating = 4.7 },
        new Restaurant { Name = "SUSHIRO", Type = "Japanese", Rating = 4.8 },
        new Restaurant { Name = "Burgerking", Type = "Fast Food", Rating = 4.1 },
        new Restaurant { Name = "Bonus Suki", Type = "Suki", Rating = 4.5 },
        new Restaurant { Name = "Ootoya", Type = "Japanese", Rating = 5.0 }
    };

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n===== Restaurant Menu =====");
                Console.WriteLine("1. Add Restaurant");
                Console.WriteLine("2. Show Good Rating");
                Console.WriteLine("3. Show Summary");
                Console.WriteLine("0. Exit");
                Console.Write("Select Menu: ");

                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        AddRestaurant();
                        break;
                    case "2":
                        ShowGoodRating();
                        break;
                    case "3":
                        ShowSummary();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid Menu");
                        break;
                }
            }
        }

        // คน A รับผิดชอบ
        static void AddRestaurant()
        {
          
            
                Console.WriteLine("\n===== Add Restaurant =====");

                // รับชื่อร้าน
                Console.Write("Enter Restaurant Name: ");
                string name = Console.ReadLine();

                // รับประเภทร้าน
                Console.Write("Enter Restaurant Type: ");
                string type = Console.ReadLine();

                // รับคะแนนร้าน
                Console.Write("Enter Restaurant Rating: ");
                double rating = Convert.ToDouble(Console.ReadLine());

                // สร้าง Object และเพิ่มเข้า List
                Restaurant newRestaurant = new Restaurant
                {
                    Name = name,
                    Type = type,
                    Rating = rating
                };

                restaurants.Add(newRestaurant);

                Console.WriteLine("\nRestaurant added successfully!");
            
        }

        // คน B รับผิดชอบ
        static void ShowGoodRating()
        {
                Console.WriteLine("\n===== Good Rating Restaurants =====");

                var goodRestaurants = restaurants
                    .Where(r => r.Rating >= 4.5)
                    .ToList();

                if (goodRestaurants.Count == 0)
                {
                    Console.WriteLine("No restaurants with good rating.");
                    return;
                }

                foreach (var restaurant in goodRestaurants)
                {
                    Console.WriteLine($"Name: {restaurant.Name}");
                    Console.WriteLine($"Type: {restaurant.Type}");
                    Console.WriteLine($"Rating: {restaurant.Rating}");
                    Console.WriteLine("----------------------");
                }
        }

        // คน C รับผิดชอบ
        static void ShowSummary()
        {
            Console.WriteLine("\n===== Restaurant Summary =====");

            if (restaurants.Count == 0)
            {
                Console.WriteLine("No restaurants available.");
                return;
            }

            Console.WriteLine("Total Restaurants: " + restaurants.Count);

            double averageRating = restaurants.Average(r => r.Rating);

            Console.WriteLine("Average Rating: " + averageRating.ToString("F2"));

            var highestRating = restaurants.OrderByDescending(r => r.Rating).First();

            Console.WriteLine("Highest Rated Restaurant: " + highestRating.Name);
            Console.WriteLine("Highest Rating: " + highestRating.Rating);

            var lowestRating = restaurants.OrderBy(r => r.Rating).First();

            Console.WriteLine("Lowest Rated Restaurant: " + lowestRating.Name);
            Console.WriteLine("Lowest Rating: " + lowestRating.Rating);

            Console.WriteLine("\n===== Restaurant by Type =====");

            var summaryByType = restaurants.GroupBy(r => r.Type);

            foreach (var group in summaryByType)
            {
                Console.WriteLine(group.Key + ": " + group.Count() + " restaurant(s)");
            }
        }
    }

}
