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
            Console.Write("Введите Id новой вершины: ");
            var input = Console.ReadLine();

            if (input is null) return;

            if (!int.TryParse(input, out int id)) return;

            Console.Write("Введите имя новой вершины: ");
            var name = Console.ReadLine();

            graph.AddVertex(new Vertex(id, name));

            Console.WriteLine("Вершина добавлена успешно");
        }),

        ("Удалить вершину", graph =>
        {
            Console.Write("Введите Id удаляемой вершины: ");
            var input = Console.ReadLine();

            if (input is null) return;

            if (!int.TryParse(input, out int id)) return;

            graph.RemoveVertex(id);

            Console.WriteLine("Вершина удалена успешно");
        }),

    };

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