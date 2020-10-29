using CarDealership.Data.Interfaces;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.ADO
{
    public class CarTypeRepositoryADO : ICarTypeRepository
    {
        public List<CarType> GetAll()
        {
            List<CarType> carTypes = new List<CarType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectAllCarTypes", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CarType currentRow = new CarType();
                        currentRow.CarId = (int)dr["CarId"];
                        currentRow.TypeId = (int)dr["TypeId"];

                        carTypes.Add(currentRow);
                    }
                }
            }

            return carTypes;
        }
    }
}
