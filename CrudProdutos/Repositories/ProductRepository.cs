using CrudProducts;
using CrudProducts.Data;
using CrudProducts.Models;
using Microsoft.Data.Sqlite;  

namespace CrudProducts.Repositories 
{ 
    public class ProductRepository 
    {
        private Database _db = new Database();

        public void Add(Product product) 
        {
            using var conn = _db.GetConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Products (Name, Price) VALUES (@name, @price)";
            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.ExecuteNonQuery(); // executa comandos que não retornam dados (INSERT, UPDATE, DELETE)
        }

        public List<Product> AllList() 
        {
            var list = new List<Product>(); //é uma lista que só aceita objetos do tipo Produto. o <Produto> entre o "<>" é chamado de genérico

            using var conn = _db.GetConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, Name, Price FROM Products";

            using var reader = cmd.ExecuteReader(); // executa comandos que retorna linhas (SELECT) 
            
            while(reader.Read()) // avanca linha por linha no resultado do banco, como um cursor
            {
                list.Add(new Product
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Price = reader.GetDouble(2)
                });

            }

            return list;      
        }
        public void Update(Product Product) 
        {
            using var conn = _db.GetConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Products SET Name = @name, Price = @price WHERE Id = @id"; // @name e @price, são parâmetros que serão substituídos pelos valores reais quando o comando for executado. Isso ajuda a evitar ataques de injeção SQL e torna o código mais seguro.
            cmd.Parameters.AddWithValue("@name", Product.Name);
            cmd.Parameters.AddWithValue("@price", Product.Price);
            cmd.Parameters.AddWithValue("@id", Product.Id);
            cmd.ExecuteNonQuery();
        }
        public bool Remove(int id)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Products WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0; // retorna true se deletou, false se não encontrou
        }
    }
}

