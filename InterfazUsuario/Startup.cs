using InterfazUsuario.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Services.ScopeLibrary.ScopeHandler;
using Services.ScopeLibrary.ScopeRequirement;
using BlazorStrap;
using DAL.Contracts;
using DAL.Repositories.SQL;
using DOMINIO;
using SERVICIOS;
using SERVICIOS.Reportes;

namespace InterfazUsuario
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            // Set variables
            string domain = Configuration["Auth0:Domain"];
            string clientId = Configuration["Auth0:ClientId"];
            string clientSecret = Configuration["Auth0:ClientSecret"];
            string audience = Configuration["Auth0:Audience"];

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<IRepositoryDayEvent, DayEventRepository>();

            services.AddBootstrapCss(); // BOOTSTRAP

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            var httpClientHanndler = new HttpClientHandler();
            httpClientHanndler.ServerCertificateCustomValidationCallback =
                (message, cert, chai, errors) => true;

            services.AddSingleton(new HttpClient(httpClientHanndler)
            {
                BaseAddress = new Uri("https://localhost:44394/")

            });

            services.AddHttpClient();

            services.AddI18nText<Startup>(options => options.PersistanceLevel = Toolbelt.Blazor.I18nText.PersistanceLevel.SessionAndLocal);

            services.AddSingleton<QuizService>();

            services.AddSingleton<ExportService>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Add authentication services
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect("Auth0", options =>
            {
                // Set the authority to your Auth0 domain
                //options.Authority = $"https://{Configuration["Auth0:Domain"]}";
                options.Authority = $"https://{domain}";

                // Configure the Auth0 Client ID and Client Secret
                // options.ClientId = Configuration["Auth0:ClientId"];
                options.ClientId = clientId;
                //options.ClientSecret = Configuration["Auth0:ClientSecret"];
                options.ClientSecret = clientSecret;

                // Set response type to code
                options.ResponseType = "code";

      // Configure the scope
                options.Scope.Clear();
                options.Scope.Add("openid");
                options.Scope.Add("profile");

      // Set the callback path, so Auth0 will call back to http://localhost:3000/callback
      // Also ensure that you have added the URL as an Allowed Callback URL in your Auth0 dashboard
                options.CallbackPath = new PathString("/callback");

      // Configure the Claims Issuer to be Auth0
      options.ClaimsIssuer = "Auth0";

                // Saves tokens to the AuthenticationProperties
                options.SaveTokens = true;

                // Authorization //
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name",
                    RoleClaimType = $"https://schemas.{domain}/roles"
                };

                options.Events = new OpenIdConnectEvents
                {
                    //Add audience parameter
                    OnRedirectToIdentityProvider = context =>
                    {
                        context.ProtocolMessage.SetParameter("audience", audience);
                        return Task.FromResult(0);
                    },

                    //Add event when token were validated
                    OnTokenValidated = context =>
                    {
                        //set security token
                        string secJwt = context.SecurityToken.RawData;
                        //set access token
                        string accessJwt = context.TokenEndpointResponse.AccessToken;
                        //read access token
                        var handler = new JwtSecurityTokenHandler();
                        var jwt = handler.ReadJwtToken(accessJwt);
                        //get permissions from access token
                        List<Claim> permissions = jwt.Claims.Where(x => x.Type == "permissions").ToList();
                        //add permission to user claims (in this case add new identity)
                        context.Principal.AddIdentity(new ClaimsIdentity(permissions));

                        //this is a test to get response from api
                        //in this part yo have to save token on a global var and call api on page component
                        //
                        //var client3 = new RestClient("https://localhost:44339/WeatherForecast");
                        //var request3 = new RestRequest(Method.GET);
                        //request3.AddHeader("authorization", $"Bearer {accessJwt}");
                        //IRestResponse response3 = client3.Execute(request3);
                        //
                        //

                        return Task.FromResult(0);
                    },
                    // handle the logout redirection
                    OnRedirectToIdentityProviderForSignOut = (context) =>
                    {
                        var logoutUri = $"https://{Configuration["Auth0:Domain"]}/v2/logout?client_id={Configuration["Auth0:ClientId"]}";

                        var postLogoutUri = context.Properties.RedirectUri;
                        if (!string.IsNullOrEmpty(postLogoutUri))
                        {
                            if (postLogoutUri.StartsWith("/"))
                            {
                      // transform to absolute
                      var request = context.Request;
                                postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
                            }
                            logoutUri += $"&returnTo={ Uri.EscapeDataString(postLogoutUri)}";
                        }

                        context.Response.Redirect(logoutUri);
                        context.HandleResponse();

                        return Task.CompletedTask;
                    }
                };
            });

            // Add policies
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.Requirements.Add(new HasScopeRequirement("read:admin", $"https://{domain}/")));
                options.AddPolicy("User", policy => policy.Requirements.Add(new HasScopeRequirement("read:user", $"https://{domain}/")));
            });
            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

            services.AddHttpContextAccessor();
            services.AddSingleton<QuizService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication(); //AGREGADO AUTH0
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            
        }
    }
}
