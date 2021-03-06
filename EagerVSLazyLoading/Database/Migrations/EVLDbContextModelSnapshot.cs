// <auto-generated />
using EagerVSLazyLoading.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EagerVSLazyLoading.Database.Migrations
{
    [DbContext(typeof(EagerDbContext))]
    partial class EVLDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.14");

            modelBuilder.Entity("EagerVSLazyLoading.Model.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Math"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Chemistry"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Physical"
                        });
                });

            modelBuilder.Entity("EagerVSLazyLoading.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentId = 1,
                            Name = "mathUser1"
                        },
                        new
                        {
                            Id = 2,
                            DepartmentId = 1,
                            Name = "mathUser2"
                        },
                        new
                        {
                            Id = 3,
                            DepartmentId = 2,
                            Name = "chemUser1"
                        },
                        new
                        {
                            Id = 4,
                            DepartmentId = 2,
                            Name = "chemUser2"
                        },
                        new
                        {
                            Id = 5,
                            DepartmentId = 2,
                            Name = "chemUser3"
                        },
                        new
                        {
                            Id = 6,
                            DepartmentId = 3,
                            Name = "physUser1"
                        },
                        new
                        {
                            Id = 7,
                            DepartmentId = 3,
                            Name = "physUser2"
                        },
                        new
                        {
                            Id = 8,
                            DepartmentId = 3,
                            Name = "physUser3"
                        },
                        new
                        {
                            Id = 9,
                            DepartmentId = 3,
                            Name = "physUser4"
                        });
                });

            modelBuilder.Entity("EagerVSLazyLoading.Model.User", b =>
                {
                    b.HasOne("EagerVSLazyLoading.Model.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EagerVSLazyLoading.Model.Department", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
