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
    public class CarRepositoryADO : ICarRepository
    {
        public List<Car> GetAll()
        {
            List<Car> car = new List<Car>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectAllCars", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Car currentRow = new Car();
                        currentRow.CarId = (int)dr["CarId"];
                        currentRow.UserId = dr["UserId"].ToString();
                        currentRow.MakeId = (int)dr["MakeId"];
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.TypeId = (int)dr["TypeId"];
                        currentRow.BodyStyleId = (int)dr["BodyStyleId"];
                        currentRow.TransmissionId = (int)dr["TransmissionId"];
                        currentRow.ColorId = (int)dr["ColorId"];
                        currentRow.InteriorId = (int)dr["InteriorId"];
                        currentRow.Year = dr["Year"].ToString();
                        currentRow.Milage = dr["Milage"].ToString();
                        currentRow.VIN = (int)dr["VIN"];
                        currentRow.MSRP = (int)dr["MSRP"];
                        currentRow.SalePrice = (decimal)dr["SalePrice"];
                        currentRow.Desciption = dr["Desciption"].ToString();
                        currentRow.UploadedPicture = dr["UploadedPicture"].ToString();
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];

                        car.Add(currentRow);
                    }
                }
            }

            return car;
        }
    }
}
