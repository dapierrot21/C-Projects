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

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Color currentRow = new Color
                        {
                            ColorId = (int)dr["ColorId"],
                            ColorName = dr["ColorName"].ToString()
                        };

                        colors.Add(currentRow);
                    }
                }
            }

            return colors;
        }
    }
}
