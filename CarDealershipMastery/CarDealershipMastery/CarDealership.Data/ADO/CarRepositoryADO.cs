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

        public IEnumerable<Car> Search(CarSearchParams parameters)
        {
            List<Car> cars = new List<Car>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT TOP 10 * FROM Car c " +
                    "JOIN Make m on m.MakeId = c.MakeId" +
                    "JOIN Model mo ON mo.ModelId = c.ModelId" +
                    "JOIN CarNewOrUsedType ct ON ct.TypeId = c.TypeId" +
                    "JOIN BodyStyle b ON b.BodyStyleId = c.BodyStyleId" +
                    "JOIN Transmission t on t.TransmissionId = c.TransmissionId" +
                    "JOIN Color co on co.ColorId = c.ColorId" +
                    "JOIN Interior i on i.InteriorId = c.InteriorId" +
                    "WHERE 1 = 1";

                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn
                };

                if (parameters.Mileage == "Used")
                {
                    query += "AND Car.TypeId = '2' ";
                }
                else if (parameters.Mileage == "New")
                {
                    query += "AND Car.TypeId = '1' ";
                }

                if (parameters.OnSale == "true")
                {
                    query += "AND Car.IsFeatured = '1' ";
                }

                if (parameters.MakeId.HasValue)
                {
                    query += "AND m.MakeType LIKE @MakeType";
                    cmd.Parameters.AddWithValue("@MakeType", parameters.MakeId.HasValue);
                }

                if (parameters.ModelId.HasValue)
                {
                    query += "AND Model.ModelType LIKE @ModelType";
                    cmd.Parameters.AddWithValue("@ModelType", parameters.ModelId.HasValue);
                }

                if (!string.IsNullOrEmpty(parameters.MinPrice) || !string.IsNullOrEmpty(parameters.MaxPrice))
                {
                    query += "AND c.SalePrice BETWEEN @MinPrice AND @MaxPrice ";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice);
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice);
                }

                if (parameters.MinYear != "Any" && parameters.MaxYear != "Any")
                {
                    query += "AND [Car].[Year] BETWEEN @MinYear  AND @MaxYear ";
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear);
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear);
                }

                if (parameters.MinYear != "Any" && parameters.MaxYear == "Any")
                {
                    query += "AND [Car].[Year] >= @MinYear ";
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear);
                }

                if (parameters.MinYear == "Any" && parameters.MaxYear != "Any")
                {
                    query += "AND [Car].[Year] <= @MaxYear ";
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear);
                }

                cmd.CommandText = query;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
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

                        cars.Add(car);
                    }
                }
            }

            return cars;
        }
    }
}
