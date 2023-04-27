using Microsoft.AspNetCore.Mvc;
using MVCGuessingGameAssignment.Models;

namespace MVCGuessingGameAssignment.Controllers
{
    public class AssignmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult GuessingGame()
        { 
            Random rnd = new Random();
            int secretNumber=rnd.Next(1,501);

            HttpContext.Session.SetInt32("sNum",secretNumber);
            GGame obj = new GGame();
            obj.SNumber = secretNumber;
            return View(obj);
        }
        [HttpPost]
        public IActionResult GuessingGame(GGame obj)
        {
            int?sNum = HttpContext.Session.GetInt32("sNum");
            obj.SNumber = (int)sNum;
            if (obj.Guess < obj.SNumber)
                obj.Message = "Your guess is smaller ";
            else if (obj.Guess > obj.SNumber)
                obj.Message = "Your guess is higher";
            else
                obj.Message = "Bingo! you guessed it.";
            return View(obj);
        }
    }
}
