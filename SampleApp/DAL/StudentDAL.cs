using Microsoft.Extensions.Configuration;
using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SampleApp.DAL
{
    public class StudentDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        public List<StudentModel> GetStudents()
        {
            cmd = new SqlCommand("GetStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<StudentModel> list = new List<StudentModel>();
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(new StudentModel { 
                    StudentId = Convert.ToInt32(dr["StudentId"]),
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                    Email = dr["Email"].ToString(),
                    Department = dr["Department"].ToString(),
                    Username = dr["Username"].ToString(),
                    Password = dr["Password"].ToString(),   
                });
            }
            return list;
        }
        public bool InsertStudent(StudentModel student)
        {
            try
            {
                cmd = new SqlCommand("InsertStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Firstname", student.FirstName);
                cmd.Parameters.AddWithValue("@Lastname", student.LastName);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@Department", student.Department);
                cmd.Parameters.AddWithValue("@Username", student.Username);
                cmd.Parameters.AddWithValue("@Password", student.Password);
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    return true;
                }
                else { return false; };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateStudent(StudentModel student)
        {
            try
            {
                cmd = new SqlCommand("UpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Firstname", student.FirstName);
                cmd.Parameters.AddWithValue("@Lastname", student.LastName);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@Department", student.Department);
                cmd.Parameters.AddWithValue("@Username", student.Username);
                cmd.Parameters.AddWithValue("@Password", student.Password);
                cmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    return true;
                }
                else { return false; };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int DeleteStudent(int StudentId)
        {
            try
            {
                cmd = new SqlCommand("DeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentId", StudentId);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

    }

}