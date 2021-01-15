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
    public class InteriorRepositoryADO : IInteriorRepository
    {
        public List<Interior> GetAll()
        {
            List<Interior> interior = new List<Interior>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectAllInteriors", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Interior currentRow = new Interior();
                        currentRow.InteriorId = (int)dr["InteriorId"];
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();

                        interior.Add(currentRow);
                    }
                }
            }

            return interior;
        }
    }
}
