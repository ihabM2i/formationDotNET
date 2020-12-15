using CoursEntityFrameWorkCore.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace CoursEntityFrameWorkCore.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Person person;

        public Person SelectedPerson { get; set; }

        private DataContext data;
        public string FirstName { get => person.FirstName; set { person.FirstName = value; RaisePropertyChanged(); } }
        public string LastName { get => person.LastName; set { person.LastName = value; RaisePropertyChanged(); } }
        public string Phone { get => person.Phone; set { person.Phone = value; RaisePropertyChanged(); } }
        
        public ObservableCollection<Person> Persons { get; set; }
        public ICommand ConfirmCommand { get; set; }
        public ICommand SelectCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public MainViewModel()
        {
            person = new Person();
            data = new DataContext();
            Persons = new ObservableCollection<Person>(data.Persons);
            ConfirmCommand = new RelayCommand(ActionConfirm);
            SelectCommand = new RelayCommand(ActionSelect);
            DeleteCommand = new RelayCommand(ActionDelete);
            SelectedPerson = null;
        }

        private void ActionConfirm()
        {
            if(SelectedPerson == null)
            {
                data.Persons.Add(person);             
                Persons.Add(person);
                MessageBox.Show("Insert");               
            }
            else
            {  
                MessageBox.Show("Update");
            }
            data.SaveChanges();
            person = new Person();
            RaisePropertyChanged("FirstName");
            RaisePropertyChanged("LastName");
            RaisePropertyChanged("Phone");
        }

        private void ActionSelect()
        {
            FirstName = SelectedPerson.FirstName;
            LastName = SelectedPerson.LastName;
            Phone = SelectedPerson.Phone;
            person = SelectedPerson;
        }
        private void ActionDelete()
        {
            if(SelectedPerson != null)
            {
                data.Persons.Remove(SelectedPerson);
                data.SaveChanges();
                Persons.Remove(SelectedPerson);
            }
        }
    }
}
