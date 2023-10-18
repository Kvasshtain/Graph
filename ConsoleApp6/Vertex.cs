namespace ConsoleApp6
{
    public class Vertex
    {
        public string? Name { get; }

        public int Id { get; }

        public Vertex(int id, string? name)
        {
            Id = id;
            Name = name;
        }
    }
}
