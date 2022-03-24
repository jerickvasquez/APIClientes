namespace APIClientes.Modelo.DTo
{
    public class ResponseDTo
    {

        public bool IsSuccess { get; set; } = true;

        public object Result { get; set; }

        public string DisplayMessage { get; set; }

        public List<string> ErrorMesagge { get; set; }
    }
}
