using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDLRouteHelper.Data;
using System.Data.Entity.Migrations;
using CDLRouteHelper.Data.Model;
using System.Data.Entity.Validation;

namespace CDLRouteHelper.Data.Migrations
{
    public class Seeder
    {
        public static void Seed(CDLRouteHelper.Data.CDLContext context, bool seedUser = true, bool seedUserAddress = true, bool seedState = true, bool seedBridge = true, bool seedWeight = true, bool seedRoles = true, bool seedUserRoles = true, bool seedMembership = true)
        {
            if (seedUser) SeedUser(context);
            if (seedState) SeedState(context);
            if (seedUserAddress) SeedUserAddress(context);
            if (seedBridge) SeedBridge(context);
            if (seedWeight) SeedWeight(context);
            if (seedRoles) SeedRoles(context);
            if (seedUserRoles) SeedUserRoles(context);
            if (seedMembership) SeedMembership(context);

        }

        private static void SeedUser(CDLContext context)
        {
            context.User.AddOrUpdate(u => u.Email,
                new User() { Username = "Admin01", FirstName = "Donovan", LastName = "May", Email = "Frannie@May.com" },
                new User() { Username = "Staff01", FirstName = "Freddie", LastName = "Mack", Email = "Freddie@Mack.com" },
                new User() { Username = "User01", FirstName = "Darth", LastName = "Vader", Email = "Darth@deathstar.com" },
                new User() { Username = "Admin02", FirstName = "Loke", LastName = "Groundrunner", Email = "Loke@groundrunner.com" },
                new User() { Username = "Staff02", FirstName = "Grumpy", LastName = "Pants", Email = "Grumpy@pants.com" },
                new User() { Username = "User02", FirstName = "Captain", LastName = "Crunch", Email = "crunch@gmail.com" });

            context.SaveChanges();
        }

        private static void SeedRoles(CDLContext context)
        {
            context.Roles.AddOrUpdate(r => r.Name,
                new Role() { Name = Role.ADMINISTRATOR },
                new Role() { Name = Role.STAFF },
                new Role() { Name = Role.USER }
                );

            context.SaveChanges();
        }

        private static void SeedUserRoles(CDLContext context)
        {
            context.UserRole.AddOrUpdate(ur => ur.UserId,
                new UserRole() { UserId = 1, RoleId = 1 },
                new UserRole() { UserId = 2, RoleId = 2 },
                new UserRole() { UserId = 3, RoleId = 3 },
                new UserRole() { UserId = 4, RoleId = 1 },
                new UserRole() { UserId = 5, RoleId = 2 },
                new UserRole() { UserId = 6, RoleId = 3 }
                );

            context.SaveChanges();
        }

        private static void SeedMembership(CDLContext context)
        {
            try
            {
                context.Memberships.AddOrUpdate(m => m.UserId,    //userID is PK
                new Membership() { UserId = 1, CreateDate = DateTime.UtcNow, IsConfirmed = true, PasswordFailuresSinceLastSuccess = 0, Password = "ALlZTyhnwc0adbi+mk5Co7tTwwn8he5Nsv0rVzBKCaAJW7rH7tWktvPehMjGj7BhiQ==", PasswordSalt = "" },
                new Membership() { UserId = 2, CreateDate = DateTime.UtcNow, IsConfirmed = true, PasswordFailuresSinceLastSuccess = 0, Password = "ALlZTyhnwc0adbi+mk5Co7tTwwn8he5Nsv0rVzBKCaAJW7rH7tWktvPehMjGj7BhiQ==", PasswordSalt = "" },
                new Membership() { UserId = 3, CreateDate = DateTime.UtcNow, IsConfirmed = true, PasswordFailuresSinceLastSuccess = 0, Password = "ALlZTyhnwc0adbi+mk5Co7tTwwn8he5Nsv0rVzBKCaAJW7rH7tWktvPehMjGj7BhiQ==", PasswordSalt = "" },
                new Membership() { UserId = 4, CreateDate = DateTime.UtcNow, IsConfirmed = true, PasswordFailuresSinceLastSuccess = 0, Password = "ALlZTyhnwc0adbi+mk5Co7tTwwn8he5Nsv0rVzBKCaAJW7rH7tWktvPehMjGj7BhiQ==", PasswordSalt = "" },
                new Membership() { UserId = 5, CreateDate = DateTime.UtcNow, IsConfirmed = true, PasswordFailuresSinceLastSuccess = 0, Password = "ALlZTyhnwc0adbi+mk5Co7tTwwn8he5Nsv0rVzBKCaAJW7rH7tWktvPehMjGj7BhiQ==", PasswordSalt = "" },
                new Membership() { UserId = 6, CreateDate = DateTime.UtcNow, IsConfirmed = true, PasswordFailuresSinceLastSuccess = 0, Password = "ALlZTyhnwc0adbi+mk5Co7tTwwn8he5Nsv0rVzBKCaAJW7rH7tWktvPehMjGj7BhiQ==", PasswordSalt = "" }
                );

                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    ////  Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    //     eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        private static void SeedUserAddress(CDLContext context)
        {
            context.UserAddress.AddOrUpdate(a => new { a.Address1 },
               new UserAddress() { Address1 = "1234 Dearborn Pkwy", Address2 = "Address Line 2", City = "Houston", PostalCode = "12345", StateId = 43, UserId = 1 },
               new UserAddress() { Address1 = "5678 Transit St", Address2 = "Address Line 2", City = "Houston", PostalCode = "12345", StateId = 43, UserId = 2 },
               new UserAddress() { Address1 = "8912 Stone Rd", Address2 = "Address Line 2", City = "Houston", PostalCode = "12345", StateId = 43, UserId = 3 },
               new UserAddress() { Address1 = "12 Black St", Address2 = "Address Line 2", City = "Houston", PostalCode = "12345", StateId = 43, UserId = 4 },
               new UserAddress() { Address1 = "8932 Fisk Rd", Address2 = "Address Line 2", City = "Houston", PostalCode = "12345", StateId = 43, UserId = 5 },
               new UserAddress() { Address1 = "4023 Carriage Lane", Address2 = "Address Line 2", City = "Houston", PostalCode = "12345", StateId = 43, UserId = 6 }
             );

            context.SaveChanges();
        }


        private static void SeedState(CDLContext context)
        {
            context.State.AddOrUpdate(s => s.PostalCode,
               new State() { Name = "Alabama", PostalCode = "AL", CountryId = 1 },
               new State() { Name = "Alaska", PostalCode = "AK", CountryId = 1 },
               new State() { Name = "Arizona", PostalCode = "AZ", CountryId = 1 },
               new State() { Name = "Arkansas", PostalCode = "AR", CountryId = 1 },
               new State() { Name = "California", PostalCode = "CA", CountryId = 1 }, //5
               new State() { Name = "Colorado", PostalCode = "CO", CountryId = 1 },
               new State() { Name = "Connecticut", PostalCode = "CT", CountryId = 1 },
               new State() { Name = "Deleware", PostalCode = "DE", CountryId = 1 },
               new State() { Name = "Florida", PostalCode = "FL", CountryId = 1 },
               new State() { Name = "Georgia", PostalCode = "GA", CountryId = 1 }, //10
               new State() { Name = "Hawaii", PostalCode = "HI", CountryId = 1 },
               new State() { Name = "Idaho", PostalCode = "ID", CountryId = 1 },
               new State() { Name = "Illinois", PostalCode = "IL", CountryId = 1 },
               new State() { Name = "Indiana", PostalCode = "IN", CountryId = 1 },
               new State() { Name = "Iowa", PostalCode = "IA", CountryId = 1 },
               new State() { Name = "Kansas", PostalCode = "KS", CountryId = 1 }, //16
               new State() { Name = "Kentucky", PostalCode = "KY", CountryId = 1 },
               new State() { Name = "Lousiana", PostalCode = "LA", CountryId = 1 },
               new State() { Name = "Maine", PostalCode = "ME", CountryId = 1 },
               new State() { Name = "Maryland", PostalCode = "MD", CountryId = 1 }, //20
               new State() { Name = "Massachucetts", PostalCode = "MA", CountryId = 1 },
               new State() { Name = "Michigan", PostalCode = "MI", CountryId = 1 },
               new State() { Name = "Minnesota", PostalCode = "MN", CountryId = 1 },
               new State() { Name = "Mississippi", PostalCode = "MS", CountryId = 1 },
               new State() { Name = "Missouri", PostalCode = "MO", CountryId = 1 },//25
               new State() { Name = "Montana", PostalCode = "MT", CountryId = 1 },
               new State() { Name = "Nebraska", PostalCode = "NE", CountryId = 1 },
               new State() { Name = "Nevada", PostalCode = "NV", CountryId = 1 },
               new State() { Name = "New Hampshire", PostalCode = "NH", CountryId = 1 },
               new State() { Name = "New Jersey", PostalCode = "NJ", CountryId = 1 },//30
               new State() { Name = "New Mexico", PostalCode = "NM", CountryId = 1 },
               new State() { Name = "New York", PostalCode = "NY", CountryId = 1 },
               new State() { Name = "North Carolina", PostalCode = "NC", CountryId = 1 },
               new State() { Name = "North Dakota", PostalCode = "ND", CountryId = 1 },
               new State() { Name = "Ohio", PostalCode = "OH", CountryId = 1 }, //35
               new State() { Name = "Oklahoma", PostalCode = "OK", CountryId = 1 },
               new State() { Name = "Oregon", PostalCode = "OR", CountryId = 1 },
               new State() { Name = "Pennsylvania", PostalCode = "PA", CountryId = 1 },
               new State() { Name = "Rhode Island", PostalCode = "RI", CountryId = 1 },
               new State() { Name = "South Carolina", PostalCode = "SC", CountryId = 1 }, //40
               new State() { Name = "South Dakota", PostalCode = "SD", CountryId = 1 },
               new State() { Name = "Tennessee", PostalCode = "TN", CountryId = 1 },
               new State() { Name = "Texas", PostalCode = "TX", CountryId = 1 },
               new State() { Name = "Utah", PostalCode = "UT", CountryId = 1 },
               new State() { Name = "Vermont", PostalCode = "VT", CountryId = 1 }, //45
               new State() { Name = "Virginia", PostalCode = "VA", CountryId = 1 },
               new State() { Name = "Washington", PostalCode = "WA", CountryId = 1 },
               new State() { Name = "West Virgina", PostalCode = "WV", CountryId = 1 },
               new State() { Name = "Wisconsin", PostalCode = "WI", CountryId = 1 },
               new State() { Name = "Wyoming", PostalCode = "WY", CountryId = 1 } //50
               );

            context.SaveChanges();
        }

        private static void SeedBridge(CDLContext context)
        {
            context.Bridge.AddOrUpdate(b => new { b.Address1 },

                 //new Bridge()
                //{
                //    Guid = Guid.NewGuid(),
                //    Height = 14.0f,
                //    LastUpdated = DateTime.UtcNow,
                //    NumTimesReported = 1,
                //    Address1 = "Airport Blvd @ Mykawa Rd",
                //    City = "Houston",
                //    PostalCode = "12345",
                //    StateId = 43,
                //    Latitude = 29.645679f,
                //    Longitude = -95.312018f
                //},
                //   new Bridge()
                //   {
                //       Guid = Guid.NewGuid(),
                //       Height = 10.5f,
                //       LastUpdated = DateTime.UtcNow,
                //       NumTimesReported = 3,
                //       Address1 = "LawnDale St @ San Antonio St",
                //       City = "Houston",
                //       PostalCode = "12345",
                //       StateId = 43,
                //       Latitude = 29.716600f,
                //       Longitude = -95.284102f
                //   },
                //   new Bridge()
                //   {
                //       Guid = Guid.NewGuid(),
                //       Height = 12.5f,
                //       LastUpdated = DateTime.UtcNow,
                //       NumTimesReported = 2,
                //       Address1 = "Griggs Rd @ Evergreen Dr",
                //       City = "Houston",
                //       PostalCode = "12345",
                //       StateId = 43,
                //       Latitude = 29.716824f,
                //       Longitude = -95.290153f
                //   },
                //   new Bridge()
                //   {
                //       Guid = Guid.NewGuid(),
                //       Height = 14.0f,
                //       LastUpdated = DateTime.UtcNow,
                //       NumTimesReported = 1,
                //       Address1 = "Telephone Rd @ Tellespen St",
                //       City = "Houston",
                //       PostalCode = "12345",
                //       StateId = 43,
                //       Latitude = 29.726216f,
                //       Longitude = -95.324743f
                //   },
                //   new Bridge()
                //   {
                //       Guid = Guid.NewGuid(),
                //       Height = 10.5f,
                //       LastUpdated = DateTime.UtcNow,
                //       NumTimesReported = 3,
                //       Address1 = "N Transit @ Green St",
                //       City = "Lockport",
                //       PostalCode = "14094",
                //       StateId = 32,
                //       Latitude = 43.172961f,
                //       Longitude = -78.696839f
                //   },
                //   new Bridge()
                //   {
                //       Guid = Guid.NewGuid(),
                //       Height = 12.5f,
                //       LastUpdated = DateTime.UtcNow,
                //       NumTimesReported = 2,
                //       Address1 = "Cold Springs Rd @ Chestnut Ridge",
                //       City = "Hartland",
                //       PostalCode = "14032",
                //       StateId = 32,
                //       Latitude = 43.183789f,
                //       Longitude = -78.662099f
                //   },
                //   new Bridge()
                //   {
                //       Guid = Guid.NewGuid(),
                //       Height = 11.5f,
                //       LastUpdated = DateTime.UtcNow,
                //       NumTimesReported = 1,
                //       Address1 = "Genesse St @ Wasmuth Ave",
                //       City = "Buffalo",
                //       PostalCode = "14201",
                //       StateId = 32,
                //       Latitude = 42.906426f,
                //       Longitude = -78.828771f
                //   },
                //   new Bridge()
                //   {
                //       Guid = Guid.NewGuid(),
                //       Height = 9.5f,
                //       LastUpdated = DateTime.UtcNow,
                //       NumTimesReported = 1,
                //       Address1 = "Main St @ Fillmore Ave",
                //       City = "Buffalo",
                //       PostalCode = "14094",
                //       StateId = 32,
                //       Latitude = 42.935793f,
                //       Longitude = -78.842268f
                //   },

                 //   // BridgeId = 9   -- weight
                //   new Bridge()
                //   {
                //       Guid = Guid.NewGuid(),
                //       Height = null,
                //       LastUpdated = DateTime.UtcNow,
                //       NumTimesReported = 2,
                //       Address1 = "W 21st ST N @ N Mclean",
                //       City = "Wichita",
                //       PostalCode = "12235",
                //       StateId = 16,
                //       Latitude = 37.722997f,
                //       Longitude = -97.383435f
                //   },
                //   new Bridge()
                //   {
                //       Guid = Guid.NewGuid(),
                //       Height = null,
                //       LastUpdated = DateTime.UtcNow,
                //       NumTimesReported = 3,
                //       Address1 = "W Zoo Blvd @ W Windmill",
                //       City = "Wichita",
                //       PostalCode = "122345",
                //       StateId = 16,
                //       Latitude = 37.715515f,
                //       Longitude = -97.401448f
                //   },
                //   new Bridge()
                //   {
                //       Guid = Guid.NewGuid(),
                //       Height = null,
                //       LastUpdated = DateTime.UtcNow,
                //       NumTimesReported = 5,
                //       Address1 = "E 83rd St S @ N River St",
                //       City = "Derby",
                //       PostalCode = "12245",
                //       StateId = 16,
                //       Latitude = 37.544321f,
                //       Longitude = -97.276087f
                //   },

                 //   //  Derby Texas
                //   new Bridge()
                //   {
                //       Guid = Guid.NewGuid(),
                //       Height = null,
                //       LastUpdated = DateTime.UtcNow,
                //       NumTimesReported = 1,
                //       Address1 = "S Pleasant Vally Rd @ E Ceasar Chavez St",
                //       City = "Austin",
                //       PostalCode = "12345",
                //       StateId = 43,
                //       Latitude = 30.250127f,
                //       Longitude = -97.713454f
                //   },

                 //   // Utah
                //   new Bridge()
                //   {
                //       Guid = Guid.NewGuid(),
                //       Height = null,
                //       LastUpdated = DateTime.UtcNow,
                //       NumTimesReported = 3,
                //       Address1 = "900 S Indiana Ave @ 2015 W St",
                //       City = "Lockport",
                //       PostalCode = "14094",
                //       StateId = 44,
                //       Latitude = 40.750405f,
                //       Longitude = -111.952765f
                //   },
                //   new Bridge()
                //   {
                //       Guid = Guid.NewGuid(),
                //       Height = null,
                //       LastUpdated = DateTime.UtcNow,
                //       NumTimesReported = 2,
                //       Address1 = "Grant St @ Amherst St",
                //       City = "Buffalo",
                //       PostalCode = "14120",
                //       StateId = 32,
                //       Latitude = 42.936865f,
                //       Longitude = -78.888992f
                //   },
                //   new Bridge()
                //   {
                //       Guid = Guid.NewGuid(),
                //       Height = null,
                //       LastUpdated = DateTime.UtcNow,
                //       NumTimesReported = 1,
                //       Address1 = "Elmwood Ave @ Scajaquada Expy",
                //       City = "Buffalo",
                //       PostalCode = "14120",
                //       StateId = 32,
                //       Latitude = 42.934681f,
                //       Longitude = -78.877662f
                //   },
                //   new Bridge()
                //   {
                //       Guid = Guid.NewGuid(),
                //       Height = null,
                //       LastUpdated = DateTime.UtcNow,
                //       NumTimesReported = 1,
                //       Address1 = "Deleware Ave @ Forest Ave",
                //       City = "Buffalo",
                //       PostalCode = "14120",
                //       StateId = 32,
                //       Latitude = 42.929230f,
                //       Longitude = -78.865517f
                //   },
                //   new Bridge()
                //   {
                //       Guid = Guid.NewGuid(),
                //       Height = null,
                //       LastUpdated = DateTime.UtcNow,
                //       NumTimesReported = 2,
                //       Address1 = "E Orem @ Webercrest",
                //       City = "Houston",
                //       PostalCode = "12345",
                //       StateId = 43,
                //       Latitude = 29.625505f,
                //       Longitude = -95.329292f
                //   },
                //   new Bridge()
                //   {
                //       Guid = Guid.NewGuid(),
                //       Height = null,
                //       LastUpdated = DateTime.UtcNow,
                //       NumTimesReported = 3,
                //       Address1 = "W Orem @ East of Almeda",
                //       City = "Houston",
                //       PostalCode = "12345",
                //       StateId = 43,
                //       Latitude = 29.627398f,
                //       Longitude = -95.407172f
                //   },
                //   new Bridge()
                //   {
                //       Guid = Guid.NewGuid(),
                //       Height = null,
                //       LastUpdated = DateTime.UtcNow,
                //       NumTimesReported = 5,
                //       Address1 = "Memorial Dr @ Sawer",
                //       City = "Houston",
                //       PostalCode = "12345",
                //       StateId = 43,
                //       Latitude = 29.762623f,
                //       Longitude = -95.381595f
                //   },

                      new Bridge()
                      {
                          Guid = Guid.NewGuid(),
                          Height = null,
                          LastUpdated = DateTime.UtcNow,
                          NumTimesReported = 5,
                          Address1 = "Youngstown Wilson Rd @ 3 mi east of Youngstown",
                          City = "Youngstown",
                          PostalCode = "14174",
                          StateId = 32,
                          Latitude = 43.271437f,
                          Longitude = -78.957582f
                      },
                      new Bridge()
                      {
                          Guid = Guid.NewGuid(),
                          Height = null,
                          LastUpdated = DateTime.UtcNow,
                          NumTimesReported = 5,
                          Address1 = "Willow Rd @ 0.1 mi SE of South Wilson",
                          City = "Wilson",
                          PostalCode = "14172",
                          StateId = 32,
                          Latitude = 43.231428f,
                          Longitude = -78.811626f
                      },
                      new Bridge()
                      {
                          Guid = Guid.NewGuid(),
                          Height = null,
                          LastUpdated = DateTime.UtcNow,
                          NumTimesReported = 5,
                          Address1 = "Canal Rd @ 1.8 mi E of Lockport",
                          City = "Lockport",
                          PostalCode = "14094",
                          StateId = 32,
                          Latitude = 43.193392f,
                          Longitude = -78.633129f
                      },
                       new Bridge()
                       {
                           Guid = Guid.NewGuid(),
                           Height = null,
                           LastUpdated = DateTime.UtcNow,
                           NumTimesReported = 5,
                           Address1 = "Day Rd @ 1.0 mi E of Lockport",
                           City = "Lockport",
                           PostalCode = "14094",
                           StateId = 32,
                           Latitude = 43.190049f,
                           Longitude = -78.650769f
                       },
                        new Bridge()
                        {
                            Guid = Guid.NewGuid(),
                            Height = null,
                            LastUpdated = DateTime.UtcNow,
                            NumTimesReported = 5,
                            Address1 = "Interstate 190 @ 0.5 mi N JCT I190 & SH198",
                            City = "Buffalo",
                            PostalCode = "14207",
                            StateId = 32,
                            Latitude = 42.931774f,
                            Longitude = -78.901448f
                        },

            new Bridge()
            {
                Guid = Guid.NewGuid(),
                Height = null,
                LastUpdated = DateTime.UtcNow,
                NumTimesReported = 5,
                Address1 = "Robert Rich Way @ 2.5 mi S JCT RTS I190<198",
                City = "Buffalo",
                PostalCode = "14213",
                StateId = 43,
                Latitude = 42.915199f,
                Longitude = -78.901543f
            }

          );

        }

        private static void SeedWeight(CDLContext context)
        {
            context.Weight.AddOrUpdate(w => new { w.BridgeId, w.TruckType },
                    //new Weight() { BridgeId = 1, maxWeight = null, TruckType = Model.TruckType.Straight },
                    //new Weight() { BridgeId = 1, maxWeight = null, TruckType = Model.TruckType.Single },
                    //new Weight() { BridgeId = 1, maxWeight = null, TruckType = Model.TruckType.Double },
                    //new Weight() { BridgeId = 2, maxWeight = null, TruckType = Model.TruckType.Straight },
                    //new Weight() { BridgeId = 2, maxWeight = null, TruckType = Model.TruckType.Single },
                    //new Weight() { BridgeId = 2, maxWeight = null, TruckType = Model.TruckType.Double },
                    //new Weight() { BridgeId = 3, maxWeight = null, TruckType = Model.TruckType.Straight },
                    //new Weight() { BridgeId = 3, maxWeight = null, TruckType = Model.TruckType.Single },
                    //new Weight() { BridgeId = 3, maxWeight = null, TruckType = Model.TruckType.Double },
                    //new Weight() { BridgeId = 4, maxWeight = null, TruckType = Model.TruckType.Straight },
                    //new Weight() { BridgeId = 4, maxWeight = null, TruckType = Model.TruckType.Single },
                    //new Weight() { BridgeId = 4, maxWeight = null, TruckType = Model.TruckType.Double },
                    //new Weight() { BridgeId = 5, maxWeight = null, TruckType = Model.TruckType.Straight },
                    //new Weight() { BridgeId = 5, maxWeight = null, TruckType = Model.TruckType.Single },
                    //new Weight() { BridgeId = 5, maxWeight = null, TruckType = Model.TruckType.Double },
                    //new Weight() { BridgeId = 6, maxWeight = null, TruckType = Model.TruckType.Straight },
                    //new Weight() { BridgeId = 6, maxWeight = null, TruckType = Model.TruckType.Single },
                    //new Weight() { BridgeId = 6, maxWeight = null, TruckType = Model.TruckType.Double },
                    //new Weight() { BridgeId = 7, maxWeight = null, TruckType = Model.TruckType.Straight },
                    //new Weight() { BridgeId = 7, maxWeight = null, TruckType = Model.TruckType.Single },
                    //new Weight() { BridgeId = 7, maxWeight = null, TruckType = Model.TruckType.Double },
                    //new Weight() { BridgeId = 8, maxWeight = null, TruckType = Model.TruckType.Straight },
                    //new Weight() { BridgeId = 8, maxWeight = null, TruckType = Model.TruckType.Single },
                    //new Weight() { BridgeId = 8, maxWeight = null, TruckType = Model.TruckType.Double },
                    //new Weight() { BridgeId = 9, maxWeight = 15f, TruckType = Model.TruckType.Straight },
                    //new Weight() { BridgeId = 9, maxWeight = 22f, TruckType = Model.TruckType.Single },
                    //new Weight() { BridgeId = 9, maxWeight = 25f, TruckType = Model.TruckType.Double },
                    //new Weight() { BridgeId = 10, maxWeight = 15f, TruckType = Model.TruckType.Straight },
                    //new Weight() { BridgeId = 10, maxWeight = 15f, TruckType = Model.TruckType.Single },
                    //new Weight() { BridgeId = 10, maxWeight = 15f, TruckType = Model.TruckType.Double },
                    //new Weight() { BridgeId = 11, maxWeight = 12f, TruckType = Model.TruckType.Straight },
                    //new Weight() { BridgeId = 11, maxWeight = 12f, TruckType = Model.TruckType.Single },
                    //new Weight() { BridgeId = 11, maxWeight = 12f, TruckType = Model.TruckType.Double },
                    //new Weight() { BridgeId = 12, maxWeight = 50f, TruckType = Model.TruckType.Straight },
                    //new Weight() { BridgeId = 12, maxWeight = 50f, TruckType = Model.TruckType.Single },
                    //new Weight() { BridgeId = 12, maxWeight = 50f, TruckType = Model.TruckType.Double },
                    //new Weight() { BridgeId = 13, maxWeight = 35f, TruckType = Model.TruckType.Straight },
                    //new Weight() { BridgeId = 13, maxWeight = 35f, TruckType = Model.TruckType.Single },
                    //new Weight() { BridgeId = 13, maxWeight = 35f, TruckType = Model.TruckType.Double },
                    //new Weight() { BridgeId = 14, maxWeight = 22f, TruckType = Model.TruckType.Straight },
                    //new Weight() { BridgeId = 14, maxWeight = 22f, TruckType = Model.TruckType.Single },
                    //new Weight() { BridgeId = 14, maxWeight = 22f, TruckType = Model.TruckType.Double },
                    //new Weight() { BridgeId = 15, maxWeight = 11.5f, TruckType = Model.TruckType.Straight },
                    //new Weight() { BridgeId = 15, maxWeight = 11.5f, TruckType = Model.TruckType.Single },
                    //new Weight() { BridgeId = 15, maxWeight = 11.5f, TruckType = Model.TruckType.Double },
                    //new Weight() { BridgeId = 16, maxWeight = 20f, TruckType = Model.TruckType.Straight },
                    //new Weight() { BridgeId = 16, maxWeight = 30f, TruckType = Model.TruckType.Single },
                    //new Weight() { BridgeId = 16, maxWeight = 40f, TruckType = Model.TruckType.Double },
                    //new Weight() { BridgeId = 17, maxWeight = 20f, TruckType = Model.TruckType.Straight },
                    //new Weight() { BridgeId = 17, maxWeight = 25f, TruckType = Model.TruckType.Single },
                    //new Weight() { BridgeId = 17, maxWeight = 25f, TruckType = Model.TruckType.Double },
                    //new Weight() { BridgeId = 18, maxWeight = 10f, TruckType = Model.TruckType.Straight },
                    //new Weight() { BridgeId = 18, maxWeight = 15f, TruckType = Model.TruckType.Single },
                    //new Weight() { BridgeId = 18, maxWeight = 20f, TruckType = Model.TruckType.Double },
                    //new Weight() { BridgeId = 19, maxWeight = 20f, TruckType = Model.TruckType.Straight },
                    //new Weight() { BridgeId = 19, maxWeight = 20f, TruckType = Model.TruckType.Single },
                    //new Weight() { BridgeId = 19, maxWeight = 20f, TruckType = Model.TruckType.Double },


                    new Weight() { BridgeId = 1, maxWeight = 3f, TruckType = Model.TruckType.Straight },
                    new Weight() { BridgeId = 1, maxWeight = 3f, TruckType = Model.TruckType.Single },
                    new Weight() { BridgeId = 1, maxWeight = 3f, TruckType = Model.TruckType.Double },
                    new Weight() { BridgeId = 2, maxWeight = 15f, TruckType = Model.TruckType.Straight },
                    new Weight() { BridgeId = 2, maxWeight = 15f, TruckType = Model.TruckType.Single },
                    new Weight() { BridgeId = 2, maxWeight = 15f, TruckType = Model.TruckType.Double },
                    new Weight() { BridgeId = 3, maxWeight = 20f, TruckType = Model.TruckType.Straight },
                    new Weight() { BridgeId = 3, maxWeight = 20f, TruckType = Model.TruckType.Single },
                    new Weight() { BridgeId = 3, maxWeight = 20f, TruckType = Model.TruckType.Double },
                    new Weight() { BridgeId = 4, maxWeight = 20f, TruckType = Model.TruckType.Straight },
                    new Weight() { BridgeId = 4, maxWeight = 20f, TruckType = Model.TruckType.Single },
                    new Weight() { BridgeId = 4, maxWeight = 20f, TruckType = Model.TruckType.Double },
                    new Weight() { BridgeId = 5, maxWeight = 32f, TruckType = Model.TruckType.Straight },
                    new Weight() { BridgeId = 5, maxWeight = 32f, TruckType = Model.TruckType.Single },
                    new Weight() { BridgeId = 5, maxWeight = 32f, TruckType = Model.TruckType.Double },
                    new Weight() { BridgeId = 6, maxWeight = 15f, TruckType = Model.TruckType.Straight },
                    new Weight() { BridgeId = 6, maxWeight = 15f, TruckType = Model.TruckType.Single },
                    new Weight() { BridgeId = 6, maxWeight = 15f, TruckType = Model.TruckType.Double }

            );
        }


    }
}
