using System.Data.SqlClient;

namespace EmployeeCRUD_MVC.Models
{
    public class DepartmentCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public DepartmentCrud(IConfiguration configuration)
        {
                this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }
       
        public int AddDepartment(Department dept)
        {
            int result = 0;
            string qry = "insert into Department values(@dname)";
            cmd= new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@dname", dept.DName);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateDepartment(Department dept)
        {
            int result = 0;
            string qry = "update Department set dname=@dname where did=@did";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@dname", dept.DName);
            cmd.Parameters.AddWithValue("@did", dept.Did);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteDepartment(Department dept)
        {
            int result = 0;
            string qry = "delete from Department where did=@did";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@did", dept.Did);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public IEnumerable<Department> GetDepartments()
        {
            List<Department> list = new List<Department>();
            string qry = "select * from Department";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Department dept = new Department();
                    dept.Did = Convert.ToInt32(dr["did"]);
                    dept.DName = dr["dname"].ToString();
                    list.Add(dept);
                }
            }
            con.Close();
            return list;
        }

        public Department GetDepartmentById(int id)
        {
            Department dept = new Department();
            string qry = "select * from Department where did=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dept.Did = Convert.ToInt32(dr["did"]);
                    dept.DName = dr["dname"].ToString();
                }
            }
            con.Close();
            return dept;
        }

    }
}
