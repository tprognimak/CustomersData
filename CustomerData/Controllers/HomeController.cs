using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;
using CustomerData.Model;

namespace UsersData.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            //user should be login
            if (Session["login"] != null)
            {
                //pass data to view
                var data = GetData();

                return View(data);
            }
            return RedirectToAction("Login");
        }

        public ActionResult TagFilter(string tag)
        {
            //filter data by tag
            var data = GetData();
            var filtered = data.Where(x => x.Tags.Contains(tag)).ToList();

            //pass filtered data to view
            return View("Index", filtered);
        }

        public ActionResult Detail(Guid guid)
        {
            //user should be login
            if (Session["login"] != null)
            {
                //pass data to view
                var data = GetDetailData(guid);
                ViewBag.Login = (string)Session["login"];

                return View(data);
            }
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account account)
        {
            var accounts = GetAccounts();


            try
            {
                //get input users data 
                var checkLogin = accounts.Where(x => x.Login == account.Login);
                Account accLogin = checkLogin.First();

                var checkPassword = accounts.Where(x => x.Password == account.Password);
                Account accLogin2 = checkPassword.First();

                //check input users data
                if (accLogin == accLogin2)
                {
                    //write login of user
                    Session["login"] = accLogin.Login;
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Login");
            }
            catch (Exception)
            {
                return RedirectToAction("Login");
            }
        }

        public List<Data> GetData()
        {
            //get data from json
            string dataPath = String.Format(AppDomain.CurrentDomain.BaseDirectory + "\\JSONData\\data.json");
            string JSONString = System.IO.File.ReadAllText(dataPath);
            List<Data> data = JsonConvert.DeserializeObject<List<Data>>(JSONString);

            return data;
        }

        public Data GetDetailData(Guid guid)
        {
            //get filtred data from json
            string dataPath = String.Format(AppDomain.CurrentDomain.BaseDirectory + "\\JSONData\\data.json");
            string JSONString = System.IO.File.ReadAllText(dataPath);
            List<Data> allData = JsonConvert.DeserializeObject<List<Data>>(JSONString);

            Data data = allData.Find(d => d.Guid == guid);

            return data;
        }

        public List<Account> GetAccounts()
        {
            //get data from json
            string accountPath = String.Format(AppDomain.CurrentDomain.BaseDirectory + "\\JSONData\\accounts.json");
            string JSONString = System.IO.File.ReadAllText(accountPath);
            List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(JSONString);

            return accounts;
        }
    }
}