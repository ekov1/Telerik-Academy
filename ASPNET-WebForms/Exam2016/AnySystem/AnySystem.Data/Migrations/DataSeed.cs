namespace AnySystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class DataSeed
    {
        public static void SeedUsers(ApplicationDbContext context)
        {
            // var userManager = new UserManager<User>(new UserStore<User>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            
            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Administrator" });
            }

            if (!context.Roles.Any())
            {
                var userRole = new IdentityRole { Name = "Administrator", Id = Guid.NewGuid().ToString() };
                context.Roles.Add(userRole);
            }

            var hasher = new PasswordHasher();

            var adminUser = context.Users.FirstOrDefault(x => x.Email == "admin@site.com");

            if (adminUser == null)
            {
                var admin = new User
                {
                    Email = "admin@site.com",
                    UserName = "admin@site.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    PasswordHash = hasher.HashPassword("admin"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ProfileImageUrl = "http://www.gfi.com/blog/wp-content/uploads/2013/03/stresses-of-the-IT-administrator.jpg",
                };

                var userId = admin.Id;

                // userManager.Create(admin, "admin");
                admin.Roles.Add(new IdentityUserRole { RoleId = context.Roles.First().Id, UserId = userId });
                context.Users.Add(admin);
                context.SaveChanges();
            }

            for (int i = 0; i < 5; i++)
            {
                var usernameA = string.Format("user{0}@site.com", i);

                var user = context.Users.FirstOrDefault(x => x.Email == usernameA);

                if (user == null)
                {
                    var username = string.Format("user{0}@site.com", i);

                    var newUser = new User
                    {
                        Email = username,
                        UserName = username,
                        FirstName = "Yor-" + i + "-keey",
                        LastName = "Leeeeeroy",
                        PasswordHash = hasher.HashPassword(string.Format("user{0}", i)),
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ProfileImageUrl =
                            "http://donatered-asset.s3.amazonaws.com/assets/default/default_user-884fcb1a70325256218e78500533affb.jpg"
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();
                }
            }
        }

        public static void SeedCategories(ApplicationDbContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            new List<string>()
            {
                "Dermatology","Rail Transport Modeling",
                "Handball","Robotics",
                "Airsoft",
                "Sustainability","Memes",
                "Bollywood","Hollywood",
                "Adaptive Sports","Entrepreneurship",
                "Sports","Music",
                "Yoga","Sledding",
                "Magic","Sewing",
                "Pop-Rap","Christian Music",
                "Pediatrics","Musical Movies",
                "Home","Trick Shots",
                "Fails","Education",
                "Martial Arts","Hunting",
                "Home Decoration","Makeup and Hairstyles",
                "Wildlife","Ghosts",
                "Documentaries","Mental Health",
                "Health","Rock",
                "Latino","TV Show",
                "Crafts","Seltic Music",
                "Filmmaking","Props building"
            }.ForEach(c => context.Categories.Add(new Category { Name = c }));

            context.SaveChanges();
        }

        public static void SeedPlaylists(ApplicationDbContext context)
        {
            if (context.Playlists.Any())
            {
                return;
            }

            var users = context.Users.OrderBy(u => Guid.NewGuid()).ToList();
            var categories = context.Categories.OrderBy(c => Guid.NewGuid()).ToList();
            var rng = new Random();

            var yTVideos = new List<string>()
            {
                "https://www.youtube.com/embed/9bZkp7q19f0",
                "https://www.youtube.com/embed/nfWlot6h_JM",
                "https://www.youtube.com/embed/OPf0YbXqDm0",
                "https://www.youtube.com/embed/e-ORhEE9VVg",
                "https://www.youtube.com/embed/CevxZvSJLk8",
                "https://www.youtube.com/embed/hT_nvWreIhg",
                "https://www.youtube.com/embed/YQHsXMglC9A",
                "https://www.youtube.com/embed/ASO_zypdnsQ",
                "https://www.youtube.com/embed/rYEDA3JcQqw",
                "https://www.youtube.com/embed/7zp1TbLFPp8",
                "https://www.youtube.com/embed/L0MK7qz13bU",
                "https://www.youtube.com/embed/DrL2-orVL84",
                "https://www.youtube.com/embed/vJkmHSaKpd8"
            };

            for (int i = 0; i < 25; i++)
            {
                yTVideos = yTVideos.OrderBy(v => Guid.NewGuid()).ToList();

                var playlist = new Playlist()
                {
                    CategoryId = categories[i].Id,
                    CreatedOn = DateTime.Now.AddDays(rng.Next(-500, 500)),
                    Creator = users[i % (users.Count - 1)],
                    Description = @"Curabitur in condimentum justo. Quisque aliquam et nisl sit amet ultrices. Mauris sodales sem vitae erat euismod bibendum. Suspendisse condimentum ut erat vitae faucibus. Pellentesque ut dui at sem porttitor volutpat sit amet consequat nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Vivamus dignissim est elit, id pretium sapien tempor nec. Ut varius libero sed mauris tempor faucibus. In ac dictum ipsum, id mollis nibh. Nam ultricies laoreet tortor sit amet imperdiet. Maecenas finibus ante sed metus facilisis pulvinar. Curabitur quis nibh imperdiet, hendrerit odio nec, vulputate sapien.",
                    Title = "Playlist " + i + " wee",
                    Videos = new List<Video>()
                    {
                        new Video
                        {
                            Url = yTVideos[rng.Next(0, yTVideos.Count - 1)]
                        },
                        new Video
                        {
                            Url = yTVideos[rng.Next(0, yTVideos.Count - 1)]
                        },
                        new Video
                        {
                            Url = yTVideos[rng.Next(0, yTVideos.Count - 1)]
                        },
                    }
                };

                var usersRated = new HashSet<string>();

                for (int j = 0; j < rng.Next(3, 5); j++)
                {
                    var userId = users[rng.Next(0, users.Count)].Id;

                    if (!usersRated.Contains(userId))
                    {
                        usersRated.Add(userId);

                        var rating = new Rating
                        {
                            Value = rng.Next(1, 6)
                        };

                        rating.UserId = userId;

                        playlist.Ratings.Add(rating);
                    }
                    else
                    {
                        j--;
                    }
                }

                context.Playlists.Add(playlist);
                context.SaveChanges();
            }
        }
    }
}
