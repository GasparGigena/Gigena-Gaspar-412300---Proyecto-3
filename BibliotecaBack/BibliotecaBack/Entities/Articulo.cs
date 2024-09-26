namespace proyecto_Practica02_.Entities;

public class Articulo
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }

    public Articulo()
    {
        Codigo = 0;
        Nombre = string.Empty;
        Precio = 0;        
    }
    public Articulo(int codigo, string nombre, int precio)
    {
        Codigo = codigo;
        Nombre = nombre;
        Precio = precio;
    }
    public override string ToString()
    {
        return $"Codigo: {Codigo}, Nombre: {Nombre}, Precio: {Precio}";
    }
}
