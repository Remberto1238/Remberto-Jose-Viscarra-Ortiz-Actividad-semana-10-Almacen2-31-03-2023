using Almacen2.DAO;
using Almacen2.Models;

Console.WriteLine("Precio 1 para Insertar Productos");

Console.WriteLine("Precio 2 para Actualizar Producto");

Console.WriteLine("Precio 3 para Eliminar Producto");

Console.WriteLine("Precio 4 para Mostrar Lista de La Base de Dato");

var menu = Convert.ToInt32(Console.ReadLine());


Producto producto = new Producto();
CrudProductos crudProducto = new CrudProductos();


bool Continuar = true;
while (Continuar)
    switch (menu)
{
    case 1:
        Console.WriteLine("Ingrese El Nombre del Producto: ");
        producto.Nombre = Console.ReadLine();

        Console.WriteLine("Ingrese la Descripcion del Producto: ");
        producto.Descripcion = Console.ReadLine();

        Console.WriteLine("Ingrese el Precio del Producto: ");
        producto.Precio = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese la Cantidad de Stock: ");
        producto.Stock = Convert.ToInt32(Console.ReadLine());

        crudProducto.AgregarUsuario(producto);
        
        Console.WriteLine("Su Registro Ha Sido Guardado Exitosamente...");
        
        Console.WriteLine("");

        break;

    case 2:
        Console.WriteLine("Actualizar datos");
        Console.WriteLine("");
        Console.WriteLine("Ingresa el ID del usuario a actualizar");
        var UsuarioIndividualU = crudProducto.UsuarioIndividual(Convert.ToInt32(Console.ReadLine()));
        if (UsuarioIndividualU == null)
        {
            Console.WriteLine("El Usuario no existe");
        }
        else
        {
            Console.WriteLine($"Nombre: {UsuarioIndividualU.Nombre}, Descripcion: {UsuarioIndividualU.Descripcion}, Precio: {UsuarioIndividualU.Precio}, Stock: {UsuarioIndividualU.Stock}");

            Console.WriteLine("");

            Console.WriteLine("Nombre y Descripcion preciona 1");

            Console.WriteLine("");

            Console.WriteLine("Precio y Stock preciona 2");

            var Lector = Convert.ToInt32(Console.ReadLine());
            if (Lector == 1)
            {
                Console.WriteLine("Ingrese el nuevo Nombre: ");
                UsuarioIndividualU.Nombre = (Console.ReadLine());

                Console.WriteLine("");

                Console.WriteLine("Ingrese la nueva Descripcion: ");
                UsuarioIndividualU.Descripcion = (Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Ingrese el nuevo Precio: ");
                UsuarioIndividualU.Precio = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("");

                Console.WriteLine("Ingrese el nuevo Stock: ");
                UsuarioIndividualU.Stock = Convert.ToInt32(Console.ReadLine());
            }
            crudProducto.ActualizarUsuario(UsuarioIndividualU, Lector);
            Console.WriteLine("");
            Console.WriteLine("Actualizacion Correcta");
        }
        break;
    case 3:
        Console.WriteLine("Ingresa el Id a Eliminar");
        var UsuarioIndividualD = crudProducto.UsuarioIndividual(Convert.ToInt32(Console.ReadLine()));
        if (UsuarioIndividualD == null)
        {
            Console.WriteLine("Este Usuario no Existe");
        }
        else
        {
            Console.WriteLine("Eliminar usuario");
            Console.WriteLine("");
            Console.WriteLine($"Nombre: {UsuarioIndividualD.Nombre}, Descripcion: {UsuarioIndividualD.Descripcion}, Precio: {UsuarioIndividualD.Precio}, Stock: {UsuarioIndividualD.Stock},");
            Console.WriteLine("");
            Console.WriteLine("El usuario encontrado es el correcto?");
            var Lector = Convert.ToInt32(Console.ReadLine());
            if (Lector == 1)
            {
                var Id = Convert.ToInt32(UsuarioIndividualD.Id);
                Console.WriteLine(crudProducto.EliminarUsuario(Id));
            }
            else
            {
                Console.WriteLine("Inicia Nuevamente");
            }
        }
        break;
    case 4:
        Console.WriteLine("Lista de Productos");
        var ListarProducto = crudProducto.ListarProducto();
        foreach (var iteracionProducto in ListarProducto)
        {
            Console.WriteLine($"{iteracionProducto.Id}, {iteracionProducto.Nombre},  " +
                $"{iteracionProducto.Descripcion}, {iteracionProducto.Precio}, {iteracionProducto.Stock}");

        }
        break;
}
Console.WriteLine("");
Console.WriteLine("Desea continuar ?");
var cont = Console.ReadLine();
if (cont.Equals("N"))
{
    Continuar = false;
}

}