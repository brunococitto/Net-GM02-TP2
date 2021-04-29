using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuario
    {
        public UsuarioLogic UsuarioNegocio { get; set; }
        public Usuario()
        {
            UsuarioNegocio = new UsuarioLogic();
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
            switch (LeerOpcionMenu())
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
            int opcion = 6;
            try
            {
                Console.Write("Ingrese la opción deseada: ");
                opcion = Convert.ToInt32(Console.ReadLine());
                if (opcion < 1 | opcion > 6)
                {
                    throw new Exception("La opción ingresada es incorrecta!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                LeerOpcionMenu();
            }
            return opcion;
        }
        private void ListadoGeneral() { }
        private void Consultar() { }
        private void Agregar() { }
        private void Modificar() { }
        private void Eliminar() { }
        private void MostrarDatos() { }
    }
}
