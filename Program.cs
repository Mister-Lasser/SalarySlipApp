using SalarySlipApp;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Staff> listOfStaff = new List<Staff>();
            FileReader fileReader = new FileReader();

            int month = 0;
            int year = 0;

            while (year == 0)
            {
                Console.WriteLine("\nPlease enter the year: ");
                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                } catch (FormatException)
                {
                    Console.Error.WriteLine("Try entering a valid year.\n E.g. 2009");
                    year= 0;
                }
            }

            while (month == 0)
            {
                Console.WriteLine("\nPlease enter the month number: ");
                try
                {
                    month = Convert.ToInt32(Console.ReadLine());
                    if (month < 1 || month > 12)
                    {
                        Console.Error.WriteLine("Invalid month.");
                        month = 0;
                    }
                }
                catch (FormatException)
                {
                    Console.Error.WriteLine("Try entering a valid month.\n " +
                        "E.g. 1 for January, 2 for February, etc.");
                }
            }

            listOfStaff = fileReader.ReadFile();

            for (int i = 0; i < listOfStaff.Count; i++)
            {
                try
                {
                    Console.WriteLine($"Enter hours worked for {listOfStaff[i].NameOfStaff}");
                    listOfStaff[i].HoursWorked = Convert.ToInt32(Console.ReadLine());
                    listOfStaff[i].CalculatePay();
                    Console.WriteLine(listOfStaff[i].ToString());
                } catch (Exception e)
                {
                    Console.WriteLine(e);
                    i--;
                }
            }

            PaySlip paySlip = new PaySlip(month, year);

            paySlip.GeneratePaySlip(listOfStaff);
            paySlip.GenerateSummary(listOfStaff);

            Console.Read();
        }
    }
}