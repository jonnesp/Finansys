using Finansys.Dominio.Entidades;
using System;

namespace Testes
{
    class Program
    {
        static void Main(string[] args)
        {
            var novaCategoria = new Categoria("Contas", "Todas as contas comuns (agua,luz,etc)", "joao.braghin");
            Console.WriteLine(novaCategoria.CategoriaId);
        }
    }
}
