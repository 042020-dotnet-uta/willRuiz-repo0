using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp
{
    //OrderPrompt:  Prompts the User to input information
    //Store Locations + Inventory with avaiable Products +(how many) are created on ititialization
    public class OrderPrompt : IOrderPrompt
    {
        public int Id { get; set; }                     //Set the id taken by user console input

        private string fullName;
        private int id;                                 //Id entered by Customer
        private int storeNumber;                        //Store number prompt selected from (1,2,3)
        private string[] products = null;               //Product/s placeholder for Name to set what Products the user will input for purchase purchase (A,B,C)
        private List<int> quantities = new List<int>(); //Quantity/s placeholder taken in prompt for 1+ products

        public OrderPrompt() { }

        private readonly List<Location> availableStores = new List<Location>()
        {
            new Location(1),        //set available store locations (1,2,3)
            new Location(2),
            new Location(3),
        };


        
        // Prompts the user for input
    
        public bool Prompt()
        {                       //Promps user + get full name + save to DB
            try { NamePrompt(); } catch (Exception e) { Console.WriteLine(e.Message); }

            // Get id
            if (IdPrompt())     //If method returns false, go to the next method ...StoreNumberPrompt()
                return true;    //If outcome is true return to top ... re-starts prompt()

            if (StoreNumberPrompt()) return true;   // Get store number


            if (ProductPrompt()) return true;    // Get product


            if (PromptQuantity()) return true;    // Get quantity

            // region - hides display of what the display of what teh customer ordered
            #region 
            // string of the products the user chose
            string productString = "";
            products.ToList().ForEach(p => productString += $"| {p} | ");

            // string of the quantites the user chose
            string quantityString = "";
            quantities.ForEach(q => quantityString += $"| {q} | ");


            // Display the prodcuts + their quantities

            Console.WriteLine($"\n\nThank you for choosing product {productString} with a quantity of {quantityString} ...Have a nice day");

            Console.ReadKey(true); //Keeps program up after all user inputs ... just press enter to get to next line
            #endregion          

            return false;   //false break out of the loop ... end program
        }
    

        
        // Prompts the user for their full name
        private void NamePrompt()
        {
            
            while (true)
            {                                               // Prompt user for input
                Console.Write("Welcome to XYZ store Please enter your full name: \n\n >");
                                                           //store user input
                fullName = Console.ReadLine();

                // Validate input (name can't be empty or number value)
                if (!string.IsNullOrEmpty(fullName) && !int.TryParse(fullName, out _))// out _ is a Discard dummy var
                {
                     string[] n = fullName.Split(' ');
                    CustomersCollection c = new CustomersCollection();
                    c.AddCustomer(n[0], n[1]);                          //save Customer to the DB
                    

                    break; //break loop ... next line code after this method
                }
                else
                    Console.WriteLine("\nThe name cannot be a number or an empty space");
            }       //statement is still true ... starts the loop over

            
        }

       
        // Prompts the user for their ID, if user chose q return them to main menu
        
        private bool IdPrompt()
        {
            while (true)
            {                                       // Prompt use for input
                Console.Write("\nPlease enter your ID or q to return to the main menu: \n\n >");
                                                    // Store user input
                string input = Console.ReadLine();
                
                if (input.ToLower() == "q")     return true;

                // Validate input (id should be a positive numerical value)
                else if (!string.IsNullOrEmpty(input) && int.TryParse(input, out id) && id > 0)
                    break;  //breaks out and reads return false;
                else
                    Console.WriteLine("\nThe id must be a positive integar");//back to top of loop
            }
            return false;  //must return false to exit 
        }

        
        // Prompts the user for the store number, if the user chose q return them to main menu
        
        private bool StoreNumberPrompt()
        {
            while (true)
            {
                Console.WriteLine("\nWhich store would you like to puchase from?");       // Prompt user for input
                Console.Write("Please enter the store number (1, 2 or 3) or q to return to the main menu: \n\n >");
                                                                                        // Store user input
                string input = Console.ReadLine();
                
                if (input.ToLower() == "q") return true;
                
                // Validate input (store number can only be 1, 2, 3)
                else if (!string.IsNullOrEmpty(input) && int.TryParse(input, out storeNumber) && storeNumber <= 3 && storeNumber >= 1)
                    break;
                else
                    Console.WriteLine("\nThe store number can only be 1-3");
            }
            return false;
        }

        // Prompts the user for the products, if the user chose q return them to main menu
        private bool ProductPrompt()
        {
            while (true)
            {                                                 // Prompt the user for A B or C + store response as "product"
                Console.WriteLine($"\nThank you for choosing store number [{storeNumber}], What would you like to order?");
                Console.Write("Please choose Products (A B or C) or q to return to the main menu: \n\n > ");
                
                products = Console.ReadLine().ToUpper().Split(' '); //string[] products is being initialized (up to 3 values)
                
                if (products[0].ToLower() == "q") return true;

                // Validate input (product can only be A, B, C) ... 
                else if (products.Where(p => p == "A" || p == "B" || p == "C").Count() == products.Length)
                    break;
                else
                    Console.WriteLine("\nThe products can only be A B or C");
            }
            return false;
        }
    
        // Prompts the user for the quantity, if the user chose q return them to main menu
        private bool PromptQuantity()
        {
            while (true)
            {
                for (int i = 0; i < products.Length;)
                {
                    string product = products[i];                                           //string[] products (A,B or C)
                    Console.Write($"\nPlease enter the quantity (1-{Order.QUANTITY_LIMT}) for prodcut {product} or q to return to the main menu: ");
                    
                    string input = Console.ReadLine();
                    
                    if (input.ToLower() == "q") return true;

                    // Validate input (quantity can only be 1 up to QUANTITY_LIMIT 3 in Order class)
                    else if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int quantity) && quantity <= Order.QUANTITY_LIMT && quantity >= 1)
                    {   //List<Location> availableStores //location Number == out storeNumber line 135

                            //NOT a valid store number(already created 1,2,3) vs. input || Exceeds inventory # 
                        if (!availableStores.Where(s => s.Number == storeNumber).FirstOrDefault()  //output Location w/ store #(input)
                            .ValidateProduct(new Product(product), quantity))  //passing Product(A, B or C) , # 
                        {
                            Console.WriteLine("\nThe order can't be fulfilled");
                            continue;
                        }
                        
                        quantities.Add(quantity);   //Add to the List ...private List<int> quantities = new List<int>();
                        
                        i++;  //update loop 

                        //List<Location> availableStores(3) outputs LocationObj + passed storeNumber is 1,2,3  ...Product is what was selected A,B,C  ...quantity = user input

                        availableStores.Where(s => s.Number == storeNumber).FirstOrDefault().AddProductOrder(new Product(product), quantity);
                    }
                    else
                        Console.WriteLine($"\nThe quantity can only be 1-{Order.QUANTITY_LIMT}");
                }
                break;
            }
            return false;
        }
    }

}
