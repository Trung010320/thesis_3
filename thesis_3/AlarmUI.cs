using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace thesis_3
{
    public partial class AlarmUI : Form
    {
        private Thread cputhread;
        private short[] storage_Lv = new short[30];
        private Device device = null;
        private int x = 0;
        public AlarmUI(Device _device)
        {
            InitializeComponent();
            device = _device;
            InitializeChart();
        }
        private void InitializeChart()
        {
            // Add a series to the chart with line chart type
            Level_trend.Series.Add("WaterLevel");
            Level_trend.Series["WaterLevel"].ChartType = SeriesChartType.Line;
            Level_trend.Series["WaterLevel"].BorderWidth = 2;
            Level_trend.Series["WaterLevel"].Color = Color.Black;

            // Chemical
            Level_trend.Series.Add("ChemicalLevel");
            Level_trend.Series["ChemicalLevel"].ChartType = SeriesChartType.Line;
            Level_trend.Series["ChemicalLevel"].BorderWidth = 2;
            Level_trend.Series["ChemicalLevel"].Color = Color.Red;

            // Fresh water 1
            Level_trend.Series.Add("FreshWater1");
            Level_trend.Series["FreshWater1"].ChartType = SeriesChartType.Line;
            Level_trend.Series["FreshWater1"].BorderWidth = 2;
            Level_trend.Series["FreshWater1"].Color = Color.Blue;

            // Fresh water 2
            Level_trend.Series.Add("FreshWater2");
            Level_trend.Series["FreshWater2"].ChartType = SeriesChartType.Line;
            Level_trend.Series["FreshWater2"].BorderWidth = 2;
            Level_trend.Series["FreshWater2"].Color = Color.Green;


            // Normal water
            Level_trend.Series.Add("Normal Water");
            Level_trend.Series["Normal Water"].ChartType = SeriesChartType.Line;
            Level_trend.Series["Normal Water"].BorderWidth = 2;
            Level_trend.Series["Normal Water"].Color = Color.Pink;




        }

        private void UpdateValue_Tick(object sender, EventArgs e)
        {

            int yWaterLevel = device.Storage_water;
            int yChemicalLevel = device.Chemical_water;
            int yFreshWater1 = device.Fresh_water_1;
            int yFreshWater2 = device.Fresh_water_2;
            int yHotWater = device.Hot_water;
            int yNormalWater = device.Normal_water;

            Level_trend.Series["WaterLevel"].Points.AddXY(x, yWaterLevel);
            if (Level_trend.Series["WaterLevel"].Points.Count > 600)
                Level_trend.Series["WaterLevel"].Points.RemoveAt(0);

            Level_trend.Series["ChemicalLevel"].Points.AddXY(x, yChemicalLevel);
            if (Level_trend.Series["ChemicalLevel"].Points.Count > 150)
                Level_trend.Series["ChemicalLevel"].Points.RemoveAt(0);

            Level_trend.Series["FreshWater1"].Points.AddXY(x, yFreshWater1);
            if (Level_trend.Series["FreshWater1"].Points.Count > 300)
                Level_trend.Series["FreshWater1"].Points.RemoveAt(0);

            Level_trend.Series["FreshWater2"].Points.AddXY(x, yFreshWater2);
            if (Level_trend.Series["FreshWater2"].Points.Count > 300)
                Level_trend.Series["FreshWater2"].Points.RemoveAt(0);


            Level_trend.Series["Normal Water"].Points.AddXY(x, yNormalWater);
            if (Level_trend.Series["Normal Water"].Points.Count > 1000)
                Level_trend.Series["Normal Water"].Points.RemoveAt(0);


            Level_trend.ChartAreas[0].AxisX.Minimum = Level_trend.Series["WaterLevel"].Points[0].XValue;
            Level_trend.ChartAreas[0].AxisX.Minimum = Level_trend.Series["ChemicalLevel"].Points[0].XValue;
            Level_trend.ChartAreas[0].AxisX.Minimum = Level_trend.Series["FreshWater1"].Points[0].XValue;
            Level_trend.ChartAreas[0].AxisX.Minimum = Level_trend.Series["FreshWater2"].Points[0].XValue;
            Level_trend.ChartAreas[0].AxisX.Minimum = Level_trend.Series["Normal Water"].Points[0].XValue;
            Level_trend.ChartAreas[0].AxisX.Minimum = x;



            x += UpdateValue.Interval / 1000;


        }

        private void AlarmUI_Load(object sender, EventArgs e)
        {
            UpdateValue.Enabled = true;
        }
    }
}
