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
        }
    }
}
