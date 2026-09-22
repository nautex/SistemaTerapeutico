using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using SistemaTerapeutico.Core.Exceptions;
using System;
using System.Net;

namespace SistemaTerapeutico.Infrastucture.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;
        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);

            if (context.Exception is BusinessException be)
            {
                var problem = new ProblemDetails
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = be.Message
                };

                context.Result = new ObjectResult(problem)
                {
                    StatusCode = 400
                };
            }
            else
            {
                var problem = new ProblemDetails
                {
                    Status = 500,
                    Title = "Internal Server Error",
                    Detail = GetAllExceptionMessages(context.Exception)
                };

                context.Result = new ObjectResult(problem)
                {
                    StatusCode = 500
                };
            }

            context.ExceptionHandled = true;
        }
        private string GetAllExceptionMessages(Exception ex)
        {
            string msg = ex.Message;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                msg += " | " + ex.Message;
            }
            return msg;
        }
        //public void OnException(ExceptionContext context)
        //{
        //    if (context.Exception.GetType() == typeof(BusinessException))
        //    {
        //        var exception = (BusinessException)context.Exception;
        //        var validation = new
        //        {
        //            Status = 400,
        //            Title = "Bad Request",
        //            Detail = exception.Message
        //        };
        //        var json = new
        //        {
        //            errors = new[] { validation }
        //        };
        //        context.Result = new BadRequestObjectResult(json);
        //        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //        context.ExceptionHandled = true;
        //    }
        //    else
        //    {
        //        var exception = context.Exception;
        //        var validation = new
        //        {
        //            Status = 500,
        //            Title = "Internal Server Error",
        //            Detail = ObtenerDetallesError(exception)
        //        };
        //        var json = new
        //        {
        //            errors = new[] { validation }
        //        };
        //        context.Result = new BadRequestObjectResult(json);
        //        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //        context.ExceptionHandled = true;
        //    }
        //}
        //private string ObtenerDetallesError(Exception xExcepcion)
        //{
        //    string Detalles = xExcepcion.Message;

        //    Exception Excepcion = xExcepcion.InnerException;

        //    while (Excepcion != null)
        //    {
        //        Detalles += " - " + Excepcion.Message;

        //        Excepcion = Excepcion.InnerException;
        //    }

        //    return Detalles;
        //}
    }
}

