using FHP_Res.Entity;
using FHP_VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_BL
{
    internal class EntityValidation
    {
        public bool IsValide(VO valueObject)
        {
            bool valid = true;
            // ------------- the first name is required
            if (string.IsNullOrEmpty(valueObject.Trainee.FirstName))
            {
                valueObject.ValidationMessage["first name"].Add("required", "Username is required.");
                valid = false;
            }
            // ------------ the length of first name should me less that 50
            if (valueObject.Trainee.FirstName.Length > 50)
            {
                valueObject.ValidationMessage["first name"].Add("length", "The Length of First name should be less than 50");
                valid = false;
            }

            if (valueObject.Trainee.Education == 0)
            {
                valueObject.ValidationMessage["education"].Add("required", "Education is Required");
                valid = false;
            }

            // ------------- joining date

            // ---------- current address should be less than 500
            if (valueObject.Trainee.CurrentAddress.Length > 500)
            {
                valueObject.ValidationMessage["current address"].Add("length", "The Length of First name should be less than 50");
                valid = false;
            }

            // ------------ current company is required
            if (String.IsNullOrEmpty(valueObject.Trainee.CurrentCompany))
            {
                valueObject.ValidationMessage["current company"].Add("required", "Current Company is required.");
                valid = false;
            }
            return valid;
        }
    }
}
