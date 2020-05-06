using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modbus.Device;

namespace HIC_FireDetectReceiver_Manager.Src
{
    class Modbus_RTU
    {
        public void Initialize()
        {

            ModbusSerialMaster MSM;
            MSM = ModbusSerialMaster.CreateRtu(Global_Variable.oSP);
            MSM.Transport.ReadTimeout = 500;
            MSM.Transport.WriteTimeout = 500;
            MSM.Transport.Retries = 0;

        }
    }
}
