using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_V2.Entity
{
    public class Word
    {
        public Guid Id { get; set; }

        public string Header { get; set; }
        public string KeyWord { get; set; }

        [NotMapped]
        public List<KeyParams> ProductLink { get; set; }
    }
}
