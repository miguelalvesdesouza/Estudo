using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Xml;
using Microsoft.VisualBasic;
class Program
{
    static List<Agendamento> agendamentos = new List<Agendamento>();
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("== Sistema de Agendamento ==");
            Console.WriteLine("1 - Adicionar Agendamento");
            Console.WriteLine("2 - Listar Agendamento");
            Console.WriteLine("3 - Alterar Agendamento");
            Console.WriteLine("4 - Remover Agendamento");
            Console.WriteLine("0 - Sair");

            var opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1": AdicionarAgendamento(); break;
                case "2": ListarAgendamentos(); break;
                case "3": AlterarAgendamento(); break;
                case "4": RemoverAgendamento(); break;
                case "0": return;
                default:
                    Console.WriteLine("Opção inválida!"); break;

            }
        }

    }

    private static void RemoverAgendamento()
    {
        Console.WriteLine("Digite o ID a ser removido: ");
        var id = Console.ReadLine();
        var agendamento = ListarAgendamento(int.Parse(id));
        agendamentos.Remove(agendamento);

    }

    static void AdicionarAgendamento()
    {
        Console.Write("Cliente: ");
        string nome = Console.ReadLine();
        Console.Write("Data: ");
        string data = Console.ReadLine();
        agendamentos.Add(new Agendamento(nome, data));

    }

    static void ListarAgendamentos()
    {
        foreach (Agendamento agendamento in agendamentos)
        {
            Console.Write($"ID: {agendamento.Id} Agendamento: {agendamento.Nome}, Data: {agendamento.DataAgendamento}\n");
        }
        Console.ReadKey();
    }

    static Agendamento ListarAgendamento(int id)
    {
        return agendamentos.Find(a => a.Id == id);

    }

    static void AlterarAgendamento()
    {
        Console.WriteLine("Digite o ID do agendamento: ");
        var id = Console.ReadLine();
        var agendamento = ListarAgendamento(int.Parse(id));

        Console.WriteLine("O que deseja alterar?");
        Console.WriteLine("1 - Nome");
        Console.WriteLine("2 - Data do agendamento");
        var opcao = Console.ReadLine();
        switch (opcao)
        {
            case "1": agendamento.Nome = Console.ReadLine(); break;
            case "2": agendamento.DataAgendamento = Console.ReadLine(); break;
        }
    }

}

class Agendamento
{
    private static int contadorId = 1;

    public int Id { get; }
    public string Nome { get; set; }
    public string DataAgendamento { get; set; }

    public Agendamento(string _nome, string _dataAgendamento)
    {
        Id = contadorId++;
        Nome = _nome;
        DataAgendamento = _dataAgendamento;
    }

}