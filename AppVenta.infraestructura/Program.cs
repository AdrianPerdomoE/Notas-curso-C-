using AppVenta.infraestructura.datos.Contextos;

namespace AppVenta.infraestructura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creando la DB si no existe...");
            VentaContexto db = new VentaContexto();
            db.Database.EnsureCreated();
            Console.WriteLine("DB creada o ya existía.");
            Console.ReadKey();  
        }
    }
}
