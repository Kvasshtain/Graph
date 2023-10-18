namespace ConsoleApp6
{
    public class Edge
    {
        public Vertex FirstVertex { get; }
        public Vertex SecondVertex { get; }
        public int Weight { get; }
        public int Label { get; }


        public Edge(Vertex firstVertex, Vertex secondVertex, int weight, int label)
        {

            if (firstVertex.Id == secondVertex.Id)
                throw new ArgumentException($"Id первой (Id = {firstVertex.Id}) и второй (Id = {secondVertex.Id}) вершины совпадают.");

            FirstVertex = firstVertex ?? throw new ArgumentNullException(nameof(firstVertex));
            SecondVertex = secondVertex ?? throw new ArgumentNullException(nameof(secondVertex));
            Weight = weight;
            Label = label;
        }
    }
}
