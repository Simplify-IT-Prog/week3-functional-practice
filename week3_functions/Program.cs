using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3_functions
{
    public class Program
    {

        public static int sumOfArray(int[] arr)
        {
             // PART 0
             // Write a function that calculates the sum of all the numbers in an array

            int sum = 0;
            for(int i=0; i <= arr.GetUpperBound(0); i++) 
            {
                sum += arr[i];
            }
            return sum;
        }


         // PART 1
         // Write a function that takes two numbers as arguments and computes the sum of those two numbers.
         
        public static Func<int, int, int> sum = (int a, int b) => (a + b);

        //public static int sum(int a, int b)
        //{
        //    return (a+b);         // or see the Func delegate above.
        //}

        public static int sumAll(params int[] nums)
        {
         // PART 1B
         // Write a function that handles any ampunt of numbers as input and computes the sum of those numbers
            return sumOfArray(nums);
        }


        public static Func<int, int, bool> IsFactor = (int dividend, int divisor) => (dividend % divisor == 0) ? true : false;

        public static int GCD(int a, int b)
        {
            // PART 2
            // write a function that finds the Greatest Common Denominator of two numbers
            // - if no GCD exists, return 1
            int calc_GCD = 1;


            List<int> factors_a = new List<int>();
            List<int> factors_b = new List<int>();

            for (int i = 1; i <= a; i++)
                { if (IsFactor(a, i)) { factors_a.Add(i); } }
            for (int i = 1; i <= b; i++)
                { if (IsFactor(b, i)) { factors_b.Add(i); } }

            foreach (int i in factors_a)
            {
                foreach (int j in factors_b)
                {
                    if (i==j && i > calc_GCD) { calc_GCD = i; }
                }
            }
            return calc_GCD;
        }

        public static int GCD_Efficient(int a, int b)
        {
            int calc_GCD = 1;
            int biggerValue = a > b ? a : b;
            int lesserValue = a < b ? a : b;

            for (int i = lesserValue; i >= 1; i--)
            { if (lesserValue % i == 0)
                {
                    for (int j = biggerValue; j >= 1; j--)
                    {
                        if ((biggerValue % j == 0) && j == i)
                        {
                            calc_GCD = j;
                            break;
                        }
                    }
                }
                if (calc_GCD != 1) { break; }
            }
            return calc_GCD;
        }


        public static int LCM(int a, int b)
        {          // PART 3
            //write a function that prints out the Least Common Multiple of two numbers
            int calc_LCM = 0;
            int biggerValue = a > b ? a : b;
            int lesserValue = a < b ? a : b;
            int bigCount = 0;
            int lesserCount = 0;

            if (a == 0 || b == 0) { return biggerValue; } else
            {
                do
                {
                    bigCount += 1;
                    do
                    {
                        lesserCount += 1;
                        calc_LCM = (biggerValue * bigCount == lesserValue * lesserCount) ? biggerValue * bigCount : 0;
                    } while (lesserValue * lesserCount <= biggerValue * bigCount && calc_LCM == 0);
                } while (calc_LCM == 0);
                return calc_LCM;
            }
        }



        public static string fizzbuzz(int n)
        {
            /**
            * Part 4
            *
            * write a function the returns a FizzBuzz string for some number N (counting up from 1).
            * - for every number that isn't a multiple of 3 or 5, return a period "."
            * - for every number that is a multiple of 3 (but not 5), return "fizz"
            * - for every number that is a multiple of 5 (but not 3), return "buzz"
            * - for every number that is a multiple of 3 and 5, return "fizzbuzz"
            */
            string combinedString = "";
            for (int i = 1; i<=n; i++)
            {
                if (i%3==0&&i%5==0) { combinedString += "fizzbuzz"; } else 
                if (i%3 == 0 && i%5 != 0) { combinedString += "fizz"; } else
                if (i%3 != 0 && i%5 == 0) { combinedString += "buzz"; } else
                if (i%3 != 0 && i%5 != 0) { combinedString += "."; }
            }
            return combinedString;
        }


         // PART 5
         // Define a function max() that takes two numbers as arguments and returns the largest of them. Use the if-then-else construct available in Javascript.

        public static Func<int, int, int> max = (int a, int b) => ((a > b) ? a : b);
        //public static int max(int a, int b)
        //{
        //    return (a > b) ? a : b;  // or see the Func above
        //}

        public static int maxOfThree(int a, int b, int c)
        {
            // PART 6
            // Define a function maxOfThree() that takes three numbers as arguments and returns the largest of them.
            return max(max(a, b), c);
        }

        public static int maxOfAll(params int[] nums)
        {
            // PART 6B
            // Define a function maxOfAll() that takes any amount of numbers as arguments and returns the largest of them.
            int maxNum = nums[0];
            for (int i=0; i<nums.GetUpperBound(0); i++)
            {
                maxNum = max(maxNum, nums[i + 1]);
            }
            return maxNum;
        }


        public static bool isVowel(char c)
        {
            // PART 7
            // Write a function isVowel() that takes a character (i.e. a string of length 1) and returns true if it is a vowel, false otherwise.
            switch (c.ToString())
            {
                case "a":
                case "e":
                case "i":
                case "o":
                case "u":
                case "A":
                case "E":
                case "I":
                case "O":
                case "U":
                    return true;
                    break;
                default:
                    return false;
                    break;
            }
        }

        public static string rovarspraket(string s)
        {
            // PART 8
            // Write a function rovarspraket() that will translate a text into a "rövarspråket". That is, double every consonant and place an occurrence of "o" in between.
            // For example, rovarspraket("this is fun") should return the string "tothohisos isos fofunon".
            string rovarspraket = "";

            foreach (char character in s)
            {
                rovarspraket += ((isVowel(character)) ?  character.ToString() : (character + "o" + character));
            }
            return rovarspraket;
        }

        public static string reverse(string str)
        {
            // Part 9
            // Define a function reverse() that computes the reversal of a string. For example, reverse("skoob") should return the string "books".
            string reverse_STR="";
            char[] arrayCHAR = str.ToCharArray();
            for  (int i = arrayCHAR.GetUpperBound(0); i>=0; i--)
            {
                reverse_STR = reverse_STR + arrayCHAR[i].ToString();
            }
            return reverse_STR;
        }

        public static string findLongestWord(string sentence)
        {
            // Part 10
            // Write a function findLongestWord() that takes an string returns the first, longest word in the string. i.e. findLongestWord("book dogs") should return "book".
            char[] arraySeparators = { ' ', '\'' };
            string[] arraySubStrings = sentence.Split(arraySeparators);
            string largestWord = "";

            foreach (string word in arraySubStrings)
            {
                largestWord = (word.Length > largestWord.Length ? word : largestWord);
            }
            return largestWord;
        }

        public static void Main()
        {
            Debug.Assert(sumOfArray(new int[] { 1, 2 }) == 3);
            Debug.Assert(sumOfArray(new int[] { }) == 0);
            Debug.Assert(sumOfArray(new int[] { 1, 2, 3 }) == 6);
            Debug.Assert(sumOfArray(new int[] { 10, 9, 8 }) == 27);

            Debug.Assert(sum(8, 11) == 19);
            Debug.Assert(sum(4, 100) == 104);

            Debug.Assert(sumAll(8, 11) == 19);
            Debug.Assert(sumAll(4, 100) == 104);
            Debug.Assert(sumAll(8, 11, 20, 30, 11) == 80);
            Debug.Assert(sumAll(4, 100, 1, 4, -10, 15, 21) == 135);

            Debug.Assert(GCD(5, 1) == 1);
            Debug.Assert(GCD(15, 3) == 3);
            Debug.Assert(GCD(15, 5) == 5);
            Debug.Assert(GCD(50, 20) == 10);

            Debug.Assert(GCD_Efficient(5, 1) == 1);
            Debug.Assert(GCD_Efficient(15, 3) == 3);
            Debug.Assert(GCD_Efficient(15, 5) == 5);
            Debug.Assert(GCD_Efficient(50, 20) == 10);

            Debug.Assert(LCM(10, 10) == 10);
            Debug.Assert(LCM(2, 5) == 10);
            Debug.Assert(LCM(3, 6) == 6);
            Debug.Assert(LCM(0, 1) == 1);

            Debug.Assert(fizzbuzz(1) == ".");
            Debug.Assert(fizzbuzz(2) == "..");
            Debug.Assert(fizzbuzz(3) == "..fizz");
            Debug.Assert(fizzbuzz(5) == "..fizz.buzz");
            Debug.Assert(fizzbuzz(10) == "..fizz.buzzfizz..fizzbuzz");

            Debug.Assert(max(1, 3) == 3);
            Debug.Assert(max(0, 3) == 3);
            Debug.Assert(max(10, 3) == 10);
            Debug.Assert(max(-1, -3) == -1);

            Debug.Assert(maxOfThree(1, 3, 2) == 3);
            Debug.Assert(maxOfThree(0, 3, -1) == 3);
            Debug.Assert(maxOfThree(10, 3, 50) == 50);
            Debug.Assert(maxOfThree(-1, -3, -10) == -1);
            Debug.Assert(maxOfAll(-30, -50, -1, -3, -10, -11, -20) == -1);
            Debug.Assert(maxOfAll(10, 20, 11, 53, 100, 211, -20) == 211);

            Debug.Assert(isVowel('B') == false);
            Debug.Assert(isVowel('b') == false);
            Debug.Assert(isVowel('a') == true);
            Debug.Assert(isVowel('E') == true);

            Debug.Assert(rovarspraket("a") == "a");
            Debug.Assert(rovarspraket("b") == "bob");
            Debug.Assert(rovarspraket("cat") == "cocatot");
            Debug.Assert(rovarspraket("javascript") == "jojavovasoscocroripoptot");

            Debug.Assert(reverse("books") == "skoob");
            Debug.Assert(reverse("we don't want no trouble") == "elbuort on tnaw t'nod ew");

            Debug.Assert(findLongestWord("book dogs") == "book");
            Debug.Assert(findLongestWord("don't mess with Texas") == "Texas");

            Console.WriteLine("Finished! All tests passed.");
            Console.ReadLine();
        }
    }
}

