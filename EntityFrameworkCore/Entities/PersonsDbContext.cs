using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class PersonsDbContext : DbContext
    {
        public PersonsDbContext(DbContextOptions<PersonsDbContext> options) :base(options) { 
        
        }
        //An instance of DBContext is responsible to hold a set of DBSets and represent a connection with the db
        public DbSet<Country> Countries { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().ToTable("Countries");
            modelBuilder.Entity<Person>().ToTable("Persons");
            
       

            //Seed Data to Countries
            //1-Read the file content:
            string countriesJson = System.IO.File.ReadAllText("countries.json");
            //2-Deserialize json format into list of countries:
            List<Country> countries = System.Text.Json.JsonSerializer.Deserialize<List<Country>>(countriesJson)!;
            //modelBuilder.Entity<Country>().HasData(new Country()
            //{
            //    CountryID = Guid.NewGuid(),
            //    CountryName = "Sample"
            //});
            //Instead of creating a country one by one, add the countries from json file:
            foreach (Country country in countries) { 
                modelBuilder.Entity<Country>().HasData(country);
            }

            //Seed Data to Persons
            string personsJson = System.IO.File.ReadAllText("persons.json");
            
            List<Person> persons = System.Text.Json.JsonSerializer.Deserialize<List<Person>>(personsJson)!;
            
            foreach (Person person in persons)
            {
                modelBuilder.Entity<Person>().HasData(person);
            }
        }

        //Access stored procedure
        public List<Person> sp_GetAllPersons()
        {
            return Persons.FromSqlRaw("EXECUTE [dbo].[GetAllPersons]").ToList();
        }
    }
}
