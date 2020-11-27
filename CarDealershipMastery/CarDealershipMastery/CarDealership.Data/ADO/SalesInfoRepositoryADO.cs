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
        public void Delete(int salesInfoId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SalesInfoDelete", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };


                cmd.Parameters.AddWithValue("@SalesInfoId", salesInfoId);


                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public SalesInfo GetById(int salesInfoId)
        {
            SalesInfo salesInfo = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SalesInfoSelect", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@SalesInfoId", salesInfoId);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        salesInfo  = new SalesInfo();
                        salesInfo.CarId = (int)dr["CarId"];
                        salesInfo.UserId = dr["UserId"].ToString();
                        salesInfo.SalesInfoId = (int)dr["SalesInfoId"];
                        salesInfo.Name = dr["Name"].ToString();
                        salesInfo.Email = dr["Email"].ToString();
                        salesInfo.Street1 = dr["Street1"].ToString();
                        salesInfo.Street2 = dr["Street2"].ToString();
                        salesInfo.City = dr["City"].ToString();
                        salesInfo.StateId = (int)dr["StateId"];
                        salesInfo.ZipCode = (int)dr["ZipCode"];
                        salesInfo.PurchasePrice = (decimal)dr["PurchasePrice"];
                        salesInfo.PurchaseTypeId = (int)dr["PurchaseTypeId"];
                    }
                }
            }

            return salesInfo;
        }

        public void Insert(SalesInfo salesInfo)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SalesInfoInsert", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter param = new SqlParameter("@SalesInfoId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@CarId", salesInfo.CarId);
                cmd.Parameters.AddWithValue("@UserId", salesInfo.UserId);
                cmd.Parameters.AddWithValue("@Name", salesInfo.Name);
                cmd.Parameters.AddWithValue("@Email", salesInfo.Email);
                cmd.Parameters.AddWithValue("@Street1", salesInfo.Street1);
                cmd.Parameters.AddWithValue("@Street2", salesInfo.Street2);
                cmd.Parameters.AddWithValue("@City", salesInfo.City);
                cmd.Parameters.AddWithValue("@StateId", salesInfo.StateId);
                cmd.Parameters.AddWithValue("@ZipCode", salesInfo.ZipCode);
                cmd.Parameters.AddWithValue("@PurchasePrice", salesInfo.PurchasePrice);
                cmd.Parameters.AddWithValue("@PurchaseTypeId", salesInfo.PurchaseTypeId);

                cn.Open();

                cmd.ExecuteNonQuery();

                salesInfo.SalesInfoId = (int)param.Value;
            }
        }

        public void Update(SalesInfo salesInfo)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SalesInfoUpdate", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@CarId", salesInfo.CarId);
                cmd.Parameters.AddWithValue("@UserId", salesInfo.UserId);
                cmd.Parameters.AddWithValue("@SalesInfoId", salesInfo.SalesInfoId);
                cmd.Parameters.AddWithValue("@Name", salesInfo.Name);
                cmd.Parameters.AddWithValue("@Email", salesInfo.Email);
                cmd.Parameters.AddWithValue("@Street1", salesInfo.Street1);
                cmd.Parameters.AddWithValue("@Street2", salesInfo.Street2);
                cmd.Parameters.AddWithValue("@City", salesInfo.City);
                cmd.Parameters.AddWithValue("@StateId", salesInfo.StateId);
                cmd.Parameters.AddWithValue("@ZipCode", salesInfo.ZipCode);
                cmd.Parameters.AddWithValue("@PurchasePrice", salesInfo.PurchasePrice);
                cmd.Parameters.AddWithValue("@PurchaseTypeId", salesInfo.PurchaseTypeId);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
