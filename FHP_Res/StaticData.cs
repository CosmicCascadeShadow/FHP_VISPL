using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_Res
{
   
    public class StaticData
    {
        public enum Roles
        {
            SuperAdmin,
            Admin,
            GuestUser,
            Self
        }
        public enum QualificationEnum
        {
            [Description("Bachelor of Technology")]
            Btech,
            [Description("Master of Technology")]
            Mtech,
            [Description("10th Grade")]
            Tenth,
            [Description("12th Grade")]
            Twelveth,
            [Description("B.C.A")]
            BCA,
            [Description("Bachelor of Science")]
            BSc,
            [Description("Master of Science")]
            MSc,
            [Description("Bachelor of Arts")]
            BA,
            [Description("Master of Arts")]
            MA,
            [Description("Doctor of Philosophy")]
            PhD,
            [Description("Bachelor of Commerce")]
            BCom,
            [Description("Master of Commerce")]
            MCom,
            [Description("Bachelor of Business Administration")]
            BBA,
            [Description("Master of Business Administration")]
            MBA,
            [Description("Bachelor of Engineering")]
            BE,
            [Description("Master of Engineering")]
            ME,
            [Description("Bachelor of Medicine, Bachelor of Surgery")]
            MBBS,
            [Description("Bachelor of Dental Surgery")]
            BDS,
            [Description("Doctor of Medicine")]
            MD,
            [Description("Doctor of Dental Medicine")]
            DDM,
            [Description("Bachelor of Pharmacy")]
            BPharm,
            [Description("Master of Pharmacy")]
            MPharm,
            [Description("Bachelor of Arts in Education")]
            BAEd,
            [Description("Master of Arts in Education")]
            MAEd,
            [Description("Bachelor of Laws")]
            LLB,
            [Description("Master of Laws")]
            LLM,
            [Description("Bachelor of Fine Arts")]
            BFA,
            [Description("Master of Fine Arts")]
            MFA,
            [Description("Bachelor of Architecture")]
            BArch,
            [Description("Master of Architecture")]
            MArch,
            [Description("Bachelor of Computer Applications")]
            MCA,
            [Description("Bachelor of Design")]
            BDes,
            [Description("Master of Design")]
            MDes,
            [Description("Bachelor of Journalism")]
            BJ,
            [Description("Master of Journalism")]
            MJ,
            [Description("Bachelor of Social Work")]
            BSW,
            [Description("Master of Social Work")]
            MSW,
            [Description("Bachelor of Physiotherapy")]
            BPT,
            [Description("Master of Physiotherapy")]
            MPT,
            [Description("Bachelor of Occupational Therapy")]
            BOT,
            [Description("Master of Occupational Therapy")]
            MOT,
            [Description("Bachelor of Science in Nursing")]
            BSN,
            [Description("Master of Science in Nursing")]
            MSN,
            [Description("Bachelor of Hotel Management")]
            BHM,
            [Description("Master of Hotel Management")]
            MHM,
            [Description("Bachelor of Ayurvedic Medicine and Surgery")]
            BAMS,
            [Description("Master of Ayurvedic Medicine and Surgery")]
            MAMS
        }
        public static string GetEnumValueAtIndex<TEnum>(byte index) where TEnum : Enum
        {
            TEnum[] enumValues = (TEnum[])Enum.GetValues(typeof(TEnum));

            if (index < 0 || index >= enumValues.Length)
            {
               // MessageBox.Show("Education does't found");
                return "";
            }
            return enumValues[index].ToString();
        }
        public static string GetQualificationDescriptionAtIndex(byte index)
        {
            QualificationEnum[] enumValues = (QualificationEnum[])Enum.GetValues(typeof(QualificationEnum));

            if (index < 0 || index >= enumValues.Length)
            {
                return "";
            }

            QualificationEnum enumValue = enumValues[index];
            var descriptionAttribute = (DescriptionAttribute[])enumValue.GetType().GetField(enumValue.ToString())
                                                          .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return descriptionAttribute.Length > 0 ? descriptionAttribute[0].Description : enumValue.ToString();
        }

        public static List<string> GetQualificationDescriptions()
        {
            List<string> descriptions = new List<string>();

            foreach (QualificationEnum qualification in Enum.GetValues(typeof(QualificationEnum)))
            {
                string description = GetEnumDescription(qualification);
                descriptions.Add(description);
            }

            return descriptions;
        }
        public static string GetEnumDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
        public static byte GetEnumIndexFromDescription(string description)
        {
            foreach (QualificationEnum qualification in Enum.GetValues(typeof(QualificationEnum)))
            {
                if (GetEnumDescription(qualification) == description)
                {
                    return (byte)qualification;
                }
            }
            return 0;
        }
    }
}
