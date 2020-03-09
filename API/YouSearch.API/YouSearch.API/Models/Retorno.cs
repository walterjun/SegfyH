using System.Collections.Generic;

namespace YouSearch.API.Models
{
    public class Retorno
    {
        public Retorno()
        {
            this.Dados = new List<Dados>();
        }
        public string ProximaPagina { get; set; }
        public List<Dados> Dados { get; set; }
    }

    public class Dados
    {
        public string Tipo { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
    }
}
