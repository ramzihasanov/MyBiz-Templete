using MyBiz.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBiz.Business.Services
{
    public interface ISliderService
    {
        Task CreateAsync(Slider slider);
        Task<List<Slider>> GetAllSAsync();
        Task<Slider> GetAsync(int id);
        Task UpdateAsync(Slider slide);

        Task DeleteAsync(int id);
    }
}
