using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FirstProgressProyect.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FirstProgressProyect.Models.Student> Student { get; set; } = default!;

public DbSet<FirstProgressProyect.Models.Admin> Admin { get; set; } = default!;

public DbSet<FirstProgressProyect.Models.Category> Category { get; set; } = default!;

public DbSet<FirstProgressProyect.Models.Competence> Competence { get; set; } = default!;

public DbSet<FirstProgressProyect.Models.StudentCompetence> StudentCompetence { get; set; } = default!;
    public DbSet<FirstProgressProyect.Models.Login> Logins { get; set; } = default!;
}
