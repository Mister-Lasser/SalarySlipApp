using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySlipApp
{
    internal class Staff
    {
        //fields
        private float hourlyRate;
        private int hWorked;

        //constructor
        public Staff(string name, float rate)
        {
            NameOfStaff = name;
            hourlyRate = rate;
        }

        //properties
        public float TotalPay {  get; protected set; }
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }
        public int HoursWorked {
            get
            {
                return hWorked;
            }
            set
            {
                if (hWorked > 0)
                    hWorked = value;
                else
                    hWorked = 0;
            }  
        }

        //methods

        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating pay...");
            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return 
                $"Name:\t\t{NameOfStaff}\n" +
                $"Hours Worked:\t\t{HoursWorked}\n" +
                $"Basic Pay:\t\t{BasicPay}\n" +
                $"Total Pay:\t\t{TotalPay}";
        }
        
    }
}
