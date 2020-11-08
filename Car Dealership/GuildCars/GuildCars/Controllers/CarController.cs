using GuildCars.Data.Factory;
using GuildCars.Data.Interface;
using GuildCars.Migrations;
using GuildCars.Models;
using GuildCars.Models.QueryModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace GuildCars.Controllers
{
    public class CarController : ApiController
    {
        public IDealerRepository InitRepo()
        {
            GuildCarsFactory factory = new VehicleRepositoryFactory();
            IDealerRepository repo = factory.GetRepository();
            return repo;
        }

        [AllowAnonymous]
        [Route("api/addContact")]
        [HttpPost]
        public void AddContact([FromBody] Contact newContact)
        {
            InitRepo().AddContact(newContact);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/addMake")]
        [HttpPost]
        public void AddMake([FromBody] Make newMake)
        {
            InitRepo().AddMake(newMake);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/addModel")]
        [HttpPost]
        public void AddModel([FromBody] Model newModel)
        {
            InitRepo().AddModel(newModel);
        }

        [Authorize(Roles = "Sales")]
        [Route("api/addSale")]
        [HttpPost]
        public void AddSalesData([FromBody] SalesData sales)
        {
            InitRepo().AddSalesData(sales);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/addSpecial")]
        [HttpPost]
        public void AddSpecial([FromBody] Specials newSpecial)
        {
            InitRepo().AddSpecial(newSpecial);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/addVehicle")]
        [HttpPost]
        public void AddVehicle([FromBody] Vehicle newVehicle)
        {
            InitRepo().AddVehicle(newVehicle);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/deleteSpecial/{specialID}")]
        [HttpDelete]
        public void DeleteSpecial(int specialID)
        {
            InitRepo().DeleteSpecial(specialID);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/deleteVehicle/{vehicleID}")]
        [HttpDelete]
        public void DeleteVehicle(int vehicleID) // must also remove picture from images folder
        {
            deletePicture(vehicleID);
            InitRepo().DeleteVehicle(vehicleID);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/editVehicle")]
        [HttpPut]
        public void EditVehicle([FromBody] Vehicle updatedVehicle)
        {
            InitRepo().EditVehicle(updatedVehicle);
        }

        [Authorize(Roles = "Admin, Sales")]
        [Route("api/getAvailableVehicles")]
        [HttpGet, HttpPost]
        public IHttpActionResult GetAvailableVehicles([FromBody] VehicleSearch vehicleSearch)
        {
            var result = InitRepo().GetAvailableVehicles(vehicleSearch);
            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/getBodyStyle")]
        [HttpGet]
        public IHttpActionResult GetBodyStyle()
        {
            var result = InitRepo().GetBodyStyle();
            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/getColor")]
        [HttpGet]
        public IHttpActionResult GetCarColor()
        {
            var result = InitRepo().GetCarColor();
            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/getType")]
        [HttpGet]
        public IHttpActionResult GetCarType()
        {
            var result = InitRepo().GetCarType();
            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result);
        }

        [AllowAnonymous]
        [Route("api/getFeatured")]
        [HttpGet]
        public IHttpActionResult GetFeaturedVehicles()
        {
            var result = InitRepo().GetFeaturedVehicles();
            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/getInterior")]
        [HttpGet]
        public IHttpActionResult GetInterior()
        {
            var result = InitRepo().GetInterior();
            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/getInvNew")]
        [HttpGet]
        public IHttpActionResult getInventoryReportNew()
        {
            var result = InitRepo().GetInventoryReportNew();
            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/getInvUsed")]
        [HttpGet]
        public IHttpActionResult getInventoryReportUsed()
        {
            var result = InitRepo().GetInventoryReportUsed();
            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/getSalesRpt")]
        [HttpGet, HttpPost]
        public IHttpActionResult getSalesReport([FromBody] SalesReportQuery salesQ)
        {
            var result = InitRepo().GetSalesReport(salesQ);
            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/getMake")]
        [HttpGet]
        public IHttpActionResult GetMake()
        {
            var result = InitRepo().GetMake();
            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/getMakesModels")]
        [HttpGet]
        public IHttpActionResult GetAllMakesModels()
        {
            var result = InitRepo().GetAllMakesModels();
            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/getModel/{make_ID}")]
        [HttpGet]
        public IHttpActionResult GetModel(int make_ID)
        {
            var result = InitRepo().GetModel(make_ID);
            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result);
        }

        [AllowAnonymous]
        [Route("api/getNewVehicles")]
        [HttpGet, HttpPost]
        public IHttpActionResult GetNewVehicles([FromBody] VehicleSearch vehicleSearch)
        {
            var result = InitRepo().GetNewVehicles(vehicleSearch);
            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result);
        }

        [AllowAnonymous]
        [Route("api/getUsedVehicles")]
        [HttpGet, HttpPost]
        public IHttpActionResult GetUsedVehicles([FromBody] VehicleSearch vehicleSearch)
        {
            var result = InitRepo().GetUsedVehicles(vehicleSearch);
            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result);
        }

        [Authorize(Roles = "Sales")]
        [Route("api/getPurchaseType")]
        [HttpGet]
        public IHttpActionResult GetPurchaseType()
        {
            var result = InitRepo().GetPurchaseType();
            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result);
        }

        [Authorize(Roles = "Sales")]
        [HttpGet]
        public IHttpActionResult GetSalesData(int salesDataID)
        {
            var result = InitRepo().GetSalesData(salesDataID);
            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }

        [AllowAnonymous]
        [Route("api/getSpecials")]
        [HttpGet]
        public IHttpActionResult GetSpecials()
        {
            var result = InitRepo().GetSpecials();
            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result);
        }

        [Authorize(Roles = "Sales")]
        [Route("api/getState")]
        [HttpGet]
        public IHttpActionResult GetState()
        {
            var result = InitRepo().GetState();
            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/getTransmission")]
        [HttpGet]
        public IHttpActionResult GetTransmission()
        {
            var result = InitRepo().GetTransmission();
            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result);
        }

        [AllowAnonymous]
        [Route("api/getVehicleDetails/{id}")]
        [HttpGet]
        public IHttpActionResult GetVehicleDetails(int id)
        {
            var result = InitRepo().GetVehicleDetails(id);
            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/getVehicle/{id}")]
        [HttpGet]
        public IHttpActionResult GetVehicle(int id)
        {
            var result = InitRepo().GetVehicle(id);
            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/getFileNumber")]
        [HttpGet]
        public int getImagesNumber()
        {
            var fileNumber = InitRepo().getFileNumber();
            return fileNumber;
        }

        [Authorize(Roles = "Admin")]
        [Route("api/addFile")]
        [HttpPost]
        public string AddFile()
        {
            var file = HttpContext.Current.Request.Files.Count > 0 ?
                HttpContext.Current.Request.Files[0] : null;

            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/"), _FileName);
                    if(System.IO.File.Exists(_path)) //check if file, given path, already exists and delete it. Accomplishes necessary op for edit
                    {
                        System.IO.File.Delete(_path);
                    }
                    file.SaveAs(_path);
                }
               
            }
            catch
            {
                
            }
            return file != null ? "/Images/" + file.FileName : null;
        }

        public void deletePicture(int fileID)
        {
            DirectoryInfo di = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/Images/"));
            string search = "inventory-" + fileID + ".*";
            var filename = di.GetFiles(search);
            string _path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/"), filename[0].Name);
            if (System.IO.File.Exists(_path)) //check if file, given path, already exists and delete it. Accomplishes necessary op for edit
            {
                System.IO.File.Delete(_path);
            }
        }

        

    }
}
