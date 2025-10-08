using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySlipApp
{
    internal class Manager : Staff
    {
        private const float managerHourlyRate = 50;

        public Manager(string name) : base(name, managerHourlyRate)
        {
        }

        public int Allowance {  get; private set; }

        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;
            if (HoursWorked > 160)
                TotalPay = BasicPay + Allowance;
        }

        public override string ToString()
        {
            return base.ToString() + "\n" +
                $"Allowance:\t\t{Allowance}";
        }
    }
}
