using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using IU1.Models;

namespace IU1.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20171005124518_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IU1.Models.Case", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<DateTime>("DateOfObservation");

                    b.Property<string>("Department");

                    b.Property<string>("Employee");

                    b.Property<string>("Info");

                    b.Property<string>("InformerName")
                        .IsRequired();

                    b.Property<string>("InformerPhone")
                        .IsRequired();

                    b.Property<string>("Observation");

                    b.Property<string>("Place")
                        .IsRequired();

                    b.Property<string>("RefNumber");

                    b.Property<string>("Status");

                    b.Property<string>("TypeOfCrime")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("IU1.Models.Department", b =>
                {
                    b.Property<string>("DepartmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DepartmentName");

                    b.HasKey("DepartmentID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("IU1.Models.Employee", b =>
                {
                    b.Property<string>("EmployeeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Department");

                    b.Property<string>("EmployeeName");

                    b.Property<string>("RoleTitle");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("IU1.Models.Status", b =>
                {
                    b.Property<string>("StatusID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StatusName");

                    b.HasKey("StatusID");

                    b.ToTable("Statuses");
                });
        }
    }
}
