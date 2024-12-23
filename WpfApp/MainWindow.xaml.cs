using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using ClassLibrary.Datadase;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Clinical_Hospital_33Entities dbContext;
        public MainWindow()
        {
            InitializeComponent();
            dbContext = new Clinical_Hospital_33Entities(); // Используем контекст из библиотеки
            LoadPatients();
        }

        private void LoadPatients()
        {
            // Загрузка данных из таблицы Med_card через библиотеку
            var patients = dbContext.Med_card.ToList();
            PatientsDataGrid.ItemsSource = patients;
        }

        private void AddPatientButton_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddPatientWindow();
            if (addWindow.ShowDialog() == true)
            {
                // Добавляем нового пациента в базу данных
                dbContext.Med_card.Add(addWindow.NewPatient);
                dbContext.SaveChanges();
                LoadPatients(); // Обновляем список
            }
        }

        private void EditPatientButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedPatient = PatientsDataGrid.SelectedItem as Med_card;
            if (selectedPatient != null)
            {
                var editWindow = new EditPatientWindow(selectedPatient);
                if (editWindow.ShowDialog() == true)
                {
                    dbContext.SaveChanges();
                    LoadPatients(); // Обновляем список
                }
            }
            else
            {
                MessageBox.Show("Выберите пациента для редактирования.");
            }
        }

        private void DeletePatientButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedPatient = PatientsDataGrid.SelectedItem as Med_card;
            if (selectedPatient != null)
            {
                dbContext.Med_card.Remove(selectedPatient);
                dbContext.SaveChanges();
                LoadPatients(); // Обновляем список
            }
            else
            {
                MessageBox.Show("Выберите пациента для удаления.");
            }
        }
    }
}
