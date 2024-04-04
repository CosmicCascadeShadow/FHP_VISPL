using FHP_DL;
using FHP_Res;
using FHP_Res.Entity;
using FHP_VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_BL
{
    public class EntityHandler
    {
        public bool Handle(VO valueObject)
        {
            if (valueObject.IsDelete == true)
            {
                // --------------- if mode is read only then we will not delete it
                TraineeRepository repository = new TraineeRepository();
                repository.Delete(valueObject.Trainee);
                valueObject.TraineeList.Remove(valueObject.Trainee);
                valueObject.IsDelete = false;
                return true;
            }
            else
            {
                EntityValidation validation = new EntityValidation();
                if (validation.IsValide(valueObject))
                {
                    if (valueObject.EditMode == VOResource.EditMode.Add)
                    {
                        TraineeRepository repository = new TraineeRepository();
                        repository.Add(valueObject.Trainee);
                        valueObject.TraineeList.Add(valueObject.Trainee);
                    }
                    else if (valueObject.EditMode == VOResource.EditMode.Edit)
                    {
                        TraineeRepository repository = new TraineeRepository();
                        repository.Add(valueObject.Trainee);
                        Trainee updatedTrainee = valueObject.TraineeList.FirstOrDefault(t => t.SerialNumber == valueObject.Trainee.SerialNumber);
                        if (updatedTrainee != null)
                        {
                            updatedTrainee.SerialNumber = valueObject.Trainee.SerialNumber;
                            updatedTrainee.Prefix = valueObject.Trainee.Prefix;
                            updatedTrainee.FirstName = valueObject.Trainee.FirstName;
                            updatedTrainee.MiddleName = valueObject.Trainee.MiddleName;
                            updatedTrainee.LastName = valueObject.Trainee.LastName;
                            updatedTrainee.Education = valueObject.Trainee.Education;
                            updatedTrainee.JoiningDate = valueObject.Trainee.JoiningDate;
                            updatedTrainee.CurrentCompany = valueObject.Trainee.CurrentCompany;
                            updatedTrainee.CurrentAddress = valueObject.Trainee.CurrentAddress;
                            updatedTrainee.DateOfBirth = valueObject.Trainee.DateOfBirth;
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
