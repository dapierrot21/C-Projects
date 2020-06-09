using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatViews;
using Hat.Data;
using Hat.Model;

namespace Hat.Controller
{
    public class HatController
    {
        private List<HatModel> _showHatList;
        private HatView _views;
        private HatRepository _HatRepo;

        //The state of this object when initializied.
        public HatController()
        {
            _views = new HatView();
            _showHatList = new List<HatModel>();
            _HatRepo = new HatRepository();
        }

        public void Run()
        {
            Console.WriteLine("Welcome to Hat Manager");
            Console.WriteLine("As you can tell this program helps you manage your hats!");
            Console.WriteLine("Below you will be presented with options to interact with Hat Manager. Please Enjoy.\n");

            while(true)
            {
                int result = _views.UserChoice("Choose 1 of 5 choices: 1. To create a hat, 2. List all of hats, 3. Find Hat by Id, 4. To edit a previous entered hat, 5. To Remove a hat.");
                switch(result)
                {
                    case 1:
                        CreateAHat();
                        break;
                    case 2:
                        DisplayHats();
                        break;
                    case 3:
                        SearchHats();
                        break;
                    case 4:
                        EditHats();
                        break;
                    case 5:
                        RemoveHat();
                        break;
                    default:
                        break;
                }

                string response = _views.YesOrNo("Do you want to keep using this app? Yes/No");

                if(response.ToUpper() == "NO")
                {
                    Console.WriteLine("Thanks for using Hat Manager!");
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Let's get it then");
                }
            }
        }

        private void CreateAHat()
        {
            _HatRepo.AddCreatedHatToList(_views.CreateHatModel());
        }

        private void DisplayHats()
        {
            _showHatList = _HatRepo.ReadAll();

            if(_showHatList.Count != 0)
            {
                foreach (HatModel hat in _showHatList)

                    _views.ListHats(hat);
            }
            else
            {
                Console.WriteLine("There's nothing to display");
            }
        }

        private void SearchHats()
        {
            int id = _views.EnteredHatId();
            bool exists = _HatRepo.DoesExists(id);

            if(exists)
            {
               _views.ListHats(_HatRepo.SearchById(id));             
            }
            else
            {
                Console.WriteLine("Could not find that Hat Id.");
            }
        }

        private void EditHats()
        {

            int id = _views.EnteredHatId();
            bool exists = _HatRepo.DoesExists(id);

            if(exists)
            {
                HatModel hat = _views.EditHatModel(_HatRepo.SearchById(id));

                if(_views.ValidateHat(hat))
                {
                    _HatRepo.Update(id, hat);
                }
            }
            else
            {
                Console.WriteLine("Hat Id doesn't exist.");
            }
        }

        private void RemoveHat()
        {
            int id = _views.EnteredHatId();
            bool exists = _HatRepo.DoesExists(id);

            if(exists)
            {
                HatModel hatModel = _HatRepo.SearchById(id);

                if(_views.ValidateHat(hatModel))
                {
                    _HatRepo.Delete(id);
                }
            }
            else
            {
                Console.WriteLine("Hat Id doesn't exists.");
            }
        }

    }
}
