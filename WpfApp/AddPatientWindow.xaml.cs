using ClassLibrary;
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
using System.Windows.Shapes;
using ClassLibrary.Datadase;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для AddPatientWindow.xaml
    /// </summary>
    public partial class AddPatientWindow : Window
    {
        public Med_card NewPatient { get; private set; }

        public AddPatientWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем нового пациента
            NewPatient = new Med_card
            {
                Familya = LastNameTextBox.Text,
                Name = FirstNameTextBox.Text,
                Otchestvo = MiddleNameTextBox.Text
            };

            this.DialogResult = true;
            this.Close();
        }
    }
}

