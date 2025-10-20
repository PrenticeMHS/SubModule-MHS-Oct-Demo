using DbupDemo;
using System.Data;
using Microsoft.Data.SqlClient;

namespace SubModuleDemo
{
    class Program
    {
        public static int Main(string[] args)
        {
            //TODO: ADD DBUPDemo updator

            // Get connection string from config
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Query all stores from the Stores table
                var command = new SqlCommand("Select strs.outlet, strs.location, p.Name, stck.quantity  From [dbo].[stores] strs  inner join [dbo].[stock] stck  on strs.id = stck.store_id  inner join [dbo].[Product] p  on stck.product_id = p.id", connection);
                using (var reader = command.ExecuteReader())
                {
                    // Print column names
                    for (int i = 0; i < reader.FieldCount; i++)
                        Console.Write($"{reader.GetName(i)}\t");
                    Console.WriteLine();

                    // Print each store row
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                            Console.Write($"{reader.GetValue(i)}\t");
                        Console.WriteLine();
                    }
                }
            }

            return 1;
        }
    }
}