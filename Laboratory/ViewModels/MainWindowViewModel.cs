using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Laboratory.Models;
using Laboratory.ViewModels.Base;

namespace Laboratory.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private readonly CollectionViewSource _Employees = new CollectionViewSource();

        public ICollectionView Employees => _Employees?.View;

        #region SelectedEmployee : Employee - Выбранный сотрудник

        private Employee _SelectedEmployee;

        /// <summary>Выбранный сотружник</summary>
        public Employee SelectedEmployee
        {
            get => _SelectedEmployee;
            set => Set(ref _SelectedEmployee, value);
        }

        #endregion

        #region EmployeesFilterText : string - Текст фильтра сотрудников

        private string _EmployeesFilterText;

        /// <summary>Текст фильтра сотрудников</summary>
        public string EmployeesFilterText
        {
            get => _EmployeesFilterText;
            set
            {
                if (!Set(ref _EmployeesFilterText, value)) return;
                _Employees.View.Refresh();
            }
        }

        #endregion

        private void OnEmployeesFiltered(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Employee employee))
            {
                e.Accepted = false;
                return;
            }

            var filter_text = _EmployeesFilterText;
            if (string.IsNullOrWhiteSpace(filter_text)) return;

            if (employee.Surname is null || employee.Name is null)
            {
                e.Accepted = false;
                return;
            }

            if (employee.Surname.Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return;
            if (employee.Name.Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return;
            if (employee.Surname.Contains(filter_text.Split(' ')[0], StringComparison.OrdinalIgnoreCase) &&
                employee.Name.Contains(filter_text.Split(' ')[1], StringComparison.OrdinalIgnoreCase))
                return;

            e.Accepted = false;
        }
        public MainWindowViewModel()
        {
            var employees = new List<Employee>();

            //for (int i = 0 ; i < 3; ++i)
            //{
            //    Employee employee = new Employee()
            //    {
            //        Name = i.ToString(),
            //        Surname = i.ToString(),
            //        Patronymic = i.ToString(),
            //        Gender = true,
            //        Age = i,
            //        MaritalStatus = i.ToString(),
            //        HavingChildren = false,
            //        Post = i.ToString(),
            //        Degree = i.ToString()
            //    };
            //    employees.Add(employee);
            //}
            Employee employee;
            employee = new Employee()
            {
                Name = "Владимир",
                Surname = "Заваркин",
                Patronymic = "Назарбаевич",
                Gender = "Мужчина",
                Age = 42,
                MaritalStatus = "Не женат",
                HavingChildren = "Нет",
                Post = "Главный научный сотрудник",
                Degree = "Доктор"
            };
            employees.Add(employee);

            employee = new Employee()
            {
                Name = "Игорь",
                Surname = "Паустовский",
                Patronymic = "Прокофьевич",
                Gender = "Мужчина",
                Age = 23,
                MaritalStatus = "Женат",
                HavingChildren = "Да",
                Post = "Стажёр-исследователь",
                Degree = "Бакалавр"
            };
            employees.Add(employee);

            employee = new Employee()
            {
                Name = "Августина",
                Surname = "Закусова",
                Patronymic = "Потаповна",
                Gender = "Женщина",
                Age = 32,
                MaritalStatus = "Вдова",
                HavingChildren = "Да",
                Post = "Старший научный сотрудник",
                Degree = "Магистр"
            };
            employees.Add(employee);

            _Employees.Source = employees;
            SelectedEmployee = employees.First();
            _Employees.Filter += OnEmployeesFiltered;
        }
    }
}
