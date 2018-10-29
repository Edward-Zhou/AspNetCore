using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.Models
{
    [Table("Translation", Schema = "core")]
    public class Translation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TranslationID { get; set; }

        [Required]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }

        [ForeignKey("Language")]
        public Guid LanguageID { get; set; }

        //[ForeignKey("Portal")]
        //public Guid PortalID { get; set; }
    }
    public class Language
    {
        public Guid LanguageID { get; set; }
        public string LanguageName { get; set; }
    }
    public class TranslationsModel
    {
        public List<Translation> Translations { get; set; }
    }
}
