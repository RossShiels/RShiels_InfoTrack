using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace RShiels_InfoTrack.Services
{
    public class WebService : IWebService
    {
        public string GetHTML(string URL)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(URL);
            }
        }
    }
}