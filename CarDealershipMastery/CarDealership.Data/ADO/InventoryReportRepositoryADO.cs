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
    public class InventoryReportRepositoryADO : IInventoryReportRepository
    {
        public List<InventoryReport> GetAll()
        {
            List<InventoryReport> report = new List<InventoryReport>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectAllInventoryReports", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InventoryReport currentRow = new InventoryReport();
                        currentRow.InventoryReportId = (int)dr["InventoryReport"];
                        currentRow.Year = dr["Year"].ToString();
                        currentRow.MakeId = (int)dr["MakeId"];
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.Count = (int)dr["Count"];
                        currentRow.StockValue = (int)dr["StockValue"];
                        currentRow.IsSold = (bool)dr["IsSold"];

                        report.Add(currentRow);
                    }
                }
            }

            return report;
        }
    }
}
