using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Common.Models
{
    public class ConfigurationModel
    {
        public int ConfigurationId { get; set; }
        public int ConfigurationTypeId { get; set; }
        public string ConfigurationName { get; set; }
        public string ConfigurationValue { get; set; }


    }
}
