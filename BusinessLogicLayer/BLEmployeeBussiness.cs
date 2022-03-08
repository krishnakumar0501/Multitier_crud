using CommonLayer.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public class BLEmployeeBussiness
    {
        private EmployeeDataAccess dataAccess;
        public BLEmployeeBussiness()
        {
            dataAccess = new EmployeeDataAccess();

        }

        public List<Employee>GetEmployees()
        {
            return dataAccess.GetEmployees();
        }

        public bool InsertEmployee(Employee employee)
        {
            return dataAccess.InsertEmployee(employee);
        }
        public bool DeleteEmployee(int id)
        {
            return dataAccess.DeleteEmployee(id);
        }

        public bool UpdateEmployee(Employee employee)
        {
            return dataAccess.UpdateEmployee(employee);
        }

        public Employee GetEmployeeById(int id)
        {
            return dataAccess.GetEmployeeById(id);
        }
    }
}
