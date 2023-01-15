using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PortfolioProject.Server.Models;
using PortfolioSite.Shared.Models;

namespace PortfolioProject.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        //DBsets
        public DbSet<Post> Posts { get; set; }
        public DbSet<SiteVisitor> SiteVisitors { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }

    }
}