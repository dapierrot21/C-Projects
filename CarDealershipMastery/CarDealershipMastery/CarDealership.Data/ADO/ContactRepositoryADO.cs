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
    public class ContactRepositoryADO : IContactRepository
    {
        public List<Contact> GetAll()
        {
            List<Contact> contact = new List<Contact>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectAllContacts", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Contact currentRow = new Contact();
                        currentRow.ContactId = (int)dr["ContactId"];
                        currentRow.Name = dr["Name"].ToString();
                        currentRow.Email = dr["Email"].ToString();
                        currentRow.Phone = dr["Phone"].ToString();
                        currentRow.Message = dr["Message"].ToString();

                        contact.Add(currentRow);
                    }
                }
            }

            return contact;
        }
    }
}
