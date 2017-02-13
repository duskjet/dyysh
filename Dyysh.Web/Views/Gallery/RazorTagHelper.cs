using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Dyysh.Web.Models.ViewModels;

namespace Dyysh.Web.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("image", TagStructure = TagStructure.WithoutEndTag)]
    public class ImageTagHelper : TagHelper
    {
        private const string ImageThumbnailAttributeName = "src";
        private const string ImageSourceAttributeName = "origin";
        private const string ImageInfoAttributeName = "info";

        [HtmlAttributeName(ImageThumbnailAttributeName)]
        public string ImageThumbnail { get; set; }
        [HtmlAttributeName(ImageSourceAttributeName)]
        public string ImageSource { get; set; }
        [HtmlAttributeName(ImageInfoAttributeName)]
        public ImageInfo ImageInfo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";

            output.Attributes.SetAttribute("src", ImageThumbnail);

            output.Attributes.SetAttribute("img-height", ImageInfo.Height);
            output.Attributes.SetAttribute("img-width", ImageInfo.Width);
            output.Attributes.SetAttribute("img-size", ImageInfo.Size);
        }
    }
}
