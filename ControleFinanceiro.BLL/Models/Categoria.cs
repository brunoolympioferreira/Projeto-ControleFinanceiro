using System.Collections.Generic;

namespace ControleFinanceiro.BLL.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Icone { get; set; }

        // Foreign Key
        public int TipoId { get; set; }

        //Propriedade de Navegação
        public Tipo Tipo { get; set; }

        //Coleções
        public virtual ICollection<Despesa> Despesas { get; set; }
        public virtual ICollection<Ganho> Ganhos { get; set; }
    }
}
