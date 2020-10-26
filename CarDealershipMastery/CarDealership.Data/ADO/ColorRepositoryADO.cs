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
    public class ColorRepositoryADO : IColorRepository
    {
        public List<Color> GetAll()
        {
            List<Color> colors = new List<Color>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectAllColors", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Color currentRow = new Color();
                        currentRow.ColorId = (int)dr["ColorId"];
                        currentRow.ColorName = dr["ColorName"].ToString();

                        colors.Add(currentRow);
                    }
                }
            }

            return colors;
        }
    }
}
