using GuildCars.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GuildCars.Startup))]
namespace GuildCars
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if(!roleManager.RoleExists("Admin"))
            {

                // create admin role
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //create admin user
                var user = new ApplicationUser();
                user.firstName = "test";
                user.lastName = "admin";
                user.Email = "testadmin@admin.com";
                user.UserName = user.Email;

                string userpwd = "testing123";
                var chkUser = UserManager.Create(user, userpwd);
                
                if(chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }

            if(!roleManager.RoleExists("Sales"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Sales";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.firstName = "test";
                user.lastName = "sales";
                
                user.Email = "testsales@admin.com";
                user.UserName = user.Email;

                string userpwd = "testing123";
                var chkUser = UserManager.Create(user, userpwd);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Sales");
                }
            }

            if(!roleManager.RoleExists("Disabled"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Disabled";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.firstName = "test";
                user.lastName = "disabled";
                
                user.Email = "testdisabled@admin.com";
                user.UserName = user.Email;

                string userpwd = "testing123";
                var chkUser = UserManager.Create(user, userpwd);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Disabled");
                }
            }
        }
    }
}
