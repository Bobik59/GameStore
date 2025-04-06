using DataAccess.Entities;
using DataAccess.Filters;
using DataAccess.Repositories.Abstract;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace GamesStore.Services
{
    public class RequestHandlerService
    {
        private IWebHostEnvironment _webHostEnvironment;
        private IGameRepository _gameRepository;
        public RequestHandlerService(IWebHostEnvironment webHostEnvironment, IGameRepository gameRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _gameRepository = gameRepository;
        }

        public IResult ShowHtml(string fileName)
        {
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "html/", fileName);
            string contentType = "text/html";
            return Results.File(path, contentType);
        }

        public async Task<IResult> GetGamesAsync(GameFilter filter)
        {
            var games = await _gameRepository.GetByFilterAsync(filter);
            return Results.Json(games);
        }
        public async Task<IResult> GetGameAsync(int id)
        {
            var game = await _gameRepository.GetByIdAsync(id);

            if (game == null)
                return Results.NotFound();

            return Results.Json(game);
        }
        public async Task<IResult> CreateGameAsync(IFormCollection form)
        {
            var entity = new Game
            {
                Name = form["gameName"],
                Description = form["gameDescription"],
                Genre = form["gameGenre"],
                Author = form["gameAuthor"]
            };

            var gameImage = form.Files.GetFile("gameImage");

            if (gameImage != null && gameImage.Length > 0)
                entity.ImagePath = await SaveImg(gameImage);

            var id = await _gameRepository.CreateAsync(entity);
            return Results.Redirect("/games");
        }
        public async Task<IResult> UpdateGameAsync(IFormCollection form)
        {
            var entity = await _gameRepository.GetByIdAsync(int.Parse(form["gameId"]!));

            if (entity == null)
                return Results.NotFound();

            entity.Name = form["gameName"];
            entity.Description = form["gameDescription"];
            entity.Genre = form["gameGenre"];
            entity.Author = form["gameAuthor"];

            var gameImage = form.Files.GetFile("gameImage");

            if (gameImage != null && gameImage.Length > 0)
                entity.ImagePath = await SaveImg(gameImage);

            var id = await _gameRepository.UpdateAsync(entity);
            return Results.Ok();
        }
        public async Task<IResult> DeleteGameAsync(int id)
        {
            var game = await _gameRepository.GetByIdAsync(id);

            if (game == null)
                return Results.NotFound();

            await _gameRepository.DeleteAsync(game);

            return Results.Ok();
        }


        private async Task<string> SaveImg(IFormFile img)
        {
            string imagePath = Path.Join($"/img/", img.FileName);
            string absolutePath = Path.Join(_webHostEnvironment.WebRootPath, imagePath);
            await using FileStream stream = File.Create(absolutePath);
            await img.CopyToAsync(stream);

            return imagePath;
        }
    }
}
