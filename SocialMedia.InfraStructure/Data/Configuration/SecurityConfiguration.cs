using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.InfraStructure.Data.Configuration
{
    public class SecurityConfiguration : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> builder)
        {
            builder.ToTable("Security");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("SecurityId");

            builder.Property(e => e.User)
            .HasColumnName("Users")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Username)
            .HasColumnName("Username")
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Password)
            .HasColumnName("Password")
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Role)
            .HasColumnName("Rol")
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasConversion(
                x=>x.ToString(), x=> (RoleType)Enum.Parse(typeof(RoleType), x));

        }
    }
}
