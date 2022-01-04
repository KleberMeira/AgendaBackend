namespace APIAgenda.Models
{
    public class Evento
    {
        private string _nome;
        private string _descricao;
        private string _data;
        private string _local;
        private string partipantes;
    }
    
        public string Nome
        {
            get => _nome;
            set => _nome = value?.Trim();
        }

        public double Data { get; set; }
        
        public double Local { get; set; }
        
        public double Participantes { get; set; }
        
        public double Descricao { get; set; }
    }
}