using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using gestion_riad_projet_fin_etude.Models;

namespace gestion_riad_projet_fin_etude.Controllers
{
    public class login_emplController : Controller
    {
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader rd;

        [HttpGet]
        // GET: login
        public ActionResult Login()
        {
            return View();
        }
        void connection_string()
        {
            cnx.ConnectionString = "Data Source=localhost;Initial Catalog=Gestion_riad2;Integrated Security=True";
        }

        public ActionResult Verifier(Account_empl acc)
        {
            connection_string();
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "select Num_empl,Nom_empl from Employé where Num_empl='" + acc.Num_employé + "' and Nom_empl='" + acc.Nom_employé + "'";
            rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                cnx.Close();
                return View("create");
            }
            else
            {
                cnx.Close();
                return View("erreur");

            }


        }
    }
}