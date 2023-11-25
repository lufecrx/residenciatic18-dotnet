using System;
using System.Text;

public class Product
{
	// Campos
	private (int ProductCode, string ProductName, int QuantityInStock, float Value) productDetails;

	// Propriedades
	public (int, string, int, float) ProductDetails 
	{ 
		get { return productDetails; }  
		private set { }  	
	}

	public int ProductCode 
	{ 
		get { return productDetails.ProductCode; }  
		private set {  }  	
	}
	public string ProductName 	{ 
		get { return productDetails.ProductName; }  
		private set {}  	
	}
	public int QuantityInStock 	{ 
		get { return productDetails.QuantityInStock; }  
		set { if((productDetails.QuantityInStock += value) < 0) {return;} 
			  else {productDetails.QuantityInStock = value;}
			}  	
	}
	public float Value 	{ 
		get { return productDetails.Value; }  
		private set {}  	
	}

	public Product()
	{
		// Valores padrões para os detalhes do produto
		productDetails = (-1, "", 0, 0.0f);
	}

	public Product(int productCode, string productName, int quantityInStock, float value)
	{
		// Criando produto com parametros
		productDetails = (productCode, productName, quantityInStock, value);		
	}

	// Override object.ToString()
	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Product Code: {ProductCode}");
			sb.AppendLine($"Product Name: {ProductName}");
			sb.AppendLine($"Quantity In Stock: {QuantityInStock}");
			sb.AppendLine($"Value: {Value}");
		return sb.ToString();
	}
}
