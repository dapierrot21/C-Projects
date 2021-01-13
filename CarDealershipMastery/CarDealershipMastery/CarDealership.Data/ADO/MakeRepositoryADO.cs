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
    public class MakeRepositoryADO : IMakeRepository
    {
        public void Delete(int MakeId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeDelete", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };


                cmd.Parameters.AddWithValue("@MakeId", MakeId);


                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public Make GetById(int makeId)
        {
            Make make = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeSelect", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@MakeId", makeId);
                cn.Open();


                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        make = new Make
                        {
                            MakeId = (int)dr["MakeId"],
                            MakeType = dr["MakeType"].ToString()
                        };
                    }
                }
            }

            return make;
        }

        public void Insert(Make make)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeInsert", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter param = new SqlParameter("@MakeId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@UserId", make.UserId);
                cmd.Parameters.AddWithValue("@MakeType", make.MakeType);


                cn.Open();

                cmd.ExecuteNonQuery();

                make.MakeId = (int)param.Value;
            }

        }

        public void Update(Make make)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeUpdate", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };


                cmd.Parameters.AddWithValue("@MakeId", make.MakeId);
                cmd.Parameters.AddWithValue("@UserId", make.UserId);
                cmd.Parameters.AddWithValue("@MakeType", make.MakeType);


                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }
    }
}
