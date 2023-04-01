using Almacen2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen2.DAO
{
    public class CrudProductos
    {
        public void AgregarUsuario(Producto ParamentrosProducto)
        {

            using (Almacen2Context db =
                new Almacen2Context())
            {
                Producto producto = new Producto();
                producto.Nombre = ParamentrosProducto.Nombre;
                producto.Precio = ParamentrosProducto.Precio;
                producto.Descripcion = ParamentrosProducto.Descripcion;
                producto.Stock = ParamentrosProducto.Stock;
                db.Add(producto);
                db.SaveChanges();
            }
        }

        public Producto UsuarioIndividual(int id)
        {
            using (Almacen2Context bd = new Almacen2Context())
            {

                var buscar = bd.Productos.FirstOrDefault(x => x.Id == id);

                return buscar;
            }
        }
        public void ActualizarUsuario(Producto ParamentrosUsuario, int Lector)
        {
            using (Almacen2Context db =
                new Almacen2Context())
            {

                var buscar = UsuarioIndividual(ParamentrosUsuario.Id);
                if (buscar == null)
                {
                    Console.WriteLine("El id no existe");
                }
                else
                {
                    if (Lector == 1)
                    {
                        buscar.Nombre = ParamentrosUsuario.Nombre;
                        buscar.Descripcion = ParamentrosUsuario.Descripcion;
                    }
                    else
                    {
                        buscar.Precio = ParamentrosUsuario.Precio;
                        buscar.Stock = ParamentrosUsuario.Stock;
                    }

                    buscar.Descripcion = ParamentrosUsuario.Descripcion;
                    db.Update(buscar);
                    db.SaveChanges();

                }

            }
        }
        public string EliminarUsuario(int id)
        {
            using (Almacen2Context db =
                    new Almacen2Context())
            {
                var buscar = UsuarioIndividual(id);
                if (buscar == null)
                {
                    return "El usuario no existe";
                }
                else
                {
                    db.Productos.Remove(buscar);
                    db.SaveChanges();
                    return "El usuario se elimino";
                }
            }
        }

        public List<Producto> ListarProducto()
        {
            using (Almacen2Context db =
                   new Almacen2Context())
            {
                return db.Productos.ToList();
            }

        }

    }
}