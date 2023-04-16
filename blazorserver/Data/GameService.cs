using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace blazorserver.Data
{
    public class GameService : IGameService
    {
        public List<Game> Games { get; set; } = new();

        private readonly DataContext dataContext;
        private readonly NavigationManager navigationManager;

        public GameService(DataContext dataContext, NavigationManager navigationManager)
        {
            this.dataContext = dataContext;
            this.navigationManager = navigationManager;
            dataContext.Database.EnsureCreated();
        }

        public async Task LoadGames()
        {
            Games = await dataContext.Games.ToListAsync();
        }

        public async Task<Game> GetSingleGame(int id)
        {
            var game = await dataContext.Games.FindAsync(id);
            return game ?? throw new Exception("Game doesn't exist.");
        }

        public async Task CreateGame(Game game)
        {
            await dataContext.Games.AddAsync(game);
            await dataContext.SaveChangesAsync();
            navigationManager.NavigateTo("videogames");
        }

        public async Task UpdateGame(Game game, int id)
        {
            var dbGame = await dataContext.Games.FindAsync(id) ?? throw new Exception("Game doesn't exist.");
            dbGame.Name = game.Name;
            dbGame.Developer = game.Developer;
            dbGame.ReleaseDate = game.ReleaseDate;
            await dataContext.SaveChangesAsync();
            navigationManager.NavigateTo("videogames");
        }

        public async Task DeleteGame(int id)
        {
            var game = await dataContext.Games.FindAsync(id) ?? throw new Exception("Game doesn't exist.");
            dataContext.Remove(game);
            await dataContext.SaveChangesAsync();
            navigationManager.NavigateTo("videogames");
        }
    }
}