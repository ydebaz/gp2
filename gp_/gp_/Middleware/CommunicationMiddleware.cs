﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using gp_.Services;

namespace gp_.Middleware
{
    public class CommunicationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUserService _userService;

        public CommunicationMiddleware(RequestDelegate next, IUserService userService)
        {
            _next = next;
            _userService = userService;
        }
        public async Task Invoke(HttpContext context) {
            await _next.Invoke(context);
            return;
        }
    }
}
