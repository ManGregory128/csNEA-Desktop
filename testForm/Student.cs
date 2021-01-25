using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csNEA
{
    public class Student
    {
        public Student(string firstName, string lastName, string group, string motherName, string fatherName, string thirdName, string thirdRole, int motherPhone, int fatherPhone, int thirdPhone)
        {
            FirstName = firstName;
            LastName = lastName;
            Group = group;
            MothersName = motherName;
            FathersName = fatherName;
            ThirdName = thirdName;
            ThirdRole = thirdRole;
            MotherPhone = motherPhone;
            FatherPhone = fatherPhone;
            ThirdPhone = thirdPhone;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Group { get; set; }
        public string MothersName { get; set; }
        public string FathersName { get; set; }
        public string ThirdName { get; set; }
        public string ThirdRole { get; set; }
        public int MotherPhone { get; set; }
        public int FatherPhone { get; set; }
        public int ThirdPhone { get; set; }
    }
}
