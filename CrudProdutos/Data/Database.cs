using Microsoft.Data.Sqlite; // Importa o "Plugin" do SQLite que eu instalei via NuGet.

namespace CrudProducts.Data  // Lembrar do .Data 
{
    public class Database
    {
        private string _connectionString = "Data Source=products.db";  //"_connectionString" é o endereco do banco (o arquivo products.db vai ser criado automaticamente)

        public SqliteConnection GetConnection()  //"GetConnection()" método que abre uma "porta" para o banco de dados  
        {
            return new SqliteConnection(_connectionString);
        }

        public void InitializeBank() //"ItializeBank()" Cria tabela se ela ainda não existir 
        { 
            using var conn = GetConnection(); //"using var conn" o "using" garante que a conexão seja fechada automaticamente após o uso - importante para não vazar recursos
            conn.Open();

            string sql = @"CREATE TABLE IF NOT EXISTS Products (   
                 Id INTEGER PRIMARY KEY AUTOINCREMENT,
                 Name TEXT NOT NULL,
                 Price REAL NOT NULL
            ) "; // "CREATE TABLE IF NOT EXISTS" SQL que cria a tabela (só cria se não existir ainda)

            var cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
    }
}