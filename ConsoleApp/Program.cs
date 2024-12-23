using ClassLibrary;
using ClassLibrary.Datadase; 
using System;
using System.Linq;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Используем метод GetContext() из библиотеки классов
            var dbContext = Data.GetContext();

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Просмотреть список пациентов");
                Console.WriteLine("2. Просмотреть список врачей");
                Console.WriteLine("3. Просмотреть список диагнозов");
                Console.WriteLine("4. Просмотреть список выписок");
                Console.WriteLine("5. Выйти");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManagePatients(dbContext);
                        break;
                    case "2":
                        ManageDoctors(dbContext);
                        break;
                    case "3":
                        ManageDiagnoses(dbContext);
                        break;
                    case "4":
                        ManageDischarges(dbContext);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        static void ManagePatients(Clinical_Hospital_33Entities dbContext)
        {
            while (true)
            {
                Console.WriteLine("\nВыберите действие для пациентов:");
                Console.WriteLine("1. Просмотреть список пациентов");
                Console.WriteLine("2. Добавить пациента");
                Console.WriteLine("3. Удалить пациента");
                Console.WriteLine("4. Редактировать пациента");
                Console.WriteLine("5. Вернуться в главное меню");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowPatients(dbContext);
                        break;
                    case "2":
                        AddPatient(dbContext);
                        break;
                    case "3":
                        DeletePatient(dbContext);
                        break;
                    case "4":
                        UpdatePatient(dbContext);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        static void ShowPatients(Clinical_Hospital_33Entities dbContext)
        {
            Console.WriteLine("\nСписок пациентов:");
            var patients = dbContext.Med_card.ToList();
            foreach (var patient in patients)
            {
                Console.WriteLine($"ID: {patient.Id_medcard}, Фамилия: {patient.Familya}, Имя: {patient.Name}, Отчество: {patient.Otchestvo}, Диагноз: {patient.Diagnoz?.Name_diagnoza}");
            }
        }

        static void AddPatient(Clinical_Hospital_33Entities dbContext)
        {
            Console.WriteLine("\nДобавление нового пациента:");
            Console.Write("Введите фамилию пациента: ");
            string lastName = Console.ReadLine();
            Console.Write("Введите имя пациента: ");
            string firstName = Console.ReadLine();
            Console.Write("Введите отчество пациента: ");
            string middleName = Console.ReadLine();
            Console.Write("Введите ID диагноза: ");
            int diagnosisId = int.Parse(Console.ReadLine());

            var newPatient = new Med_card
            {
                Familya = lastName,
                Name = firstName,
                Otchestvo = middleName,
                Id_diagnoza = diagnosisId
            };

            dbContext.Med_card.Add(newPatient);
            dbContext.SaveChanges();

            Console.WriteLine("Пациент успешно добавлен!");
        }

        static void DeletePatient(Clinical_Hospital_33Entities dbContext)
        {
            Console.WriteLine("\nУдаление пациента:");
            Console.Write("Введите ID пациента для удаления: ");
            int patientIdToDelete = int.Parse(Console.ReadLine());

            var patientToDelete = dbContext.Med_card.FirstOrDefault(p => p.Id_medcard == patientIdToDelete);
            if (patientToDelete != null)
            {
                dbContext.Med_card.Remove(patientToDelete);
                dbContext.SaveChanges();
                Console.WriteLine("Пациент успешно удален!");
            }
            else
            {
                Console.WriteLine("Пациент не найден.");
            }
        }

        static void UpdatePatient(Clinical_Hospital_33Entities dbContext)
        {
            Console.WriteLine("\nОбновление данных пациента:");
            Console.Write("Введите ID пациента для обновления: ");
            int patientIdToUpdate = int.Parse(Console.ReadLine());

            var patientToUpdate = dbContext.Med_card.FirstOrDefault(p => p.Id_medcard == patientIdToUpdate);
            if (patientToUpdate != null)
            {
                Console.Write("Введите новую фамилию пациента: ");
                string newLastName = Console.ReadLine();
                Console.Write("Введите новое имя пациента: ");
                string newFirstName = Console.ReadLine();
                Console.Write("Введите новое отчество пациента: ");
                string newMiddleName = Console.ReadLine();
                Console.Write("Введите новый ID диагноза: ");
                int newDiagnosisId = int.Parse(Console.ReadLine());

                patientToUpdate.Familya = newLastName;
                patientToUpdate.Name = newFirstName;
                patientToUpdate.Otchestvo = newMiddleName;
                patientToUpdate.Id_diagnoza = newDiagnosisId;

                dbContext.SaveChanges();
                Console.WriteLine("Данные пациента успешно обновлены!");
            }
            else
            {
                Console.WriteLine("Пациент не найден.");
            }
        }

        static void ManageDoctors(Clinical_Hospital_33Entities dbContext)
        {
            while (true)
            {
                Console.WriteLine("\nВыберите действие для врачей:");
                Console.WriteLine("1. Просмотреть список врачей");
                Console.WriteLine("2. Добавить врача");
                Console.WriteLine("3. Удалить врача");
                Console.WriteLine("4. Редактировать врача");
                Console.WriteLine("5. Вернуться в главное меню");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowDoctors(dbContext);
                        break;
                    case "2":
                        AddDoctor(dbContext);
                        break;
                    case "3":
                        DeleteDoctor(dbContext);
                        break;
                    case "4":
                        UpdateDoctor(dbContext);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        static void ShowDoctors(Clinical_Hospital_33Entities dbContext)
        {
            Console.WriteLine("\nСписок врачей:");
            var doctors = dbContext.Vrach.ToList();
            foreach (var doctor in doctors)
            {
                Console.WriteLine($"ID: {doctor.Id_vracha}, Фамилия: {doctor.Familya}, Имя: {doctor.Name}, Отчество: {doctor.Otchestvo}, Должность: {doctor.Doljnost?.name}");
            }
        }

        static void AddDoctor(Clinical_Hospital_33Entities dbContext)
        {
            Console.WriteLine("\nДобавление нового врача:");
            Console.Write("Введите фамилию врача: ");
            string lastName = Console.ReadLine();
            Console.Write("Введите имя врача: ");
            string firstName = Console.ReadLine();
            Console.Write("Введите отчество врача: ");
            string middleName = Console.ReadLine();
            Console.Write("Введите ID должности: ");
            int positionId = int.Parse(Console.ReadLine());

            var newDoctor = new Vrach
            {
                Familya = lastName,
                Name = firstName,
                Otchestvo = middleName,
                id_doljnosti = positionId
            };

            dbContext.Vrach.Add(newDoctor);
            dbContext.SaveChanges();

            Console.WriteLine("Врач успешно добавлен!");
        }

        static void DeleteDoctor(Clinical_Hospital_33Entities dbContext)
        {
            Console.WriteLine("\nУдаление врача:");
            Console.Write("Введите ID врача для удаления: ");
            int doctorIdToDelete = int.Parse(Console.ReadLine());

            var doctorToDelete = dbContext.Vrach.FirstOrDefault(d => d.Id_vracha == doctorIdToDelete);
            if (doctorToDelete != null)
            {
                dbContext.Vrach.Remove(doctorToDelete);
                dbContext.SaveChanges();
                Console.WriteLine("Врач успешно удален!");
            }
            else
            {
                Console.WriteLine("Врач не найден.");
            }
        }

        static void UpdateDoctor(Clinical_Hospital_33Entities dbContext)
        {
            Console.WriteLine("\nОбновление данных врача:");
            Console.Write("Введите ID врача для обновления: ");
            int doctorIdToUpdate = int.Parse(Console.ReadLine());

            var doctorToUpdate = dbContext.Vrach.FirstOrDefault(d => d.Id_vracha == doctorIdToUpdate);
            if (doctorToUpdate != null)
            {
                Console.Write("Введите новую фамилию врача: ");
                string newLastName = Console.ReadLine();
                Console.Write("Введите новое имя врача: ");
                string newFirstName = Console.ReadLine();
                Console.Write("Введите новое отчество врача: ");
                string newMiddleName = Console.ReadLine();
                Console.Write("Введите новый ID должности: ");
                int newPositionId = int.Parse(Console.ReadLine());

                doctorToUpdate.Familya = newLastName;
                doctorToUpdate.Name = newFirstName;
                doctorToUpdate.Otchestvo = newMiddleName;
                doctorToUpdate.id_doljnosti = newPositionId;

                dbContext.SaveChanges();
                Console.WriteLine("Данные врача успешно обновлены!");
            }
            else
            {
                Console.WriteLine("Врач не найден.");
            }
        }

        static void ManageDiagnoses(Clinical_Hospital_33Entities dbContext)
        {
            while (true)
            {
                Console.WriteLine("\nВыберите действие для диагнозов:");
                Console.WriteLine("1. Просмотреть список диагнозов");
                Console.WriteLine("2. Добавить диагноз");
                Console.WriteLine("3. Удалить диагноз");
                Console.WriteLine("4. Редактировать диагноз");
                Console.WriteLine("5. Вернуться в главное меню");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowDiagnoses(dbContext);
                        break;
                    case "2":
                        AddDiagnosis(dbContext);
                        break;
                    case "3":
                        DeleteDiagnosis(dbContext);
                        break;
                    case "4":
                        UpdateDiagnosis(dbContext);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        static void ShowDiagnoses(Clinical_Hospital_33Entities dbContext)
        {
            Console.WriteLine("\nСписок диагнозов:");
            var diagnoses = dbContext.Diagnoz.ToList();
            foreach (var diagnosis in diagnoses)
            {
                Console.WriteLine($"ID: {diagnosis.Id_diagnoza}, Название: {diagnosis.Name_diagnoza}");
            }
        }

        static void AddDiagnosis(Clinical_Hospital_33Entities dbContext)
        {
            Console.WriteLine("\nДобавление нового диагноза:");
            Console.Write("Введите название диагноза: ");
            string diagnosisName = Console.ReadLine();

            var newDiagnosis = new Diagnoz
            {
                Name_diagnoza = diagnosisName
            };

            dbContext.Diagnoz.Add(newDiagnosis);
            dbContext.SaveChanges();

            Console.WriteLine("Диагноз успешно добавлен!");
        }

        static void DeleteDiagnosis(Clinical_Hospital_33Entities dbContext)
        {
            Console.WriteLine("\nУдаление диагноза:");
            Console.Write("Введите ID диагноза для удаления: ");
            int diagnosisIdToDelete = int.Parse(Console.ReadLine());

            var diagnosisToDelete = dbContext.Diagnoz.FirstOrDefault(d => d.Id_diagnoza == diagnosisIdToDelete);
            if (diagnosisToDelete != null)
            {
                dbContext.Diagnoz.Remove(diagnosisToDelete);
                dbContext.SaveChanges();
                Console.WriteLine("Диагноз успешно удален!");
            }
            else
            {
                Console.WriteLine("Диагноз не найден.");
            }
        }

        static void UpdateDiagnosis(Clinical_Hospital_33Entities dbContext)
        {
            Console.WriteLine("\nОбновление данных диагноза:");
            Console.Write("Введите ID диагноза для обновления: ");
            int diagnosisIdToUpdate = int.Parse(Console.ReadLine());

            var diagnosisToUpdate = dbContext.Diagnoz.FirstOrDefault(d => d.Id_diagnoza == diagnosisIdToUpdate);
            if (diagnosisToUpdate != null)
            {
                Console.Write("Введите новое название диагноза: ");
                string newDiagnosisName = Console.ReadLine();

                diagnosisToUpdate.Name_diagnoza = newDiagnosisName;

                dbContext.SaveChanges();
                Console.WriteLine("Данные диагноза успешно обновлены!");
            }
            else
            {
                Console.WriteLine("Диагноз не найден.");
            }
        }

        static void ManageDischarges(Clinical_Hospital_33Entities dbContext)
        {
            while (true)
            {
                Console.WriteLine("\nВыберите действие для выписок:");
                Console.WriteLine("1. Просмотреть список выписок");
                Console.WriteLine("2. Добавить выписку");
                Console.WriteLine("3. Удалить выписку");
                Console.WriteLine("4. Редактировать выписку");
                Console.WriteLine("5. Вернуться в главное меню");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowDischarges(dbContext);
                        break;
                    case "2":
                        AddDischarge(dbContext);
                        break;
                    case "3":
                        DeleteDischarge(dbContext);
                        break;
                    case "4":
                        UpdateDischarge(dbContext);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        static void ShowDischarges(Clinical_Hospital_33Entities dbContext)
        {
            Console.WriteLine("\nСписок выписок:");
            var discharges = dbContext.Vipiska.ToList();
            foreach (var discharge in discharges)
            {
                Console.WriteLine($"ID: {discharge.Id_vipiski}, Дата выписки: {discharge.Date}, Пациент: {discharge.Med_card?.Familya}, Причина выписки: {discharge.Prichina_vypiski?.name}");
            }
        }

        static void AddDischarge(Clinical_Hospital_33Entities dbContext)
        {
            Console.WriteLine("\nДобавление новой выписки:");
            Console.Write("Введите ID пациента: ");
            int patientId = int.Parse(Console.ReadLine());
            Console.Write("Введите дату выписки (гггг-мм-дд): ");
            DateTime dischargeDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Введите ID причины выписки: ");
            int reasonId = int.Parse(Console.ReadLine());

            var newDischarge = new Vipiska
            {
                Id_medcard = patientId,
                Date = dischargeDate,
                id_prichiny_vipiski = reasonId
            };

            dbContext.Vipiska.Add(newDischarge);
            dbContext.SaveChanges();

            Console.WriteLine("Выписка успешно добавлена!");
        }

        static void DeleteDischarge(Clinical_Hospital_33Entities dbContext)
        {
            Console.WriteLine("\nУдаление выписки:");
            Console.Write("Введите ID выписки для удаления: ");
            int dischargeIdToDelete = int.Parse(Console.ReadLine());

            var dischargeToDelete = dbContext.Vipiska.FirstOrDefault(d => d.Id_vipiski == dischargeIdToDelete);
            if (dischargeToDelete != null)
            {
                dbContext.Vipiska.Remove(dischargeToDelete);
                dbContext.SaveChanges();
                Console.WriteLine("Выписка успешно удалена!");
            }
            else
            {
                Console.WriteLine("Выписка не найдена.");
            }
        }

        static void UpdateDischarge(Clinical_Hospital_33Entities dbContext)
        {
            Console.WriteLine("\nОбновление данных выписки:");
            Console.Write("Введите ID выписки для обновления: ");
            int dischargeIdToUpdate = int.Parse(Console.ReadLine());

            var dischargeToUpdate = dbContext.Vipiska.FirstOrDefault(d => d.Id_vipiski == dischargeIdToUpdate);
            if (dischargeToUpdate != null)
            {
                Console.Write("Введите новый ID пациента: ");
                int newPatientId = int.Parse(Console.ReadLine());
                Console.Write("Введите новую дату выписки (гггг-мм-дд): ");
                DateTime newDischargeDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Введите новый ID причины выписки: ");
                int newReasonId = int.Parse(Console.ReadLine());

                dischargeToUpdate.Id_medcard = newPatientId;
                dischargeToUpdate.Date = newDischargeDate;
                dischargeToUpdate.id_prichiny_vipiski = newReasonId;

                dbContext.SaveChanges();
                Console.WriteLine("Данные выписки успешно обновлены!");
            }
            else
            {
                Console.WriteLine("Выписка не найдена.");
            }
        }
    }
}