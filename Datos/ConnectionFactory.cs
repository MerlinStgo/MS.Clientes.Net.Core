using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;


namespace MS.Commerce.Datos
{
    public class ConnectionFactory
    {
        public IDbConnection ObtenerConexionMS
        {
            get { return ObtenerConexion("DefaultConnection"); }
        }

        private DbConnection ObtenerConexion(string connectionStringName)
        {
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);

            var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            var conn = factory.CreateConnection();

            if (conn == null) return null;

            conn.ConnectionString = GetConnection().GetSection("ConnectionStrings").GetSection(connectionStringName).Value;
            conn.Open();
            return conn;
        }


        private IConfigurationRoot GetConnection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json").Build();
            return builder;
        }
    }

   
}
