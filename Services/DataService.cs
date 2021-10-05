using BlogProject.Data;
using BlogProject.Enums;
using BlogProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;
        public DataService(ApplicationDbContext dbContext,
                           RoleManager<IdentityRole> roleManager,
                           UserManager<BlogUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task ManageDataAsync() //Wrapper method
        {
            //Task 0: Create the DB from the Migrations

            await _dbContext.Database.MigrateAsync(); //Does the update-database command

            //Task 1: Seed in a few roles into the system
            await SeedRolesAsync();
            //Task 2: Seed a user into the system
            await SeedUsersAsync();
        }

        private async Task SeedRolesAsync()
        {
            //If there are already role in the system, do nothing.
            if (_dbContext.Roles.Any()) return;

            //Otherwise create a few roles
            foreach (var role in Enum.GetNames(typeof(BlogRole)))
            {
                //Use Role Manager to create roles
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        private async Task SeedUsersAsync()
        {
            //If there are already role in the system, do nothing.
            if (_dbContext.Users.Any()) return;

            //Step 1: Create a new instance of BlogUser
            var adminUser = new BlogUser()
            {
                FirstName = "Dominic",
                LastName = "Wegrzynowski",
                Email = "dominicwegrzynowski@gmail.com",
                UserName = "dominicwegrzynowski",
                PhoneNumber = "(716) 785-2948",
                EmailConfirmed = true
            };

            //Step 2: Use the UserManager to create a new user that is defined by adminUser
            await _userManager.CreateAsync(adminUser, "Abc&123!");

            //Step 3: Add this new user to the administrator role

            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());

            //Step 1 Repeat: Create the moderator user

            var modUser = new BlogUser()
            {
                FirstName = "Dominic",
                LastName = "Wegrzynowski",
                Email = "dominicwegrzynowski@gmail.com",
                UserName = "dominicwegrzynowski@gmail.com",
                PhoneNumber = "(716) 785-2948",
                EmailConfirmed = true
            };

            //Step 2 Repeat: Use the UserManager to create a new user that is defined by adminUser
            await _userManager.CreateAsync(modUser, "Abc&123!");
            //Step 3 Repeat: Add this new user to the moderator role
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Moderator.ToString());

        }

    }
}
