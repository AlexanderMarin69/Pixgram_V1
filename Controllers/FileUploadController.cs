using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Pixgram_V1.Models;
using Pixgram_V1.ViewModels;
using vueproject.DB;

namespace Pixgram_V1.Controllers
{
    public class FileUploadController : Controller
    {

        private readonly PixgramDbContext ctx;
        private IHostingEnvironment _appEnvironment;
        private IMemoryCache _cache;
        public FileUploadController(PixgramDbContext context, IHostingEnvironment appEnvironment, IMemoryCache memoryCache)
        {
            ctx = context;
            _appEnvironment = appEnvironment;
            _cache = memoryCache;
        }

        [HttpPost]
        public IActionResult CreateCategory(ImageUploadViewModel vm)
        {
            var NewCategory = new Category();
            NewCategory.Name = vm.CategoryName;

            ctx.Categories.Add(NewCategory);
            ctx.SaveChangesAsync();
            return RedirectToAction("upload", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> FileUpload(ImageUploadViewModel vm, ICollection<IFormFile> images)
        {
            if (ModelState.IsValid && vm != null)
            {
                var imageFolder = "\\UserUploadedImages";
                /* Paths to save image in disk */
                // to wwwroot
                string rootPath = _appEnvironment.WebRootPath;
                // to Images folder
                string imageFolderPath = rootPath + imageFolder;
                // to Registration folder
                string targetFolder = imageFolderPath;
                /* Create Registration folder*/
                Directory.CreateDirectory(targetFolder);

                // Array to store each image
                List<FileUpload> gallery = new List<FileUpload>();

                string targetFileName = "";
                foreach (var image in images)
                {
                    if (Path.GetExtension(image.FileName) != ".jpg" 
                        || 
                        Path.GetExtension(image.FileName) != ".jpeg"
                        || 
                        Path.GetExtension(image.FileName) != ".png")
                    {
                        TempData["FileNotAccepted"] = "File not accepted." +
                            " File must be of type jpg, jpeg or png";
                        return RedirectToAction("Upload", "Home");
                    }
                    
                    Guid uniqueGuid = Guid.NewGuid();
                    targetFileName = uniqueGuid + image.FileName;
                    string finalTargetFilePath = targetFolder + "\\" + targetFileName;
                    // Replace backslash with forward slash
                    finalTargetFilePath = finalTargetFilePath.Replace("\\", "/");

                     
                    if (image.Length > 0)
                    {
                        using (var stream = new FileStream(finalTargetFilePath, FileMode.Create))
                        {
                            await image.CopyToAsync(stream);
                        }
                    }

                    var imageProperty = new FileUpload
                    {
                        FileTitle = uniqueGuid,
                        FilePath = imageFolder.Replace("\\", "/") /*+ "/" + vm.Image.FileName*/ + "/" + targetFileName
                    };
                    gallery.Add(imageProperty);
                }
                var hello = new Image();
                hello.FileUpload = gallery;

               
                hello.DateAdded = DateTime.Now;
                hello.CategoryId = vm.CategoryId;

                hello.ImageUrl = /*vm.Image.FileName.ToString() + "/" + */targetFileName.ToString();

                //Removes all cahce on upload to be able to have a cache that is up to date :))
                 _cache.Remove(CacheKeys.AllImages);

                ctx.Images.Add(hello);
                await ctx.SaveChangesAsync();
                return RedirectToAction("index", "Home");
            } else
            {
                return RedirectToAction("index", "Home");
            }
        }
    }
}