using Telepulesek.Models.Entities;

namespace Telepulesek.Models.DTOs
{
    public class TelepulesDTO
    {
        public TelepulesDTO
            (
                string megnevezes, 
                int IRSZ, 
                string telepulesresz, 
                int ksh_kod, 
                string jogallas, 
                string megye, 
                string jaras, 
                string hivatal_tipus, 
                string hivatal_szekhely, 
                int terulet, 
                int nepesseg, 
                int lakasok,
                List<string> kisebbsegiOnkormanyzatok
            )
        {
            this.megnevezes = megnevezes;
            this.IRSZ = IRSZ;
            this.telepulesresz = telepulesresz;
            this.ksh_kod = ksh_kod;
            this.jogallas = jogallas;
            this.megye = megye;
            this.jaras = jaras;
            this.hivatal_tipus = hivatal_tipus;
            this.hivatal_szekhely = hivatal_szekhely;
            this.terulet = terulet;
            this.nepesseg = nepesseg;
            this.lakasok = lakasok;
            this.kisebbsegiOnkormanyzatok = kisebbsegiOnkormanyzatok;
        }

        public string megnevezes { get; set; }
        public int IRSZ { get; set; }
        public string telepulesresz { get; set; }
        public int ksh_kod { get; set; }
        public string jogallas { get; set; }
        public string megye { get; set; }
        public string jaras { get; set; }
        public string hivatal_tipus { get; set; }
        public string hivatal_szekhely { get; set; }
        public int terulet { get; set; }
        public int nepesseg { get; set; }
        public int lakasok { get; set; }
        public List<string> kisebbsegiOnkormanyzatok { get; set; }
    }
}
