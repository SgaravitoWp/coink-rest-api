namespace CoinRestAPI.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Clase base abstracta para manejar la conexión a la base de datos.
    /// </summary>
    public abstract class ConnectionRepository
    {
        /// <summary>
        /// Cadena de conexión a la base de datos.
        /// </summary>
        protected readonly string _connectionString;

        /// <summary>
        /// Constructor que inicializa la cadena de conexión.
        /// </summary>
        /// <param name="configuration">Configuración de la aplicación.</param>
        protected ConnectionRepository(IConfiguration configuration)
        {
            string host = configuration["HOST"];
            string port = configuration["PORT"];
            string username = configuration["USERNAME"];
            string password = configuration["PWD"];
            _connectionString = $"Host={host};Port={port};Database=userregistration;Username={username};Password={password};";
        }
    }
}