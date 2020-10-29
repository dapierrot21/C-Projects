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
    public class CarNewOrUsedTypeRepositoryADO : ICarNewOrUsedTypeRepository
    {
        public List<CarNewOrUsedType> GetAll()
        {
            List<CarNewOrUsedType> newOrUsedTypes = new List<CarNewOrUsedType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectAllNewOrUsed", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CarNewOrUsedType currentRow = new CarNewOrUsedType
                        {
                            TypeId = (int)dr["TypeId"],
                            TypeName = dr["TypeName"].ToString()
                        };

                        newOrUsedTypes.Add(currentRow);
                    }
                }
            }

            return newOrUsedTypes;
        }
    }
}
