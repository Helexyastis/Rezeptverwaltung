using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Rezeptverwaltung
{
    class Manager
    {
        string pathToRecipes = @"D:\VSProjects\Rezeptverwaltung\Recipes.xml";
        string pathToIngredients = @"D:\VSProject\Rezeptverwaltung\Ingredients.xml";
        XmlDocument recipesXML;
        XmlDocument ingredientsXML;

        public List<string> Ingredients { get; private set; }
        public Manager()
        {

            recipesXML = LoadXML(pathToRecipes,"recipes");
            ingredientsXML = LoadXML(pathToIngredients,"ingredients");
            Ingredients = new List<string>();
            LoadIngredients();
        }

        public XmlDocument LoadXML(string path, string startNode)
        {
            XmlDocument doc = new XmlDocument();
            if (!System.IO.File.Exists(path))
            {
                System.IO.StreamWriter writer = System.IO.File.CreateText(path);
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                writer.WriteLine("<" + startNode + ">");
                writer.WriteLine("</" + startNode + ">");
                writer.Close();
            }
            doc = new XmlDocument();
            doc.Load(path);
            return doc;
        }
        private void LoadIngredients()
        {
            XmlNodeList ingredients = ingredientsXML.SelectNodes("ingredients");
            foreach(XmlNode ingredient in ingredients)
            {
                Ingredients.Add(ingredient.InnerText);
            }
        }

    }
}
