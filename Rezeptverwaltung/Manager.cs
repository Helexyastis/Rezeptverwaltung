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

        XmlDocument document;
        public Manager()
        {
            if (!System.IO.File.Exists(pathToRecipes))
            {
                System.IO.StreamWriter writer = System.IO.File.CreateText(pathToRecipes);
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                writer.WriteLine("<recipes>");
                writer.WriteLine("</recipes>");
                writer.Close();
            }
            document = new XmlDocument();
            document.Load(pathToRecipes);
            
        }
    }
}
