﻿using MMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MMS.Controllers
{
    public class HomeController : Controller
    {
        private JavaScriptSerializer javaScriptSerializer
        {
            get
            {
                return new JavaScriptSerializer();
            }
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admin()
        {
            var jsonStr = HTTP_GET(Configuration.Settings.Host + Configuration.Settings.Members + "?pageindex=1&pagesize=60");
            MemberResopnse memberResopnse = (MemberResopnse)javaScriptSerializer.Deserialize(jsonStr, typeof(MemberResopnse));

            return View(memberResopnse.MemberList);
        }

        public ActionResult Create()
        {
            return RedirectToAction("Admin", "Home");
        }

        private static string HTTP_GET(string Url)
        {
            string Out = string.Empty;
            WebRequest req = WebRequest.Create(Url);
            try
            {
                WebResponse resp = req.GetResponse();
                using (System.IO.Stream stream = resp.GetResponseStream())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(stream))
                    {
                        Out = sr.ReadToEnd();
                        sr.Close();
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Out = string.Format("HTTP_ERROR :: The second HttpWebRequest object has raised an Argument Exception as 'Connection' Property is set to 'Close' :: {0}", ex.Message);
            }
            catch (WebException ex)
            {
                Out = string.Format("HTTP_ERROR :: WebException raised! :: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Out = string.Format("HTTP_ERROR :: Exception raised! :: {0}", ex.Message);
            }

            return Out;

        }

    }

    public class Configuration : ConfigurationSection
    {
        public static Configuration Settings
        {
            get
            {
                return ConfigurationManager.GetSection("MMSConfiguration") as Configuration;
            }
        }

        [ConfigurationProperty("Host", IsRequired = true)]
        public string Host
        {
            get
            {
                return (string)this["Host"];
            }
        }

        [ConfigurationProperty("members", IsRequired = true)]
        public string Members
        {
            get
            {
                return (string)this["members"];
            }
        }

        [ConfigurationProperty("create", IsRequired = true)]
        public string Create
        {
            get
            {
                return (string)this["create"];
            }
        }

        [ConfigurationProperty("edit", IsRequired = true)]
        public string Edit
        {
            get
            {
                return (string)this["edit"];
            }
        }

        [ConfigurationProperty("delete", IsRequired = true)]
        public string Delete
        {
            get
            {
                return (string)this["delete"];
            }
        }

        [ConfigurationProperty("search", IsRequired = true)]
        public string Search
        {
            get
            {
                return (string)this["search"];
            }
        }

    }
}