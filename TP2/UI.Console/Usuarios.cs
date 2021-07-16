using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;
using Data.Database;

namespace UI.Consola
{
    public class Usuarios
    {
        public UsuarioLogic UsuarioNegocio { get; set; }
        public Usuarios()
        {
            AcademyContext context = new AcademyContext();
            UsuarioNegocio = new UsuarioLogic(new UsuarioAdapter(context));
        }
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Menú de opciones");
            Console.WriteLine("1 - Listado General");
            Console.WriteLine("2 - Consulta");
            Console.WriteLine("3 - Agregar");
            Console.WriteLine("4 - Modificar");
            Console.WriteLine("5 - Eliminar");
            Console.WriteLine("6 - Salir");
            int opcion;
            do
            {
                opcion = LeerOpcionMenu();
            } while (opcion == -1);
            switch (opcion)
            {
                case 1:
                    ListadoGeneral();
                    break;
                case 2:
                    Consultar();
                    break;
                case 3:
                    Agregar();
                    break;
                case 4:
                    Modificar();
                    break;
                case 5:
                    Eliminar();
                    break;
            }
        }
        private int LeerOpcionMenu()
        {
            int opcion = 0;
            try
            {
                Console.Write("Ingrese la opción deseada: ");
                opcion = Convert.ToInt32(Console.ReadLine());
                if (opcion < 1 | opcion > 6)
                {
                    throw new Exception("La opción ingresada es incorrecta, esta debe estar entre 1 y 6!");
                }
                return opcion;
            }
            catch (FormatException e)
            {
                Console.WriteLine("La opción ingresada es incorrecta, esta debe ser un número entero!");
                opcion = -1;
                return opcion;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                opcion = -1;
                return opcion;
            }
        }
        private void VolverAlMenu()
        {
            Console.Write("Presione ENTER para volver al menú principal.");
            Console.ReadLine();
            Menu();
        }
        private int SolicitarID()
        {
            int ID = 0;
            try
            {
                Console.Write("Ingrese el ID del usuario deseado: ");
                ID = Convert.ToInt32(Console.ReadLine());
                if (ID <= 0)
                {
                    throw new Exception();
                }
                Console.Clear();
                return ID;
            }
            catch (FormatException e)
            {
                Console.WriteLine("El ID ingresado no es válido, este debe ser un número entero!");
                ID = -1;
                return ID;
            }
            catch (Exception e)
            {
                Console.WriteLine("El ID ingresado no es válido, este debe ser un número entero mayor que 0!");
                ID = -1;
                return ID;
            }
        }
        private void ListadoGeneral()
        {
            Console.Clear();
            List<Usuario> lista = UsuarioNegocio.GetAll();
            foreach (Usuario usr in lista)
            {
                MostrarDatos(usr);
            }
            VolverAlMenu();
        }
        private void Consultar()
        {
            Console.Clear();
            int ID;
            do
            {
                ID = SolicitarID();
            } while (ID == -1);
            // el catch para la excepción de que no se ingresó un entero lo trato en SolicitarID()
            try
            {
                Usuario usr = UsuarioNegocio.GetOne(ID);
                MostrarDatos(usr);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                VolverAlMenu();
            }
        }
        private void Agregar()
        {
            Console.Clear();
            try
            {
                Usuario usr = new Usuario();
                Console.Write("Ingrese el nombre del usuario y presione ENTER: ");
                usr.Nombre = Console.ReadLine();
                Console.Write("Ingrese el apellido del usuario y presione ENTER: ");
                usr.Apellido = Console.ReadLine();
                Console.Write("Ingrese el nombre de usuario del usuario y presione ENTER: ");
                usr.NombreUsuario = Console.ReadLine();
                Console.Write("Ingrese la clave del usuario y presione ENTER: ");
                usr.Clave = Console.ReadLine();
                Console.Write("Ingrese el email del usuario y presione ENTER: ");
                usr.Email = Console.ReadLine();
                Console.Write("Ingrese el estado habilitado (True/False) del usuario y presione ENTER: ");
                usr.Habilitado = Convert.ToBoolean(Console.ReadLine());
                usr.State = BusinessEntity.States.New;
                UsuarioNegocio.Save(usr);
                Console.WriteLine($"El ID asignado al nuevo usuario es: {usr.ID}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                VolverAlMenu();
            }
        }
        private void Modificar()
        {
            Console.Clear();
            int ID;
            do
            {
                ID = SolicitarID();
            } while (ID == -1);
            try
            {
                Usuario usr = UsuarioNegocio.GetOne(ID);
                Console.WriteLine($"Está modificando el usuario: {usr.ID}");
                Console.Write($"El actual nombre del usuario es: {usr.Nombre}, ingrese el nombre modificado: ");
                usr.Nombre = Console.ReadLine();
                Console.Write($"El actual apellido del usuario es: {usr.Apellido}, ingrese el apellido modificado: ");
                usr.Apellido = Console.ReadLine();
                Console.Write($"El actual nombre de usuario del usuario es: {usr.NombreUsuario}, ingrese el nombre de usuario modificado: ");
                usr.NombreUsuario = Console.ReadLine();
                Console.Write($"La clave actual del usuario es: {usr.Clave}, ingrese la clave modificada: ");
                usr.Clave = Console.ReadLine();
                Console.Write($"El actual email del usuario es: {usr.Email}, ingrese el email modificado: ");
                usr.Email = Console.ReadLine();
                Console.Write($"El estado habilitado actual del usuario es: {usr.Habilitado}, ingrese el estado habilitado modificado: ");
                usr.Habilitado = Convert.ToBoolean(Console.ReadLine());
                usr.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usr);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                VolverAlMenu();
            }
        }
        private void Eliminar()
        {
            Console.Clear();
            int ID;
            do
            {
                ID = SolicitarID();
            } while (ID == -1);
            try
            {
                Usuario usr = UsuarioNegocio.GetOne(ID);
                Console.WriteLine($"El usuario a eliminar es: {usr.Nombre} {usr.Apellido}");
                UsuarioNegocio.Delete(ID);
                Console.WriteLine("Usuario eliminado!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                VolverAlMenu();
            }
        }
        private void MostrarDatos(Usuario usr)
        {
            // \t dentro de un string representa un TAB
            Console.WriteLine($"Usuario: {usr.ID}");
            Console.WriteLine($"\t\tNombre: {usr.Nombre}");
            Console.WriteLine($"\t\tApellido: {usr.Apellido}");
            Console.WriteLine($"\t\tNombre de Usuario: {usr.NombreUsuario}");
            Console.WriteLine($"\t\tClave: {usr.Clave}");
            Console.WriteLine($"\t\tEmail: {usr.Email}");
            Console.WriteLine($"\t\tHabilitado: {usr.Habilitado}");
            Console.WriteLine();
        }
    }
}
