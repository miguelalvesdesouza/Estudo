namespace BizFlow.Domain.Entities;
public class Agendamento
{
    public Guid Id { get; set; }
    public string ClienteNome { get; set; } = string.Empty;
    public string Servico { get; set; } = string.Empty;
    public DateTime DataHora { get; set; }

}
