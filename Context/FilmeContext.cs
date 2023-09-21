using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WEBAPI_Filmes.Models;

namespace WEBAPI_Filmes.Context
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> options) : base(options) { }

        public DbSet<Filme> Filmes { get; set; }
    }
}