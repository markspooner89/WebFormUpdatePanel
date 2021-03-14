using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web.UI;

namespace Web
{
    public partial class Control1 : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            var ds = GetEmployeeDataset(null);
            gvEmployees.DataSource = ds;
            gvEmployees.DataBind();
        }

        private DataSet GetEmployeeDataset(string filter)
        {
            var allEmployees = GetAllEmployees();
            var employees = new List<Employee>();

            if (string.IsNullOrWhiteSpace(filter))
                employees.AddRange(allEmployees);
            else
                employees.AddRange(
                    allEmployees.Where(employee =>
                    employee.FirstName.ToLower().Contains(filter.ToLower()) ||
                    employee.LastName.ToLower().Contains(filter.ToLower())));

            var ds = new DataSet();
            var dt = new DataTable();

            dt.Columns.Add(new DataColumn("Id", Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("FirstName", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("LastName", Type.GetType("System.String")));

            foreach(var employee in employees)
            {
                var row = dt.NewRow();
                row["Id"] = employee.Id;
                row["FirstName"] = employee.FirstName;
                row["LastName"] = employee.LastName;
                dt.Rows.Add(row);
            }

            ds.Tables.Add(dt);

            //FAKE IO COST

            Thread.Sleep(1000);

            return ds;
        }

        private List<Employee> GetAllEmployees()
        {
            return new List<Employee>
            {
                new Employee(1, "Mark", "Spooner"),
                new Employee(2, "Scott", "Clarke"),
                new Employee(3, "Monica", "Duong"),
                new Employee(4, "Sarah", "Lyon"),
                new Employee(5, "Swathi", "Kamath")
            };
        }

        protected void btnemployeeFilter_Click(object sender, EventArgs e)
        {
            var employees = GetEmployeeDataset(txtEmployeeFilter.Text);
            gvEmployees.DataSource = employees;
            gvEmployees.DataBind();
        }

        protected void btnEmployeeFilterReset_Click(object sender, EventArgs e)
        {
            txtEmployeeFilter.Text = "";
            var employees = GetEmployeeDataset(null);
            gvEmployees.DataSource = employees;
            gvEmployees.DataBind();
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}