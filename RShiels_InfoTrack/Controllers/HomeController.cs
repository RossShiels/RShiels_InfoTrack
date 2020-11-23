using RShiels_InfoTrack.Models;
using RShiels_InfoTrack.Services;
using RShiels_InfoTrack.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RShiels_InfoTrack.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebService _webService;

        public HomeController()
        {
            _webService = new WebService();
        }

        public ActionResult Index()
        {
            SearchResultViewModel searchResultModel = new SearchResultViewModel();
            searchResultModel.SearchResultAmount = 100;
            searchResultModel.SearchTerms = "land registry search";
            searchResultModel.SearchURL = "www.infotrack.co.uk";

            return View(searchResultModel);
        }       

        [HttpPost]
        public ActionResult SubmitScrape(SearchResultViewModel formData)
        {

            string urlAddress = string.Format("https://www.google.co.uk/search?num={0}&q={1}", formData.SearchResultAmount, formData.SearchTerms);
            string rawHTML = _webService.GetHTML(urlAddress);
            formData.SearchResult = string.Format("The URL appeared in the search results in position(s): {0}", HTMLScraper.GetResults(rawHTML, formData.SearchURL));
            return RedirectToAction("SearchResults", "Home", formData);
        }

        public ActionResult SearchResults(SearchResultViewModel formData)
        {
            return View(formData);
        }

    }
}