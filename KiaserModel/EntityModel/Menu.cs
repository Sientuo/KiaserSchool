using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiaserModel.EntityModel
{
    public class Menu
    {
        [Column(TypeName = "varchar")]
        [MaxLength(length: 50)]
        public string Id { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(length: 50)]
        public string MenuCode { get; set; }

        [MaxLength(length: 50)]
        public string MenuName { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(length: 50)]
        public string PId { get; set; }

        [MaxLength(length: 50)]
        public string MenuUrl { get; set; }

        [MaxLength(length: 200)]
        public string Remark { get; set; }

        public DateTime?  CreateDate { get; set; }

        [MaxLength(length: 50)]
        public string CreateBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        [MaxLength(length: 50)]
        public string ModifyBy { get; set; }

    }
}
