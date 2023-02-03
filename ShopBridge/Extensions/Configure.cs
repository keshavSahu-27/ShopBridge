using System;
using ShopBridge.Middlewares;
namespace ShopBridge
{
	internal static class Configure
	{
		public static WebApplication ConfigureMiddleware(this WebApplication app)
		{
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();

            app.MapControllers();

            return app;
		}
	}
}

