using GamesStore.Services;

namespace GamesStore.Endpoints
{
    public static class GameEndpoints
    {
        public static IEndpointRouteBuilder MapGameEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/games",
                (RequestHandlerService requestHandler) => requestHandler.ShowHtml("ShowGames.html"));

            endpoints.MapGet("/game/{id:int}",
                (RequestHandlerService requestHandler) => requestHandler.ShowHtml("ShowGame.html"));

            endpoints.MapGet("/game/create",
                (RequestHandlerService requestHandler) => requestHandler.ShowHtml("CreateGame.html"));

            endpoints.MapGet("/game/edit/{id:int}",
                (RequestHandlerService requestHandler) => requestHandler.ShowHtml("EditGame.html"));

            return endpoints;
        }
    }
}
