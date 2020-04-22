using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        Person person = new Person { Name = "Salman", Age = 26 };

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = person;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message = person.Name + " is " + person.Age;
            MessageBox.Show(message);

            person.Name = "test";
            person.Age = 23;
        }
    }
    public class Person
    {
        private string nameValue;

        public string Name
        {
            get { return nameValue; }
            set { nameValue = value; }
        }

        private double ageValue;
        public double Age
        {
            get { return ageValue; }
            set
            {
                if (value != ageValue)
                {
                    ageValue = value;
                }
            }
        }

    }
}
