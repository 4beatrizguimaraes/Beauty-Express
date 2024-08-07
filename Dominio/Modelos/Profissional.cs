using Dominio.Modelos;
using System.Diagnostics.CodeAnalysis;

namespace Modelos.Profissional
{
    public class Profissional : EntitiesAbstract
    {
        public int Id { get; set; }
        [NotNull] public string Nome { get; set; }
        public string Especialidade { get; set; }
        public string? Foto { get; set; }
        public int EstabelecimentoId { get; set; }
    }
}