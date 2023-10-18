namespace ConsoleApp6
{
    public class Graph
    {
        private readonly Dictionary<Vertex, List<Edge>> adjList;

        public Graph() => adjList = new Dictionary<Vertex, List<Edge>>();

        public Graph(Graph source)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            adjList = new Dictionary<Vertex, List<Edge>>(source.adjList);
        }

        public Graph(string fileName)
        {
            throw new NotImplementedException(); // To do. Необходимо реализовать загрузку из файла
        }

        public void AddVertex(Vertex vertex)
        {
            if (vertex is null)
                throw new ArgumentNullException(nameof(vertex));

            if (adjList.Any(v => v.Key.Id == vertex.Id))
                throw new ArgumentException($"Вершина с Id = {vertex.Id} уже существует.");
                
            adjList.Add(vertex, new List<Edge>());
        }

        public void RemoveVertex(int id)
        {
            var removedVertex = adjList.FirstOrDefault(v => v.Key.Id == id);
            
            if (removedVertex.Equals(default(KeyValuePair<Vertex, List<Edge>>)))
                return;

            adjList.Remove(removedVertex.Key);
            
            foreach (var adj in adjList)
            {
                adj.Value.RemoveAll(edge => edge.FirstVertex.Id == id || edge.SecondVertex.Id == id);
            }
        }

        public void AddEdge(Edge edge)
        {
            if (edge is null)
                throw new ArgumentNullException(nameof(edge));

            if (!adjList.ContainsKey(edge.FirstVertex))
                throw new ArgumentException($"Граф не содержит первую вершину с Id = {edge.FirstVertex.Id}");

            if (!adjList.ContainsKey(edge.SecondVertex))
                throw new ArgumentException($"Граф не содержит вторую вершину с Id = {edge.SecondVertex.Id}");

            adjList[edge.FirstVertex].Add(edge);

            adjList[edge.SecondVertex].Add(edge);
        }
    }
}
