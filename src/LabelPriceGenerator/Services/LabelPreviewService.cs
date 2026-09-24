using Microsoft.Data.Sqlite;

namespace LabelPriceGenerator;

public class ProductRepository
{
    private readonly string _connectionString;

    public ProductRepository()
    {
        var dataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LabelPriceGenerator");
        Directory.CreateDirectory(dataFolder);

        var dbPath = Path.Combine(dataFolder, "price_labels.db");
        _connectionString = $"Data Source={dbPath}";
        InitializeDatabase();
    }

    public void InitializeDatabase()
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Products (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Price REAL NOT NULL,
                PromoPrice REAL NULL,
                Unit TEXT NOT NULL,
                Barcode TEXT NOT NULL,
                Notes TEXT NULL,
                CreatedAt TEXT NOT NULL
            );
        ";

        command.ExecuteNonQuery();
    }

    public List<Product> GetAll()
    {
        var result = new List<Product>();

        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, Name, Price, PromoPrice, Unit, Barcode, Notes, CreatedAt FROM Products ORDER BY CreatedAt DESC";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new Product
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Price = reader.GetDecimal(2),
                PromoPrice = reader.IsDBNull(3) ? null : reader.GetDecimal(3),
                Unit = reader.GetString(4),
                Barcode = reader.GetString(5),
                Notes = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                CreatedAt = DateTime.Parse(reader.GetString(7))
            });
        }

        return result;
    }

    public Product Add(Product product)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO Products (Name, Price, PromoPrice, Unit, Barcode, Notes, CreatedAt)
            VALUES (@Name, @Price, @PromoPrice, @Unit, @Barcode, @Notes, @CreatedAt);
        ";

        command.Parameters.AddWithValue("@Name", product.Name);
        command.Parameters.AddWithValue("@Price", (double)product.Price);
        command.Parameters.AddWithValue("@PromoPrice", product.PromoPrice.HasValue ? (double)product.PromoPrice.Value : DBNull.Value);
        command.Parameters.AddWithValue("@Unit", product.Unit);
        command.Parameters.AddWithValue("@Barcode", product.Barcode);
        command.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(product.Notes) ? DBNull.Value : product.Notes);
        command.Parameters.AddWithValue("@CreatedAt", product.CreatedAt.ToString("O"));

        command.ExecuteNonQuery();

        product.Id = (int)connection.LastInsertRowId;
        return product;
    }

    public void Update(Product product)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            UPDATE Products SET
                Name = @Name,
                Price = @Price,
                PromoPrice = @PromoPrice,
                Unit = @Unit,
                Barcode = @Barcode,
                Notes = @Notes,
                CreatedAt = @CreatedAt
            WHERE Id = @Id;
        ";

        command.Parameters.AddWithValue("@Id", product.Id);
        command.Parameters.AddWithValue("@Name", product.Name);
        command.Parameters.AddWithValue("@Price", (double)product.Price);
        command.Parameters.AddWithValue("@PromoPrice", product.PromoPrice.HasValue ? (double)product.PromoPrice.Value : DBNull.Value);
        command.Parameters.AddWithValue("@Unit", product.Unit);
        command.Parameters.AddWithValue("@Barcode", product.Barcode);
        command.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(product.Notes) ? DBNull.Value : product.Notes);
        command.Parameters.AddWithValue("@CreatedAt", product.CreatedAt.ToString("O"));

        command.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Products WHERE Id = @Id;";
        command.Parameters.AddWithValue("@Id", id);
        command.ExecuteNonQuery();
    }
}
