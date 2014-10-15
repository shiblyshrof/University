using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.DLL.DAO;
using UniversityApp.DLL.Gateway;

namespace UniversityApp.BLL
{
    class StudentBLL
    {
        StudentGateway aStudentGateway=new StudentGateway();
        public string Save(Student aStudent)
        {
            if (aStudent.Name == string.Empty || aStudent.Email == string.Empty || aStudent.Address == string.Empty)
            {
                return "pls fill up all field";
            }
            else
            {
                if (!HasThisEmailValid(aStudent.Email))
                {
                    return aStudentGateway.Save(aStudent);
                }
                else 
                {
                    return "email already in system";
                }
            }
        }

        private bool HasThisEmailValid(string email)
        {
           return aStudentGateway.HasThisEmailValid(email);
        }
    }
}
