namespace CrudProducts.Models
{
    public class Product
    {
        public int Id { get; set; } // "Id" é a chave primária da tabela, é um número inteiro que é gerado automaticamente pelo banco de dados para cada novo produto inserido. Ele serve para identificar unicamente cada produto na tabela.
        public string Name { get; set; } = string.Empty; // "Name" é o nome do produto, é uma string (texto) que não pode ser nula (NOT NULL) no banco de dados.
        public double Price { get; set; } // "Price" é o preço do produto, é um número real (double) que também não pode ser nulo (NOT NULL) no banco de dados.
    }
}
