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
        string pathToRecipes = Form1.PATH+"\\Recipes.xml";
        string pathToIngredients = Form1.PATH+"\\Ingredients.xml";
        string pathToUnits = Form1.PATH + "\\Units.xml";
        string pathToCategories = Form1.PATH + "\\Categories.xml";
        XmlDocument recipesXML;
        XmlDocument ingredientsXML;
        XmlDocument unitsXML;
        XmlDocument categoriesXML;
        public List<string> Ingredients { get; private set; }
        public List<string> Categories { get; private set; }
        public List<string> Units { get; set; }
        public Manager()
        {
            
            recipesXML = LoadXML(pathToRecipes,"recipes");
            ingredientsXML = LoadXML(pathToIngredients,"ingredients");
            unitsXML = LoadXML(pathToUnits, "units");
            categoriesXML = LoadXML(pathToCategories, "categories");
            Ingredients = new List<string>();
            LoadAllItems(ingredientsXML, Ingredients, "ingredients", "ingredient");
            LoadAllItems(categoriesXML, Categories, "categories", "category");
            LoadAllItems(unitsXML, Units, "units", "unit");
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
        private void LoadAllItems(XmlDocument doc,List<string> list,string rootNode,string targetNode)
        {
            XmlNodeList results = doc.SelectNodes(rootNode+"/"+targetNode);
            foreach(XmlNode result in results)
            {
                list.Add(result.InnerText);
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
