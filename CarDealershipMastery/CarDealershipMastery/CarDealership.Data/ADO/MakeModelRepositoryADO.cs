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
    public class MakeModelRepositoryADO : IMakeModelRepository
    {
        public List<MakeModel> GetAll()
        {
            List<MakeModel> makeModel = new List<MakeModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectAllMakeModels", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        MakeModel currentRow = new MakeModel();
                        currentRow.MakeId = (int)dr["MakeId"];
                        currentRow.ModelId = (int)dr["ModelId"];

                        makeModel.Add(currentRow);
                    }
                }
            }

            return makeModel;
        }
    }
}
