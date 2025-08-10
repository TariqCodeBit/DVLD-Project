using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Fill_project.Global_Classes
{
    public class ClsValdtion
    {

        public static bool ValidateEmail(string emailAddress)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            var regex = new Regex(pattern);
            return regex.IsMatch(emailAddress);
        }

        public static bool ValidateInteger(string Number)
        {
            return int.TryParse(Number, out _);
        }
        public static bool ValidateFloat(string Number)
        {
            return double.TryParse(Number, out _);
        }

        public static bool ISNumber(string Number)
        {
            return (ValidateFloat(Number) || ValidateInteger(Number));
        }
    }
}
