using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlithuvien
{
    public class GeneralMethod
    {
        public static void ResetText(List<Control> controls)
        {
            foreach (Control control in controls)
            {
                if (control is ListBox listBox) listBox.SelectedIndex = -1;
                else control.Text = string.Empty;
            }
        }
    }
}
