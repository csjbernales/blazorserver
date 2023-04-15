namespace blazorserver.Data
{
    public class Game
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Developer { get; set; }
        public required DateOnly ReleaseDate { get; set; }
    }
}
