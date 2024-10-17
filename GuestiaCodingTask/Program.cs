using GuestiaCodingTask.Data;
using GuestiaCodingTask.Helpers;
using System;
using System.Linq;
using GuestiaCodingTask.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GuestiaCodingTask
{
    class Program
    {
        static string Csv(string input)
        {
            if (input.IndexOf(',') >= 0 || input.IndexOf('\"') >= 0)
            {
                return $"\"{input.Replace("\"", "\"\"")}\"";
            }

            return input;
        }
        
        static void Main(string[] args)
        {
            DbInitialiser.CreateDb();

            var context = new GuestiaContext();

            var guests = from x in context.Guests.Include(y => y.GuestGroup) 
                where !x.RegistrationDate.HasValue 
                orderby x.GuestGroup descending, x.LastName, x.FirstName
                select x;

            var guestList = from x in guests select new GuestReportItem(x);

            Console.Out.WriteLine("Group,Guest");
            foreach (var reportItem in guestList)
            {
                Console.Out.WriteLine($"{Csv(reportItem.GroupName)},{Csv(reportItem.GuestName)}");
            }
        }
    }
}
