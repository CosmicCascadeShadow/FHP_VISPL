using FHP_DL;
using FHP_Res.Entity;
using FHP_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace FHP_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // ----------------- main page
        public IActionResult Index()
        {
            return View();
        }

        // ----------------- sign in page
        public ActionResult SignInPage()
        {
            return PartialView("~/Views/Shared/_SignInPage.cshtml");
        }
        // ----------------- new user registeration
        public ActionResult RegisterationPage()
        {
            return PartialView("~/Views/Shared/_RegisterationPage.cshtml");
        }
        public List<FHP_Res.Entity.Trainee> GetAllTrainee()
        {
            TraineeRepository repository = new TraineeRepository();
            List<FHP_Res.Entity.Trainee> trainees = repository.GetAllTrainee();
            return trainees;
        }
        // ----------------- Add or Update page
        public ActionResult Upsert(int? id)
        {

            // ---------- we will have to pass the qualification to the view for showing on the ui
            QualificationSQLDL qualificationSQLDL = new QualificationSQLDL();
            IEnumerable<SelectListItem> qualificationList = qualificationSQLDL.GetAllQualifications().Select(
                item => new SelectListItem
                {
                    Text = item.long_name,
                    Value = item.id.ToString()
                });
            ViewBag.QualificationList = qualificationList;

            //  if id == 0, then the operation is Addition
            if (id == 0 || id == null)
            {
                // -- we will have to pass the id for populating
                TraineeRepository repository = new TraineeRepository();
                List<FHP_Res.Entity.Trainee> trainees = repository.GetAllTrainee();
                TempData["currentElementId"]= trainees[trainees.Count-1].SerialNumber+1;
                return View();
            }
            else
            {
                TraineeRepository repository = new TraineeRepository();
                Trainee? trainee = repository.GetAllTrainee().Where(t => t.SerialNumber == id).FirstOrDefault();
                return View(trainee);
            }
        }
        //  ----------------- Add or Update page [POST]
        [HttpPost]
        public ActionResult Upsert(Trainee trainee)
        {
            //  addding
            if (trainee.SerialNumber == 0)
            {
                TraineeRepository repository = new TraineeRepository();
                if (repository.Add(trainee))
                {
                    TempData["success"] = "Employee added successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            //  updating 
            else
            {
                TraineeRepository repository = new TraineeRepository();
                if (repository.Update(trainee))
                {
                    TempData["success"] = "Employee updated successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
        }
        // ----------------- read-only view page
        public ActionResult ReadOnlyView(int? id)
        {
            TraineeRepository traineeRepository = new TraineeRepository();
            Trainee? trainee = traineeRepository.GetAllTrainee().Where(t => t.SerialNumber == id).FirstOrDefault();
            return View(trainee);
        }
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                //  invalid delete operation
                return RedirectToAction("Index");
            }
            else
            {
                TraineeRepository traineeRepository = new TraineeRepository();
                Trainee? trainee = traineeRepository.GetAllTrainee().Where(t => t.SerialNumber == id).FirstOrDefault();
                if (trainee != null)
                {
                    traineeRepository.Delete(trainee);
                    TempData["success"] = "Employee deleted successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    // trainee with corresponding id is not found
                    return RedirectToAction("Index");
                }
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
