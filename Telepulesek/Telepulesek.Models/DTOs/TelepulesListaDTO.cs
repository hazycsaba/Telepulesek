namespace Telepulesek.Models.DTOs
{
    public class TelepulesListaDTO
    {
        public TelepulesListaDTO(string megnevezes, int IRSZ, string? telepulesresz = null)
        {
            this.megnevezes = megnevezes;
            this.IRSZ = IRSZ;
            this.telepulesresz = telepulesresz;
        }

        public string megnevezes { get; set; }
        public int IRSZ { get; set; }
        public string? telepulesresz { get; set; }
    }
}
