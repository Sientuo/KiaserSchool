using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiaserModel.EntityModel
{
    public class Student
    {
        [Column(TypeName = "varchar")]
        [MaxLength(length: 50)]
        public string Id { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(length: 50)]
        public string SUserCode { get; set; }

        [MaxLength(length: 50)]
        public string SName { get; set; }

        [MaxLength(length: 50)]
        public string ClassId { get; set; }

        public int Sex { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(length: 50)]
        public string CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(length: 50)]
        public string SPassword { get; set; }
    }
}
