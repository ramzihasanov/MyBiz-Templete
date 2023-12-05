using Microsoft.AspNetCore.Hosting;
using MyBiz.Business.CustomException;
using MyBiz.Business.Helpers;
using MyBiz.Core.Models;
using MyBiz.Core.Repositories;


namespace MyBiz.Business.Services
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IWebHostEnvironment _env;

        public SliderService(ISliderRepository sliderRepository, IWebHostEnvironment env)
        {
            _sliderRepository = sliderRepository;
            _env = env;
        }
        public async Task CreateAsync(Slider slider)
        {
            if (slider.SliderImg != null)
            {

                if (slider.SliderImg.ContentType != "image/png" && slider.SliderImg.ContentType != "image/jpeg")
                {
                    throw new InvalidContentType("Image", "ancaq sekil yukleye bilirsen davay sekil tap gel");
                }

                if (slider.SliderImg.Length > 1048576)
                {
                    throw new InvalidImgSize("Image", "1 mb dan az sekil tap gel");
                }
            }
            else
            {
                throw new InvalidImg("Image", "sekil deyil bu ");
            }



            string newFileName = Helper.GetFileName(_env.WebRootPath, "uploads", slider.SliderImg);

             slider.Name = newFileName;

            await _sliderRepository.CreateAsync(slider);
            await _sliderRepository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {

            if (id == null) throw new InvalidNullReferance();

            Slider wantedSlide = await _sliderRepository.GetByIdAsync(x => x.Id == id && x.IsDeleted == false);

            if (wantedSlide == null) throw new InvalidNullReferance();

            wantedSlide.IsDeleted = true;
            await _sliderRepository.CommitAsync();

        }

        public async Task<List<Slider>> GetAllSAsync()
        {
            return await _sliderRepository.GetAllAsync();
        }

        public async Task<Slider> GetAsync(int id)
        {
            return await _sliderRepository.GetByIdAsync(x => x.Id == id && x.IsDeleted == false);

        }

        public async Task UpdateAsync(Slider slider)
        {
            Slider ExistesSlide = await _sliderRepository.GetByIdAsync(x => x.Id == slider.Id && x.IsDeleted == false);

            if (ExistesSlide == null) throw new InvalidNullReferance();

            if (slider.SliderImg != null)
            {

                if (slider.SliderImg.ContentType != "image/png" && slider.SliderImg.ContentType != "image/jpeg")
                {
                    throw new InvalidContentType("Image", "ancaq sekil yukleye bilirsen davay sekil tap gel");
                }

                if (slider.SliderImg.Length > 1048576)
                {
                    throw new InvalidImgSize("Image", "1 mb dan az sekil tap gel");
                }



                string fileName = Helper.GetFileName(_env.WebRootPath, "uploads", slider.SliderImg);

                   string path = Path.Combine(_env.WebRootPath, "uploads", ExistesSlide.Name);

                  if (File.Exists(path))
                    {
                          File.Delete(path);
                    }

                      ExistesSlide.Name = fileName;
                }

                ExistesSlide.Title = slider.Title;
                ExistesSlide.Desc = slider.Desc;
                ExistesSlide.RedirectUrlText = slider.RedirectUrlText;
                ExistesSlide.RedirectUrl = slider.RedirectUrl;


                await _sliderRepository.CommitAsync();
         }
     }
 }

