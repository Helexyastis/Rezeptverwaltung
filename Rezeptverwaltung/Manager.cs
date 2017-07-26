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
        string pathToRecipes = @"D:\VSProjects\Rezeptverwaltung\Rezeptverwaltung\Recipes.xml";
        string pathToIngredients = @"D:\VSProjects\Rezeptverwaltung\Rezeptverwaltung\Ingredients.xml";
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
            XmlNodeList ingredients = ingredientsXML.SelectNodes("ingredients/ingredient");
            foreach(XmlNode ingredient in ingredients)
            {
                Ingredients.Add(ingredient.InnerText);
            }
        }
        public void AddIngredient(string name)
        {
            List<string> doubles = Ingredients.FindAll(i => i == name);
            if (doubles.Count > 0)
            {
                throw new Exception("Zutat ist bereits angelegt.");
            }
            else
            {
                Ingredients.Add(name);
                CreateteNode(ingredientsXML, ingredientsXML.SelectSingleNode("ingredients"), "ingredient", name);

            }
        }
        private void CreateteNode(XmlDocument doc, XmlNode parent,string name,string value)
        {
            XmlNode toAdd = doc.CreateElement(name);
            toAdd.InnerText = value;
            parent.AppendChild(toAdd);
            doc.Save(doc.BaseURI.Remove(0, "file:///".Length));
            //"file:///D:/VSProjects/Rezeptverwaltung/Rezeptverwaltung/Ingredients.xml"
            
        }
    }
}
