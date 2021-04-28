using MVCSERIESTEST.Models;
using MVCSERIESTEST.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSERIESTEST.Controllers
{
    public class SeriesController : Controller
    {


        #region Metodos Publicos
        // GET: Series
        public ActionResult Index()
        {

          
            List<sp_GetAllSeriesUser_Result> lst;
            using (DB_TESTASPNETEntities db = new DB_TESTASPNETEntities())
            {
                lst = db.sp_GetAllSeriesUser().ToList();
            }

            return View(lst);
        }




        // GET: Series
        [HttpGet]
        public ActionResult ListUser(string UserName)
        {
            List<sp_GetSeriesUser_Result> lst;
            using (DB_TESTASPNETEntities db = new DB_TESTASPNETEntities())
            {
                lst = db.sp_GetSeriesUser(UserName).ToList();
            }

            return View(lst);
        }



        public ActionResult New()
        {

            return View("Nuevo");
        }

        [HttpPost]
        public ActionResult New(SeriesAddViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  using (DB_TESTASPNETEntities db = new DB_TESTASPNETEntities())
                    {  
                        if (!existUser(model.UserName.Trim()))
                        {
                             createUser(model.UserName.Trim());
                        }
                            var oTabla = new Series();
                            oTabla.IDUser = getUserId(model.UserName);
                            oTabla.SeriesSplit = calculatedSerie(model.InvtervalInitial,model.InvtervalEnd);
                            oTabla.CreationDate = DateTime.Now;
                            db.Series.Add(oTabla);
                            db.SaveChanges();
                  
                    }
                  return Redirect("~/Series/");
                }

                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        #endregion fin Metodos Publicos

        #region Metodos Privados

        private bool existUser(string userName)
        {
            using (DB_TESTASPNETEntities db = new DB_TESTASPNETEntities())
            {
                return db.Users.Any(x => x.UserName == userName);
            }

        }

        private int getUserId(string userName)
        {
            using (DB_TESTASPNETEntities db = new DB_TESTASPNETEntities())
            {
                var u= db.Users.FirstOrDefault(x => x.UserName == userName);
                return u.IDUser;
            }
        }

        private string calculatedSerie(int initial, int final)
        {
            string result="";
            for (int i =initial; i<=final; i++)
            {
                result += i+",";
            }

            return result.Remove(result.Count()-1,1);
        }

        private int createUser(string userName)
        {
            int idUser = -1;
            using (DB_TESTASPNETEntities db = new DB_TESTASPNETEntities())
            {
                var oTabla = new Users();
                oTabla.UserName = userName;
                oTabla.CreationDate = DateTime.Now;
                db.Users.Add(oTabla);
                db.SaveChanges();
                idUser = oTabla.IDUser;
            }
            return idUser;
        }

        #endregion FIN Metodos Privados

    }
}