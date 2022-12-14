using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace App1
{
    [ContentProperty(nameof(Source))]
    public class ImageResourseExntension : IMarkupExtension
    {
        public string Source { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null) { 
                return null;
            }
            var imageSource = ImageSource.FromResource(Source, typeof(ImageResourseExntension).GetTypeInfo().Assembly);
            return imageSource;

        }
    }
}
