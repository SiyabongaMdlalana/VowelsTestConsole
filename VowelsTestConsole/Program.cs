using System;
using System.Collections.Generic;
using System.Linq;

namespace VowelsTestConsole
{
  public  class Program
    {
        static void Main(string[] args)
        {

            try
            {
                INonVowel nonVowel = new NonVowel();
                IVowel vowel = new Vowel();
                IDuplicate duplicate = new Duplicate();
                IProcessingOperation processingOperation = new ProcessingOperation();


                Console.WriteLine("Enter the text  to be displayed".ToUpper());
                var sentence = Console.ReadLine();
                SelectionMessageTextOptions();
                var selectionOption = Convert.ToInt32(Console.ReadLine());
                switch (selectionOption)
                {
                    case 1:
                        duplicate.DuplicateMessage(duplicate.CheckDuplicates(sentence));
                        vowel.VowelMessage(vowel.GetNumberOfVowels(sentence));
                        break;
                    case 2:
                         vowel.VowelMessage(vowel.GetNumberOfVowels(sentence));
                        break;
                    case 3:
                        nonVowel.NonNovelMessage(nonVowel.GetNumberOfNoneVowels(sentence));
                        break;
                    default:
                        Console.WriteLine("No selection was done");
                        break;
                }
                if (!string.IsNullOrEmpty(sentence))
                {
                    processingOperation.DisplayMessage(vowel.GetNumberOfVowels(sentence), nonVowel.GetNumberOfNoneVowels(sentence));
                }

            }
            catch (Exception ex)
            {

                throw;
            }
          
            Console.ReadLine();
        }

      
        interface IDuplicate {
            string CheckDuplicates(string word);
            void DuplicateMessage(string sentence); 
           
        }

        interface IVowel {
            int GetNumberOfVowels(string word);

            void VowelMessage(int number);
        }

        interface INonVowel
        {
            int GetNumberOfNoneVowels(string noun);
            void NonNovelMessage(int number);
        }
        interface IProcessingOperation
        {
            void DisplayMessage(int vowel, int nonVowel);

        }


        public class Duplicate : IDuplicate
        {
            public string CheckDuplicates(string sentence)
            {
                char[] Array = sentence.ToCharArray();
                var duplicates = Array.GroupBy(p => p).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
                string duplicate = string.Join(",", duplicates.ToArray());
                return duplicate;
            }

            public void DuplicateMessage( string  text)
            {
                if (!string.IsNullOrEmpty(text)) {
                    Console.WriteLine($"Found the following duplicates: {text}");
                }
                else
                {
                    Console.WriteLine($"No duplicate values were found");
                }      
            }

        }

        public class Vowel : IVowel 
        {
            public  int GetNumberOfVowels(string text)
            {
                var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
                var total = text.Count(c => vowels.Contains(c));
                return total;
            }

            public void VowelMessage(int  number)
            {
                if (number > 0) {
                    Console.WriteLine($"The number of vowels is : {number}");
                }
                else
                {
                    Console.WriteLine("No vowels were found.");
                }         
               
            }
        }

        public class NonVowel : INonVowel
        {
            public  int GetNumberOfNoneVowels(string text)
            {
                var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
                var  total = text.Count(c => !vowels.Contains(c));
                return total;
            }

            public void NonNovelMessage(int  number)
            {
                Console.WriteLine($"The number of non vowels is : {number}");
            }
        }

        private static void SelectionMessageTextOptions() 
        {
            Console.WriteLine($"Enter which operations to do on the supplied text,");
            Console.WriteLine("‘1’ for a duplicate character check,");
            Console.WriteLine("‘2’ to count the number of vowels,");
            Console.WriteLine("‘3’ to check if there are more vowels or non vowels,");
            Console.WriteLine("or any combination of ‘1’, ‘2’ and ‘3’ to perform multiple checks");
        }


        
        public class ProcessingOperation : IProcessingOperation
        {
            public void DisplayMessage (int vowel, int nonVowel)
            {
                if (vowel > nonVowel)
                {
                    Console.WriteLine("The text has more vowels than non vowels");
                }
                if (vowel < nonVowel)
                {
                    Console.WriteLine("The text has more non vowels than vowels");
                }
                if (vowel == nonVowel) 
                {
                    Console.WriteLine("The text has an equal amount of vowels and non vowels");
                }


            }

          
        }
    }
}
