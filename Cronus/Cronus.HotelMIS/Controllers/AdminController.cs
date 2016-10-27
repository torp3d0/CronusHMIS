using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cronus.HotelMIS.Models;
using AutoMapper;
using PagedList;

namespace Cronus.HotelMIS.Controllers
{
    [RoutePrefix("admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        private CronusEntities db = new CronusEntities();
        public ActionResult Index()
        {
            return View();
        }

        #region Maintenance 

        #region Countries
        [Route("maintenance/countries")]
        public ActionResult Countries(int? page,string q="")
        {
           // Mapper.Initialize(cfg => cfg.CreateMap<Country, CountryModel>());
            var countries=  db.Countries.Where(x=>x.CountryIsActive==true).ToList();
            if (!string.IsNullOrEmpty(q))
            {
                countries = countries.Where(x => x.CountryName.ToLower().Trim().Contains(q.ToLower().Trim()) || x.CountryCode.ToLower().Trim().Contains(q.ToLower().Trim())).ToList();
            }
            var pageNumber = page ?? 1;
            var map_countries = Mapper.Map<List<Country>, List<CountryModel>>(countries);
            ViewBag.Countries = map_countries.ToPagedList(pageNumber, Utils.DisplayPerPage);
            ViewBag.Keyword = q;
            return View("Country/Countries");
        }
       
        [Route("maintenance/countries/new")]
        public ActionResult NewCountry()
        {
            return View("Country/NewCountry");
        }
        [Route("maintenance/countries/new")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewCountry(CountryModel model)
        {
            if (ModelState.IsValid)
            {
               // Mapper.Initialize(cfg => cfg.CreateMap<CountryModel, Country>());
                Country country = Mapper.Map<CountryModel, Country>(model);
                country.CountryAddedBy = Utils.CurrentUser;
                country.CountryAddedDate = DateTime.Now;
                country.CountryIsActive = true;
                db.Countries.Add(country);
                db.SaveChanges();
                return RedirectToAction("Countries");
            }
            return View("Country/NewCountry",model);
        }
        [Route("maintenance/countries/edit/{id:int}")]
        public ActionResult EditCountry(int id)
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<Country, CountryModel>());
            var country = db.Countries.Where(x => x.CountryID == id).SingleOrDefault();
            CountryModel model = Mapper.Map<Country, CountryModel>(country);
            return View("Country/EditCountry", model);
        }
        [Route("maintenance/countries/edit/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCountry(CountryModel model)
        {
            if (ModelState.IsValid)
            {
                

                var country = db.Countries.Find(model.CountryID);
                country.CountryCode = model.CountryCode;
                country.CountryName = model.CountryName;
                country.CountryEditedBy = Utils.CurrentUser;
                country.CountryEditedDate = DateTime.Now;
                country.CountryIsActive = true;
                db.Entry(country).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Countries");
            }
            return View("Country/NewCountry", model);
        }

        [Route("maintenance/countries/remove/{id:int}")]
        public ActionResult RemoveCountry(int id)
        {

            var country = db.Countries.Find(id);
            if (country == null)
            {
                return Json(new { success = false, responseText = "Unable to get data" }, JsonRequestBehavior.AllowGet);
            }
            country.CountryEditedBy = Utils.CurrentUser;
            country.CountryEditedDate = DateTime.Now;
            country.CountryIsActive = false;
            db.Entry(country).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return Json(new { success = true, responseText = "Successfully remove" }, JsonRequestBehavior.AllowGet);


        }
        #endregion

        #region States
        [Route("maintenance/countries/{id:int}/states")]
        public ActionResult States(int id, int? page, string q = "")
        {
            var country = db.Countries.Where(x => x.CountryID == id).SingleOrDefault();
            ViewBag.Country = Mapper.Map<Country, CountryModel>(country);
            var states = db.States.Where(s =>s.StateCountryID==id &&  s.StateIsActive == true).ToList();
            if (!string.IsNullOrEmpty(q))
            {
                states = states.Where(x => x.StateName.ToLower().Trim().Contains(q.ToLower().Trim()) || x.StateName.ToLower().Trim().Contains(q.ToLower().Trim())).ToList();
            }
            var map_states = Mapper.Map<List<State>, List<StateModel>>(states);

            var pageNumber = page ?? 1;

            ViewBag.States = map_states.ToPagedList(pageNumber, Utils.DisplayPerPage);
            ViewBag.Keyword = q;

            return View("State/States");
        }


        [Route("maintenance/countries/{id:int}/state/new")]
        public ActionResult NewState(int id)
        {
            var country = db.Countries.Where(x => x.CountryID == id).SingleOrDefault();
            ViewBag.Country = Mapper.Map<Country, CountryModel>(country);

            return View("State/NewState");
        }
        [Route("maintenance/countries/{id:int}/state/new")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewState(StateModel model,int id)
        {
            model.StateCountryID = id;
            if (ModelState.IsValid)
            {
                State state = Mapper.Map<StateModel, State>(model);
                state.StateAddedBy = Utils.CurrentUser;
                state.StateAddedDate = DateTime.Now;
                state.StateIsActive = true;
                db.States.Add(state);
                db.SaveChanges();
                return RedirectToAction("States");
            }
            return View("State/NewState", model);
        }
        [Route("maintenance/countries/{id:int}/state/edit/{stateId:int}")]
        public ActionResult EditState(int id,int stateId)
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<Country, CountryModel>());
            var state = db.States.Where(x => x.StateID == stateId).SingleOrDefault();
            StateModel model = Mapper.Map<State, StateModel>(state);
            return View("State/EditState", model);
        }

        [Route("maintenance/countries/{id:int}/state/edit/{stateId:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditState(StateModel model, int id, int stateId)
        {
            if (ModelState.IsValid)
            {


                var state = db.States.Find(model.StateID);
               state.StateName = model.StateName;
             
               state.StateEditedBy = Utils.CurrentUser;
               state.StateEditedDate = DateTime.Now;
               state.StateIsActive = true;
                db.Entry(state).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("States");
            }
            return View("State/EditState", model);
        }

        #endregion
        [Route("maintenance/countries/{id:int}/state/{stateId:int}/cities")]
        #region Cities
        public ActionResult Cities(int id, int stateId, int? page, string q="")
        {
            var state = db.States.Where(x => x.StateID == stateId).SingleOrDefault();
            ViewBag.State = Mapper.Map<State, StateModel>(state);
            var cities = db.Cities.Where(s => s.CityStateID == stateId && s.CityIsActive == true).ToList();
            if (!string.IsNullOrEmpty(q))
            {
                cities = cities.Where(x => x.CityName.ToLower().Trim().Contains(q.ToLower().Trim()) || x.CityName.ToLower().Trim().Contains(q.ToLower().Trim())).ToList();
            }
            var map_cities = Mapper.Map<List<City>, List<CityModel>>(cities);

            var pageNumber = page ?? 1;
         
            ViewBag.Cities = map_cities.ToPagedList(pageNumber, Utils.DisplayPerPage);
            ViewBag.Keyword = q;
           

            return View("City/Cities", map_cities);
            
        }
        #endregion
        #endregion
    }
}