using Serilog;
namespace ByuerApp.Models
{
    public class ExceptionMiddleware: IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)//1 тест на неправильный контекст, 2 - на неправильный делегат, 3 - все хорошо 200 статус, 4 инвоук возвращает эксепшн -- но надо сложно замокать статический логгер -- через диай
        {
            if (context.Response == null)
                await next.Invoke(context);

            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "error");//можно ли переписать логгер не статическим, а через диай

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync("Error");
            }
        }
    }//open telemetry
}
