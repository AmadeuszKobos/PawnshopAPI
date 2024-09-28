namespace HomeAPI.DI
{
  public static partial class ConfigMiddleware
  {
    public static WebApplication ConfigureMiddleware(this WebApplication app)
    {
      ConfigureSwagger(app);
      app.UseHttpsRedirection();

      return app;
    }

    private static void ConfigureSwagger(WebApplication app)
    {
      app.UseSwagger();
      app.UseSwaggerUI();
    }
  }
}