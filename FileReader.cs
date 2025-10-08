﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySlipApp
{
    internal class FileReader
    {
        public List<Staff> ReadFile()
        {
            List<Staff> list = new List<Staff>();
            string[] result = new string[2];
            string path = "staff.txt";
            string[] separator = { ", " };

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.EndOfStream != true)
                    {
                        string line = sr.ReadLine();
                        result = line.Split(separator, StringSplitOptions.None);

                        if (result[1] == "Manager")
                        {
                            list.Add(new Manager(result[0]));
                        } else if (result[1] == "Admin")
                        {
                            list.Add(new Admin(result[0]));
                        }
                    }
                    sr.Close();
                }
            } else
            {
                Console.Error.WriteLine($"No such file named \"{path}\" exists.");
            }

            return list;
        }
    }
}
