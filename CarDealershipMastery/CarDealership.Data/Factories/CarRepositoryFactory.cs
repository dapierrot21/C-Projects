using CarDealership.Data.ADO;
using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Factories
{
    public static class CarRepositoryFactory
    {
        public static ICarRepository GetRepository()
        {
            switch(Settings.GetRepositoryType())
            {
                case "ADO":
                    return new CarRepositoryADO();
                default:
                    throw new Exception("Could not find value RepositoryType config value. Check Web.config");
            }
        }
    }
}
