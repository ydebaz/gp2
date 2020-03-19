using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using gp_.Middleware;

namespace gp_.Extentions
{
    public static class CommunicationMiddlewareExtention
    {
        public static IApplicationBuilder UseCommunicationMiddleware(this IApplicationBuilder app) {
            return app.UseMiddleware<CommunicationMiddleware>();
        }
    }
}
