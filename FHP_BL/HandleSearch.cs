using FHP_Res;
using FHP_Res.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_BL
{
    public class HandleSearch
    {
        public List<Trainee> Filter(List<Trainee> traineeList, List<string> filters)
        {
            // ------------- id
            if (!string.IsNullOrEmpty(filters[0].Trim(' ')))
            {
                traineeList = traineeList.Where(t => t.SerialNumber == long.Parse(filters[0])).ToList();
            }
            // ------------- prefix
            return traineeList.Where(t => t.Prefix.Contains(filters[1]))
                .Where(t => t.FirstName.ToLower().StartsWith(filters[2].ToLower()))
                .Where(t => t.MiddleName.ToLower().StartsWith(filters[3].ToLower()))
                .Where(t => t.LastName.ToLower().StartsWith(filters[4].ToLower()))
                .Where(t => t.JoiningDate.ToString().Contains(filters[6]))
                .Where(t => t.CurrentCompany.ToLower().StartsWith(filters[7].ToLower()))
                .Where(t => t.CurrentAddress.ToLower().Contains(filters[8].ToLower()))
                .Where(t => t.DateOfBirth.ToString().Contains(filters[9])).ToList();
        }
    }
}
 