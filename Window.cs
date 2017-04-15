using System.Windows.Forms;
using System.Data;

// Creates base window for application, calls and refreshes graphs

namespace ConsoleApplication
{
    public class Window : Form
    {
        private System.ComponentModel.Container components = null;
        private Label label1;
        private ComboBox buildingSelect;

        public Window()
        {
            this.Size = new System.Drawing.Size(600,700);
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            components = new System.ComponentModel.Container();

            //Add labels
            label1 = new Label();
            label1.Text = "Eventually this might be great";
            Controls.Add(label1);

            //Add dropdown menus
            buildingSelect = new ComboBox();
            string[] buildings = GlobalVars.Buildings;
            buildingSelect.Items.AddRange(buildings);
            Controls.Add(buildingSelect);
        }
    }
}