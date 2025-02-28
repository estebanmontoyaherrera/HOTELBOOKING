﻿using HOTELBOOKING.Application.UseCase.Commons.Bases;
using HOTELBOOKING.Utilities.Constants;
using HOTELBOOKING.Application.UseCase.Commons.Exceptions;
using System.Text.Json;

namespace HOTELBOOKING.Api.Extensions.Middleware
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (ValidationException e)
            {
                context.Response.ContentType = "application/json";
                await JsonSerializer.SerializeAsync(context.Response.Body, new BaseResponse<object>
                {
                    Message = GlobalMessages.MESSAGE_VALIDATE,
                    Errors = e.Errors
                });
            }
        }
    }
}
