using System.ComponentModel;

namespace HIC_FireDetectReceiver_Manager
{
    //public class P2000_Data_Table : ObservableCollection<P2000_Data> { }
    public class P2000_Data : INotifyPropertyChanged, IEditableObject
    {
        private string _DEVICE_ID;
        private string _HMI_PHNUM;
        private string _MY_CDMANUM;
        private string _SMART_PHNUMS;
        private string _SMART_PHNUM0;
        private string _SMART_PHNUM1;
        private string _SMART_PHNUM2;
        private string _SMART_PHNUM3;
        private string _SMART_PHNUM4;
        private string _SENSOR_BOARDS;
        private string _RELAY_BOARDS;
        private string _DISPLAY_BOARDS;
        private string _ONOFF_BOARDS;
        private string _AUTO_BOARDS;

        public string DEVICE_ID
        {
            get { return _DEVICE_ID; }
            set { _DEVICE_ID = value; NotifyPropertyChanged("_DEVICE_ID"); }
        }
        public string HMI_PHNUM
        {
            get { return _HMI_PHNUM; }
            set { _HMI_PHNUM = value; NotifyPropertyChanged("_HMI_PHNUM"); }
        }
        public string MY_CDMANUM
        {
            get { return _MY_CDMANUM; }
            set { _MY_CDMANUM = value; NotifyPropertyChanged("_MY_CDMANUM"); }
        }
        public string SMART_PHNUMS
        {
            get { return _SMART_PHNUMS; }
            set { _SMART_PHNUMS = value; NotifyPropertyChanged("_SMART_PHNUMS"); }
        }
        public string SMART_PHNUM0
        {
            get { return _SMART_PHNUM0; }
            set { _SMART_PHNUM0 = value; NotifyPropertyChanged("_SMART_PHNUM0"); }
        }
        public string SMART_PHNUM1
        {
            get { return _SMART_PHNUM1; }
            set { _SMART_PHNUM1 = value; NotifyPropertyChanged("_SMART_PHNUM1"); }
        }
        public string SMART_PHNUM2
        {
            get { return _SMART_PHNUM2; }
            set { _SMART_PHNUM2 = value; NotifyPropertyChanged("_SMART_PHNUM2"); }
        }
        public string SMART_PHNUM3
        {
            get { return _SMART_PHNUM3; }
            set { _SMART_PHNUM3 = value; NotifyPropertyChanged("_SMART_PHNUM3"); }
        }
        public string SMART_PHNUM4
        {
            get { return _SMART_PHNUM4; }
            set { _SMART_PHNUM4 = value; NotifyPropertyChanged("_SMART_PHNUM4"); }
        }
        public string SENSOR_BOARDS
        {
            get { return _SENSOR_BOARDS; }
            set { _SENSOR_BOARDS = value; NotifyPropertyChanged("_SENSOR_BOARDS"); }
        }
        public string RELAY_BOARDS
        {
            get { return _RELAY_BOARDS; }
            set { _RELAY_BOARDS = value; NotifyPropertyChanged("_RELAY_BOARDS"); }
        }
        public string DISPLAY_BOARDS
        {
            get { return _DISPLAY_BOARDS; }
            set { _DISPLAY_BOARDS = value; NotifyPropertyChanged("_DISPLAY_BOARDS"); }
        }
        public string ONOFF_BOARDS
        {
            get { return _ONOFF_BOARDS; }
            set { _ONOFF_BOARDS = value; NotifyPropertyChanged("_ONOFF_BOARDS"); }
        }
        public string AUTO_BOARDS
        {
            get { return _AUTO_BOARDS; }
            set { _AUTO_BOARDS = value; NotifyPropertyChanged("_AUTO_BOARDS"); }
        }

        // Implement INotifyPropertyChanged interface.
        public event PropertyChangedEventHandler PropertyChanged;

        // Data for undoing canceled edits.
        private P2000_Data temp_Task = null;
        private bool m_Editing = false;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        // Implement IEditableObject interface.
        public void BeginEdit()
        {
            if (m_Editing == false)
            {
                temp_Task = this.MemberwiseClone() as P2000_Data;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                this._DEVICE_ID = temp_Task._DEVICE_ID;
                this._HMI_PHNUM = temp_Task._HMI_PHNUM;
                this._MY_CDMANUM = temp_Task._MY_CDMANUM;
                this._SMART_PHNUMS = temp_Task._SMART_PHNUMS;
                this._SMART_PHNUM0 = temp_Task._SMART_PHNUM0;
                this._SMART_PHNUM1 = temp_Task._SMART_PHNUM1;
                this._SMART_PHNUM2 = temp_Task._SMART_PHNUM2;
                this._SMART_PHNUM3 = temp_Task._SMART_PHNUM3;
                this._SMART_PHNUM4 = temp_Task._SMART_PHNUM4;
                this._SENSOR_BOARDS = temp_Task._SENSOR_BOARDS;
                this._RELAY_BOARDS = temp_Task._RELAY_BOARDS;
                this._DISPLAY_BOARDS = temp_Task._DISPLAY_BOARDS;
                this._ONOFF_BOARDS = temp_Task._ONOFF_BOARDS;
                this._AUTO_BOARDS = temp_Task._AUTO_BOARDS;

                m_Editing = false;
            }
        }

        public void EndEdit()
        {
            if (m_Editing == true)
            {
                temp_Task = null;
                m_Editing = false;
            }
        }

    }
}
