using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeAjax.Models
{
    public class EmployeeDB
    {
        //declare connection string  
        string cs = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
        public List<Employee> lst = new List<Employee>();
        public List<Employee> ListAll()
        {
            List<Employee> lst = new List<Employee>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SelectEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Employee
                    {
                        EmployeeID = Convert.ToInt32(rdr["EmployeeId"]),
                        Name = rdr["Name"].ToString(),
                        Age = Convert.ToInt32(rdr["Age"]),
                        State = rdr["State"].ToString(),
                        Country = rdr["Country"].ToString(),
                    });
                }
                return lst;
            }
        }
        public int Add(Employee emp)
        {
            int i;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                SqlCommand comm = new SqlCommand("InsertUpdateEmployee", con);

                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@ID", emp.EmployeeID);
                comm.Parameters.AddWithValue("@Name", emp.Name);
                comm.Parameters.AddWithValue("@Age", emp.Age);
                comm.Parameters.AddWithValue("@State", emp.State);
                comm.Parameters.AddWithValue("@Country", emp.Country);
                comm.Parameters.AddWithValue("@Action", "Insert");

                i = comm.ExecuteNonQuery();
            }
            return i;
        }

        public int Update(Employee emp)
        {
            int i;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                SqlCommand comm = new SqlCommand("InsertUpdateEmployee", con);

                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@ID", emp.EmployeeID);
                comm.Parameters.AddWithValue("@Name", emp.Name);
                comm.Parameters.AddWithValue("@Age", emp.Age);
                comm.Parameters.AddWithValue("@State", emp.State);
                comm.Parameters.AddWithValue("@Country", emp.Country);
                comm.Parameters.AddWithValue("@Action", "Update");

                i = comm.ExecuteNonQuery();
            }
            return i;
        }

        public int Delete(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                SqlCommand com = new SqlCommand("DeleteEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", ID);
                i = com.ExecuteNonQuery();
                con.Close();
            }

            return i;
        }

    }
}