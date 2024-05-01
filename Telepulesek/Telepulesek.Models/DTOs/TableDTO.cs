namespace Telepulesek.Models.DTOs
{
    public class TableDTO
    {
        public TableDTO(int count, List<string> capitals, List<TelepulesListaDTO> telepulesek)
        {
            this.count = count;
            this.capitals = capitals;
            this.telepulesek = telepulesek;
        }

        public int count { get; set; }
        public List<string> capitals { get; set; }
        public List<TelepulesListaDTO> telepulesek { get; set; }
    }
}
