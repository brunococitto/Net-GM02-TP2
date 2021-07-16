using System;
using Data.Database;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace UI.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Usuarios usrs = new Usuarios();
            usrs.Menu();
        }
    }
}
