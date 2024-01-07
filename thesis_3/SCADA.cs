using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using S7.Net;


namespace thesis_3
{
    public class SCADA
    {
        public static SCADA root = new SCADA();
        public List<Device> devices = new List<Device>();
        public List<Motor> motors = new List<Motor>();
        public List<short> Tanks = new List<short>();
        public List<Valve> valves = new List<Valve>();
        public ushort stg;
        public ushort che;
        public ushort fw1;
        public ushort fw2;

        public ushort nw;
        public Plc s71500PLC;


        System.Timers.Timer updateTimer = null;
        public SCADA()
        {
            updateTimer = new System.Timers.Timer(250);
            updateTimer.Elapsed += UpdateTimer_Elapsed;
            updateTimer.Start();
            
            

        }
        public static void Connection (string ip)
        {
            

            Device PLC_1 = new Device(ip ,"PLC_1");
            root.AddDevice(PLC_1);
            // declear add motor to list
            Motor motor = new Motor("Mtr_pump_1", 250,root,"PLC_1");
            root.Addmotor(motor);
            motor = new Motor("Mtr_pump_2", 250, root, "PLC_1");
            root.Addmotor(motor);
            motor = new Motor("Mtr_pump_3", 250, root, "PLC_1");
            root.Addmotor(motor);
            motor = new Motor("Mtr_pump_4", 250, root, "PLC_1");
            root.Addmotor(motor);
            motor = new Motor("Mtr_pump_5", 250, root, "PLC_1");
            root.Addmotor(motor);
            motor = new Motor("Mtr_pump_6", 250, root, "PLC_1");
            root.Addmotor(motor);
            motor = new Motor("Mtr_pump_7", 250, root, "PLC_1");
            root.Addmotor(motor);

            // valve
            Valve valve = new Valve("Valve_1", 250, root, "PLC_1");
            root.Addvalve(valve);
            valve = new Valve("Valve_2", 250, root, "PLC_1");
            root.Addvalve(valve);
            valve = new Valve("Valve_3", 250, root, "PLC_1");
            root.Addvalve(valve);
            valve = new Valve("Valve_4", 250, root, "PLC_1");
            root.Addvalve(valve);
            valve = new Valve("Valve_5", 250, root, "PLC_1");
            root.Addvalve(valve);
            valve = new Valve("Valve_6", 250, root, "PLC_1");
            root.Addvalve(valve);
            valve = new Valve("Valve_7", 250, root, "PLC_1");
            root.Addvalve(valve);
            valve = new Valve("Valve_8", 250, root, "PLC_1");
            root.Addvalve(valve);
            valve = new Valve("Valve_9", 250, root, "PLC_1");
            root.Addvalve(valve);
            valve = new Valve("Valve_10", 250, root, "PLC_1");
            root.Addvalve(valve);
            valve = new Valve("Valve_11", 250, root, "PLC_1");
            root.Addvalve(valve);
            valve = new Valve("Valve_12", 250, root, "PLC_1");
            root.Addvalve(valve);
            valve = new Valve("Valve_13", 250, root, "PLC_1");
            root.Addvalve(valve);
            valve = new Valve("Valve_14", 250, root, "PLC_1");
            root.Addvalve(valve);






        }
        public void Connect()
        {


           
            Console.WriteLine("PLC status:"+s71500PLC.IsConnected.ToString());
            Console.WriteLine("PLC IP:" + s71500PLC.IP);



        }
        public void Disconnect()
        {

           s71500PLC.Close();

        }
        private void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {

        }
        public void AddDevice(Device dev)
        {
            devices.Add(dev);
        }
        public Device FindDevice(string name)
        {
            Device device = null;
            foreach (Device dev in devices)
            {
                if (dev.name == name)
                {
                    device = dev;
                }
            }
            return device;
        }
        public void Addmotor(Motor motor)
        {
            motors.Add(motor);
        }
        public Motor FindMotor(string name)
        {
            Motor motor = null;
            foreach (Motor mot in motors)
            {
                
                if (mot.name == name)
                {
                    motor = mot;
                }
            }
            return motor;
        }
        public void Addvalve (Valve valve)
        {
            valves.Add(valve);
        }
        public Valve FindValve( string name)
        {
            Valve valve = null;
            foreach( Valve val in valves)
            {
                if(val.vName == name)
                {
                    valve = val;
                }
            }
            return valve;
        }
        public enum ErrorCode
        {
            NoError = 0,
            WrongCPU_Type = 1,
            ConnectionError = 2,
            IPAddressNotAvailable,
            WrongVarFormat = 10,
            WrongNumberReceivedBytes = 11,
            SendData = 20,
            ReadData = 30,
            WriteData = 50
        }
    }
}
