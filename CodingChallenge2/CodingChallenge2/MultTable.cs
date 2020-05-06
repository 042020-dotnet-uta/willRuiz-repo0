using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge2
{
    
    class MultTable
    {
        
        string inputNumber;
        int number;

        //Prints multiplication table based on user input
        public void Mult_Table()
        {
            
                Console.Write("Question 2: Enter a whole number 1-3 or, or type exit to return to main menu \n");

                inputNumber = Console.ReadLine();

                if (!string.IsNullOrEmpty(inputNumber) && int.TryParse(inputNumber, out number) && number > 0 && number < 4)
                {
                    for (int i = 1; i <= number; i++)
                    {
                        for (int j = 1; j <= number; j++)
                        {
                            Console.WriteLine(i + " x " + j + " = " + i * j + " , ");
                        }
                    }
                }
                else { Console.WriteLine("Please enter a valid whole number"); }
                
                
            

        }

    }
}
