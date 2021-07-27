using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Finansys.Data.Repository.Contexto
{
    public class ContextoFabrica : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Port=3306;Database=Fynansys;Uid=root;Pwd=mudar@123";
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 4, 17)));
            return new Context(optionsBuilder.Options);
        }
    }
}
