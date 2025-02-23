﻿using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace TaxiDepo.Model;

/// <summary>
/// TaxiDepoDbContext class
/// </summary>
public sealed class TaxiDepoDbContext : DbContext
{
    /// <summary>
    /// Cars of Db
    /// </summary>
    public DbSet<Car>? Cars { get; set; }

    /// <summary>
    /// Drivers of Db
    /// </summary>
    public DbSet<Driver>? Drivers { get; set; }

    /// <summary>
    /// Users of Db
    /// </summary>
    public DbSet<User>? Users { get; set; }

    /// <summary>
    /// Rides of Db
    /// </summary>
    public DbSet<Ride>? Rides { get; set; }

    /// <summary>
    /// TaxiDepoDbContext constructor 
    /// </summary>
    public TaxiDepoDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    /// <summary>
    /// OnModelCreating method
    /// </summary>
    /// <param name="modelBuilder">EF param</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var car1 = new Car
        {
            Id = 1,
            CarColor = "Black",
            CarModel = "Geely Atlas",
            CarNumber = "A232MM133",
            DriverId = 10
        };
        var car2 = new Car
        {
            Id = 2,
            CarColor = "White",
            CarModel = "Geely Emgrand",
            CarNumber = "A111AA11",
            DriverId = 9
        };
        var car3 = new Car
        {
            Id = 3,
            CarColor = "Pink",
            CarModel = "BMW E34",
            CarNumber = "M111MM133",
            DriverId = 8
        };
        var car4 = new Car
        {
            Id = 4,
            CarColor = "Green",
            CarModel = "BMW E39",
            CarNumber = "M117AM78",
            DriverId = 7
        };

        modelBuilder.Entity<Car>().HasData(new List<Car>() { car1, car2, car3, car4 });

        var driver1 = new Driver
        {
            Id = 10,
            DriverSurname = "Antonov",
            DriverName = "V.",
            DriverPatronymic = "A.",
            DriverAddress = "Samara",
            DriverPassportId = 121234,
            DriverPhoneNumber = "89128764929"
        };
        var driver2 = new Driver
        {
            Id = 9,
            DriverSurname = "Antipov",
            DriverName = "V.",
            DriverPatronymic = "V.",
            DriverAddress = "Moscow",
            DriverPassportId = 193829,
            DriverPhoneNumber = "89123456789"
        };
        var driver3 = new Driver
        {
            Id = 8,
            DriverSurname = "Pavlov",
            DriverName = "A.",
            DriverPatronymic = "O.",
            DriverAddress = "Orel",
            DriverPassportId = 493928,
            DriverPhoneNumber = "89987654321"
        };
        var driver4 = new Driver
        {
            Id = 7,
            DriverSurname = "Oev",
            DriverName = "D.",
            DriverPatronymic = "D.",
            DriverAddress = "Orsk",
            DriverPassportId = 584393,
            DriverPhoneNumber = "89898987766"
        };

        modelBuilder.Entity<Driver>().HasData(new List<Driver>() { driver1, driver2, driver3, driver4 });

        var trip1 = new Ride
        {
            Id = 1,
            TripDate = new DateTime(2022, 01, 01, 11, 11, 11),
            CarId = 1,
            TripPrice = 223,
            TripTime = 121,
            TripDeparturePlace = "Samara",
            TripDestinationPlace = "Moscow",
            UserId = 1
        };
        var trip2 = new Ride
        {
            Id = 2,
            TripDate = new DateTime(2020, 01, 01, 11, 11, 11),
            CarId = 2,
            TripPrice = 423,
            TripTime = 57,
            TripDeparturePlace = "Orsk",
            TripDestinationPlace = "Moscow",
            UserId = 2
        };
        var trip3 = new Ride
        {
            Id = 3,
            TripDate = new DateTime(2018, 02, 02, 12, 12, 12),
            CarId = 3,
            TripPrice = 243,
            TripTime = 34,
            TripDeparturePlace = "Orel",
            TripDestinationPlace = "Orsk",
            UserId = 3
        };
        var trip4 = new Ride
        {
            Id = 4,
            TripDate = new DateTime(2015, 11, 11, 03, 31, 31),
            CarId = 4,
            TripPrice = 777,
            TripTime = 34,
            TripDeparturePlace = "Moscow",
            TripDestinationPlace = "Orel",
            UserId = 4
        };

        modelBuilder.Entity<Ride>().HasData(new List<Ride>() { trip1, trip2, trip3, trip4 });

        var user1 = new User
        {
            Id = 1,
            UserName = "A.",
            UserSurname = "Kurin",
            UserPatronymic = "P.",
            UserPhoneNumber = "89124325748"
        };
        var user2 = new User
        {
            Id = 2,
            UserName = "L.",
            UserSurname = "Tulin",
            UserPatronymic = "D.",
            UserPhoneNumber = "89174239284"
        };
        var user3 = new User
        {
            Id = 3,
            UserName = "M.",
            UserSurname = "Sofin",
            UserPatronymic = "D.",
            UserPhoneNumber = "89234894244"
        };
        var user4 = new User
        {
            Id = 4,
            UserName = "N.",
            UserSurname = "Korin",
            UserPatronymic = "P.",
            UserPhoneNumber = "89113223921"
        };

        modelBuilder.Entity<User>().HasData(new List<User>() { user1, user2, user3, user4 });

        modelBuilder.Entity<Car>().HasKey(e => e.Id);
        modelBuilder.Entity<Driver>().HasKey(e => e.Id);
        modelBuilder.Entity<User>().HasKey(e => e.Id);
        modelBuilder.Entity<Ride>().HasKey(e => e.Id);
    }
}
