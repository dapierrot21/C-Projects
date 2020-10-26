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
            List<CarNewOrUsedType> type = new List<CarNewOrUsedType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectAllType", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CarNewOrUsedType currentRow = new CarNewOrUsedType();
                        currentRow.TypeId = (int)dr["TypeId"];
                        currentRow.TypeName = dr["TypeName"].ToString();

                        type.Add(currentRow);
                    }
                }
            }

            return type;
        }
    }
}
