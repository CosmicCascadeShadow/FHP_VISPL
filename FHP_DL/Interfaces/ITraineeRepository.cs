using FHP_Res.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_DL
{
    public interface ITraineeRepository
    {
        bool Add(Trainee trainee);
        List<Trainee> GetAllTrainee();
        bool Delete(Trainee trainee);
        bool Update(Trainee trainee);
    }
}
