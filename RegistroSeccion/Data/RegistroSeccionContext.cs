using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegistroSeccion.Models;

namespace RegistroSeccion.Data
{
    public class RegistroSeccionContext : DbContext
    {
        public RegistroSeccionContext (DbContextOptions<RegistroSeccionContext> options)
            : base(options)
        {
        }

        public DbSet<RegistroSeccion.Models.Alumno> Alumno { get; set; } = default!;
        public DbSet<RegistroSeccion.Models.Asignacion> Asignacion { get; set; } = default!;
        public DbSet<RegistroSeccion.Models.Carrera> Carrera { get; set; } = default!;
    }
}
