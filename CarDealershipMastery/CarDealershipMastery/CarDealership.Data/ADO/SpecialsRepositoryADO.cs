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
        public void Delete(int specialsId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialsDelete", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };


                cmd.Parameters.AddWithValue("@SpecialsId", specialsId);


                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public Specials GetById(int specialsId)
        {
            Specials specials = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialsSelect", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@SpecialsId", specialsId);
                cn.Open();


                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        specials = new Specials();
                        specials.SpecialsId = (int)dr["SpecialsId"];
                        specials.Title = dr["Title"].ToString();
                        specials.Description = dr["Description"].ToString();
                    }
                }
            }

            return specials;
        }

        public IEnumerable<Specials> GetSpecials()
        {
            List<Specials> specials = new List<Specials>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialsSelectRecent", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Specials row = new Specials();


                        row.SpecialsId = (int)dr["SpecialsId"];
                        row.Title = dr["Title"].ToString();
                        row.Description = dr["Description"].ToString();

                        specials.Add(row);
                    }
                }
            }

            return specials;
        }

        public void Insert(Specials specials)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialsInsert", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter param = new SqlParameter("@SpecialsId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Title", specials.Title);
                cmd.Parameters.AddWithValue("@Description", specials.Description);

                cn.Open();

                cmd.ExecuteNonQuery();

                specials.SpecialsId = (int)param.Value;
            }
        }

        public void Update(Specials specials)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialsUpdate", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };


                cmd.Parameters.AddWithValue("@SpecialsId", specials.SpecialsId);
                cmd.Parameters.AddWithValue("@Title", specials.Title);
                cmd.Parameters.AddWithValue("@Description", specials.Description);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
