using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string cadenaConexion = @"Data Source=DESKTOP-7KN5JV1\SQLEXPRESS;Initial Catalog=NORTHWND;Integrated Security=True";
            string query = "select * from employees";
            using (SqlConnection objConexion = new SqlConnection(cadenaConexion))
            {
                objConexion.Open();
                SqlDataAdapter daEmpleados = new SqlDataAdapter(query, objConexion);

                DataSet dsEmpresa = new DataSet("Empresa"); /*DATASET*/
                daEmpleados.Fill(dsEmpresa, "Empleados");

                DataTable tblEmpleados = dsEmpresa.Tables["Empleados"];

                foreach (DataRow drCurrent in tblEmpleados.Rows)
                {
                    Console.WriteLine("{0} - {1} - {2} ", drCurrent [0] , drCurrent[1] , drCurrent [2]);
                }
                Console.ReadKey();
            }

        }
    }
}
