using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Services
{
    public class EmployeeModel
    {
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public string profile_img { get; set; }
        public string gender { get; set; }
        public string department { get; set; }
        public string salary { get; set; }
        public DateTime startDate { get; set; }
        public string notes { get; set; }
    }
}
