using SachAdoNet.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SachAdoNet.Responsitory
{

    public class BookRes
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["Model1"].ToString();
            con = new SqlConnection(constr);
        }

        internal object AddBook()
        {
            throw new NotImplementedException();
        }

        public List<BookModel> GetBook()
        {
            connection();
            List<BookModel> bkM = new List<BookModel>();
            SqlCommand com = new SqlCommand("GetSach", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            
            foreach(DataRow dr in dt.Rows)
            {
                bkM.Add(
                    new BookModel
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        Title = Convert.ToString(dr["title"])
                    }
                    );
            }
            return bkM;
        }
        public  bool AddBook(BookModel obj)
        {
            connection();
            SqlCommand com = new SqlCommand("AddSach", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@title", obj.Title);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if(i >= 0)
            {
                return true;
            }
            else
            {
               return false;
            }
        }
    }
}
