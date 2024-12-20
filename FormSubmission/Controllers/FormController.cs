using FormSubmission.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FormSubmission.Controllers
{
    public class FormController : Controller
    {
        private readonly ILogger<FormController> _logger;

        public FormController(ILogger<FormController> logger)
        { 
            _logger = logger;
        }

        public IActionResult Index() 
        {
            var form = new Form();
            return View(form);
        }

        [HttpPost]
        public IActionResult Submit( Form data)
        {          
            if (ModelState.IsValid)
            {
                try
                {
                    data.FirstName = data.FirstName.Trim();
                    data.LastName = data.LastName.Trim();

                    string jsonString = JsonSerializer.Serialize(data);

                    SaveToJsonFile(jsonString);

                    _logger.LogInformation($"Form data submitted successfully: {jsonString}");

                    TempData["Message"] = "Data has been saved successfully.";

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Message"] = $"An error occurred,please try again";

                    _logger.LogError($"{ex.Message} {ex.StackTrace}");
                }
            }

            return View("Index", data);
        }

        private void SaveToJsonFile(string jsonString)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Data.json");

            System.IO.File.AppendAllText(path, jsonString + Environment.NewLine);

            _logger.LogInformation($"Data has been saved to {path}");
        }
    }
}
