using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rezeptverwaltung
{
    class Recipe
    {
        public string Name { get; private set; }
        public Dictionary<int, string> Ingredients { get; private set; }
        public Dictionary<int, float> Amounts { get; private set; }
        public Dictionary<int, string> Units { get; private set; }
        public DateTime LastTimeCooked { get; private set; }
        public int CookedAmount { get; private set; }
        public string Description { get; private set; }
        public string Text { get; private set; }
        public TimeSpan DaysSinceCooked { get { return DateTime.Today.Subtract(LastTimeCooked); } }
        public int Rating { get; private set; }
        public List<string> Categories { get; set; }
        private int ratings = 0;
        private int ratingsCount = 0;

        public Recipe(string name)
        {
            Name = name;
            Categories = new List<string>();
            Ingredients = new Dictionary<int, string>();
            Amounts = new Dictionary<int, float>();
            Units = new Dictionary<int, string>();
            CookedAmount = 0;
        }

        public Recipe(string name, int cookedAmount, string description, string text, DateTime lastTimeCooked)
        {
            Name = name;
            CookedAmount = cookedAmount;
            Description = description;
            Text = text;
            LastTimeCooked = lastTimeCooked;
            Ingredients = new Dictionary<int, string>();
            Amounts = new Dictionary<int, float>();
            Units = new Dictionary<int, string>();
        }
        public void InitializeDictionaries(Dictionary<int, string> ingredients, Dictionary<int, float> amounts, Dictionary<int, string> units)
        {
            Ingredients = ingredients;
            Amounts = amounts;
            Units = units;
        }

        public void AddIngredient(string name)
        {
            Ingredients.Add(Ingredients.Count, name);
        }
        public void AddAmount(float value)
        {
            Amounts.Add(Amounts.Count, value);
        }
        public void AddUnit(string name)
        {
            Units.Add(Units.Count, name);
        }
        public void SetLastTimeCooked(DateTime time)
        {
            LastTimeCooked = time;
        }

    }
}
