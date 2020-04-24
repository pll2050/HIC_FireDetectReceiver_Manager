using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;

namespace HIC_FireDetectReceiver_Manager.Helper
{
    public class Serial
    {
        public bool Open(string port, int boud)
        {
            Global_Variable.oSP.PortName = port;
            Global_Variable.oSP.BaudRate = boud;

            if (Global_Variable.oSP.IsOpen == false)
            {
                Global_Variable.oSP.Open();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Close()
        {
            Global_Variable.oSP.Close();

            return true;
        }

        public void Write(string item)
        {
            //Global_Variable.oSP.WriteLine(item);
            Global_Variable.oSP.Write(item);
        }

        public string Read()
        {
            string tmp_receive = string.Empty;
            //string tmp_receive = Global_Variable.oSP.ReadExisting();
            //while (!(Global_Variable.oSP.ReadLine().Contains(end_str)))
            //{
            //    tmp_receive += Global_Variable.oSP.ReadLine() + "/";
            //}
            tmp_receive = Global_Variable.oSP.ReadLine();
            //tmp_receive = Global_Variable.oSP.ReadExisting();
            return tmp_receive;

        }

        public void Dispose()
        {
            Global_Variable.oSP.Dispose();
        }

        public void Buffer_Clear()
        {
            Global_Variable.oSP.DiscardInBuffer();
            Global_Variable.oSP.DiscardOutBuffer();
        }
    }
}
