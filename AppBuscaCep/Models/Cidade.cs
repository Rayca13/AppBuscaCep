namespace AppBuscaCep.Models
{
    public class Cidade
    {
        public int id_cidade { get; set; }    
        public int codigo_ibge { get; set; }
        public int ddd { get; set; }
        public string descricao { get; set; }
        public string uf { get; set; }
    }
}
