using Dominio.Enumeradores;
using System.Diagnostics.CodeAnalysis;

namespace Dominio.Modelos
{
    public class Servico : EntitiesAbstract
    {
        public int Id { get; set; }
        [NotNull] public string Nome { get; set; }
        public double DuracaoHoras { get; set; }
        public CategoriaServicoEnum Categoria { get; set; }      
        public int ProfissionalId { get; set; }

        public int IdProfissional { get; set; }

    }
}