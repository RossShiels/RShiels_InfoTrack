using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RShiels_InfoTrack.Services
{
    interface IWebService
    {
        string GetHTML(string URL);
    }
}
