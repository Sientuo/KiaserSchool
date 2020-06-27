using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiaserModel.EntityModel
{
    public class ClassData
    {
        [Column(TypeName ="varchar")]
        [MaxLength(length:50)]
        public string Id { get; set; }

        [MaxLength(length:50)]
        public string ClassName { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(length:50)]
        public string TeacherId { get; set; }

        [MaxLength(length: 50)]
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
