using _04Prokhorov.Model.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Collections;
using _04Prokhorov.Model;
using System.ComponentModel;
using System.Windows.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace _04Prokhorov.ViewModel
{
    internal class ViewModel
    {
        public static List<Person> Persons = new List<Person>();

        private static ListSortDirection? sortDirection = null;

        public static bool CalculateAge(DateTime? birthDate)
        {
            if (birthDate != null)
            {
                DateTime today = DateTime.Today;
                int age = today.Year - birthDate.Value.Year;
                if (birthDate > today.AddYears(-age)) age--;
                if (age > 135)
                {
                    throw new AgeTooLowException("to small");
                }
                else if (age < 0)
                {
                    throw new AgeTooHighException("to old");
                }
                else
                {
                    if (birthDate.Value.Month == today.Month && birthDate.Value.Day == today.Day)
                        MessageBox.Show("Happy B-day!");
                    return true;
                }
            }
            return false;
        }

        public static void SaveData()
        {
            var formatter = new BinaryFormatter();
            using (var stream = new FileStream("data.dat", FileMode.Create))
            {
                formatter.Serialize(stream, Persons);
            }
        }

        public static void LoadData()
        {
            if (File.Exists("data.dat"))
            {
                var formatter = new BinaryFormatter();
 
                using (var stream = new FileStream("data.dat", FileMode.Open))
                {
                    Persons = (List<Person>)formatter.Deserialize(stream);
                }
            }
        }

        internal static void GenerateData()
        {
            List<Person> p = new List<Person>
            {
                new Person("John"       ,"Doe"      ,"1@google.com"     ,new DateTime(1991, 11, 21)),
                new Person("Jane"       ,"Doe"      ,"2@google.com"     ,new DateTime(2005, 5, 10)),
                new Person("Sarah"      ,"Johnson"  ,"3@google.com"     ,new DateTime(1998, 2, 15)),
                new Person("Mark"       ,"Smith"    ,"4@google.com"     ,new DateTime(1985, 9, 3)),
                new Person("Emily"      ,"Williams" ,"5@google.com"     ,new DateTime(2001, 4, 22)),
                new Person("Michael"    ,"Davis"    ,"6@google.com"     ,new DateTime(1977, 8, 7)),
                new Person("Jessica"    ,"Martinez" ,"7@google.com"     ,new DateTime(1995, 12, 31)),
                new Person("David"      ,"Garcia"   ,"8@google.com"     ,new DateTime(1989, 6, 18)),
                new Person("Ashley"     ,"Brown"    ,"9@google.com"     ,new DateTime(2002, 11, 9)),
                new Person("William"    ,"Rodriguez","10@google.com"    ,new DateTime(1979, 7, 28)),
                new Person("Amanda"     ,"Lopez"    ,"11@google.com"    ,new DateTime(1992, 3, 13)),
                new Person("Matthew"    ,"Hernandez","12@google.com"    ,new DateTime(1984, 5, 26)),
                new Person("Jennifer"   ,"Gonzalez" ,"13@google.com"    ,new DateTime(2004, 10, 4)),
                new Person("Christopher","Perez"    ,"14@google.com"    ,new DateTime(1997, 1, 27)),
                new Person("Elizabeth"  ,"Wilson"   ,"15@google.com"    ,new DateTime(1981, 4, 6)),
                new Person("Andrew"     ,"Anderson" ,"16@google.com"    ,new DateTime(2000, 8, 19)),
                new Person("Stephanie"  ,"Thomas"   ,"17@google.com"    ,new DateTime(1993, 9, 14)),
                new Person("Joshua"     ,"Jackson"  ,"18@google.com"    ,new DateTime(1986, 11, 2)),
                new Person("Megan"      ,"White"    ,"19@google.com"    ,new DateTime(2003, 1, 1)),
                new Person("Kevin"      ,"Harris"   ,"20@google.com"    ,new DateTime(1975, 6, 30)),
                new Person("Lauren"     ,"Martin"   ,"21@google.com"    ,new DateTime(1996, 2, 12)),
                new Person("Anthony"    ,"Thompson" ,"22@google.com"    ,new DateTime(1990, 3, 30)),
                new Person("Brittany"   ,"Moore"    ,"23@google.com"    ,new DateTime(2006, 7, 8)),
                new Person("Daniel"     ,"Young"    ,"24@google.com"    ,new DateTime(1978, 10, 16)),
                new Person("Melissa"    ,"Allen"    ,"25@google.com"    ,new DateTime(1994, 12, 24)),
                new Person("Ryan"       ,"King"     ,"26@google.com"    ,new DateTime(1982, 2, 17)),
                new Person("Victoria"   ,"Wright"   ,"27@google.com"    ,new DateTime(2002, 5, 21)),
                new Person("Joseph"     ,"Scott"    ,"28@google.com"    ,new DateTime(1999, 8, 23)),
                new Person("Samantha"   ,"Green"    ,"29@google.com"    ,new DateTime(1987, 11, 5)),
                new Person("Brandon"    ,"Baker"    ,"30@google.com"    ,new DateTime(2001, 1, 2)),
                new Person("Sarah"      ,"Mitchell" ,"54@google.com"    ,new DateTime(1998, 6, 15)),
                new Person("Matthew"    ,"Graham"   ,"55@google.com"    ,new DateTime(1985, 9, 24)),
                new Person("Emily"      ,"Turner"   ,"56@google.com"    ,new DateTime(2002, 4, 8)),
                new Person("Christopher","Bennett"  ,"57@google.com"    ,new DateTime(1977, 7, 11)),
                new Person("Lauren"     ,"Chen"     ,"58@google.com"    ,new DateTime(1995, 12, 19)),
                new Person("Joshua"     ,"Nguyen"   ,"59@google.com"    ,new DateTime(1989, 8, 26)),
                new Person("Avery"      ,"Liu"      ,"60@google.com"    ,new DateTime(2004, 5, 9)),
                new Person("William"    ,"Wang"     ,"61@google.com"    ,new DateTime(1979, 11, 22)),
                new Person("Amanda"     ,"Lin"      ,"62@google.com"    ,new DateTime(1992, 5, 3)),
                new Person("Victoria"   ,"Zhang"    ,"63@google.com"    ,new DateTime(1984, 6, 16)),
                new Person("Matthew"    ,"Liu"      ,"64@google.com"    ,new DateTime(2003, 9, 23)),
                new Person("Elizabeth"  ,"Wu"       ,"65@google.com"    ,new DateTime(1981, 1, 12)),
                new Person("Andrew"     ,"Tan"      ,"66@google.com"    ,new DateTime(2000, 10, 14)),
                new Person("Stephanie"  ,"Zhao"     ,"67@google.com"    ,new DateTime(1993, 2, 27)),
                new Person("Jonathan"   ,"Xu"       ,"68@google.com"    ,new DateTime(1986, 4, 30)),
                new Person("Megan"      ,"Zhou"     ,"69@google.com"    ,new DateTime(2005, 1, 1)),
                new Person("Kevin"      ,"Gao"      ,"70@google.com"    ,new DateTime(1975, 8, 8)),
                new Person("Sophia"     ,"Huang"    ,"71@google.com"    ,new DateTime(1996, 6, 7)),
                new Person("Benjamin"   ,"Cheng"    ,"72@google.com"    ,new DateTime(1990, 3, 30)),
                new Person("Grace"      ,"Li"       ,"73@google.com"    ,new DateTime(2006, 7, 8))
            };

            Persons = p;
        }

        internal static void SortHandler(object sender, DataGridSortingEventArgs e)
        {
            var data = (IEnumerable<Person>)((DataGrid)sender).ItemsSource;
            var sortMemberPath = e.Column.SortMemberPath;

            if (sortDirection == null)
            {
                sortDirection = ListSortDirection.Ascending;
            }
            else
            {
                sortDirection = sortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
            }

            var sortedData = sortDirection == ListSortDirection.Ascending ? data.OrderBy(x => x.GetType().GetProperty(sortMemberPath).GetValue(x, null)) : data.OrderByDescending(x => x.GetType().GetProperty(sortMemberPath).GetValue(x, null));

            e.Handled = true;

            ((DataGrid)sender).ItemsSource = sortedData;
        }

        internal static void AddPerson(Person person)
        {
            Persons.Add(person);
        }

        internal static void RemovePerson(Person person)
        {
            Persons.RemoveAll(x => x.Name == person.Name && x.Surname == person.Surname && x.DateOfBirth == person.DateOfBirth && x.EmailAddress == person.EmailAddress);
        }

        internal static void UpdatePerson(Person person)
        {
            var index = Persons.FindIndex(x => x.Name == person.Name && x.Surname == person.Surname);
            if (index >= 0 && index < Persons.Count)
            {
                Persons[index] = person;
            }
         
        }
    }
}
