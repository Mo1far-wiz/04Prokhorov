using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _04Prokhorov.Model.CustomException
{
    internal class AgeTooLowException : Exception
    {
        public AgeTooLowException(string message) : base(message)
        {
            MessageBox.Show("didn't born");
        }


    }
}
