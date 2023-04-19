using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
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
using _04Prokhorov.Model;
using _04Prokhorov.Model.CustomException;
using _04Prokhorov.ViewModel;

namespace _04Prokhorov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //add a list of persons to personlist
            //add a list of persons to personlist
            ViewModel.ViewModel.LoadData();
            if (ViewModel.ViewModel.Persons.Count == 0)
                ViewModel.ViewModel.GenerateData();
            PersonList.ItemsSource = ViewModel.ViewModel.Persons;
            PersonList.Sorting += new DataGridSortingEventHandler(ViewModel.ViewModel.SortHandler);
        }

        private void DateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FirstName.Text.Length > 0 && LastName.Text.Length > 0 && Email.Text.Length > 0 && DatePicker.SelectedDate != null)
            {
                EnableButtons();
            }
            else
            {
                DisableButtons();
            }
        }

        private void ProceedButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ViewModel.ViewModel.CalculateAge(DatePicker.SelectedDate) || !Person.IsValidEmail(Email.Text))
            {
                return;
            }
            Person person = new Person(FirstName.Text, LastName.Text, Email.Text, DatePicker.SelectedDate.Value);
            person.InitializeAsync();
            ViewModel.ViewModel.AddPerson(person);
            PersonList.ItemsSource = ViewModel.ViewModel.Persons;
            PersonList.Items.Refresh();
            ViewModel.ViewModel.SaveData();
        }

        private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FirstName.Text.Length > 0 && LastName.Text.Length > 0 && Email.Text.Length > 0 && DatePicker.SelectedDate != null)
            {
                EnableButtons();
            }
            else
            {
                DisableButtons();
            }
        }

        private void DisableButtons()
        {
            ProceedButton.IsEnabled = false;
            UpdateButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
        }

        private void EnableButtons()
        {
            ProceedButton.IsEnabled = true;
            UpdateButton.IsEnabled = true;
            DeleteButton.IsEnabled = true;
        }

        private void LastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FirstName.Text.Length > 0 && LastName.Text.Length > 0 && Email.Text.Length > 0 && DatePicker.SelectedDate != null)
            {
                EnableButtons();
            }
            else
            {
                DisableButtons();
            }
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FirstName.Text.Length > 0 && LastName.Text.Length > 0 && Email.Text.Length > 0 && DatePicker.SelectedDate != null)
            {
                EnableButtons();
            }
            else
            {
                DisableButtons();
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person(FirstName.Text, LastName.Text, Email.Text, DatePicker.SelectedDate.Value);
            person.InitializeAsync();
            ViewModel.ViewModel.UpdatePerson(person);
            PersonList.ItemsSource = ViewModel.ViewModel.Persons;
            PersonList.Items.Refresh();
            ViewModel.ViewModel.SaveData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person(FirstName.Text, LastName.Text, Email.Text, DatePicker.SelectedDate.Value);
            ViewModel.ViewModel.RemovePerson(person);
            //update personlist
            PersonList.ItemsSource = ViewModel.ViewModel.Persons;
            PersonList.Items.Refresh();
            ViewModel.ViewModel.SaveData();

        }

        private void PersonList_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (PersonList.SelectedItem != null)
            {
                Person person = (Person)PersonList.SelectedItem;
                FirstName.Text = person.Name;
                LastName.Text = person.Surname;
                Email.Text = person.EmailAddress;
                DatePicker.SelectedDate = person.DateOfBirth;
            }

        }
    }
}