using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge2
{
    class AlternatingElements
    {
        string inputString;
        

        // 10 user input elements are merged into a single List of alternating values and returned
        public void Shuffle()
        {
            string[] array1 = new string[5];
            string[] array2 = new string[5];

            
            for (int i = 0; i < 5; i++)
            {  
                

                while (true)//Prompt user for elements to fill up the array
                {
                    Console.WriteLine($"Enter Element {i} for 1st array:");
                    inputString = Console.ReadLine();

                    if (!string.IsNullOrEmpty(inputString))
                    {
                        array1[i] = inputString;
                        break; //re-starts while loop for next entry
                    }
                    else Console.WriteLine("You need to enter something ... try again");
                }
                Console.WriteLine($"The 1st array is [ {String.Join(",", array1)} ]");//Shows them what they just entered
            }
            inputString = ""; //reset var for new inputs
            for (int i = 0; i < 5; i++)
            {
                while (true)//Prompt user for elements to fill up the array
                {
                    Console.WriteLine($"Enter Element {i} for 2nd array:");
                    inputString = Console.ReadLine();
                    if (!string.IsNullOrEmpty(inputString))
                    {
                        array1[i] = inputString;
                        break; //re-starts while loop for next entry
                    }
                    else Console.WriteLine("You need to enter something ... try again");
                }
            }
            Console.WriteLine($"The 2nd array is [ {String.Join(",", array1)} ]");

            string[] combinedArray = new string[10];
            string[][] _2d = new string[2][];   //2-Dimentional array 
            _2d[0] = array1;//1st row
            _2d[1] = array2;//2nd row

            //pattern for interating all values of a 2d array
            int counter = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 5; j++)// holds position i until all values of j have cycled through loop
                {
                    if (counter % 2 == 0)
                    {
                        combinedArray[counter] = _2d[i][j]; //alternate entry if even
                        counter++;
                    }
                    else combinedArray[counter] = _2d[i][j]; // alternate entry if odd
                    counter++;
                }
            }
            Console.WriteLine($"Combined Array:  [ {String.Join(",", combinedArray) } ]");
        }
    }
}
