using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.BLL.Models
{
    public class Ganho
    {
        public int GanhoId { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public int Dia { get; set; }
        public int Ano { get; set; }

        //Foreign Key
        public int CategoriaId { get; set; }
        public int MesId { get; set; }
        public string UsuarioId { get; set; }

        //Propriedade de Navegação
        public Categoria Categoria { get; set; }
        public Mes Mes { get; set; }
        public Usuario Usuario { get; set; }
    }
}
