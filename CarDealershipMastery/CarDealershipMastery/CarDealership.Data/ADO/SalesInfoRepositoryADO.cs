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
    public class SalesInfoRepositoryADO : ISalesInfoRepository
    {
        public List<SalesInfo> GetAll()
        {
            List<SalesInfo> salesInfo = new List<SalesInfo>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectAllSalesInfo", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SalesInfo currentRow = new SalesInfo();
                        currentRow.UserId = dr["UserId"].ToString();
                        currentRow.SalesInfoId = (int)dr["SalesInfoId"];
                        currentRow.Name = dr["Name"].ToString();
                        currentRow.Email = dr["Email"].ToString();
                        currentRow.Street1 = dr["Street1"].ToString();
                        currentRow.Street2 = dr["Street2"].ToString();
                        currentRow.City = dr["City"].ToString();
                        currentRow.StateId = (int)dr["StateId"];
                        currentRow.PurchasePrice = (decimal)dr["PurchasePrice"];
                        currentRow.PurchaseTypeId = (int)dr["PurchaseTypeId"];

                        salesInfo.Add(currentRow);
                    }
                }
            }

            return salesInfo;
        }
    }
}
