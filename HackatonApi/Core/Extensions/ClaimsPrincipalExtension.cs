using System.Security.Claims;

namespace HackatonApi.Core.Extensions;

public static class ClaimsPrincipalExtension
{
    public static int GetUserId(this ClaimsPrincipal claimsPrincipal) => int.Parse(claimsPrincipal.Claims.First(x => x.Type == ClaimTypes.PrimarySid).Value);
}