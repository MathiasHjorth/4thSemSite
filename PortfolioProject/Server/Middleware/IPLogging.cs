using Microsoft.EntityFrameworkCore;
using PortfolioProject.Server.Data;
using PortfolioSite.Shared.Models;
using System.Net;

namespace PortfolioSite.Server.Middleware
{
    public class IPLogging
    {
        private readonly ILogger<IPLogging> _logger;
        private readonly RequestDelegate _next;

        public IPLogging(RequestDelegate next, ILogger<IPLogging> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context, ApplicationDbContext dbContext)
        {
            //upload information about the visitor of the website to the DB
            await dbContext.SiteVisitors.AddAsync(new SiteVisitor { IpAddress = context.Connection.RemoteIpAddress.ToString(), VisitDate = DateTime.Now });
            await dbContext.SaveChangesAsync();

            await _next.Invoke(context);
        }
    }

    public static class IpLoggingExtension
    {
        public static IApplicationBuilder UseIpLogging(this IApplicationBuilder app)
        {
            return app.UseMiddleware<IPLogging>();
        }
    }
}
