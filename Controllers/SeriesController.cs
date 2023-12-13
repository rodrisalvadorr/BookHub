using System.Net.Http.Headers;
using System.Net.Http;
using System.Collections.Generic;
using LibraryMVC.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.Controllers
{
  public class SeriesController : Controller
  {
    public string uriBase = "http://rodrisalvadorr.somee.com/LibraryAPI/Series/";

    [HttpGet]
    public ActionResult Index()
    {
      return View();
    }
  }
}