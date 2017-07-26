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
    public partial class CreateRecipe : Form
    {
        public CreateRecipe()
        {
            InitializeComponent();
        }
        Manager manager;
        private void CreateRecipe_Load(object sender, EventArgs e)
        {
            manager = new Manager();
            
        }

        private void tb_searchIngredients_TextChanged(object sender, EventArgs e)
        {
            string search = tb_searchIngredients.Text.ToLower();

            if (lb_ergs.Items.Count > 0)
                lb_ergs.Items.Clear();

                if (!string.IsNullOrEmpty(search))
            {
                List<string> ergs = new List<string>();
                ergs = manager.Ingredients.FindAll(i => i.StartsWith(search));
                if(ergs.Count <= 2)
                {
                    ergs.AddRange(manager.Ingredients.FindAll(i => i.ToLower().Contains(search)));
                    
                }
                lb_ergs.Items.AddRange(ergs.ToArray());
            }
            
        }

        private void b_createIngredient_Click(object sender, EventArgs e)
        {
            string ingredient = tb_createIngredient.Text;

            if (!string.IsNullOrEmpty(ingredient))
            {
                try
                {
                    manager.AddIngredient(ingredient);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                tb_createIngredient.Text = "";
                MessageBox.Show("Zutat wurde gespeichert");
            }
        }
    }
}
