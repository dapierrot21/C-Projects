using CarDealership.Data.Interfaces;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CarDealership.Data.ADO
{
    public class StateRepositoryADO : IStateRepository
    {
        public List<State> GetAll()
        {
            List<State> states = new List<State>();
            
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectAllStates", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        State currentRow = new State
                        {
                            StateId = (int)dr["StateId"],
                            StateName = dr["StateName"].ToString()
                        };

                        states.Add(currentRow);
                    }
                }
            }

            return states;
        }
    }
}
