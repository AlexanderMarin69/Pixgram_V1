using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pixgram_V1.Models;
using Pixgram_V1.ViewModels;
using vueproject.DB;

namespace Pixgram_V1.Controllers
{
    
    public class FileUploadController : Controller
    {

        private readonly PixgramDbContext ctx;
        private IHostingEnvironment _appEnvironment;
        public FileUploadController(PixgramDbContext context, IHostingEnvironment appEnvironment)
        {
            ctx = context;
            _appEnvironment = appEnvironment;
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
                string targetFolder = imageFolderPath + "\\" + vm.Image.FileName;
                /* Create Registration folder*/
                Directory.CreateDirectory(targetFolder);

                // Array to store each image
                List<FileUpload> gallery = new List<FileUpload>();

                string targetFileName = "";
                foreach (var image in images)
                {
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
                        FilePath = imageFolder.Replace("\\", "/") + "/" + vm.Image.FileName + "/" + targetFileName
                    };
                    gallery.Add(imageProperty);
                }
                vm.Image.FileUpload = gallery;
                vm.Image.DateAdded = DateTime.Now;

                vm.Image.ImageUrl = vm.Image.FileName.ToString() + "/" + targetFileName.ToString();

                ctx.Images.Add(vm.Image);
                await ctx.SaveChangesAsync();
                return RedirectToAction("index", "Home");
            } else
            {
                return RedirectToAction("index", "Home");
            }
        }
    }
}