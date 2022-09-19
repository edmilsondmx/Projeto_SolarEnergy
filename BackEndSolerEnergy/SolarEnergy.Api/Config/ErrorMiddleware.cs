using System.Net;
using SolarEnergy.Domain.DTOs;
using SolarEnergy.Domain.Exceptions;

namespace SolarEnergy.Api.Config;

public class ErrorMiddleware
{
    private readonly RequestDelegate _next;
    public ErrorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            
            await TratamentoExcecao(context, ex);
        }
    }

    private Task TratamentoExcecao(HttpContext context, Exception ex)
    {
        HttpStatusCode status;
        string message;

        if(ex is DataJaCadastradaException)
        {
            status = HttpStatusCode.NotAcceptable;
            message = ex.Message;
        }
        else if(ex is UnidadeInativaException)
        {
            status = HttpStatusCode.NotAcceptable;
            message = ex.Message;
        }
        else
        {
            status = HttpStatusCode.InternalServerError;
            message = "Desculpe, tivemos um problema. Logo será resolvido!";
        }

        var response = new ErrorDto(message);

        context.Response.StatusCode = (int)status;
        return context.Response.WriteAsJsonAsync(response);
    }
}
