using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SistemaTerapeutico.Core.Exceptions;

namespace SistemaTerapeutico.Infrastucture.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(BusinessException))
            {
                var exception = (BusinessException)context.Exception;
                var validation = new
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = exception.Message
                };
                var json = new
                {
                    errors = new[] { validation }
                };
                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
            else
            {
                var exception = context.Exception;
                var validation = new
                {
                    Status = 500,
                    Title = "Internal Server Error",
                    Detail = ObtenerDetallesError(exception)
                };
                var json = new
                {
                    errors = new[] { validation }
                };
                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.ExceptionHandled = true;
            }
        }
        private string ObtenerDetallesError(Exception xExcepcion)
        {
            string Detalles = xExcepcion.Message;

            Exception Excepcion = xExcepcion.InnerException;

            while (Excepcion != null)
            {
                Detalles += " - " + Excepcion.Message;

                Excepcion = Excepcion.InnerException;
            }

            return Detalles;
        }
    }
}

