using DataAccess.Entities;
using DataAccess.Filters;
using DataAccess.Repositories.Abstract;
using GamesStore.Services;

namespace GamesStore.Endpoints
{
    public static class ApiGameEndpoints
    {
        public static IEndpointRouteBuilder MapApiGameEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("api/games",
                async ([AsParameters] GameFilter filter, RequestHandlerService requestHandler)
                => await requestHandler.GetGamesAsync(filter));

            endpoints.MapGet("api/game/{id:int}",
                async (int id, RequestHandlerService requestHandler)
                => await requestHandler.GetGameAsync(id));

            endpoints.MapPost("api/game/create",
                async (IFormCollection form, RequestHandlerService requestHandler)
                => await requestHandler.CreateGameAsync(form))
                .DisableAntiforgery();

            endpoints.MapPut("api/game/edit/{id:int}",
                async (IFormCollection form, RequestHandlerService requestHandler)
                => await requestHandler.UpdateGameAsync(form))
                .DisableAntiforgery();

            endpoints.MapDelete("api/game/delete/{id:int}",
                async (int id, RequestHandlerService requestHandler)
                => await requestHandler.DeleteGameAsync(id));

            return endpoints;
        }
    }
}
