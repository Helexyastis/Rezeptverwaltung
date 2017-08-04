using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Rezeptverwaltung
{
    class IngredientAmountControl: Control, IContainerControl
    {
         Label l_Name;
         TextBox tb_amount;
        ComboBox cb_units;

        public IngredientAmountControl()
            :base()
        {

        }
        public IngredientAmountControl(Control control)
            :base(control,"")
        {

        }

        public Control ActiveControl { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool ActivateControl(Control active)
        {
            throw new NotImplementedException();
        }
    }
}
