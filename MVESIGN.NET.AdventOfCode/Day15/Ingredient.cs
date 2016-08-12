using System;

namespace MVESIGN.NET.AdventOfCode.Day15
{
    /// <summary>
    /// Class containing details of a cookie ingredient.
    /// </summary>
    public class Ingredient
    {
        /// <summary>
        /// How many calories it adds to the cookie
        /// </summary>
        public long Calories { get; set; }

        /// <summary>
        /// How well it helps the cookie absorb milk.
        /// </summary>
        public long Capacity { get; set; }

        /// <summary>
        /// How well it keeps the cookie intact when full of milk.
        /// </summary>
        public long Durability { get; set; }

        /// <summary>
        /// How tasty it makes the cookie.
        /// </summary>
        public long Flavor { get; set; }
        
        /// <summary>
        /// Score of the ingredient.
        /// </summary>
        public long Score
        {
            get
            {
                return Math.Max(0, Capacity) * Math.Max(0, Texture) * Math.Max(0, Flavor) * Math.Max(0, Durability);
            }
        }

        /// <summary>
        /// How it improves the feel of the cookie.
        /// </summary>
        public long Texture { get; set; }

        /// <summary>
        /// Append two ingredients together.
        /// </summary>
        /// <param name="first">Details of the first ingredient.</param>
        /// <param name="second">Details of the second ingredient.</param>
        /// <returns>Returns the calculates ingredient.</returns>
        public static Ingredient operator +(Ingredient first, Ingredient second)
        {
            return new Ingredient()
            {
                Capacity = first.Capacity + second.Capacity,
                Calories = first.Calories + second.Calories,
                Durability = first.Durability + second.Durability,
                Flavor = first.Flavor + second.Flavor,
                Texture = first.Texture + second.Texture
            };
        }

        /// <summary>
        /// Multiple an ingredients with a number of teaspoons.
        /// </summary>
        /// <param name="first">Details of the ingredient.</param>
        /// <param name="number">Number of teaspoons.</param>
        /// <returns>Returns the calculates ingredient.</returns>
        public static Ingredient operator *(Ingredient ingredient, int number)
        {
            return new Ingredient()
            {
                Capacity = ingredient.Capacity * number,
                Calories = ingredient.Calories * number,
                Durability = ingredient.Durability * number,
                Flavor = ingredient.Flavor * number,
                Texture = ingredient.Texture * number
            };
        }
    }
}