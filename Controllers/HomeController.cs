using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pixgram_V1.Models;
using Pixgram_V1.ViewModels;
using vueproject.DB;

namespace Pixgram_V1.Controllers
{
    public class HomeController : Controller
    {
        private readonly PixgramDbContext ctx;
   
        public HomeController(PixgramDbContext context)
        {
            ctx = context;
           
        }
        public async Task<IActionResult> Index(DisplayImagesViewModel vm)
        {

            var listOfCategories = ctx.Categories.ToList();

            

            if (vm.CategoryId == 0 || vm.CategoryId == 1)
            {
                var AllImages = await ctx.FileUploads.ToListAsync();

                var hej = new DisplayImagesViewModel
                { FileUpload = AllImages };

                hej.Categories = listOfCategories.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()

                });

                return View(hej);
            } else
            {
                var AllImages = await ctx.FileUploads.Include(x => x.Image).ToListAsync();
                var helloo = new List<FileUpload>();
                helloo = AllImages.Where(x => x.Image.CategoryId == vm.CategoryId).ToList();


                var hej = new DisplayImagesViewModel
                { FileUpload = helloo };

                hej.Categories = listOfCategories.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()

                });

                return View(hej);
            }
            
        }

        public async Task<IActionResult> Upload()
        {
            if (!ctx.Categories.Any())
            {
                var StandardCategory = new Category();
                StandardCategory.Name = "All";
                ctx.Categories.Add(StandardCategory);
                await ctx.SaveChangesAsync();
            }

            var vm = new ImageUploadViewModel();

            var listOfCategories = ctx.Categories.ToList();

            vm.Categories = listOfCategories.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()

            });

            return View(vm);
        }

        public IActionResult Cart()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
