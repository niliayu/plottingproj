using System.Windows.Forms;
using System.Drawing;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
// Creates base window for application, calls and refreshes graphs

namespace ConsoleApplication
{
    public class Window : Form
    {
        // Containers and grids
 //       private System.ComponentModel.Container components = null;

        // Components
        private Label label1;
        private ComboBox buildingSelect;
        private PlotView plot;

        public Window()
        {
            InitializeForm();
            InitializeComponents();
        }

        private void InitializeForm()
        {
            Size = new System.Drawing.Size(600,700);
            Name = "Plotter";

        }

        private void InitializeComponents()
        {

            //Add dropdown menus
            buildingSelect = new ComboBox();
            string[] buildings = GlobalVars.Buildings;
            buildingSelect.Items.AddRange(buildings);
            buildingSelect.Location = new Point(300,500);
            Controls.Add(buildingSelect);

            //Add plots
            InitializePlot();
            var mainPlot = new PlotModel {Title = "Main"};
            ScatterSeries temp_ = new ScatterSeries {MarkerType = MarkerType.Circle};

            for (int i = 0; i < 100; i++)
            {
                temp_.Points.Add(new ScatterPoint(i, i+1));
            }

            mainPlot.Series.Add(temp_);
            plot.Model = mainPlot;
            Controls.Add(plot);
        }

        // for now initializes one main plot; eventually have option for many
        private void InitializePlot()
        {
            plot = new PlotView();
            SuspendLayout();

            plot.Dock = DockStyle.Fill;
            plot.Location = new Point(100, 100);
            plot.Name = "MainPlot";
            plot.Size = new Size(400, 400);
            plot.TabIndex = 0;
            plot.Text = "MainPlot";

        }


    }
}