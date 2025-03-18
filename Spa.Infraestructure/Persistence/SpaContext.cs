using Microsoft.EntityFrameworkCore;
using Spa.Domain.AgregatesRoot.agenda;
using Spa.Domain.AgregatesRoot.plan;

namespace Spa.Infraestructure.Persistence
{
    public class SpaContext : DbContext
    {
        public SpaContext(DbContextOptions<SpaContext> options) : base(options)
        {
        }

        //public SpaContext()
        //: base(new DbContextOptionsBuilder<SpaContext>()
        //.UseSqlServer(@"server=ecope-cacuellar\sqlexpress;database=spa;trusted_connection=true;encrypt=false;connectretrycount=0")
        //.Options)
        //{ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agenda>()
                .HasOne(a => a.Plan)
                .WithMany(p => p.Agendas)
                .HasForeignKey(a => a.PlanId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Plan> Plans { get; set; }

    }
}
