using System.Text;

namespace Api;

public static class AuthenticationTest
{
    [FunctionName(nameof(AuthenticationTest))]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] 
        HttpRequest req,
        ILogger log)
    {
        var clientPrinciple = StaticWebApiAppAuthorization.ParseHttpHeaderForClientPrinciple(req);
        var claimsPrinciple = ClientPrincipleToClaimsPrinciple.GetClaimsFromClientClaimsPrincipal(clientPrinciple);

        var name = claimsPrinciple.Identity?.Name ?? "NoName";

        var builder = new StringBuilder();
        claimsPrinciple.Claims?.ToList().ForEach(x => builder.Append($"{x.Value}\n"));
        return new OkObjectResult($"Function: {nameof(AuthenticationTest)}\n{name}\n\n{builder}");
    }
}