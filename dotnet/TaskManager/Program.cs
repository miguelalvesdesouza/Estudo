using System;
using System.Collections.Generic;

class Program
{
    static List<Tarefa> tarefas = new();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Gerenciador de Tarefas ===");
            Console.WriteLine("1 - Adicionar Tarefa");
            Console.WriteLine("2 - Listar Tarefas");
            Console.WriteLine("3 - Concluir Tarefa");
            Console.WriteLine("4 - Remover Tarefa");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            var opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1": AdicionarTarefa(); break;
                case "2": ListarTarefas(); break;
                case "3": ConcluirTarefa(); break;
                case "4": RemoverTarefa(); break;
                case "0": return;
                default: Console.WriteLine("Opção inválida!"); break;
            }
        }
    }

    static void AdicionarTarefa()
    {
        Console.Write("Título: ");
        string titulo = Console.ReadLine();
        tarefas.Add(new Tarefa(titulo));
        Console.WriteLine("Tarefa adicionada!");
        Console.ReadKey();
    }

    static void ListarTarefas()
    {
        Console.WriteLine("=== Tarefas ===");
        for (int i = 0; i < tarefas.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {tarefas[i]}");
        }
        Console.ReadKey();
    }

    static void ConcluirTarefa()
    {
        Console.Write("Número da tarefa concluída: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < tarefas.Count)
        {
            tarefas[index].Concluir();
            Console.WriteLine("Tarefa concluída!");
        }
        else
        {
            Console.WriteLine("Número inválido!");
        }
        Console.ReadKey();
    }

    static void RemoverTarefa()
    {
        Console.Write("Número da tarefa a remover: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < tarefas.Count)
        {
            tarefas.RemoveAt(index);
            Console.WriteLine("Tarefa removida!");
        }
        else
        {
            Console.WriteLine("Número inválido!");
        }
        Console.ReadKey();
    }
}

class Tarefa
{
    public string Titulo { get; set; }
    public bool Concluida { get; private set; }

    public Tarefa(string titulo)
    {
        Titulo = titulo;
        Concluida = false;
    }

    public void Concluir() => Concluida = true;

    public override string ToString() => $"[{(Concluida ? "✔" : " ")}] {Titulo}";
}
