using StudentAPI.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentAPI.Data.EntityConfiguration;

public class StudentConfiguration : IEntityTypeConfiguration<StudentEntity>
{
    public void Configure(EntityTypeBuilder<StudentEntity> builder)
    {
      
        builder.ToTable("Students", "Student");
        //
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
               .ValueGeneratedOnAdd()
               .HasColumnType("int");
        //
        builder.Property(s => s.FirstName)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnName("FirstName")
               .HasColumnType("nvarchar(50)");
        //
        builder.Property(s => s.LastName)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnName("LastName")
               .HasColumnType("nvarchar(50)");
        //
        builder.HasIndex(s => s.StudentNumber);
               //.IsUnique();
        builder.Property(s => s.StudentNumber)
               .IsRequired()
               .HasMaxLength(20)
               .HasColumnName("StudentNumber")
               .HasColumnType("nvarchar(20)");
        //
        builder.Property(s => s.Class)
               .IsRequired()
               .HasMaxLength(20)
               .HasColumnName("Class")
               .HasColumnType("nvarchar(20)");


    }
}
