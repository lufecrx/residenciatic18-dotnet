using System;

public class StockManager
{
	private List<Product> products;
	private string filePath;

	public StockManager(string filePath)
	{
		products = new List<Product>();
		this.filePath = filePath;
	}

	public void SaveToFile()
	{
		using (StreamWriter writer = new StreamWriter(filePath))
		{
			foreach (Product product in products)
			{
				writer.WriteLine($"{product.ProductCode}|{product.ProductName}|{product.QuantityInStock}|{product.Value}");
			}
		}
	}

	public void LoadFromFile()
	{
		products.Clear();

		try
		{
			using (StreamReader reader = new StreamReader(filePath))
			{
				string? line;
				while ((line = reader.ReadLine()) != null)
				{
					string[] data = line.Split('|');
					Product product = new Product(int.Parse(data[0]), data[1], int.Parse(data[2]), float.Parse(data[3])); // Product(productCode, productName, quantityInStock, value);
					products.Add(product);
				}
			}
		}
		catch (FileNotFoundException)
		{
			Console.WriteLine($"File not found: {filePath}");
		}
		catch (FormatException)
		{
			Console.WriteLine($"Invalid data format in file: {filePath}");
		}
		catch (Exception)
		{
			Console.WriteLine($"An error occurred while loading the file: {filePath}");
		}
	}

	// Adicionar produto ao estoque
	public void AddProduct(Product product)
	{
		products.Add(product);
	}

	// Remover produto do estoque
	public void RemoveProduct(Product product)
	{
		products.Remove(product);
	}

	// Criar produto para o estoque
	public void CreateProduct()
	{
		try
		{
			Console.WriteLine("Enter product details.");

			Console.Write("Product Code: ");
			int productCode;
			if (!int.TryParse(Console.ReadLine(), out productCode))
				throw new FormatException("Error: Product code must be an integer.");
			if (productCode < 0)
				throw new FormatException("Error: Product code cannot be negative.");
			if (products.Any(p => p.ProductCode == productCode))
				throw new FormatException("Error: Product with the same code already exists.");

			Console.Write("Product Name: ");
			string? productName = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(productName))
				throw new FormatException("Error: Product name cannot be empty.");

			if (products.Any(p => p.ProductName == productName))
				throw new FormatException("Error: Product with the same name already exists.");

			Console.Write("Quantity In Stock: ");
			int quantityInStock;
			if (!int.TryParse(Console.ReadLine(), out quantityInStock))
				throw new FormatException("Error: Quantity in stock must be an integer.");
			if (quantityInStock < 0)
				throw new FormatException("Error: Quantity in stock cannot be negative.");

			Console.Write("Value: ");
			float value;
			if (!float.TryParse(Console.ReadLine(), out value))
				throw new FormatException("Error: Value must be a float.");
			if (value < 0)
				throw new FormatException("Error: Value cannot be negative.");

			// Add the new product to the list
			var product = new Product(productCode, productName, quantityInStock, value);
			AddProduct(product);

			Console.WriteLine("Product created successfully.");
		}
		catch (FormatException ex)
		{
			Console.WriteLine(ex.Message);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"An unexpected error occurred: {ex.Message}");
		}
	}

	// Deletar produto do estoque
	public void DeleteProduct()
	{
		try
		{
			Console.Write("Enter product code: ");
			int productCode;
			if (!int.TryParse(Console.ReadLine(), out productCode))
				throw new FormatException("Error: Product code must be an integer.");

			Product? productToRemove = GetProductByCode(productCode);
			if (productToRemove != null)
				RemoveProduct(productToRemove);
			else
				throw new KeyNotFoundException($"Product with code {productCode} not found.");

			Console.WriteLine("Product deleted successfully.");
		}
		catch (FormatException ex)
		{
			Console.WriteLine(ex.Message);
		}
		catch (KeyNotFoundException ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	// Consultar produto do estoque pelo código
	public Product? GetProductByCode(int productCode)
	{
		try
		{
			if (products.Any(p => p.ProductCode == productCode))
				return products.FirstOrDefault(p => p.ProductCode == productCode);
			else
				throw new KeyNotFoundException($"Product with code {productCode} not found.");
		}
		catch (KeyNotFoundException ex)
		{
			Console.WriteLine(ex.Message);
			return null;
		}
	}

	// Atualizar o estoque para entrada ou saída
	public void UpdateStock()
	{
		int productCode, quantityForUpdate;

		try
		{
			Console.Write("Enter product code: ");
			if (!int.TryParse(Console.ReadLine(), out productCode))
				throw new FormatException("Invalid product code input. Please enter a valid integer.");
			if (productCode < 0)
				throw new FormatException("Invalid product code input. Please enter a positive integer.");

			Console.Write("Enter quantity (positive for addition, negative for removal): ");
			if (!int.TryParse(Console.ReadLine(), out quantityForUpdate))
				throw new FormatException("Invalid quantity input. Please enter a valid integer.");

			Product? product = GetProductByCode(productCode);
			if (product == null)
				throw new KeyNotFoundException($"Product with code {productCode} not found.");

			if (quantityForUpdate < 0 && product.QuantityInStock + quantityForUpdate < 0)
				throw new InvalidOperationException("Error: Insufficient stock.");
			else
				product.QuantityInStock += quantityForUpdate;
		}
		catch (FormatException ex)
		{
			Console.WriteLine(ex.Message);
		}
		catch (KeyNotFoundException ex)
		{
			Console.WriteLine(ex.Message);
		}
		catch (InvalidOperationException ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	// Listar todos os produtos do estoque
	public void ListProducts()
	{
		foreach (var product in products)
			Console.WriteLine(product);
	}

	// Relatorio com lista de produtos com quantidades menores que o determinado
	public void LimitStockReport()
	{
		try
		{
			int limit;
			Console.Write("Enter limit: ");
			if (!int.TryParse(Console.ReadLine(), out limit))
				throw new FormatException("Error: Limit must be an integer.");
			if (limit < 0)
				throw new FormatException("Error: Limit cannot be negative.");

			IEnumerable<Product> productsBelowTheLimit =
									from product in products
									where product.QuantityInStock < limit
									select product;

			Console.WriteLine();
			foreach (Product product in productsBelowTheLimit)
				Console.WriteLine(product);
		}
		catch (FormatException ex)
		{
			Console.WriteLine(ex.Message);
		}

	}

	// Relatorio com produtos entre valores especificados
	public void PriceStockReport()
	{
		try
		{
			int minimumPrice, maximumPrice;
			Console.Write("Enter minimum price: ");
			if (!int.TryParse(Console.ReadLine(), out minimumPrice))
				throw new FormatException("Error: Minimum price must be an integer.");
			if (minimumPrice < 0)
				throw new FormatException("Error: Minimum price cannot be negative.");

			Console.Write("Enter maximum price: ");
			if (!int.TryParse(Console.ReadLine(), out maximumPrice))
				throw new FormatException("Error: Maximum price must be an integer.");
			if (maximumPrice < 0)
				throw new FormatException("Error: Maximum price cannot be negative.");
			if (maximumPrice < minimumPrice)
				throw new FormatException("Error: Maximum price must be greater than or equal to the minimum price.");
				
			IEnumerable<Product> productsBetweenThePrices =
									from product in products
									where product.Value >= minimumPrice && product.Value <= maximumPrice
									select product;

			Console.WriteLine();
			foreach (Product product in productsBetweenThePrices)
				Console.WriteLine(product);
		}
		catch (FormatException ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	// Relatorio informando o valor total do estoque e valor toal de cada produto em estoque
	public void StockValueReport()
	{
		products.ForEach(product =>
		{
			float totalValueProduct = product.QuantityInStock * product.Value;
			Console.WriteLine($"{product.ProductCode} - {product.ProductName}: {totalValueProduct}");
		});

		float totalValueStock = products.Sum(p => p.QuantityInStock * p.Value);
		Console.WriteLine($"Total Stock Value: {totalValueStock}");
	}

}
