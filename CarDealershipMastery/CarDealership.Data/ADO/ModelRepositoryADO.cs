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
        public List<Model> GetAll()
        {
            List<Model> model = new List<Model>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectAllModels", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model currentRow = new Model();
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.ModelType = dr["ModelType"].ToString();
                        currentRow.MakeId = (int)dr["MakeId"];

                        model.Add(currentRow);
                    }
                }
            }

            return model;
        }
    }
}
