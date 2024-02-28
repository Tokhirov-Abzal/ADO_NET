using DBOperations;

namespace ADO_NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sqlDatabaseAccess = new SqlDBAccess("Server=(local);Database=AdoNetLab;Integrated Security=true;");
            var dbOperations = new DBOperations.Operation(sqlDatabaseAccess);
        }
    }
}