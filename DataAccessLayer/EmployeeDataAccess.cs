using CommonLayer.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class EmployeeDataAccess
    {
        private DbConnection db = new DbConnection();

        public List<Employee>GetEmployees()
        {
            string query = "select * from Employee";
            SqlCommand sql = new SqlCommand();
            sql.CommandText = query;
            sql.Connection = db.connection;
            if(db.connection.State==System.Data.ConnectionState.Closed)
                db.connection.Open();
            SqlDataReader reader = sql.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while(reader.Read())
            {
                Employee employee = new Employee();
                employee.id = (int)reader["id"];
                employee.Name=reader["name"].ToString();
                employee.Age=reader["Age"].ToString();
                employee.Salary = reader["Salary"].ToString();
                employee.Phone = reader["phone"].ToString();
                employee.Department_id = (int)reader["Department_id"];
                employees.Add(employee);
            }
            db.connection.Close();
            return employees;         
        }

        public bool InsertEmployee(Employee employee)
        {
            string query = "insert into Employee values ('" + employee.Name + "'," +"'" + employee.Age + "','" + employee.Salary + "'," +
                "'" + employee.Phone + "','"+employee.Department_id+"')";
            SqlCommand command=new SqlCommand(query,db.connection);
            if (db.connection.State == System.Data.ConnectionState.Closed)
            db.connection.Open();
            int i = command.ExecuteNonQuery();
            db.connection.Close();
            return Convert.ToBoolean(i);
        }
        
        public bool DeleteEmployee(int id)
        {
            string query = "delete from employee where id='" + id + "'";
            SqlCommand command=new SqlCommand(query,db.connection);
            if (db.connection.State == System.Data.ConnectionState.Closed)
                db.connection.Open();
            int i = command.ExecuteNonQuery();
            db.connection.Close();
            return Convert.ToBoolean(i);
        }

        public bool UpdateEmployee(Employee employee)
        {
            string query = "update Employee set Name='" + employee.Name + "',Age='" + employee.Age + "'," +
                "Salary='" + employee.Salary + "',Phone='" + employee.Phone + "' where id='"+employee.id+"'";
            SqlCommand command = new SqlCommand(query, db.connection);
            if (db.connection.State == System.Data.ConnectionState.Closed)
                db.connection.Open();
            int i = command.ExecuteNonQuery();
            db.connection.Close();
            return Convert.ToBoolean(i);
        }

        public Employee GetEmployeeById(int id)
        {
            string query = "select * from Employee where id='" +id+ "'";
            SqlCommand command=new SqlCommand(query,db.connection);
            if (db.connection.State == System.Data.ConnectionState.Closed)
                db.connection.Open();
            SqlDataReader reader=command.ExecuteReader();
            reader.Read();
            Employee employee=new Employee();
            employee.Name = reader["name"].ToString();
            employee.Age=reader["Age"].ToString();
            employee.Salary = reader["Salary"].ToString();
            employee.Phone = reader["Phone"].ToString();
            employee.Department_id = (int)reader["Department_id"];
            db.connection.Close();
            return employee;

        }
    }
}
