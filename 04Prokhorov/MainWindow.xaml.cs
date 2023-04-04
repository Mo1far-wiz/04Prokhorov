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
            PersonList.ItemsSource = ViewModel.ViewModel.GenerateData();
            PersonList.Sorting += new DataGridSortingEventHandler(ViewModel.ViewModel.SortHandler);
        }

        private void DateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FirstName.Text.Length > 0 && LastName.Text.Length > 0 && Email.Text.Length > 0 && DatePicker.SelectedDate != null)
            {
                ProceedButton.IsEnabled = true;
            }
            else
            {
                ProceedButton.IsEnabled = false;
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
            FirstNameAns.Content = "Name : " + person.Name;
            LastNameAns.Content = "Surname : " + person.Surname;
            EmailAns.Content = "E-mail: " + person.EmailAddress;
            BirthDayAns.Content = "D of birth: " + person.DateOfBirth.ToShortDateString();
            IsAdult.Text = "Adult: " + person.IsAdult;
            HoroscopeEnglish.Text = "Western: " + person.SunSign;
            HoroscopeAsian.Text = "Chinese: " + person.ChineseSign;
            IsBirthday.Text = "B-day: " + person.IsBirthday;


        }

        private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FirstName.Text.Length > 0 && LastName.Text.Length > 0 && Email.Text.Length > 0 && DatePicker.SelectedDate != null)
            {
                ProceedButton.IsEnabled = true;
            }
            else
            {
                ProceedButton.IsEnabled = false;
            }
        }

        private void LastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FirstName.Text.Length > 0 && LastName.Text.Length > 0 && Email.Text.Length > 0 && DatePicker.SelectedDate != null)
            {
                ProceedButton.IsEnabled = true;
            }
            else
            {
                ProceedButton.IsEnabled = false;
            }
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FirstName.Text.Length > 0 && LastName.Text.Length > 0 && Email.Text.Length > 0 && DatePicker.SelectedDate != null)
            {
                ProceedButton.IsEnabled = true;
            }
            else
            {
                ProceedButton.IsEnabled = false;
            }
        }
    }
}