using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyBiz.Business.CustomException
{
    public class InvalidContentType : Exception
    {

        public string Propertyname { get; set; }
        public InvalidContentType()
        {
        }

        public InvalidContentType(string propertyname, string? message) : base(message)
        {
            Propertyname = propertyname;
        }
    }
}
