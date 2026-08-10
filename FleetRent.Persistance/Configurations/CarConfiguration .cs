using FleetRent.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Persistance.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasOne(c => c.Branch)
                .WithMany(b => b.Cars)
                .HasForeignKey(c => c.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.CarCategory)
                .WithMany(cc => cc.Cars)
                .HasForeignKey(c => c.CarCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.PlateNumber)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
