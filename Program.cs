using SalarySlipApp;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Staff staff = new Staff("Jay", 12.12f);
            staff.HoursWorked = 50;
            staff.CalculatePay();
            Console.WriteLine(staff);
        }
    }
}