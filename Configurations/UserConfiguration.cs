using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Omnistack.Models.User;

namespace Omnistack.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder){
            
            builder.ToTable("USER");

            builder.HasKey(c => c.Id)
                .HasName("ID");

            builder.Property(c => c.UserName)
                .HasColumnName("USER_NAME");

            builder.Property(c => c.Name)
                .HasColumnName("NAME");

            builder.Property(c => c.Avatar)
                .HasColumnName("AVATAR");

            builder.Property(c => c.Url)
                .HasColumnName("URL");

            builder.Property(c => c.Bio)
                .HasColumnName("BIO");

            builder.Property(c => c.Linkedin)
                .HasColumnName("LINKEDIN");

            builder.Property(c => c.Location)
                .HasColumnName("LOCATION");
        }
    }
}