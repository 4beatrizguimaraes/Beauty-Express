using Dominio.Modelos;
using System.Diagnostics.CodeAnalysis;

namespace Modelos.Cliente
{
    public class Cliente : EntitiesAbstract
    {
        public int Id { get; set; }  
        [NotNull] public string Nome { get; set; }
        [NotNull] public string Telefone { get; set; }
        [NotNull] public string Email { get; set; }
        [NotNull] public string Senha { get; set; }
    }
}
