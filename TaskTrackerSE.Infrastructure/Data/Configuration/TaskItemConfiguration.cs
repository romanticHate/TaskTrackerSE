using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerSE.Core.Entities;

namespace TaskTrackerSE.Infrastructure.Data.Configuration
{
    public class TaskItemConfiguration: IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.ToTable("TareaItem");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("IdTaskItem");

            builder.Property(e => e.Title)
                .HasColumnName("Titulo")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Description)
                .HasColumnName("Descripcion")
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Date)
               .HasColumnName("Fecha")
               .HasColumnType("date");

            builder.Property(e => e.IsActive)
              .HasColumnName("Habilitado");

            builder.Property(e => e.EmployeeID)
                .HasColumnName("IdEmpleado");

        }
    }
}
