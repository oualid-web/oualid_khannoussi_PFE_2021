using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using gestion_riad_projet_fin_etude.Models;

namespace gestion_riad_projet_fin_etude.Controllers
{
    public class loginController : Controller
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

        public ActionResult Verifier(Account acc)
        {
            connection_string();
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "select num_gerant,Nom_gerant from Gerant where num_gerant='" + acc.Num_gerant + "' and Nom_gerant='" + acc.Nom_gerant + "'";
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