using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DownloadApp
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            //determine url to connect to
            string url = "https://commons.wikimedia.org/w/api.php?action=featuredfeed&feed=potd&format=json";
            
            DownloadWallpaper().Wait();
            GetProductAsync("?action=featuredfeed&feed=potd&format=json").Wait();

            Console.Write("Press enter to exit...");
            Console.ReadLine();
        }

        static async Task DownloadWallpaper()
        {
            // New code:
            client.BaseAddress = new Uri("https://commons.wikimedia.org/w/api.php");
            client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        static async Task<Wallpaper> GetProductAsync(string path)
        {
            Wallpaper wallpaper = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(content);
                try
                {
                    XmlElement firstItem = doc.FirstChild.NextSibling["channel"]["item"];
                    string link = firstItem["link"].InnerText;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return wallpaper;
        }
    }
}
