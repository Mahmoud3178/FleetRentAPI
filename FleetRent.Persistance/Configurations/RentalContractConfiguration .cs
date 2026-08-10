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
    public class RentalContractConfiguration : IEntityTypeConfiguration<RentalContract>

    {
        public void Configure(EntityTypeBuilder<RentalContract> builder)
        {
            builder.HasOne(rc => rc.Booking)
                .WithOne()
                .HasForeignKey<RentalContract>(rc => rc.BookingId)
                .OnDelete(DeleteBehavior.Restrict);

            // علاقة الموظف - لازم Restrict عشان تتجنب Multiple Cascade Paths
            builder.HasOne(rc => rc.Employee)
                .WithMany()
                .HasForeignKey(rc => rc.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(rc => rc.TotalAmount)
                .HasColumnType("decimal(18,2)");
        }
    }
}
