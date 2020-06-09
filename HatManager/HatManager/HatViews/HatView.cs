using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hat.Model;

namespace HatViews
{
    public class HatView
    {
        private HatModel hat;

        string userInput;

        public int UserChoice(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int results))
                {
                    if (results <= 5)
                    {
                        return results;
                    }
                }
                Console.WriteLine("That input was incorrect. Try again.");
            }
        }
        
        public decimal UserCost(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                userInput = Console.ReadLine();

                if (decimal.TryParse(userInput, out decimal results))
                {
                    if (results > 0)
                    {
                        return results;
                    }
                }
                Console.WriteLine("That input was incorrect. Try again.");
            }
        }

        public int UserIntInput(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int results))
                {
                    return results;
                }
                Console.WriteLine("That input was incorrect. Try again.");

            }
            
        }

        // Creating a Hat model.
        public HatModel CreateHatModel()
        {
            hat = new HatModel();
            Console.WriteLine("Let's fill out some infomation about your hat.");
            hat.Id = UserIntInput("Please enter a Id number for this hat.");
            Console.WriteLine("Please enter the brand name of this hat.");
            hat.Name = Console.ReadLine();
            Console.WriteLine("Please enter the color of this hat.");
            hat.Color = Console.ReadLine();
            hat.Cost = UserCost("Please enter the cost of this hat.");
            hat.InStock = true;

            return hat;
        }



        public HatModel EditHatModel(HatModel hatModel)
        {
            
            Console.WriteLine("Edit your Hat. The Id will not be include, it will remain the same.");
            Console.WriteLine("Hat Id: " + hatModel.Id);
            Console.WriteLine("Please enter the brand name of this hat.");
            hat.Name = Console.ReadLine();
            Console.WriteLine("Please enter the color of this hat.");
            hat.Color = Console.ReadLine();
            hat.Cost = UserCost("Please enter the cost of this hat.");
            hat.InStock = true;

            return hat;

        }



        // List all Hats 
        public void ListHats(HatModel hat)
        {
            Console.WriteLine("---------------------");

            if (hat.InStock == true)
            {
                Console.WriteLine("Hat Id: " + hat.Id);
                Console.WriteLine("Hat Brand Name: " + hat.Name);
                Console.WriteLine("Hat Color: " + hat.Color);
                Console.WriteLine("Hat Cost: " + hat.Cost);
                Console.WriteLine("Hat InStock: " + hat.InStock);
            }

        }


        // Edit selected Hat.
        public HatModel EditHat(HatModel hat)
        {
            ListHats(hat);
            hat = CreateHatModel();
            return hat;
        }

        //Returns Hat Id
        public int EnteredHatId()
        {
            hat = new HatModel
            {
                Id = UserIntInput("Please enter the Hat Id you would like to see.")
            };

            return hat.Id;
        }
        
        // Validates User Input.
        public bool ValidateHat(HatModel hat)
        {
            ListHats(hat);
            userInput = YesOrNo("Are you sure you want to Create/Edit/Remove this Hat? Yes/No");

            if(userInput.ToUpper() == "YES")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string YesOrNo(string prompt)
        {
            string userInput;

            while(true)
            {
                Console.WriteLine(prompt);
                userInput = Console.ReadLine();
                
                if(userInput.ToUpper() == "YES" || userInput.ToUpper() == "NO")
                {
                    break;
                }
                Console.WriteLine("Please enter either Yes or No.");
            }
            return userInput;
        }
            
    }
}
