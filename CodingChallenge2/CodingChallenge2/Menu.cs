using System;
namespace CodingChallenge2
{
    class Menu
    {
        //Menu displayed to the User
        public void Run()
        {
            
            int number;


            do
            {

                try
                {
                    printMenu();

                    
                    number = Int32.Parse(Console.ReadLine());

                    switch (number)
                    {
                        case 0:
                            break;
                        case 1:
                            new Even().IsTheNumberEven();
                            break;
                        case 2:
                            new MultTable().Mult_Table();
                            break;
                        case 3:
                            new AlternatingElements().Shuffle();
                            break;
                    }
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                    Console.Clear();
                }
                catch (System.Exception e)
                    { Console.WriteLine(e.Message + "\nPress enter to continue"); }

            } while (true);
        }

                public void printMenu() 
                {
                    Console.WriteLine("Welcome to Coding Challenge #2 ... Choose a number to start\n");
                    Console.WriteLine("\t 0=Exit \t 1 = Question 1 \t 2 = Questoin 2 \t  3 = Question 3  \n");
                }

        }
    }





