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
    public class TransmissionRepositoryADO : ITransmissionRepository
    {
        public List<Transmission> GetAll()
        {
            List<Transmission> transmissions = new List<Transmission>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectAllTransmission", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Transmission currentRow = new Transmission();
                        currentRow.TransmissionId = (int)dr["TransmissionId"];
                        currentRow.TansmissionType = dr["TransmissionType"].ToString();

                        transmissions.Add(currentRow);
                    }
                }
            }

            return transmissions;
        }
    }
}
