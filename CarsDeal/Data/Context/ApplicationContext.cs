using CarsDeal.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDeal.Data.Context
{
    internal class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                new SqlConnectionStringBuilder()
                {
                    DataSource = "(localDb)\\MSSQLLocalDB",
                    InitialCatalog = "CarDealDb2"

                }.ConnectionString
                );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserType>().HasData(
                new UserType[]
                {
                    new UserType { UserTypeId=1, TypeName="Админиистратор"},
                    new UserType { UserTypeId=2, TypeName="Оператор"},
                    new UserType { UserTypeId=3, TypeName="Автомахник"}
                });
            modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus[]
                {
                    new OrderStatus {OrderStatusId=1, StatusName="В обработке"},
                    new OrderStatus {OrderStatusId=2, StatusName="Готова"}
                });
        }
    }

}
