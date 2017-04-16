using System;
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
        private ComboBox buildingSelect;
        private PlotView plot;
        private TextBox timeD;
        private Button enter;

        public Window()
        {
            InitializeForm();
            InitializeComponents();
        }

        private void InitializeForm()
        {
            Size = new Size(600,700);
            Name = "Plotter";
        }

        private void InitializeComponents()
        {
            //Add textboxes
            timeD = new TextBox();
            timeD.Text = "Select Time Delta (seconds)";
            timeD.Location = new Point(250, 500);
            Controls.Add(timeD);

            //Add dropdown menus
            buildingSelect = new ComboBox();
            string[] buildings = GlobalVars.Buildings;
            buildingSelect.Items.AddRange(buildings);
            buildingSelect.Location = new Point(120,500);
            Controls.Add(buildingSelect);

            enter = new Button();
            enter.Text = "Plot!";
            enter.Location = new Point(370, 500);
            enter.Click += enterClick;
            Controls.Add(enter);

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

        private void enterClick(object sender, EventArgs e)
        {
           // Control btnctl = enter.Parent;
            //Form btnfrm = enter.FindForm();

            string buildingSel = null, timeVal = null;

            try
            {
                timeVal = timeD.Text;
            }
            catch
            {
                MessageBox.Show("Please enter an integer into the text box.");
            }

            try
            {
                buildingSel = buildingSelect.SelectedItem.ToString();
                buildingSelect.Text = buildingSel;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please select a building from the dropdown menu.\n");
                MessageBox.Show(ex.StackTrace);
            }

            if(timeVal != null && buildingSel != null)
                RunPython.Run(timeVal, buildingSel);
                livePlot();
        }

        private void livePlot()
        {
            CsvParser csv = new CsvParser();
            csv.parse();
        }
    }
}