using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBiz.Core.Models
{
    public class Slider:BaseEntity
    {
        public string? Name { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string? RedirectUrl { get; set; }
        public string RedirectUrlText { get; set; }
        [NotMapped]
        public IFormFile?  SliderImg { get; set; }

    }
}
