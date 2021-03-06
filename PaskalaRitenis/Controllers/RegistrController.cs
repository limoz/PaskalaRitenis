﻿using PaskalaRitenis.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace PaskalaRitenis.Controllers
{
    public class RegistrController : Controller
    {
        //
        // GET: /Registr/

        public ActionResult StudentRegistr()
        {
            if (SiteConfiguration.EnableRegistration())
            {
                var model = new StudentRegModel();
                model.School = RawSchoolList();

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult StudentRegistr(StudentRegModel model)
        {
            if (ModelState.IsValid)
            {
                var schoolList = new List<SelectListItem>();
                var schoolType = model.StudyType.Where(s => s.Value == model.SelectedStudyTypeId.ToString()).Select(t => t.Text).FirstOrDefault();

                var school = string.Empty;
                var schoolClass = string.Empty;
                var placeType = string.Empty;
                var schoolChosen = "Yes";

                if (model.SelectedStudyTypeId == 1)
                {
                    schoolList = RawSchoolList();
                    school = schoolList.Where(s => s.Text == model.SpecialSchool).Select(t => t.Text).FirstOrDefault();
                    schoolClass = model.SelectedKlass;
                }
                else
                {
                    schoolList = RawOtherList();
                    school = schoolList.Where(s => s.Text == model.SpecialSchool).Select(t => t.Text).FirstOrDefault();
                    schoolClass = model.SelectedKurss;
                }

                if (string.IsNullOrEmpty(school))
                {
                    school = model.SpecialSchool;
                    schoolChosen = "No";
                }

                var placeReq = model.PlaceRequired;
                if (placeReq != "Nē")
                {
                    placeType = model.PlaceRequiredType;
                }

                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DataSourceConnectionString"].ConnectionString))
                {
                    con.Open();
                    string command = @"INSERT INTO Registration (Created, RegType, RegCode, Vards, Uzvards, Pilseta, Telefons, Email, Skolotajs, SkolasTips, SkolasNosaukums, SkolasKlase, Kopnite, KopnitesTips, IrIzveletaSkola) 
                                     VALUES ('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ,N'" + model.RegType.ToString() + "', N'" + SpecialCode() + "',N'" + model.Name + "', N'" + model.Surname + "', N'" + model.City + "', N'" + model.Phone + "', N'" + model.Email + "', N'" + model.Advicer + "', N'" + schoolType + "', N'" + school + "', N'" + schoolClass + "', N'" + placeReq + "', N'" + placeType + "', N'" + schoolChosen + "')";

                    using (SqlCommand query = new SqlCommand(command, con))
                    {
                        query.ExecuteNonQuery();

                    }
                }

                return View("SuccessRegistr");
            }
            else
            {
                model.Sequrity = false;
                model.PlaceRequired = "Nē";
                return View(model);
            }
        }

        public ActionResult TeacherRegistr()
        {
            if (SiteConfiguration.EnableRegistration())
            {
                var model = new TeacherRegModel();
                model.School = RawSchoolList();

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult TeacherRegistr(TeacherRegModel model)
        {
            if (ModelState.IsValid)
            {
                var schoolList = new List<SelectListItem>();
                var schoolType = model.StudyType.Where(s => s.Value == model.SelectedStudyTypeId.ToString()).Select(t => t.Text).FirstOrDefault();

                var school = string.Empty;
                var placeType = string.Empty;
                var schoolChosen = "Yes";

                if (model.SelectedStudyTypeId == 1)
                {
                    schoolList = RawSchoolList();
                    school = schoolList.Where(s => s.Text == model.SpecialSchool).Select(t => t.Text).FirstOrDefault();
                }
                else if (model.SelectedStudyTypeId == 2)
                {
                    schoolList = RawOtherList();
                    school = schoolList.Where(s => s.Text == model.SpecialSchool).Select(t => t.Text).FirstOrDefault();
                }

                if (string.IsNullOrEmpty(school))
                {
                    school = model.SpecialSchool;
                    schoolChosen = "No";
                }

                var placeReq = model.PlaceRequired;

                if (placeReq != "Nē")
                {
                    placeType = model.PlaceRequiredType;
                }

                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DataSourceConnectionString"].ConnectionString))
                {
                    con.Open();
                    string command = @"INSERT INTO Registration (Created, RegType, RegCode, Vards, Uzvards, Pilseta, Telefons, Email, SkolasTips, SkolasNosaukums, Kopnite, KopnitesTips, IrIzveletaSkola) 
                                     VALUES ('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ,N'" + model.RegType.ToString() + "', N'" + SpecialCode() + "',N'" + model.Name + "', N'" + model.Surname + "', N'" + model.City + "', N'" + model.Phone + "', N'" + model.Email + "', N'" + schoolType + "', N'" + school + "', N'" + placeReq + "', N'" + placeType + "', N'" + schoolChosen + "')";

                    using (SqlCommand query = new SqlCommand(command, con))
                    {
                        query.ExecuteNonQuery();

                    }
                }

                return View("SuccessRegistr");
            }
            else
            {
                model.Sequrity = false;
                model.PlaceRequired = "Nē";
                return View(model);
            }
            
        }

        [HttpGet]
        public ActionResult GetSchoolArray(int val)
        {
            List<SelectListItem> schoolNames = new List<SelectListItem>();

            if (val == 1)
            {
                schoolNames = RawSchoolList();
            }
            else if (val == 2)
            {
                schoolNames = RawOtherList();
            }

            var array = new List<string>();

            schoolNames.ForEach(l => array.Add(l.Text));

            return Json(array, JsonRequestBehavior.AllowGet);
        }

        private List<SelectListItem> RawSchoolList()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DataSourceConnectionString"].ConnectionString);

            var sql = "SELECT * FROM Skolas";

            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new SelectListItem
                        {
                            Value = dr["Id"].ToString(),
                            Text = dr["Iestades_nosaukums"].ToString()
                        });
                    }
                }
            }

            return list;
        }

        private List<SelectListItem> RawOtherList()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DataSourceConnectionString"].ConnectionString);

            var sql = "SELECT * FROM Profes_Skolas";

            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new SelectListItem
                        {
                            Value = dr["Id"].ToString(),
                            Text = dr["Iestades_nosaukums"].ToString()
                        });
                    }
                }
            }

            return list;
        }

        private string SpecialCode()
        {
            const string chars = "ABCDEFGHIJKLMNPQRSTUVWXYZ123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
