using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dyysh.Web.Models.ViewModels
{
    public class ImageViewModel
    {
        public string Thumbnail { get; set; }
        public string Origin { get; set; }
        public ImageInfo ImageInfo { get; set; }
    }

    public class ImageInfo
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Size { get; set; }
        public ImageFileFormat Format { get; set; }
    }

    public enum ImageFileFormat
    {
        JPEG,
        PNG
    }

    public partial class AccountViewModels
    {
        public class Login
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
