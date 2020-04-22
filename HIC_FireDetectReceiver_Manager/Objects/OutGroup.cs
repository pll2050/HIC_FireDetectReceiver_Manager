using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HIC_FireDetectReceiver_Manager
{
    public class OutGroup_Table : ObservableCollection<OutGroup> { }
    public class OutGroup : INotifyPropertyChanged, IEditableObject
    {
        private string _GroupNo;
        private string _GroupName;
        private string _Output1;
        private string _Output2;
        private string _Output3;
        private string _Output4;
        private string _Output5;
        private string _Output6;
        private string _Output7;
        private string _Output8;
        private string _Output9;
        private string _Output10;
        private string _Output11;
        private string _Output12;
        private string _Output13;
        private string _Output14;
        private string _Output15;
        private string _Output16;

        public string mGroupNo
        {
            get { return _GroupNo; }
            set { _GroupNo = value; }
        }
        public string mGroupName
        {
            get { return _GroupName; }
            set { _GroupName = value; }
        }

        public string mOutput1
        {
            get { return _Output1; }
            set { _Output1 = value; }
        }
        public string mOutput2
        {
            get { return _Output2; }
            set { _Output2 = value; }
        }
        public string mOutput3
        {
            get { return _Output3; }
            set { _Output3 = value; }
        }
        public string mOutput4
        {
            get { return _Output4; }
            set { _Output4 = value; }
        }
        public string mOutput5
        {
            get { return _Output5; }
            set { _Output5 = value; }
        }
        public string mOutput6
        {
            get { return _Output6; }
            set { _Output6 = value; }
        }
        public string mOutput7
        {
            get { return _Output7; }
            set { _Output7 = value; }
        }
        public string mOutput8
        {
            get { return _Output8; }
            set { _Output8 = value; }
        }
        public string mOutput9
        {
            get { return _Output9; }
            set { _Output9 = value; }
        }
        public string mOutput10
        {
            get { return _Output10; }
            set { _Output10 = value; }
        }
        public string mOutput11
        {
            get { return _Output11; }
            set { _Output11 = value; }
        }
        public string mOutput12
        {
            get { return _Output12; }
            set { _Output12 = value; }
        }
        public string mOutput13
        {
            get { return _Output13; }
            set { _Output13 = value; }
        }
        public string mOutput14
        {
            get { return _Output14; }
            set { _Output14 = value; }
        }
        public string mOutput15
        {
            get { return _Output15; }
            set { _Output15 = value; }
        }
        public string mOutput16
        {
            get { return _Output16; }
            set { _Output16 = value; }
        }

        // Implement INotifyPropertyChanged interface.
        public event PropertyChangedEventHandler PropertyChanged;

        // Data for undoing canceled edits.
        private OutGroup temp_Task = null;
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
                temp_Task = this.MemberwiseClone() as OutGroup;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                this._GroupNo = temp_Task.mGroupNo;
                this._GroupName = temp_Task._GroupName;
                this._Output1 = temp_Task._Output1;
                this._Output2 = temp_Task._Output2;
                this._Output3 = temp_Task._Output3;
                this._Output4 = temp_Task._Output4;
                this._Output5 = temp_Task._Output5;
                this._Output6 = temp_Task._Output6;
                this._Output7 = temp_Task._Output7;
                this._Output8 = temp_Task._Output8;
                this._Output9 = temp_Task._Output9;
                this._Output10 = temp_Task._Output10;
                this._Output11 = temp_Task._Output11;
                this._Output12 = temp_Task._Output12;
                this._Output13 = temp_Task._Output13;
                this._Output14 = temp_Task._Output14;
                this._Output15 = temp_Task._Output15;
                this._Output16 = temp_Task._Output16;

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
