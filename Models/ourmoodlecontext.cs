using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text.RegularExpressions;

namespace Kyzmav2.Models
{
    public class ourmoodlecontext: DbContext
    {
        

        public ourmoodlecontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<notetype> notetypes { get; set; }
        public DbSet<role> roles { get; set; }
        public DbSet<groups> groups { get; set; }
        public DbSet<userss> userss { get; set; }
        public DbSet<notes> notes { get; set; }
        public DbSet<working_plan> working_plans { get; set; }
        public DbSet<homework> homeworks { get; set; }
        public DbSet<dates_of_dz> dates_of_dzs { get; set; }
        public DbSet<comment_teacher> comment_teachers { get; set; }
        public DbSet<commentstudent> commentstudents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=kyzma;Username=postgres;Password=123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<notes>()
                .HasOne(n => n.userss)
                .WithMany(u => u.notes)
                .HasForeignKey(n => n.UserId);

            modelBuilder.Entity<notes>()
                .HasOne(n => n.notetypes)
                .WithMany(nt => nt.notes)
                .HasForeignKey(n => n.NotesTypeId);

            modelBuilder.Entity<userss>()
                .HasOne(u => u.roles)
                .WithMany(r => r.userss)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<userss>()
                .HasOne(u => u.groups)
                .WithMany(g => g.userss)
                .HasForeignKey(u => u.GroupId);

            modelBuilder.Entity<working_plan>()
                .HasOne(wp => wp.userss)
                .WithMany(u => u.working_plans)
                .HasForeignKey(wp => wp.UserId);

            modelBuilder.Entity<homework>()
                .HasOne(hw => hw.working_plans)
                .WithMany(wp => wp.homeworks)
                .HasForeignKey(hw => hw.PlanId);

            modelBuilder.Entity<dates_of_dz>()
                .HasOne(dz => dz.homeworks)
                .WithMany(hw => hw.dates_of_dzs)
                .HasForeignKey(dz => dz.HomeworkId);

            modelBuilder.Entity<comment_teacher>()
                .HasOne(ct => ct.homeworks)
                .WithMany(hw => hw.comment_teachers)
                .HasForeignKey(ct => ct.HomeworkId);

            modelBuilder.Entity<commentstudent>()
                .HasOne(cs => cs.homeworks)
                .WithMany(hw => hw.commentstudents)
                .HasForeignKey(cs => cs.HomeworkId);

            modelBuilder.Entity<role>().HasData(
                new role { RoleId = 1, RoleName = "Учитель" },
                 new role { RoleId = 2, RoleName = "Студенет" }
                
            );

            modelBuilder.Entity<notetype>().HasData(
               new notetype { NotesTypeId = 1, NoteTypeName = "First" },
                new notetype { NotesTypeId = 2, NoteTypeName = "Second" },
                new notetype { NotesTypeId = 3, NoteTypeName = "Third" }

           );
        }
    }
}
