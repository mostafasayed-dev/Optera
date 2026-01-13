using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Optera.Models;
using Optera.Utils.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Optera.DataAccess
{
    public static class DBInitializer
    {
        public static async Task SeedUserAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();

            string username = "Admin";
            string email = "admin@example.com";
            string password = "HP@ss0rd";
            string roleName = "Admin";

            // 1. Create Role if not exists
            //if (!await roleManager.RoleExistsAsync(roleName))
            //{
            //    var role = new Role { Name = roleName, NormalizedName = roleName.ToUpper() };
            //    await roleManager.CreateAsync(role);
            //    await roleManager.AddClaimAsync(role, new Claim("AUTH_ACCESS", "AUTH_3000")); // Administration
            //    await roleManager.AddClaimAsync(role, new Claim("AUTH_ACCESS", "AUTH_3010")); // Security
            //    await roleManager.AddClaimAsync(role, new Claim("AUTH_ACCESS", "AUTH_3020")); // Groups
            //    await roleManager.AddClaimAsync(role, new Claim("AUTH_ACCESS", "AUTH_3021")); // Add Group
            //    await roleManager.AddClaimAsync(role, new Claim("AUTH_ACCESS", "AUTH_3030")); // Users
            //    await roleManager.AddClaimAsync(role, new Claim("AUTH_ACCESS", "AUTH_3031")); // Add User
            //    await roleManager.AddClaimAsync(role, new Claim("AUTH_ACCESS", "AUTH_3032")); // Edit User
            //}

            if(await roleManager.RoleExistsAsync(roleName))
            {
                var role = await roleManager.FindByNameAsync("Admin");
                if(role != null)
                {
                    var claims = await roleManager.GetClaimsAsync(role);
                    // Administration
                    bool claimExists = claims.Any(c => c.Type == "AUTH_ACCESS" && c.Value == "AUTH_3000");
                    if (!claimExists)
                        await roleManager.AddClaimAsync(role, new Claim("AUTH_ACCESS", "AUTH_3000"));
                    // Security
                    claimExists = claims.Any(c => c.Type == "AUTH_ACCESS" && c.Value == "AUTH_3010");
                    if (!claimExists)
                        await roleManager.AddClaimAsync(role, new Claim("AUTH_ACCESS", "AUTH_3010"));
                    // Groups
                    claimExists = claims.Any(c => c.Type == "AUTH_ACCESS" && c.Value == "AUTH_3020");
                    if (!claimExists)
                        await roleManager.AddClaimAsync(role, new Claim("AUTH_ACCESS", "AUTH_3020"));
                    // Add Group
                    claimExists = claims.Any(c => c.Type == "AUTH_ACCESS" && c.Value == "AUTH_3021");
                    if (!claimExists)
                        await roleManager.AddClaimAsync(role, new Claim("AUTH_ACCESS", "AUTH_3021"));
                    // Users
                    claimExists = claims.Any(c => c.Type == "AUTH_ACCESS" && c.Value == "AUTH_3030");
                    if (!claimExists)
                        await roleManager.AddClaimAsync(role, new Claim("AUTH_ACCESS", "AUTH_3030"));
                    // Add User
                    claimExists = claims.Any(c => c.Type == "AUTH_ACCESS" && c.Value == "AUTH_3031");
                    if (!claimExists)
                        await roleManager.AddClaimAsync(role, new Claim("AUTH_ACCESS", "AUTH_3031"));
                    //Edit User
                    claimExists = claims.Any(c => c.Type == "AUTH_ACCESS" && c.Value == "AUTH_3032");
                    if (!claimExists)
                        await roleManager.AddClaimAsync(role, new Claim("AUTH_ACCESS", "AUTH_3032"));
                    //Settings
                    claimExists = claims.Any(c => c.Type == "AUTH_ACCESS" && c.Value == "AUTH_3040");
                    if (!claimExists)
                        await roleManager.AddClaimAsync(role, new Claim("AUTH_ACCESS", "AUTH_3040"));
                    //Workflow Definition
                    claimExists = claims.Any(c => c.Type == "AUTH_ACCESS" && c.Value == "AUTH_3050");
                    if (!claimExists)
                        await roleManager.AddClaimAsync(role, new Claim("AUTH_ACCESS", "AUTH_3050"));
                    //Workflow Steps
                    claimExists = claims.Any(c => c.Type == "AUTH_ACCESS" && c.Value == "AUTH_3060");
                    if (!claimExists)
                        await roleManager.AddClaimAsync(role, new Claim("AUTH_ACCESS", "AUTH_3060"));
                    //Workflow Transitions
                    claimExists = claims.Any(c => c.Type == "AUTH_ACCESS" && c.Value == "AUTH_3070");
                    if (!claimExists)
                        await roleManager.AddClaimAsync(role, new Claim("AUTH_ACCESS", "AUTH_3070"));
                }
            }

            // 2. Create User if not exists
            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new User
                {
                    UserName = username,
                    Email = email,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    // 3. Add User to Admin Role
                    var roleResult = await userManager.AddToRoleAsync(user, roleName);
                    if (roleResult.Succeeded)
                    {
                        // 4. Add User Claims
                        var claimsResult = await userManager.AddClaimsAsync(user,
                            new List<Claim>() {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                                });
                    }
                }
                else
                {
                    throw new Exception("User creation failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
