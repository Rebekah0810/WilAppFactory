using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCAPP.Data;
using MVCAPP.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace mvc_app.Controllers;

public class CategoryController : Controller
{
    private static HttpClient sharedClient = new()
    {
        BaseAddress = new Uri("https://supportsystemapi.azurewebsites.net/api/"),       
    };
 
     
    List<Category> listCategories = new List<Category>();

    public CategoryController()
    {
       
    }

    [HttpGet]
    public IActionResult ReadCategory()
    { 
        var categoryNames = sharedClient.GetFromJsonAsync<List<string>>($"category/getcategoryNames").Result;
        foreach (var categoryName in categoryNames)
        {
            listCategories.Add(new Category() { CategoryName = categoryName });
        }
        return View(listCategories);
        
    }  
}
