using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace day_10_assign_12
{
    internal class Program
    {

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter a piece of text:");
                string inputText = Console.ReadLine();

                // Word Count
                int wordCount = CountWords(inputText);
                Console.WriteLine($"Word Count: {wordCount}");

                // Email Validation
                string[] emails = GetEmailAddresses(inputText);
                Console.WriteLine("Email Addresses found:");
                foreach (string email in emails)
                {
                    Console.WriteLine(email);
                }

                // Mobile Number Extraction
                string[] mobileNumbers = ExtractMobileNumbers(inputText);
                Console.WriteLine("Mobile Numbers found:");
                foreach (string number in mobileNumbers)
                {
                    Console.WriteLine(number);
                }

                // Custom Regex Search
                Console.WriteLine("Please enter a custom regular expression:");
                string customRegex = Console.ReadLine();
                string[] customRegexMatches = PerformCustomRegexSearch(inputText, customRegex);
                if(customRegexMatches.Length > 0 )
                {
                    Console.WriteLine("Custom Regex Matches found");
                    foreach (string match in customRegexMatches)
                    {
                        Console.WriteLine(match);
                    }

                }
                else
                {
                    Console.WriteLine("Custom Regex Match not found.");
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }

        // Word Count
        static int CountWords(string text)
        {
            string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        // Email Validation
        static string[] GetEmailAddresses(string text)
        {
            string emailPattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";
            MatchCollection matches = Regex.Matches(text, emailPattern);
            string[] emails = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                emails[i] = matches[i].Value;
            }
            return emails;
        }

        // Mobile Number Extraction
        static string[] ExtractMobileNumbers(string text)
        {
            string mobileNumberPattern = @"\d{10}";
            MatchCollection matches = Regex.Matches(text, mobileNumberPattern);
            string[] mobileNumbers = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                mobileNumbers[i] = matches[i].Value;
            }
            return mobileNumbers;
        }

        // Custom Regex Search
        static string[] PerformCustomRegexSearch(string text, string customRegex)
        {
            MatchCollection matches = Regex.Matches(text, customRegex);
            string[] customRegexMatches = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                customRegexMatches[i] = matches[i].Value;
            }
            return customRegexMatches;
        }
       

    }
}
