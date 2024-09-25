using System.Net.Http;

namespace TaskPlatform.API.Middlewares;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public AuthMiddleware(RequestDelegate next, IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _next = next;
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        HttpResponseMessage response;

        try
        {
            var client = new HttpClient();
            var request = BuildAuthenticationRequest(context);

            response = await client.SendAsync(request);
        }
        catch (HttpRequestException ex)
        {
            await context.Response.WriteAsync(ex.Message);
            return;
        }
        catch (Exception ex)
        {
            await context.Response.WriteAsync(ex.Message);
            return;
        }

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            context.Items["ExternalServiceResponse"] = content;
        }
        else
        {
            context.Response.StatusCode = (int)response.StatusCode;
            await context.Response.WriteAsync("Error communicating with external service.");
            return;
        }

        await _next(context);
    }
    private HttpRequestMessage BuildAuthenticationRequest(HttpContext context)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, _configuration["ConnectionStrings:AuthConnection"]);

        var cookies = context.Request.Cookies;
        var cookieString = string.Join("; ", cookies
            .Where(c => !string.IsNullOrEmpty(c.Value))
            .Select(c => $"{c.Key}={c.Value}"));


        if (!string.IsNullOrWhiteSpace(cookieString))
        {
            request.Headers.Add("Cookie", cookieString);
        }

        return request;
    }
}
