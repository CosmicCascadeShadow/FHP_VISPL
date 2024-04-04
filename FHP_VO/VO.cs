using FHP_DL;
using FHP_Res;
using FHP_Res.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_VO
{
    public class VO
    {
        public UserModel signinUser;
        public List<Trainee> TraineeList { get; set; }
        public bool IsDelete { get; set; } = false;
        public VOResource.EditMode EditMode { get; set; } = VOResource.EditMode.Add;
        public Trainee Trainee { get; set; }

        public Dictionary<string, Dictionary<string, string>> ValidationMessage;
        public DisplayText uiText = new DisplayText();
        public VO()
        {
            // ------------------ will initialize the ui text
            UITextRepository UI = new UITextRepository(); 

            foreach (var item in UI.GetUiText("ReadOnlyScreen"))
            {
                uiText.ReadOnlyScreen.Add(item[0], item[1]);
            }
            foreach (var item in UI.GetUiText("AboutUsScreen"))
            {
                uiText.AboutUsScreen.Add(item[0], item[1]);
            }
            foreach (var item in UI.GetUiText("UserManagementScreen"))
            {
                uiText.UserManagementScreen.Add(item[0], item[1]);
            }
            foreach (var item in UI.GetUiText("Messages"))
            {
                uiText.Messages.Add(item[0], item[1]);
            }
            foreach (var item in UI.GetUiText("UpsertScreen"))
            {
                uiText.UpsertScreen.Add(item[0], item[1]);
            }
            foreach (var item in UI.GetUiText("MainScreen"))
            {
                uiText.HomeScreen.Add(item[0], item[1]);
            }




            TraineeRepository repository = new TraineeRepository();
            TraineeList = repository.GetAllTrainee();

            ValidationMessage = new Dictionary<string, Dictionary<string, string>>();
            foreach (var item in VOResource.ValidationMessageDict)
            {
                ValidationMessage.Add(item.Key, new Dictionary<string, string>(item.Value));
            }
            if (TraineeList == null)
            {
                TraineeList = new List<Trainee>();
            }
        }
    }
}
