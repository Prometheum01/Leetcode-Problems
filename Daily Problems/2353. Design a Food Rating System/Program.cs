using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class Food : IComparable<Food>
    {

        public string name;
        public int rating;

        public Food(string name, int rating)
        {
            this.name = name;
            this.rating = rating;
        }

        public int CompareTo(Food other)
        {
            if (rating != other.rating)
            {
                return -1 * rating.CompareTo(other.rating);
            }
            else if (rating == other.rating)
            {
                return name.CompareTo(other.name);
            }
            else
            {
                return 0;
            }
        }
    }

    public class FoodRatings
    {
        private Dictionary<string, int> foodRatingMap;

        private Dictionary<string, string> foodCuisineMap;

        private Dictionary<string, PriorityQueue<Food, Food>> cuisineFoodMap;

        public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
        {
            foodRatingMap = new Dictionary<string, int>();
            foodCuisineMap = new Dictionary<string, string>();
            cuisineFoodMap = new Dictionary<string, PriorityQueue<Food, Food>>();

            for (int i = 0; i < foods.Length; i++)
            {
                Food food = new Food(foods[i], ratings[i]);

                foodRatingMap.Add(foods[i], ratings[i]);
                foodCuisineMap.Add(foods[i], cuisines[i]);

                if(cuisineFoodMap.TryGetValue(cuisines[i], out PriorityQueue<Food, Food> output))
                {
                    output.Enqueue(food, food);
                }
                else
                {
                    PriorityQueue<Food, Food> newQueue = new PriorityQueue<Food, Food>();

                    newQueue.Enqueue(food, food);

                    cuisineFoodMap.Add(cuisines[i], newQueue);
                }
            }
        }

        //This function change rating of given food.
        public void ChangeRating(string food, int newRating)
        {
            foodRatingMap[food] = newRating;

            Food newFood = new Food(food, newRating);

            //We do not remove the old one because we will check it with foodRatingMap and ignore the other data.
            cuisineFoodMap[foodCuisineMap[food]].Enqueue(newFood, newFood);
        }

        //This function finds the name of the highest-rated food in the given cuisine.
        public string HighestRated(string cuisine)
        {
            PriorityQueue<Food, Food> priorityQueue = cuisineFoodMap[cuisine];

            Food food = priorityQueue.Peek();

            //We will ignore the foods we changed in the ChangeRating function, that condition is checked here.
           
            //Recursive Way
            /*
            if(foodRatingMap[food.name] == food.rating)
            {
                return food.name;
            }else
            {
                priorityQueue.Dequeue();

                return HighestRated(cuisine);
            }
            */

            //Iterative Way
            while (foodRatingMap[food.name] != food.rating)
            {
                priorityQueue.Dequeue();

                food = priorityQueue.Peek();
            }

            return food.name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Test Section
            string[] foods = { "emgqdbo", "jmvfxjohq", "qnvseohnoe", "yhptazyko", "ocqmvmwjq" };
            
            string[] cuisines = { "snaxol", "snaxol", "snaxol", "fajbervsj", "fajbervsj" };
                        
            int[] ratings = { 2, 6, 18, 6, 5 };

            FoodRatings foodRatings = new FoodRatings(foods, cuisines, ratings);

            foodRatings.ChangeRating("qnvseohnoe", 11);
            string result1 = foodRatings.HighestRated("fajbervsj");
            foodRatings.ChangeRating("emgqdbo", 3);
            foodRatings.ChangeRating("jmvfxjohq", 9);
            foodRatings.ChangeRating("emgqdbo", 14);
            string result2 = foodRatings.HighestRated("fajbervsj");
            string result3 = foodRatings.HighestRated("snaxol");

            Console.ReadKey();
        }
    }
}
