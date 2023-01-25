// using statements - identify the namespaces of
// other libraries which provide more behaviours
using System.Security.Claims;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

// WebApplication Builder factory - creates a "builder"
// which supplies the services, configuration etc.
var builder = WebApplication.CreateBuilder(args);

// define our auth services
// (Auth0 service abstracts a lot of aspnet boilerplate)
// see: https://auth0.com/blog/exploring-auth0-aspnet-core-authentication-sdk/
builder.Services.AddAuth0WebAppAuthentication(options =>
{
  // builder.Configuration extracts values from the appsettings.json
  options.Domain = builder.Configuration["Auth0:Domain"];
  options.ClientId = builder.Configuration["Auth0:ClientId"];
});
builder.Services.AddAuthorization();

// construct the web app
var app = builder.Build();

// MIDDLEWARE
// specifying the middleware which will be
// processed before the route handlers are invoked
app.UseAuthentication();
app.UseAuthorization();

// ROUTES
// "/" is the default route
// [Authorize] attribute notifies the middleware that requests to this route
// must be authorized - a user must be known during the request
// (if no user is known, the middleware will redirect to the login path)
app.MapGet("/", [Authorize] (ClaimsPrincipal user) => $"Hello {user?.Identity?.Name}");

// "/Account/Login" is the default login path (aspnet)
// constructs a "challenge" which checks the login status and casues the
// Authentication middleware to invoke the Auth0 service.
// This will result in a redirect response (HTTP 302) to the Auth0 tenant
app.MapGet("/Account/Login", async (HttpContext context) =>
{
  var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
            .WithRedirectUri("/")
            .Build();
  await context.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
});

// start listening for requests
app.Run();