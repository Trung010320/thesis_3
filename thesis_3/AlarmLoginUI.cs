using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thesis_3
{
    public partial class AlarmLoginUI : Form
    {
        public Device device = null;
        public ushort stgLevel;
        public ushort stg_old_level;
        public ushort cheLevel;
        public ushort che_old_level;
        public ushort fw1Level;
        public ushort fw1_old_level;
        public ushort fw2Level;
        public ushort fw2_old_level;
        public ushort nwLevel;
        public ushort nw_old_level;
        DataSet data1;
        DataTable dt1;
        int k;
        private string realtime;

        public AlarmLoginUI(Device _device)
        {
            InitializeComponent();
            device = _device;
            k = 1;
            data1 = new DataSet();
            dt1 = new DataTable();
            dt1.Columns.Add("No", typeof(Int16));
            dt1.Columns.Add("Alarm Text");
            dt1.Columns.Add("Date");
            

        }

        private void UpdateValue_Tick(object sender, EventArgs e)
        {
            stgLevel = device.Storage_water;
            cheLevel = device.Chemical_water;
            fw1Level = device.Fresh_water_1;
            fw2Level = device.Fresh_water_2;
            nwLevel = device.Normal_water;
            if(stgLevel != stg_old_level)
            {
                if(stgLevel <=25 && stgLevel > 20)
                {
                    realtime = TimeNow.Value.ToString();
                    dt1.Rows.Add(k, "Storage Level is low", realtime.ToString());
                    k++;
                }
                else if ( stgLevel <= 10)
                {
                    dt1.Rows.Add(k, "Storage Level is very low at", realtime.ToString());
                    k++;
                }
                else if(stgLevel >= 580)
                {
                    dt1.Rows.Add(k, "Storage Level is high", realtime.ToString());
                    k++;
                }
                
                
            }
            
            stg_old_level = stgLevel;
            if(cheLevel != che_old_level)
            {
                if(cheLevel<= 20 && cheLevel >= 15)
                {
                    realtime = TimeNow.Value.ToString();
                    dt1.Rows.Add(k, "Chemical Level is low", realtime.ToString());
                    k++;

                }
                else if( cheLevel <= 10)
                {
                    realtime = TimeNow.Value.ToString();
                    dt1.Rows.Add(k, "Chemical Level is very low", realtime.ToString());
                    k++;
                }
                else if ( cheLevel >= 145)
                {
                    realtime = TimeNow.Value.ToString();
                    dt1.Rows.Add(k, "Chemical Level is high", realtime.ToString());
                    k++;
                }
                

            }
            
            che_old_level = cheLevel;
            if (fw1Level != fw1_old_level)
            {
                if (fw1Level <= 30 && fw1Level >= 25)
                {
                    realtime = TimeNow.Value.ToString();
                    dt1.Rows.Add(k, "Fresh Water 1 Level is low", realtime.ToString());
                    k++;

                }
                else if (fw1Level <= 10)
                {
                    realtime = TimeNow.Value.ToString();
                    dt1.Rows.Add(k, "Fresh Water 1 Level is very low", realtime.ToString());
                    k++;
                }
                else if (fw1Level >= 295)
                {
                    realtime = TimeNow.Value.ToString();
                    dt1.Rows.Add(k, "Fresh Water 1 Level is high", realtime.ToString());
                    k++;
                }
                

            }
            
            fw1_old_level = fw1Level;
            if (fw2Level != fw2_old_level)
            {
                if (fw2Level <= 30 && fw2Level >= 25)
                {
                    realtime = TimeNow.Value.ToString();
                    dt1.Rows.Add(k, "Fresh Water 2 Level is low", realtime.ToString());
                    k++;

                }
                else if (fw2Level <= 10)
                {
                    realtime = TimeNow.Value.ToString();
                    dt1.Rows.Add(k, "Fresh Water 2 Level is very low", realtime.ToString());
                    k++;
                }
                else if (fw2Level >= 295)
                {
                    realtime = TimeNow.Value.ToString();
                    dt1.Rows.Add(k, "Fresh Water 2 Level is high", realtime.ToString());
                    k++;
                }
                

            }
            
            fw2_old_level = fw2Level;

            Alarm_Login_view.DataSource = dt1;
            Console.WriteLine("K="+k.ToString());
        }
        

    }
}
