using GuildCars.Data.Interface;
using GuildCars.Models;
using GuildCars.Models.QueryModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repositories
{
    public class PRODRepository : IDealerRepository
    {
        public void AddContact(Contact contact)
        {

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "AddContact";

                cmd.Parameters.AddWithValue("@Name", contact.name);
                cmd.Parameters.AddWithValue("@Email", ((object)contact.email) ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Phone", ((object)contact.phoneNumber) ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", contact.description);

                conn.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void AddMake(Make newMake)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "AddMake";

                cmd.Parameters.AddWithValue("@Make", newMake.make);
                cmd.Parameters.AddWithValue("@AddedBy", newMake.addedBy);

                conn.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void AddModel(Model newModel)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "AddModel";

                cmd.Parameters.AddWithValue("@Model", newModel.model);
                cmd.Parameters.AddWithValue("@AddedBy", newModel.addedBy);
                cmd.Parameters.AddWithValue("@Make", newModel.make_ID);

                conn.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void AddSalesData(SalesData sales)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "AddSalesData";

                cmd.Parameters.AddWithValue("@Id", sales.vehicle_ID);
                cmd.Parameters.AddWithValue("@Name", sales.name);
                cmd.Parameters.AddWithValue("@Phone", sales.phone);
                cmd.Parameters.AddWithValue("@Email", sales.email);
                cmd.Parameters.AddWithValue("@Street1", sales.street_1);
                cmd.Parameters.AddWithValue("@Street2", (object)sales.street_2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@City", sales.city);
                cmd.Parameters.AddWithValue("@StateID", sales.state_ID);
                cmd.Parameters.AddWithValue("@ZipCode", sales.zipCode);
                cmd.Parameters.AddWithValue("@PurchasePrice", sales.purchasePrice);
                cmd.Parameters.AddWithValue("@PurchaseTypeID", sales.purchaseType_ID);
                cmd.Parameters.AddWithValue("@userAdded", sales.userAdded);
                

                conn.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void AddSpecial(Specials newSpecial)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "AddSpecial";

                cmd.Parameters.AddWithValue("@Name", newSpecial.name);
                cmd.Parameters.AddWithValue("@Description", newSpecial.description);
                

                conn.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void AddVehicle(Vehicle vehicle)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "AddVehicle";

                cmd.Parameters.AddWithValue("@MakeID", vehicle.make_ID);
                cmd.Parameters.AddWithValue("@ModelID", vehicle.model_ID);
                cmd.Parameters.AddWithValue("@TypeID", vehicle.type_ID);
                cmd.Parameters.AddWithValue("@BodyID", vehicle.body_ID);
                cmd.Parameters.AddWithValue("@TransmissionID", vehicle.transmission_ID);
                cmd.Parameters.AddWithValue("@ColorID", vehicle.color_ID);
                cmd.Parameters.AddWithValue("@InteriorID", vehicle.interior_ID);
                cmd.Parameters.AddWithValue("@Year", vehicle.year);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.mileage);
                cmd.Parameters.AddWithValue("@vinNumber", vehicle.vinNumber);
                cmd.Parameters.AddWithValue("@Msrp", vehicle.msrp);
                cmd.Parameters.AddWithValue("@SalePrice", vehicle.salePrice);
                cmd.Parameters.AddWithValue("@Description", vehicle.description);
                cmd.Parameters.AddWithValue("@Picture", vehicle.picture);
                cmd.Parameters.AddWithValue("@Featured", vehicle.featured);


                conn.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void DeleteSpecial(int specialID)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "DeleteSpecial";

                cmd.Parameters.AddWithValue("@Id", specialID);
                

                conn.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void DeleteVehicle(int vehicleID)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "DeleteVehicle";

                cmd.Parameters.AddWithValue("@Id", vehicleID);


                conn.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void EditVehicle(Vehicle updatedVehicle)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "EditVehicle";

                cmd.Parameters.AddWithValue("@Id", updatedVehicle.vehicle_ID);
                cmd.Parameters.AddWithValue("@MakeID", updatedVehicle.make_ID);
                cmd.Parameters.AddWithValue("@ModelID", updatedVehicle.model_ID);
                cmd.Parameters.AddWithValue("@TypeID", updatedVehicle.type_ID);
                cmd.Parameters.AddWithValue("@BodyID", updatedVehicle.body_ID);
                cmd.Parameters.AddWithValue("@TransmissionID", updatedVehicle.transmission_ID);
                cmd.Parameters.AddWithValue("@ColorID", updatedVehicle.color_ID);
                cmd.Parameters.AddWithValue("@InteriorID", updatedVehicle.interior_ID);
                cmd.Parameters.AddWithValue("@Year", updatedVehicle.year);
                cmd.Parameters.AddWithValue("@Mileage", updatedVehicle.mileage);
                cmd.Parameters.AddWithValue("@vinNumber", updatedVehicle.vinNumber);
                cmd.Parameters.AddWithValue("@Msrp", updatedVehicle.msrp);
                cmd.Parameters.AddWithValue("@SalePrice", updatedVehicle.salePrice);
                cmd.Parameters.AddWithValue("@Description", updatedVehicle.description);
                cmd.Parameters.AddWithValue("@Picture", updatedVehicle.picture);
                cmd.Parameters.AddWithValue("@Featured", updatedVehicle.featured);


                conn.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public List<MakeModel> GetAllMakesModels()
        {
            List<MakeModel> makeModels = new List<MakeModel>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetAllMakesModels";


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        MakeModel currentRow = new MakeModel();

                        currentRow.make = dr["make"].ToString();
                        currentRow.model = dr["model"].ToString();
                        currentRow.dateAdded = (DateTime)dr["dateAdded"];
                        currentRow.addedBy = dr["addedBy"].ToString();

                        makeModels.Add(currentRow);

                    }
                }
            }
            return makeModels;
        }

        public List<SearchModel> GetAvailableVehicles(VehicleSearch vehicleSearch)
        {
            List<SearchModel> availableVehicles = new List<SearchModel>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetAvailableVehicles";
                cmd.Parameters.AddWithValue("@SearchString", vehicleSearch.searchString);
                
                cmd.Parameters.AddWithValue("@minPrice", vehicleSearch.minPrice);
                cmd.Parameters.AddWithValue("@maxPrice", vehicleSearch.maxPrice);
                cmd.Parameters.AddWithValue("@minYear", vehicleSearch.minYear);
                cmd.Parameters.AddWithValue("@maxYear", vehicleSearch.maxYear);


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SearchModel currentRow = new SearchModel();

                        currentRow.vehicle_ID = (int)dr["vehicle_ID"];
                        currentRow.make = dr["make"].ToString();
                        currentRow.model = dr["model"].ToString();
                        currentRow.carType = dr["carType"].ToString();
                        currentRow.bodyStyle = dr["bodyStyle"].ToString();
                        currentRow.transmission = dr["transmission"].ToString();
                        currentRow.outerColor = dr["color"].ToString();
                        currentRow.interior = dr["interior"].ToString();
                        currentRow.year = (int)dr["year"];
                        currentRow.mileage = (int)dr["mileage"];
                        currentRow.vin = dr["vinNumber"].ToString();
                        currentRow.msrp = (decimal)dr["msrp"];
                        currentRow.salePrice = (decimal)dr["salePrice"];
                        
                        currentRow.picture = dr["picture"].ToString();
                        currentRow.description = null;

                        availableVehicles.Add(currentRow);
                    }

                }

            }
            return availableVehicles;
        }

        public List<BodyStyle> GetBodyStyle()
        {
            List<BodyStyle> bodyStyle = new List<BodyStyle>(); 

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetBodyStyle";


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BodyStyle currentRow = new BodyStyle();

                        currentRow.body_ID = (int)dr["body_ID"];
                        currentRow.bodyStyle = dr["bodyStyle"].ToString();

                        bodyStyle.Add(currentRow);
                    }

                }

            }
            return bodyStyle;
        }

        public List<CarColor> GetCarColor()
        {
            List<CarColor> carColors = new List<CarColor>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetColor";


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CarColor currentRow = new CarColor();

                        currentRow.color_ID = (int)dr["color_ID"];
                        currentRow.color = dr["color"].ToString();

                        carColors.Add(currentRow);
                    }

                }

            }
            return carColors;
        }

        public List<CarType> GetCarType()
        {
            List<CarType> carType = new List<CarType>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetCarType";


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CarType currentRow = new CarType();

                        currentRow.type_ID = (int)dr["type_ID"];
                        currentRow.carType = dr["carType"].ToString();

                        carType.Add(currentRow);
                    }

                }

            }
            return carType;
        }

        public List<featuredVehicle> GetFeaturedVehicles()
        {
            List<featuredVehicle> featuredVehicles = new List<featuredVehicle>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetFeaturedVehicles";


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        featuredVehicle currentRow = new featuredVehicle();

                        currentRow.year = (int)dr["year"];
                        currentRow.make = dr["make"].ToString();
                        currentRow.model = dr["model"].ToString();
                        currentRow.price = (decimal)dr["salePrice"];
                        currentRow.picture = dr["picture"].ToString();

                        featuredVehicles.Add(currentRow);
                    }

                }

            }
            return featuredVehicles;
        }

        public int getFileNumber()
        {

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetFileNumber";


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                        return dr.GetInt32(0);
                    else
                        return -1;

                }

            }
            
        }

        public List<Interior> GetInterior()
        {
            List<Interior> interior = new List<Interior>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetInterior";


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Interior currentRow = new Interior();

                        currentRow.interior_ID = (int)dr["interior_ID"];
                        currentRow.interior = dr["interior"].ToString();

                        interior.Add(currentRow);
                    }

                }

            }
            return interior;
        }

        public List<InventoryReport> GetInventoryReportNew()
        {
            List<InventoryReport> invNew = new List<InventoryReport>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetInventoryReportNew";

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InventoryReport currentRow = new InventoryReport();

                        currentRow.year = (int)dr["year"];
                        currentRow.make = dr["make"].ToString();
                        currentRow.model = dr["model"].ToString();
                        currentRow.inventoryCount = (int)dr["InventoryCount"];
                        currentRow.stockValue = (decimal)dr["Stock Value"];

                        invNew.Add(currentRow);

                    }
                }
            }
            return invNew;
        }

        public List<InventoryReport> GetInventoryReportUsed()
        {
            List<InventoryReport> invUsed = new List<InventoryReport>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetInventoryReportUsed";

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InventoryReport currentRow = new InventoryReport();

                        currentRow.year = (int)dr["year"];
                        currentRow.make = dr["make"].ToString();
                        currentRow.model = dr["model"].ToString();
                        currentRow.inventoryCount = (int)dr["InventoryCount"];
                        currentRow.stockValue = (decimal)dr["Stock Value"];

                        invUsed.Add(currentRow);

                    }
                }
            }
            return invUsed;
        }

        public List<SalesReportData> GetSalesReport(SalesReportQuery salesQ)
        {
            List<SalesReportData> salesData = new List<SalesReportData>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "SalesReport";
                cmd.Parameters.AddWithValue("@userEmail", salesQ.email);
                cmd.Parameters.AddWithValue("@fromDate", salesQ.fromDate);
                cmd.Parameters.AddWithValue("@toDate", salesQ.toDate);

                conn.Open();

                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        SalesReportData currentRow = new SalesReportData();

                        currentRow.firstName = dr["firstName"].ToString();
                        currentRow.lastName = dr["lastName"].ToString();
                        currentRow.vehiclesSold = (int)dr["VehiclesSold"];
                        currentRow.totalSales = (decimal)dr["TotalSales"];

                        salesData.Add(currentRow);
                    }

                }
            }

            return salesData;

        }

        public List<Make> GetMake()
        {
            List<Make> make = new List<Make>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetMake";


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Make currentRow = new Make();

                        currentRow.make_ID = (int)dr["make_ID"];
                        currentRow.make = dr["make"].ToString();
                        currentRow.dateAdded = (DateTime)dr["dateAdded"];
                        currentRow.addedBy = dr["addedBy"].ToString();

                        make.Add(currentRow);
                    }

                }

            }
            return make;
        }

        public List<Model> GetModel(int make_ID)
        {
            List<Model> model = new List<Model>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetModel";
                cmd.Parameters.AddWithValue("@MakeID", make_ID);


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model currentRow = new Model();

                        currentRow.model_ID = (int)dr["model_ID"];
                        currentRow.model = dr["model"].ToString();
                        currentRow.dateAdded = (DateTime)dr["dateAdded"];
                        currentRow.addedBy = dr["addedBy"].ToString();

                        model.Add(currentRow);
                    }

                }

            }
            return model;
        }

        public List<SearchModel> GetNewVehicles(VehicleSearch vehicleSearch)
        {
            List<SearchModel> newOrUsedVehicles = new List<SearchModel>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetNewVehicles";
                cmd.Parameters.AddWithValue("@SearchString", vehicleSearch.searchString);
                cmd.Parameters.AddWithValue("@NewOrUsed", vehicleSearch.newOrUsed);
                cmd.Parameters.AddWithValue("@minPrice", vehicleSearch.minPrice);
                cmd.Parameters.AddWithValue("@maxPrice", vehicleSearch.maxPrice);
                cmd.Parameters.AddWithValue("@minYear", vehicleSearch.minYear);
                cmd.Parameters.AddWithValue("@maxYear", vehicleSearch.maxYear);


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SearchModel currentRow = new SearchModel();

                        currentRow.vehicle_ID = (int)dr["vehicle_ID"];
                        currentRow.year = (int)dr["year"];
                        currentRow.make = dr["make"].ToString();
                        currentRow.model = dr["model"].ToString();
                        currentRow.carType = dr["carType"].ToString();
                        currentRow.bodyStyle = dr["bodyStyle"].ToString();
                        
                        currentRow.transmission = dr["transmission"].ToString();
                        currentRow.outerColor = dr["color"].ToString();
                        currentRow.interior = dr["interior"].ToString();
                        
                        currentRow.mileage = (int)dr["mileage"];
                        currentRow.vin = dr["vinNumber"].ToString();
                        currentRow.msrp = (decimal)dr["msrp"];
                        currentRow.salePrice = (decimal)dr["salePrice"];
                        currentRow.picture = dr["picture"].ToString();
                        currentRow.description = null;

                        newOrUsedVehicles.Add(currentRow);
                    }

                }

            }
            return newOrUsedVehicles;
        }

        public List<SearchModel> GetUsedVehicles(VehicleSearch vehicleSearch)
        {
            List<SearchModel> newOrUsedVehicles = new List<SearchModel>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetUsedVehicles";
                cmd.Parameters.AddWithValue("@SearchString", vehicleSearch.searchString);
                cmd.Parameters.AddWithValue("@NewOrUsed", vehicleSearch.newOrUsed);
                cmd.Parameters.AddWithValue("@minPrice", vehicleSearch.minPrice);
                cmd.Parameters.AddWithValue("@maxPrice", vehicleSearch.maxPrice);
                cmd.Parameters.AddWithValue("@minYear", vehicleSearch.minYear);
                cmd.Parameters.AddWithValue("@maxYear", vehicleSearch.maxYear);


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SearchModel currentRow = new SearchModel();

                        currentRow.vehicle_ID = (int)dr["vehicle_ID"];
                        currentRow.year = (int)dr["year"];
                        currentRow.make = dr["make"].ToString();
                        currentRow.model = dr["model"].ToString();
                        currentRow.carType = dr["carType"].ToString();
                        currentRow.bodyStyle = dr["bodyStyle"].ToString();

                        currentRow.transmission = dr["transmission"].ToString();
                        currentRow.outerColor = dr["color"].ToString();
                        currentRow.interior = dr["interior"].ToString();

                        currentRow.mileage = (int)dr["mileage"];
                        currentRow.vin = dr["vinNumber"].ToString();
                        currentRow.msrp = (decimal)dr["msrp"];
                        currentRow.salePrice = (decimal)dr["salePrice"];
                        currentRow.picture = dr["picture"].ToString();
                        currentRow.description = null;

                        newOrUsedVehicles.Add(currentRow);
                    }

                }

            }
            return newOrUsedVehicles;
        }

        public List<PurchaseType> GetPurchaseType()
        {
            List<PurchaseType> purchaseType = new List<PurchaseType>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetPurchaseType";


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PurchaseType currentRow = new PurchaseType();

                        currentRow.purchaseType_ID = (int)dr["purchaseType_ID"];
                        currentRow.purchaseType = dr["purchaseType"].ToString();

                        purchaseType.Add(currentRow);
                    }

                }

            }
            return purchaseType;
        }

        public SalesData GetSalesData(int salesDataID)
        {
            SalesData currentRow = new SalesData();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetSalesData";
                cmd.Parameters.AddWithValue("@Id", salesDataID);


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        currentRow.sale_ID = (int)dr["sale_ID"];
                        currentRow.name = dr["name"].ToString();
                        currentRow.phone = dr["phone"].ToString();
                        currentRow.email = dr["email"].ToString();
                        currentRow.street_1 = dr["street_1"].ToString();
                        currentRow.street_2 = dr["street_2"].ToString();
                        currentRow.city = dr["city"].ToString();
                        currentRow.state_ID = (int)dr["state_ID"];
                        currentRow.zipCode = dr["zipCode"].ToString();
                        currentRow.purchasePrice = (decimal)dr["purchasePrice"];
                        currentRow.purchaseType_ID = (int)dr["purchaseType_ID"];

                    }

                }

            }
            return currentRow;
        }

        public List<Specials> GetSpecials()
        {
            List<Specials> specials = new List<Specials>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetSpecials";


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Specials currentRow = new Specials();

                        currentRow.special_ID = (int)dr["special_ID"];
                        currentRow.name = dr["name"].ToString();
                        currentRow.description = dr["description"].ToString();

                        specials.Add(currentRow);
                    }

                }

            }
            return specials;
        }

        public List<State> GetState()
        {
            List<State> states = new List<State>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetState";


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        State currentRow = new State();

                        currentRow.state_ID = (int)dr["state_ID"];
                        currentRow.state = dr["state"].ToString();

                        states.Add(currentRow);
                    }

                }

            }
            return states;
        }

        public List<Transmission> GetTransmission()
        {
            List<Transmission> transmission = new List<Transmission>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetTransmission";


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Transmission currentRow = new Transmission();

                        currentRow.transmission_ID = (int)dr["transmission_ID"];
                        currentRow.transmission = dr["transmission"].ToString();

                        transmission.Add(currentRow);
                    }

                }

            }
            return transmission;
        }

        public SearchModel GetVehicleDetails(int id)
        {
            SearchModel vehicle = new SearchModel();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetVehicleDetails";
                cmd.Parameters.AddWithValue("@Id", id); 


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        vehicle.vehicle_ID = (int)dr["vehicle_ID"];
                        vehicle.year = (int)dr["year"];
                        vehicle.make = dr["make"].ToString();
                        vehicle.model = dr["model"].ToString();
                        vehicle.carType = dr["carType"].ToString();
                        vehicle.bodyStyle = dr["bodyStyle"].ToString();

                        vehicle.transmission = dr["transmission"].ToString();
                        vehicle.outerColor = dr["color"].ToString();
                        vehicle.interior = dr["interior"].ToString();

                        vehicle.mileage = (int)dr["mileage"];
                        vehicle.vin = dr["vinNumber"].ToString();
                        vehicle.msrp = (decimal)dr["msrp"];
                        vehicle.salePrice = (decimal)dr["salePrice"];
                        vehicle.picture = dr["picture"].ToString();
                        vehicle.description = dr["description"].ToString();
                        vehicle.saleID = Convert.IsDBNull(dr["sale_ID"]) ? null : (int?)dr["sale_ID"];
                    }

                }

            }
            return vehicle;
        }

        public Vehicle GetVehicle(int id)
        {
            Vehicle vehicle = new Vehicle();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetVehicle";
                cmd.Parameters.AddWithValue("@Id", id);


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        vehicle.vehicle_ID = (int)dr["vehicle_ID"];
                        vehicle.year = (int)dr["year"];
                        vehicle.make_ID = (int)dr["make_ID"];
                        vehicle.model_ID = (int)dr["model_ID"];
                        vehicle.type_ID = (int)dr["type_ID"];
                        vehicle.body_ID = (int)dr["body_ID"];

                        vehicle.transmission_ID = (int)dr["transmission_ID"];
                        vehicle.color_ID = (int)dr["color_ID"];
                        vehicle.interior_ID = (int)dr["interior_ID"];

                        vehicle.mileage = (int)dr["mileage"];
                        vehicle.vinNumber = dr["vinNumber"].ToString();
                        vehicle.msrp = (decimal)dr["msrp"];
                        vehicle.salePrice = (decimal)dr["salePrice"];
                        vehicle.picture = dr["picture"].ToString();
                        vehicle.description = dr["description"].ToString();
                        vehicle.sale_ID = Convert.IsDBNull(dr["sale_ID"]) ? null : (int?)dr["sale_ID"];
                    }

                }

            }
            return vehicle;
        }


    }
}
