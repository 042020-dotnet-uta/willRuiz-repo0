using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge2
{
    class Even
    {
        
        string inputNumber;
        int number;


        //Validates and prints if the number the user entered was odd or even
        public void IsTheNumberEven()
        {
                Console.Clear();
                string result = "";
                Console.WriteLine("Question 1:  Please enter a number \n");
                inputNumber = Console.ReadLine();

                if (!string.IsNullOrEmpty(inputNumber) && int.TryParse(inputNumber, out number))
                {

                    if (number % 2 == 0) result = "That number is even";

                    else result = "That number is Odd";
                }
                else { result = "Input is not a number"; }
                Console.WriteLine(result);      
        }

    }
}
