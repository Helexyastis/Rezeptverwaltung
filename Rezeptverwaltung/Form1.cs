using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rezeptverwaltung
{
    
    public partial class Form1 : Form
    {
        public const string PATH = @"C:\ProgramData\Chaos Solutions\Rezeptverwaltung";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateRecipe createRecipe = new CreateRecipe();

            createRecipe.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.IO.Directory.CreateDirectory(Path);
        }
    }
}
