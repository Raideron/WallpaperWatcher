using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadApp
{
    class Wallpaper
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime DateDownloaded { get; set; }

        public Wallpaper(string url)
        {
            Url = url;
            DateDownloaded = DateTime.Today;
        }
    }
}
