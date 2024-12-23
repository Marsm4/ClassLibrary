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
    /// Логика взаимодействия для EditPatientWindow.xaml
    /// </summary>
    public partial class EditPatientWindow : Window
    {
        private Med_card patient;

        public EditPatientWindow(Med_card patient)
        {
            InitializeComponent();
            this.patient = patient;

            // Заполняем поля данными пациента
            LastNameTextBox.Text = patient.Familya;
            FirstNameTextBox.Text = patient.Name;
            MiddleNameTextBox.Text = patient.Otchestvo;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Обновляем данные пациента
            patient.Familya = LastNameTextBox.Text;
            patient.Name = FirstNameTextBox.Text;
            patient.Otchestvo = MiddleNameTextBox.Text;

            this.DialogResult = true;
            this.Close();
        }
    }
}
