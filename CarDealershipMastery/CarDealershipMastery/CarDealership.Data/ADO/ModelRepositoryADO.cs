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
    public class ModelRepositoryADO : IModelRepository
    {
        public void Delete(int modelId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelDelete", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@ModelId", modelId);


                cn.Open();

                cmd.ExecuteNonQuery();


            }
        }

        public Model GetById(int modelId)
        {
            Model model = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelsSelect", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@ModelId", modelId);
                cn.Open();


                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if(dr.Read())
                    {
                        model = new Model();
                        model.ModelId = (int)dr["ModelId"];
                        model.UserId = dr["UserId"].ToString();
                        model.ModelType = dr["ModelType"].ToString();
                    }
                }
            }

            return model;
        }

        public void Insert(Model model)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelInsert", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter param = new SqlParameter("@ModelId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@UserId", model.UserId);
                cmd.Parameters.AddWithValue("@ModelType", model.ModelType);


                cn.Open();

                cmd.ExecuteNonQuery();

                model.ModelId = (int)param.Value;
            }
        }

        public void Update(Model model)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelUpdate", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@ModelId", model.ModelId);
                cmd.Parameters.AddWithValue("@UserId", model.UserId);
                cmd.Parameters.AddWithValue("@ModelType", model.ModelType);


                cn.Open();

                cmd.ExecuteNonQuery();


            }
        }
    }
}
