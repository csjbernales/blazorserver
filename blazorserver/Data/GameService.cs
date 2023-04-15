using Microsoft.EntityFrameworkCore;

namespace blazorserver.Data
{
    public class GameService
    {
        private readonly DataContext dataContext;

        public GameService(DataContext dataContext)
        {
            this.dataContext = dataContext;
            dataContext.Database.EnsureCreated();
        }

        public List<Game> Games { get; set; } = new();

        public async Task<List<Game>> LoadGames()
        {
            Games = await dataContext.Game().ToListAsync();
        }
    }
}
