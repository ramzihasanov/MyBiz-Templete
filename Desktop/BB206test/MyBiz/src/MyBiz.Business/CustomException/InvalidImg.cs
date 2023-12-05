using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBiz.Business.CustomException
{
    public class InvalidImg : Exception
    {
        public string Propertyname { get; set; }
        public InvalidImg()
        {
        }

        public InvalidImg(string propertyname, string? message) : base(message)
        {
            Propertyname = propertyname;
        }
    }
}
