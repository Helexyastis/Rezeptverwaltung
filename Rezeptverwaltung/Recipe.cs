using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rezeptverwaltung
{
    class Recipe
    {
        string name;
        Dictionary<int,string> ingredients;
        Dictionary<int, float> amounts;
        Dictionary<int, string> units;

        public Recipe(string name)
        {
            this.name = name;
            ingredients = new Dictionary<int, string>();
            amounts = new Dictionary<int, float>();
            units = new Dictionary<int, string>();
        }

        public void AddIngredient(string name)
        {
            ingredients.Add(ingredients.Count, name);
        }
        public void AddAmount(float value)
        {
            amounts.Add(amounts.Count, value);
        }
        public void AddUnit(string name)
        {
            units.Add(units.Count, name);
        }

    }
}
