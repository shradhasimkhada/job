using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace cross_Loan
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read Textfile
            string[] lines = File.ReadAllLines(@"C:\Users\shrad\Documents\job\Cross_key\prospects.txt");
            Console.WriteLine("Mortgagae Loan Customer Detail");

            //run eachline skiiping the header
            foreach (var line in lines.Skip(1))
            {
                //Parse expression
                var matches = new Regex("((?<=\")[^\"]*(?=\"(,|$)+)|(?<=,|^)[^,\"]*(?=,|$))").Matches(line).ToArray();


                //Assign values
                //Reading customer info
                string customer = (matches[0].Value);
                // Console.WriteLine(customer);

                //Assign Year
                string year = matches[3].Value;
                // Console.WriteLine(year);

                //Calculate no of payments
                float p = (float.Parse(matches[3].Value)) * 12;
                //Console.WriteLine(p);

                //Calculate Interest rate on monthly basis
                float b = (float.Parse(matches[2].Value)) / 1200;
                //Console.WriteLine(b);

                //Total Loan
                float U = (float.Parse(matches[1].Value));
                //Console.WriteLine(U);

                float b1 = 1 + b;
                // Console.WriteLine(b1);
                // Console.Write("{0} test of power", b1)


                float c = (float)Math.Pow(b1, p);
                // Console.WriteLine(c);

                //Monthly Payment for loan
                float E = U * ((b * c)) / (c - 1);
                //  Console.WriteLine(E);
                Console.WriteLine("#{0} wants to borrow {1} for a period of {2} years and pay {3} each month", customer, U, year, E);


            }


            Console.ReadKey(true);


        }
    }
}
