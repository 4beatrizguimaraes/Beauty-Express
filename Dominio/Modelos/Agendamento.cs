using Modelos.Cliente;
using Modelos.DataHorario;

namespace Dominio.Modelos
{
    public class Agendamento : EntitiesAbstract
    {
        public int Id { get; set; }
        public int EstabelecimentoId { get; set; }
        public int ServicoId { get; set; }
        public int ClienteId { get; set; }
        public int DataHorarioId { get; set; }
        public int IdServico { get; set; }
        public int IdCliente{ get; set; }

    }
}
