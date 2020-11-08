using GuildCars.Data.Interface;
using GuildCars.Models;
using GuildCars.Models.QueryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repositories
{
    public class QARepository
    {
        private static List<Specials> _specials = new List<Specials>()
        {
            new Specials { special_ID = 1, name = "Sedan Special", description = "10% off on all sedans"},
            new Specials { special_ID = 2, name = "SUV Special", description = "10% off on all SUVs/CUVs"},
            new Specials { special_ID = 3, name = "Truck Special", description = "5% off new truck purchase"}
        };

        private static List<Vehicle> _vehicle = new List<Vehicle>()
        {
            new Vehicle { vehicle_ID = 1, model_ID = 1, make_ID = 1, type_ID = 1, body_ID = 1, transmission_ID = 2,
                         color_ID = 1, interior_ID = 1, year = 2016, mileage = 55555, vinNumber = "YV1CZ91H531004744",
                         msrp = 25000, salePrice = 20000, description = "a used, well-maintained car", picture = null, featured = true,
                         sale_ID = 0 },
            new Vehicle { vehicle_ID = 2, model_ID = 4, make_ID = 2, type_ID = 3, body_ID = 2, transmission_ID = 3,
                         color_ID = 3, interior_ID = 2, year = 2017, mileage = 44444, vinNumber = "1D4HD38N45F515843",
                         msrp = 29500, salePrice = 25000, description = "a lightly used, fast car", picture = null, featured = false,
                         sale_ID = 0 }
        };

        private static List<Make> _make = new List<Make>()
        {
            new Make { make_ID = 1, make = "Ford", dateAdded = DateTime.Parse("01/01/2001"), addedBy = "admin@testingdata" },
            new Make { make_ID = 2, make = "Nissan", dateAdded = DateTime.Parse("05/06/2006"), addedBy = "admin@testingdata" }
        };

        private static List<Model> _model = new List<Model>()
        {
            new Model {model_ID = 1, model = "Mustang", dateAdded = DateTime.Parse("01/01/2001"), addedBy = "admin@testingdata" },
            new Model {model_ID = 2, model = "Fusion", dateAdded = DateTime.Parse("02/02/2002"), addedBy = "admin@testingdata" },
            new Model {model_ID = 3, model = "GT-R", dateAdded = DateTime.Parse("03/03/2003"), addedBy = "admin@testingdata" },
            new Model {model_ID = 4, model = "LEAF", dateAdded = DateTime.Parse("04/04/2004"), addedBy = "admin@testingdata" }
        };

        private static List<CarType> _carTypes = new List<CarType>()
        {
            new CarType { type_ID = 1, carType = "New"  },
            new CarType { type_ID = 2, carType = "Used" }
        };

        private static List<BodyStyle> _bodyStyle = new List<BodyStyle>()
        {
            new BodyStyle {body_ID = 1, bodyStyle = "Coupe"},
            new BodyStyle {body_ID = 2, bodyStyle = "Hatchback"}
        };

        private static List<Transmission> _transmission = new List<Transmission>()
        {
            new Transmission { transmission_ID = 3, transmission = "Automatic"},
            new Transmission { transmission_ID = 2, transmission = "Manual"}
        };

        private static List<CarColor> _color = new List<CarColor>()
        {
            new CarColor { color_ID = 1, color = "Black"},
            new CarColor { color_ID = 2, color = "Silver"},
            new CarColor { color_ID = 3, color = "Blue"}
        };

        private static List<Interior> _interior = new List<Interior>()
        {
            new Interior { interior_ID = 1, interior = "Black"},
            new Interior { interior_ID = 2, interior = "Leather"}   
        };

        public static List<Contact> _contacts = new List<Contact>()
        {

        };

        public static List<SalesData> _salesData = new List<SalesData>
        {

        };
            



        // return all specials
        public List<Specials> GetSpecials()
        {
            return _specials;
        }

        // only vehicles that have the featured bool should be shown
        public List<Vehicle> GetFeaturedVehicles()
        {
            return _vehicle.FindAll(c => c.featured == true);
        }

        //Specs:
        // 1. Only 20 matches possible
        // 2. if no filters, only 20 vehicles with highest msrp
        // 3. If filter is not provided, it does not factor into the search
        // 4. Must search all make, model, and year for search term
        // 5. Should search either "New" or "Used"
        // 6. NeworUsed has 1 as new, 2 as used, 3 as both
        // Not sure how to split things up
        // cannot target vehicles with sales data attached
       /* public List<SearchModel> GetSearchedVehicles(string searchTerms, int NeworUsed, int minPrice = 0, int maxPrice = 0, int minYear = 0, int maxYear = 0)
        {
            List<SearchModel> cars = new List<SearchModel>();

            if (NeworUsed == 1 || NeworUsed == 2)
            {
                var result = from v in _vehicle
                             join m1 in _make on v.make_ID equals m1.make_ID
                             join m2 in _model on v.model_ID equals m2.model_ID
                             join body in _bodyStyle on v.body_ID equals body.body_ID
                             join tran in _transmission on v.transmission_ID equals tran.transmission_ID
                             join color in _color on v.color_ID equals color.color_ID
                             join interior in _interior on v.interior_ID equals interior.interior_ID
                             where v.type_ID == NeworUsed
                             select new
                             {
                                 search = v.year + m1.make + m2.model,
                                 body = body.bodyStyle,
                                 transmission = tran.transmission,
                                 color = color.color,
                                 interior = interior.interior,
                                 v.mileage,
                                 v.vinNumber,
                                 v.salePrice,
                                 v.msrp,
                                 v.description
                             };

                
            }
            else if(NeworUsed == 3)
            {
                var result = from v in _vehicle
                             join m1 in _make on v.make_ID equals m1.make_ID
                             join m2 in _model on v.model_ID equals m2.model_ID
                             join body in _bodyStyle on v.body_ID equals body.body_ID
                             join tran in _transmission on v.transmission_ID equals tran.transmission_ID
                             join color in _color on v.color_ID equals color.color_ID
                             join interior in _interior on v.interior_ID equals interior.interior_ID
                             select new
                             {
                                 search = v.year + m1.make + m2.model,
                                 body = body.bodyStyle,
                                 transmission = tran.transmission,
                                 color = color.color,
                                 interior = interior.interior,
                                 v.mileage,
                                 v.vinNumber,
                                 v.salePrice,
                                 v.msrp,
                                 v.description
                             };
            }
                
            if(searchTerms == "" && (minPrice + maxPrice + minYear + maxYear) == 0)
            {
                //return (List<Vehicle>)_vehicle.OrderByDescending(c => c.msrp).Take(20);
                return (List<Vehicle>)_vehicle.
            }
            else if
            
        }*/

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }

        public void AddVehicle(Vehicle vehicle) //pictures must be renamed as inventory-databaseID 
        {
            _vehicle.Add(vehicle);
        }

        public void EditVehicle(Vehicle updatedVehicle) //can check featured box
        {

        }

        public void DeleteVehicle(int vehicleID) //also deletes image from folder
        {

        }

        public void AddMake(Make newMake)
        {

        }

        public void AddModel(Model newModel)
        {

        }

        public void AddSpecial(Specials newSpecial)
        {

        }

        public void DeleteSpecial(int specialID)
        {

        }

    }
}
