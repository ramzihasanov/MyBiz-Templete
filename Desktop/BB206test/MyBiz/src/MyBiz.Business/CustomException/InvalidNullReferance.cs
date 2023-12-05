using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBiz.Business.CustomException
{
    public class InvalidNullReferance : Exception
    {
        public string Propertyname { get; set; }
        public InvalidNullReferance()
        {
        }

        public InvalidNullReferance(string propertyname, string? message) : base(message)
        {

            Propertyname = propertyname;
        }
    }
}
