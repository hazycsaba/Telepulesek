namespace Telepulesek.Models.DTOs
{
    public class TelepulesListaDTO
    {
        public TelepulesListaDTO(string megnevezes, int IRSZ, string megye, int terulet, int nepesseg, int lakasok, string? telepulesresz = null)
        {
            nev = telepulesresz != null? $"{megnevezes} - {telepulesresz}" : megnevezes;
            this.IRSZ = IRSZ;
            this.megye = megye;
            this.terulet = terulet;
            this.nepesseg = nepesseg;
            this.lakasok = lakasok;
        }

        public string nev { get; set; }
        public int IRSZ { get; set; }
        public string megye { get; set; }
        public int terulet { get; set; }
        public int nepesseg { get; set; }
        public int lakasok { get; set; }
    }
}
