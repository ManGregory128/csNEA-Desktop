using Microsoft.Extensions.FileSystemGlobbing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csNEA
{
    public static class DataHandler
    {
        public static string connectionString { get; set; }

        public static bool SetConnectionString(string connectionStr)
        {
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                try
                {
                    con.Open();
                    connectionString = connectionStr;
                    return true;
                }
                catch { return false; }
            }
        }
        
        public static List<Student> GetStudents(String group)
        {
            List<Student> result = new List<Student>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String sqlCmd;
                if (group == String.Empty)
                    sqlCmd = "SELECT * FROM dbo.Students;";
                else
                    sqlCmd = "SELECT * FROM dbo.Students WHERE StudentGroup='" + group + "';";
                

                using (SqlCommand command = new SqlCommand(sqlCmd, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student student = new Student(
                                reader.GetInt32(0),  //ID
                                reader.GetString(1), //FirstName
                                reader.GetString(2), //LastName 
                                reader.GetString(3), //Group
                                reader.GetString(4), //Mother's Name
                                reader.GetString(6), //Father's Name
                                reader.GetString(8), //Backup Contact's Name
                                reader.GetString(9), //Backup Contact's Role
                                reader.GetInt32(5),  //Mother's Phone Number
                                reader.GetInt32(7),  //Father's Phone Number
                                reader.GetInt32(10));//Backup Contact's Number
                           result.Add(student);
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
            }
            return result;
        }
        
    }
}
