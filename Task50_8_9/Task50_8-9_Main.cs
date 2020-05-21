//using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Task50_8_9
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Task8 task8Script = new Task8();
            Console.Write("Result: " + task8Script.RefreshPageScript());

            Task9 task9Script = new Task9();
            task9Script.TablePage();
            task9Script.SelectEntries();

            List<Emploee> emploeeList = new List<Emploee>(task9Script.filterGrid(59, 322000));

            foreach(Emploee emploee in emploeeList)
            {
                Console.WriteLine($"Name: {emploee.Name}, Office: {emploee.Office}, Position: {emploee.Position}, Age: {emploee.Age}, Salary: {emploee.Salary}");
            }
        }
    }
}
