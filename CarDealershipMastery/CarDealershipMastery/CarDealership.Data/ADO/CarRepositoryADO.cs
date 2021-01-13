using CarDealership.Data.Interfaces;
using CarDealership.Models.Queries;
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
        public void Delete(int CarId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarDelete", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@CarId", CarId);


                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public Car GetByDetails(int carId)
        {
            Car car = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarSelect", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@CarId", carId);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        car = new Car();
                        car.CarId = (int)dr["CarId"];
                        car.UserId = dr["UserId"].ToString();
                        car.MakeId = (int)dr["MakeId"];
                        car.MakeType = dr["MakeType"].ToString();
                        car.ModelId = (int)dr["ModelId"];
                        car.ModelType = dr["ModelType"].ToString();
                        car.TypeId = (int)dr["TypeId"];
                        car.TypeName = dr["TypeName"].ToString();
                        car.BodyStyleId = (int)dr["BodyStyleId"];
                        car.Style = dr["Style"].ToString();
                        car.TransmissionId = (int)dr["TransmissionId"];
                        car.TransmissionType = dr["TransmissionType"].ToString();
                        car.ColorId = (int)dr["ColorId"];
                        car.ColorName = dr["ColorName"].ToString();
                        car.InteriorId = (int)dr["InteriorId"];
                        car.InteriorColor = dr["InteriorColor"].ToString();
                        car.Year = dr["Year"].ToString();
                        car.Milage = dr["Milage"].ToString();
                        car.VIN = dr["VIN"].ToString();
                        car.MSRP = (decimal)dr["MSRP"];
                        car.SalePrice = (decimal)dr["SalePrice"];
                        car.Description = dr["Description"].ToString();
                        car.IsFeatured = (bool)dr["IsFeatured"];

                        if (dr["UploadedPicture"] != DBNull.Value)
                            car.UploadedPicture = dr["UploadedPicture"].ToString();
                    }
                }
            }

            return car;
        }

        public void Insert(Car car)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarInsert", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter param = new SqlParameter("@CarId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@UserId", car.UserId);
                cmd.Parameters.AddWithValue("@MakeId", car.MakeId);
                cmd.Parameters.AddWithValue("@MakeType", car.MakeType);
                cmd.Parameters.AddWithValue("@ModelId", car.ModelId);
                cmd.Parameters.AddWithValue("@ModelType", car.ModelType);
                cmd.Parameters.AddWithValue("@TypeId", car.TypeId);
                cmd.Parameters.AddWithValue("@TypeName", car.TypeName);
                cmd.Parameters.AddWithValue("@BodyStyleId", car.BodyStyleId);
                cmd.Parameters.AddWithValue("@Style", car.Style);
                cmd.Parameters.AddWithValue("@TransmissionId", car.TransmissionId);
                cmd.Parameters.AddWithValue("@TransmissionType", car.TransmissionType);
                cmd.Parameters.AddWithValue("@ColorId", car.ColorId);
                cmd.Parameters.AddWithValue("@ColorName", car.ColorName);
                cmd.Parameters.AddWithValue("@InteriorId", car.InteriorId);
                cmd.Parameters.AddWithValue("@InteriorColor", car.InteriorColor);
                cmd.Parameters.AddWithValue("@Year", car.Year);
                cmd.Parameters.AddWithValue("@Milage", car.Milage);
                cmd.Parameters.AddWithValue("@VIN", car.VIN);
                cmd.Parameters.AddWithValue("@MSRP", car.MSRP);
                cmd.Parameters.AddWithValue("@SalePrice", car.SalePrice);
                cmd.Parameters.AddWithValue("@Description", car.Description);
                cmd.Parameters.AddWithValue("@UploadedPicture", car.UploadedPicture);
                cmd.Parameters.AddWithValue("@IsFeatured", car.IsFeatured);

                cn.Open();

                cmd.ExecuteNonQuery();

                car.CarId = (int)param.Value;
            }
        }

        public void Update(Car car)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarUpdate", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserId", car.UserId);
                cmd.Parameters.AddWithValue("@MakeId", car.MakeId);
                cmd.Parameters.AddWithValue("@MakeType", car.MakeType);
                cmd.Parameters.AddWithValue("@ModelId", car.ModelId);
                cmd.Parameters.AddWithValue("@ModelType", car.ModelType);
                cmd.Parameters.AddWithValue("@TypeId", car.TypeId);
                cmd.Parameters.AddWithValue("@TypeName", car.TypeName);
                cmd.Parameters.AddWithValue("@BodyStyleId", car.BodyStyleId);
                cmd.Parameters.AddWithValue("@Style", car.Style);
                cmd.Parameters.AddWithValue("@TransmissionId", car.TransmissionId);
                cmd.Parameters.AddWithValue("@TransmissionType", car.TransmissionType);
                cmd.Parameters.AddWithValue("@ColorId", car.ColorId);
                cmd.Parameters.AddWithValue("@ColorName", car.ColorName);
                cmd.Parameters.AddWithValue("@InteriorId", car.InteriorId);
                cmd.Parameters.AddWithValue("@InteriorColor", car.InteriorColor);
                cmd.Parameters.AddWithValue("@Year", car.Year);
                cmd.Parameters.AddWithValue("@Milage", car.Milage);
                cmd.Parameters.AddWithValue("@VIN", car.VIN);
                cmd.Parameters.AddWithValue("@MSRP", car.MSRP);
                cmd.Parameters.AddWithValue("@SalePrice", car.SalePrice);
                cmd.Parameters.AddWithValue("@Description", car.Description);
                cmd.Parameters.AddWithValue("@UploadedPicture", car.UploadedPicture);
                cmd.Parameters.AddWithValue("@IsFeatured", car.IsFeatured);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<CarItem> GetRecent()
        {
            List<CarItem> car = new List<CarItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarSelectRecent", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CarItem row = new CarItem();

                        
                        row.CarId = (int)dr["CarId"];
                        row.UserId = dr["UserId"].ToString();
                        row.MakeId = (int)dr["MakeId"];
                        row.MakeType = dr["MakeType"].ToString();
                        row.ModelId = (int)dr["ModelId"];
                        row.ModelType = dr["ModelType"].ToString();
                        row.Year = dr["Year"].ToString();
                        row.SalePrice = (decimal)dr["SalePrice"];


                        if (dr["UploadedPicture"] != DBNull.Value)
                            row.UploadedPicture = dr["UploadedPicture"].ToString();

                        car.Add(row);
                    }
                }
            }

            return car;
        }

        public CarDetails GetDetails(int carId)
        {
            CarDetails car = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarSelectDetails", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@CarId", carId);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        car = new CarDetails();
                        car.CarId = (int)dr["CarId"];
                        car.UserId = dr["UserId"].ToString();
                        car.MakeId = (int)dr["MakeId"];
                        car.MakeType = dr["MakeType"].ToString();
                        car.ModelId = (int)dr["ModelId"];
                        car.ModelType = dr["ModelType"].ToString();
                        car.BodyStyleId = (int)dr["BodyStyleId"];
                        car.Style = dr["Style"].ToString();
                        car.TransmissionId = (int)dr["TransmissionId"];
                        car.TransmissionType = dr["TransmissionType"].ToString();
                        car.ColorId = (int)dr["ColorId"];
                        car.ColorName = dr["ColorName"].ToString();
                        car.InteriorId = (int)dr["InteriorId"];
                        car.InteriorColor = dr["InteriorColor"].ToString();
                        car.Year = dr["Year"].ToString();
                        car.VIN = dr["VIN"].ToString();
                        car.MSRP = (decimal)dr["MSRP"];
                        car.SalePrice = (decimal)dr["SalePrice"];
                        car.Description = dr["Description"].ToString();
                        car.IsFeatured = (bool)dr["IsFeatured"];

                        if (dr["UploadedPicture"] != DBNull.Value)
                            car.UploadedPicture = dr["UploadedPicture"].ToString();
                    }
                }
            }

            return car;
        }

        public IEnumerable<Car> GetAllCars()
        {
            List<Car> carList = new List<Car>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarSelect", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        Car car = new Car();
                        car.CarId = (int)dr["CarId"];
                        car.UserId = dr["UserId"].ToString();
                        car.MakeId = (int)dr["MakeId"];
                        car.MakeType = dr["MakeType"].ToString();
                        car.ModelId = (int)dr["ModelId"];
                        car.ModelType = dr["ModelType"].ToString();
                        car.TypeId = (int)dr["TypeId"];
                        car.TypeName = dr["TypeName"].ToString();
                        car.BodyStyleId = (int)dr["BodyStyleId"];
                        car.Style = dr["Style"].ToString();
                        car.TransmissionId = (int)dr["TransmissionId"];
                        car.TransmissionType = dr["TransmissionType"].ToString();
                        car.ColorId = (int)dr["ColorId"];
                        car.ColorName = dr["ColorName"].ToString();
                        car.InteriorId = (int)dr["InteriorId"];
                        car.InteriorColor = dr["InteriorColor"].ToString();
                        car.Year = dr["Year"].ToString();
                        car.Milage = dr["Milage"].ToString();
                        car.VIN = dr["VIN"].ToString();
                        car.MSRP = (decimal)dr["MSRP"];
                        car.SalePrice = (decimal)dr["SalePrice"];
                        car.Description = dr["Description"].ToString();
                        car.IsFeatured = (bool)dr["IsFeatured"];

                        if (dr["UploadedPicture"] != DBNull.Value)
                            car.UploadedPicture = dr["UploadedPicture"].ToString();

                        carList.Add(car);
                    }
                }
            }

            return carList;
        }
    }
}
