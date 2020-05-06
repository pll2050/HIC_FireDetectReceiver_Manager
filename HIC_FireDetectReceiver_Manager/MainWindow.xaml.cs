using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HIC_FireDetectReceiver_Manager
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(SerialPort_init);
            this.DataContext = Global_Variable.oP2000_Data;
        }

        private void SerialPort_init(object sender, EventArgs e)
        {
            Port_Search();
            Global_Variable.oSP = new SerialPort();
            Global_Variable.oSP.DataReceived += new SerialDataReceivedEventHandler(Serial_Receive);

        }

        private void Port_Search()
        {
            string[] sPort_List = System.IO.Ports.SerialPort.GetPortNames();

            foreach (string item in sPort_List)
            {
                cb_SerialPort.Items.Add(item);
            }
            cb_SerialPort.SelectedIndex = 0;

        }

        private void btn_Serial_Open_Click(object sender, RoutedEventArgs e)
        {
            Helper.Serial serial = new Helper.Serial();

            if (serial.Open(cb_SerialPort.Text, Convert.ToInt32(cb_BoudRate.Text)))
            {
                tb_status.Text = cb_SerialPort.Text + " Connected";
                btn_status_change();
            }
        }

        private void btn_Serial_Close_Click(object sender, RoutedEventArgs e)
        {
            Helper.Serial serial = new Helper.Serial();
            serial.Buffer_Clear();
            if (serial.Close())
            {
                tb_status.Text = "Disconnected";
                btn_status_change();
                serial.Dispose();
            }
        }

        private void btn_status_change()
        {
            btn_Serial_Open.IsEnabled = !btn_Serial_Open.IsEnabled;
            btn_Serial_Close.IsEnabled = !btn_Serial_Close.IsEnabled;
            btn_Serial_Read.IsEnabled = !btn_Serial_Read.IsEnabled;
            btn_Serial_Write.IsEnabled = !btn_Serial_Write.IsEnabled;
            btn_export.IsEnabled = !btn_export.IsEnabled;
            btn_import.IsEnabled = !btn_import.IsEnabled;
            cb_BoudRate.IsEnabled = !cb_BoudRate.IsEnabled;
            cb_SerialPort.IsEnabled = !cb_SerialPort.IsEnabled;
        }

        private void btn_Serial_Write_Click(object sender, RoutedEventArgs e)
        {
            Helper.Serial serial = new Helper.Serial();
            serial.Write("$man_write");
        }

        private void btn_Serial_Read_Click(object sender, RoutedEventArgs e)
        {
            Helper.Serial serial = new Helper.Serial();
            serial.Write("$man_read");
        }
        private void btn_export_Click(object sender, RoutedEventArgs e)
        {
            Excel_helper eh = new Excel_helper();
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";


            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                eh.FileCreate(saveFile.FileName);
                System.Windows.MessageBox.Show("완료되었습니다.");
            }
        }

        private void btn_import_Click(object sender, RoutedEventArgs e)
        {
            Excel_helper eh = new Excel_helper();
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";


            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                eh.Excel_Import(openFile.FileName);
                //Pages.Tab_Device td = new Pages.Tab_Device();
                Mapping_Data();
            }
        }

        private string TransferData()
        {
            string tmp_str = "";
            this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
                new Action(delegate
                {
                    string split_str = ",";
                    tmp_str += txb_DEVICEID.Text + split_str;
                    tmp_str += txb_HMI_PHNUM.Text + split_str;
                    tmp_str += txb_MY_CDMANUM.Text + split_str;
                    tmp_str += txb_SM_cnt.Text + split_str;
                    tmp_str += txb_SM_num1.Text + split_str;
                    tmp_str += txb_SM_num2.Text + split_str;
                    tmp_str += txb_SM_num3.Text + split_str;
                    tmp_str += txb_SM_num4.Text + split_str;
                    tmp_str += txb_SM_num5.Text + split_str;

                    tmp_str += txb_SEN_BOARDS.Text + split_str;
                    tmp_str += txb_REL_BOARDS.Text + split_str;
                    tmp_str += txb_DIS_BOARDS.Text + split_str;
                    tmp_str += txb_onoff_BOARDS.Text + split_str;
                    tmp_str += txb_auto_BOARDS.Text;
                }));


            return tmp_str;
        }
        string get_sRecvData = String.Empty;

        string serial_buffer = String.Empty;

        public void Serial_Receive(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                Helper.Serial serial = new Helper.Serial();

                get_sRecvData = serial.Read();

                if ((get_sRecvData != string.Empty)) // && (g_sRecvData.Contains('\n')))
                {
                    serial_buffer += get_sRecvData;

                    if (get_sRecvData.Contains("$e"))
                    {
                        SetText(serial_buffer);
                        serial_buffer = String.Empty;
                        //serial.Buffer_Clear();
                    }
                    else if (get_sRecvData.Contains("$mw"))
                    {
                        serial.Write(TransferData());
                        serial_buffer = String.Empty;
                    }
                    else if (get_sRecvData.Contains("$mrcplt"))
                    {
                        System.Windows.MessageBox.Show("읽기 완료");
                        serial_buffer = String.Empty;
                        serial.Buffer_Clear();
                    }
                    else if (get_sRecvData.Contains("$complate"))
                    {
                        System.Windows.MessageBox.Show("쓰기 완료");
                        serial_buffer = String.Empty;
                        serial.Buffer_Clear();
                    }
                    else if (get_sRecvData.Contains("$ce"))
                    {
                        serial_buffer = String.Empty;
                        serial.Buffer_Clear();
                    }
                }
            }
            catch (TimeoutException)
            {
                get_sRecvData = string.Empty;
            }
        }

        delegate void SetTextCallBack(String text);

        private void SetText(string text)
        {
            try
            {
                string[] split_text = text.Split(',');
                Global_Variable.oP2000_Data.DEVICE_ID = split_text[0];
                Global_Variable.oP2000_Data.HMI_PHNUM = split_text[1];
                Global_Variable.oP2000_Data.MY_CDMANUM = split_text[2];
                Global_Variable.oP2000_Data.SMART_PHNUMS = split_text[3];
                Global_Variable.oP2000_Data.SMART_PHNUM0 = split_text[4];
                Global_Variable.oP2000_Data.SMART_PHNUM1 = split_text[5];
                Global_Variable.oP2000_Data.SMART_PHNUM2 = split_text[6];
                Global_Variable.oP2000_Data.SMART_PHNUM3 = split_text[7];
                Global_Variable.oP2000_Data.SMART_PHNUM4 = split_text[8];
                Global_Variable.oP2000_Data.SENSOR_BOARDS = split_text[9];
                Global_Variable.oP2000_Data.RELAY_BOARDS = split_text[10];
                Global_Variable.oP2000_Data.DISPLAY_BOARDS = split_text[11];
                Global_Variable.oP2000_Data.ONOFF_BOARDS = split_text[12];
                Global_Variable.oP2000_Data.AUTO_BOARDS = split_text[13];

                Mapping_Data();
            }
            catch (Exception ex)
            {

            }

        }
        public void Mapping_Data()
        {
            this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
                new Action(delegate
                {
                    txb_DEVICEID.Text = Global_Variable.oP2000_Data.DEVICE_ID;
                    txb_HMI_PHNUM.Text = Global_Variable.oP2000_Data.HMI_PHNUM;
                    txb_MY_CDMANUM.Text = Global_Variable.oP2000_Data.MY_CDMANUM;
                    txb_SM_cnt.Text = Global_Variable.oP2000_Data.SMART_PHNUMS;
                    txb_SM_num1.Text = Global_Variable.oP2000_Data.SMART_PHNUM0;
                    txb_SM_num2.Text = Global_Variable.oP2000_Data.SMART_PHNUM1;
                    txb_SM_num3.Text = Global_Variable.oP2000_Data.SMART_PHNUM2;
                    txb_SM_num4.Text = Global_Variable.oP2000_Data.SMART_PHNUM3;
                    txb_SM_num5.Text = Global_Variable.oP2000_Data.SMART_PHNUM4;

                    txb_SEN_BOARDS.Text = Global_Variable.oP2000_Data.SENSOR_BOARDS;
                    txb_REL_BOARDS.Text = Global_Variable.oP2000_Data.RELAY_BOARDS;
                    txb_DIS_BOARDS.Text = Global_Variable.oP2000_Data.DISPLAY_BOARDS;
                    txb_onoff_BOARDS.Text = Global_Variable.oP2000_Data.ONOFF_BOARDS;
                    txb_auto_BOARDS.Text = Global_Variable.oP2000_Data.AUTO_BOARDS;
                }));
        }
    }
}
