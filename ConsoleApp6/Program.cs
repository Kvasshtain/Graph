using System.Diagnostics;

namespace ConsoleApp6;

public class Program
{
    private static readonly (string name, Action<Graph> action)[] actions =
    {
        ("Выйти из программы", _ =>
        {
            Process.GetCurrentProcess().Kill();
        }),

        ("Добавить вершину", graph =>
        {
            if (!TryAskUserForIntValue("Введите Id новой вершины: ", out int id)) return;

            Console.Write("Введите имя новой вершины: ");
            var name = Console.ReadLine();

            graph.AddVertex(new Vertex(id, name));

            Console.WriteLine("Вершина добавлена успешно");
        }),

        ("Удалить вершину", graph =>
        {
            if (!TryAskUserForIntValue("Введите Id удаляемой вершины: ", out int id)) return;

            graph.RemoveVertex(id);

            Console.WriteLine("Вершина удалена успешно");
        }),

        ("Добавить ребро", graph =>
        {
            if (!TryAskUserForIntValue("Введите Id первой вершины: ", out int firstId)) return;

            if (!TryAskUserForIntValue("Введите Id второй вершины: ", out int secondId)) return;

            if (!TryAskUserForIntValue("Введите вес ребра: ", out int weight)) return;

            if (!TryAskUserForIntValue("Введите метку ребра: ", out int label)) return;

            var firstVertex = graph[firstId];
            var secondVertex = graph[secondId];

            var edge = new Edge(firstVertex, secondVertex, weight, label);

            graph.AddEdge(edge);

            Console.WriteLine("Ребро добавлено успешно");
        }),
    };

    private static bool TryAskUserForIntValue(string askingMessage, out int value)
    {
        value = 0;

        Console.Write(askingMessage);
        var input = Console.ReadLine();

        return input is not null && int.TryParse(input, out value);
    }

    private static void ShowAvailableUserActions()
    {
        Console.WriteLine("=====================================================================");
        
        for (int i = 0; i < actions.Length; i++)
        {
            Console.WriteLine($"{i} - {actions[i].name}");
        }
        
        Console.WriteLine("=====================================================================");
    }

    private static void Main(string[] args)
    {
        var graph = new Graph();

        while (true)
        {
            ShowAvailableUserActions();

            var input = Console.ReadLine();

            if (input is null) continue;

            int choice = int.Parse(input);

            try
            {
                actions[choice].action(graph);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}