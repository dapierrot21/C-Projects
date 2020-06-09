using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hat.Model;

namespace Hat.Data
{
    //Handles data from HatController.
    public class HatRepository
    {
        // HatModel typed list.
        private static List<HatModel> _hatList = new List<HatModel>();
        
        // Adds Hat object to list.
        public HatModel AddCreatedHatToList(HatModel hat)
        {
            _hatList.Add(hat);
            return hat;
        }

        //Display all Hats in list.
        public List<HatModel> ReadAll()
        {
            return _hatList;
        }

        //Looks up the Hat object by Id.
        public HatModel SearchById(int id)
        {
            HatModel hat = _hatList.Find(hatid => hatid.Id == id);
            return hat;
        }

        //Updates and Validates.
        public void Update(int id, HatModel hat)
        {
            if(DoesExists(id))
            {
                 id = _hatList.FindIndex(hatid => hatid.Id == id);
                _hatList[id] = hat;
            }
        }

        //Delete and Validates.
        public void Delete(int id)
        {
            if(DoesExists(id))
            {
               HatModel hat = _hatList.Find(hatid => hatid.Id == id);
                _hatList.Remove(hat);
            }
        }

        //Validates.
        public bool DoesExists(int id)
        {
            bool exists = _hatList.Exists(hatid => hatid.Id == id);
            if(exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
