using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;
using BOL;
using BLL;
namespace Portal.Controllers;

public class softdrinkController : Controller
{
    private readonly ILogger<softdrinkController> _logger;

    public softdrinkController(ILogger<softdrinkController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        CatlogManager mgr=new CatlogManager();
        List<softdrink>lst=mgr.GetDrinks();
        ViewData["Drink"]=lst;
        return View();
    }

    [HttpGet]
    public IActionResult Insert()
    {
       
        return View();
    }

    [HttpPost]
     public IActionResult Insert(int Id,string Name,int Rate)
    {
        bool status=CatlogManager.Insert(Id,Name,Rate);
        if(status){
            this.RedirectToAction("Index");
        }
        return View();
    }


    [HttpGet]
    public IActionResult Delete()
    {
       
        return View();
    }

    [HttpPost]
     public IActionResult Delete(int Id)
    {
        bool status=CatlogManager.Delete(Id);
        if(status){
            this.RedirectToAction("Index");
        }
        return View();
    }



[HttpGet]
// [Route("softdrink/GetById/")]
    public IActionResult GetById()
    {
        // CatlogManager mgr=new CatlogManager();
        // List<softdrink>xyz=mgr.GetById(Id);
        // softdrink e=xyz.Find((s)=>s.ID==Id);
        return View();
    }

    [HttpPost]
     public IActionResult GetById(int Id)
    {
        Console.WriteLine(Id);
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
