using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace MMS.Common
{
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