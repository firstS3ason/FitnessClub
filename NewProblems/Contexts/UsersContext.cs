using Microsoft.EntityFrameworkCore;
using NewProblems.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NewProblems.Contexts
{
    /*
     * Заметки:
     * DbContext - Класс, что создан для определения констекста данных, что в дальнейшем будут использоваться при взаимодействии с БД.
     * DbSet или обобщенный аналог - DbSet<Class>, классы : воссоздают экземпляры, хранящиеся внутри себя таблицы, для потенциальной БД.
     * DbContextOptionsBuilder - класс, позволяет создать экземпляр, от лица которого Вы настраиваете подключение к нужной БД.
    */


    public class UsersContext : DbContext // Для использования методов, конструкторов и свойств ниже, мы воссоздаем наследование от данного класса.
    {
        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<CoachInvites> CoachInvites { get; set; } = null!;
        public DbSet<Coaches> Coaches { get; set; } = null!;

        public DbSet<TrainingsList> TrainingsList { get; set; } = null!;

        public UsersContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Data Source=OnlyMyself\YAYA;Database=Fitnesss;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>().HasData(new Users()
            {
                ID = 1,
                Login = "owner",
                Password = "owner",
                Permissions = "Administrator"

            });
            modelBuilder.Entity<CoachInvites>().HasData(new CoachInvites()
            {
                ID = 1,
                CoachName = "He",
                RequestStatus = "E"
            });

            modelBuilder.Entity<Coaches>().HasData(new Coaches()
            {

                CoachId = 1,
                CoachName = "Igor",
                Age = 53,
                Gender = "Helicopter",
                InOurGymFrom = DateTime.Now,
                SpecialistIn = "Hight weight tooks up",
                YearsInStudyPractise = 23


            });

            modelBuilder.Entity<TrainingsList>().HasData(new TrainingsList()
            {
                ID = 1,
                CoachName = "Igor",
                ActionsPerRepeat = 23,
                Repeats = 2,
                TypeOfExcersice = "Push Ups",
                CreatedForWho = "owner"
            });

        }

        public IQueryable<Users> GetAll()
        {
            return Users;

        }

        public IQueryable<CoachInvites> CoachInvitesGetAll()
        {
            return CoachInvites;

        }

        public IQueryable<Coaches> CoachGetAll()
        {
            return Coaches;
        }

    }
}
