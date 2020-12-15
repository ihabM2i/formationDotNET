using CoursEntityFrameWorkCore.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
        
        public string Street
        {
            get;set;
        }
        public string City
        {
            get;set;
        }

        public string PostCode
        {
            get;set;
        }
        public string Search { get; set; }

        public ObservableCollection<Person> Persons { get; set; }
        public ICommand ConfirmCommand { get; set; }
        public ICommand SelectCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand AddAddressCommand { get; set; }
        public MainViewModel()
        {
            data = new DataContext();
            Persons = new ObservableCollection<Person>(data.Persons.Include(p => p.Addresses));
            person = new Person();
            person.Addresses = new List<Address>();
            ConfirmCommand = new RelayCommand(ActionConfirm);
            SelectCommand = new RelayCommand(ActionSelect);
            DeleteCommand = new RelayCommand(ActionDelete);
            SearchCommand = new RelayCommand(ActionSearch);
            AddAddressCommand = new RelayCommand(ActionAddAddress);
            SelectedPerson = null;
        }

        private void ActionAddAddress()
        {
            person.Addresses.Add(new Address() { Street = Street, City = City, PostCode = PostCode });
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
            foreach (PropertyInfo p in typeof(MainViewModel).GetProperties())
            {
                RaisePropertyChanged(p.Name);
            }
        }

        private void ActionSelect()
        {           
            person = SelectedPerson;
            if (person.Addresses == null)
                person.Addresses = new List<Address>();
            //RaisePropertyChanged("FirstName");
            //RaisePropertyChanged("LastName");
            //RaisePropertyChanged("Phone");
            //RaisePropertyChanged("Street");
            //RaisePropertyChanged("City");
            //RaisePropertyChanged("PostCode");
            foreach(PropertyInfo p in typeof(MainViewModel).GetProperties())
            {
                RaisePropertyChanged(p.Name);
            }
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

        private void ActionSearch()
        {
            Persons = new ObservableCollection<Person>(data.Persons.Where(p => p.FirstName.Contains(Search) || p.LastName.Contains(Search)));
            RaisePropertyChanged("Persons");
        }
    }
}
