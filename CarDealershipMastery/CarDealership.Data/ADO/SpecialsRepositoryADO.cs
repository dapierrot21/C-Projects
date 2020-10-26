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
    public class SpecialsRepositoryADO : ISpecialsRepositroy
    {
        public List<Specials> GetAll()
        {
            List<Specials> specials = new List<Specials>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectAllSpecials", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Specials currentRow = new Specials();
                        currentRow.SpecialsId = (int)dr["Specials"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.Description = dr["Description"].ToString();

                        specials.Add(currentRow);
                    }
                }
            }

            return specials;
        }
    }
}
