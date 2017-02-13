using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dyysh.Web.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Dyysh.Web.Controllers
{
    public class GalleryController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var images = new List<ImageViewModel>();

            images.Add(new ImageViewModel {
                Origin = @"images/1Strcgw.jpg",
                Thumbnail = @"images/1Strcgw.jpg",
                ImageInfo = new ImageInfo { Format = ImageFileFormat.PNG, Height = 965, Width = 340, Size = 123456 } });

            return View(GetStubImages());
        }

        private List<ImageViewModel> GetStubImages()
        {
            var files = System.IO.Directory.GetFiles(@"D:\images")
                .Select(file => System.IO.Path.GetFileName(file))
                .Select(file => new ImageViewModel {
                    Origin = $"images/{file}",
                    Thumbnail = $"images/{file}",
                    ImageInfo = new ImageInfo { Format = ImageFileFormat.PNG, Height = 965, Width = 340, Size = 123456 } })
                .ToList();

            return files;
        }
    }
}
