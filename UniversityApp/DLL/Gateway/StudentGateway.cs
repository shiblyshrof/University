using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.DLL.DAO;

namespace UniversityApp.DLL.Gateway
{
    class StudentGateway
    {
        public string Save(Student aStudent)
        {
            string con = @"server=SHIBLY; database=University; integrated security=true";
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = con;
            connection.Open();

            string query = string.Format("INSERT INTO t_Student VALUES ('{0}','{1}','{2}')",aStudent.Name,aStudent.Email,aStudent.Address);
            SqlCommand command=new SqlCommand(query,connection);

            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "insert success";
            return "problem";
        }

        public bool HasThisEmailValid(string email)
        {
            string con = @"server=SHIBLY; database=University; integrated security=true";
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = con;
            connection.Open();

            string query = string.Format("SELECT * FROM t_Student WHERE Email='{0}'",email);
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader aReader = command.ExecuteReader();

            if (aReader.HasRows)
            {
                return true;
            }
            return false;
        }
    }
}
