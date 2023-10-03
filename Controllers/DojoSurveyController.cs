using DateValidator.Models;
using Microsoft.AspNetCore.Mvc;

namespace DateValidator.Controllers
{
    public class DojoSurvey : Controller
    {
        [HttpGet]
        [Route("")]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("result")]
        public IActionResult Result(Survey survey)
        {
            if (ModelState.IsValid)
            {
                return View(survey);
            }
            else
            {
                return View("Index");
            }
        }
    }
}
