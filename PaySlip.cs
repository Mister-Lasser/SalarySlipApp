using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySlipApp
{
    internal class PaySlip
    {
        private int month, year;

        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        enum MonthsOfYear
        {
            JAN = 1, FEB, MAR, APR, MAY, JUN, 
            JUL, AUG, SEP, OCT, NOV, DEC
        }

        public void GeneratePaySlip(List<Staff> list)
        {
            string path;
            foreach (Staff staff in list)
            {
                path = $"{staff.NameOfStaff}.txt";
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine($"PATSLIP OF {(MonthsOfYear) month} {year}");
                    sw.WriteLine("=============================================");
                    sw.WriteLine($"Name of Staff: {staff.NameOfStaff}");
                    sw.WriteLine($"Hours Worked: {staff.HoursWorked}");
                    sw.WriteLine();
                    sw.WriteLine($"Basic Pay: {staff.BasicPay}");
                    if (staff.GetType().Name == "Manager")
                        sw.WriteLine($"Allowance: {((Manager)staff).Allowance}");
                    else if (staff.GetType().Name == "Admin")
                        sw.WriteLine($"Overtime Pay: {((Admin)staff).Overtime}");
                    sw.WriteLine();
                    sw.WriteLine("=============================================");
                    sw.WriteLine($"Total Pay: {staff.TotalPay}");
                    sw.WriteLine("=============================================");

                    sw.Close();
                }
            }
        }

        public void GenerateSummary(List<Staff> list)
        {
            var result = from staff in list
                         where staff.HoursWorked < 10
                         orderby staff.NameOfStaff ascending
                         select staff;

            string path = "summary.txt";

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Staff with less than 10 working hours:");
                sw.WriteLine();

                foreach(var staff in result)
                {
                    sw.WriteLine($"Name of Staff: {staff.NameOfStaff}, Hours worked: {staff.HoursWorked}");
                }
                sw.Close();
            }
        }


    
    }
}
