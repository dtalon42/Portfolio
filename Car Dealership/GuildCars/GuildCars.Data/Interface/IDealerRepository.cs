using GuildCars.Models;
using GuildCars.Models.QueryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GuildCars.Data.Interface
{
    public interface IDealerRepository
    {
        List<Specials> GetSpecials();
        List<featuredVehicle> GetFeaturedVehicles();
        // need search functions
        List<SearchModel> GetNewVehicles(VehicleSearch vehicleSearch);
        List<SearchModel> GetUsedVehicles(VehicleSearch vehicleSearch);
        List<SearchModel> GetAvailableVehicles(VehicleSearch vehicleSearch);
        SearchModel GetVehicleDetails(int id);
        Vehicle GetVehicle(int id);
        void AddSalesData(SalesData sales);
        SalesData GetSalesData(int salesDataID);
        int getFileNumber();
        List<State> GetState();
        List<PurchaseType> GetPurchaseType();
        List<CarType> GetCarType();
        List<BodyStyle> GetBodyStyle();
        List<Transmission> GetTransmission();
        List<CarColor> GetCarColor();
        List<Interior> GetInterior();
        List<Model> GetModel(int make_ID);
        List<MakeModel> GetAllMakesModels();
        List<Make> GetMake();
        void AddContact(Contact contact);
        void AddVehicle(Vehicle vehicle);
        void EditVehicle(Vehicle updatedVehicle);
        void DeleteVehicle(int vehicleID);
        void AddMake(Make newMake);
        void AddModel(Model newModel);
        void AddSpecial(Specials newSpecial);
        void DeleteSpecial(int specialID);
        List<InventoryReport> GetInventoryReportNew();
        List<InventoryReport> GetInventoryReportUsed();
        List<SalesReportData> GetSalesReport(SalesReportQuery salesQ);
        // reports?


    }
}
