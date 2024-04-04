using FHP_DL;
using FHP_Res.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace FHP_web.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpPost]
        public ActionResult Validate([FromBody] UserModel user)
        {
            // ---------------- validating the user
            UserRepository repository = new UserRepository();
            List<UserModel> allUser = repository.GetAllUsers();
            UserModel? loggedInUser =  allUser.Where(u => u.Id == user.Id && u.Password == user.Password).FirstOrDefault();
            if (loggedInUser == null)
            {
                return null;
            }
            else
            {
                TraineeRepository traineeRepository = new TraineeRepository();
                List<FHP_Res.Entity.Trainee> trainees = traineeRepository.GetAllTrainee();
                ValidationResponse response = new ValidationResponse
                {
                    LoggedInUser = loggedInUser,
                    Trainees = trainees
                };
                return Json(response);
            }
        }
        public class ValidationResponse
        {
            public UserModel LoggedInUser { get; set; }
            public List<FHP_Res.Entity.Trainee> Trainees { get; set; }
        }

        // ----------------- function to return the first trainee
        public Trainee GetFirstTrainee()
        {
            TraineeRepository traineeRepository = new TraineeRepository();
            return traineeRepository.GetAllTrainee()[0];
        }
        // ----------------- function to return the last trainee
        public Trainee GetLastTrainee()
        {
            TraineeRepository traineeRepository = new TraineeRepository();
            List<Trainee> trainees = traineeRepository.GetAllTrainee();
            return trainees[trainees.Count - 1];
        }
        // ----------------- function to return the previous trainee
        public Trainee GetPreviousTrainee(int id)
        {
            TraineeRepository traineeRepository = new TraineeRepository();
            List<Trainee> trainees = traineeRepository.GetAllTrainee().Where(t => t.SerialNumber < id).ToList();
            return trainees[trainees.Count - 1];
        }
        //----------------- function to return the next trainee
        public Trainee GetNextTrainee(int id)
        {
            TraineeRepository traineeRepository = new TraineeRepository();
            List<Trainee> trainees = traineeRepository.GetAllTrainee().Where(t => t.SerialNumber > id).ToList();
            return trainees.FirstOrDefault(); 
        }


    }
}
