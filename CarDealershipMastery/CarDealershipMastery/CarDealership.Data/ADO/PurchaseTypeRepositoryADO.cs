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
    public class PurchaseTypeRepositoryADO : IPurchaseTypeRepository
    {
        public List<PurchaseType> GetAll()
        {
            List<PurchaseType> purchaseTypes = new List<PurchaseType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectAllPurchaseTypes", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PurchaseType currentRow = new PurchaseType();
                        currentRow.PurchaseTypeId = (int)dr["PurchaseTypeId"];
                        currentRow.PurchaseTypeInfo = dr["PurchaseTypeInfo"].ToString();

                        purchaseTypes.Add(currentRow);
                    }
                }
            }

            return purchaseTypes;
        }
    }
}
