using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachineApp.Models
{
    /// <summary>
    /// [2]Model Class : Media 모델 클래스 == Media 테이블과 일대일로 매핑 Media , Media , Media 
    /// </summary>
    /// 
    [Table("MachinesMedias")]
    public class MachineMedia
    {
        /// <summary>
        /// Serial Numder
        /// </summary>
        /// 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// HardWare Name
        /// </summary>
        [Required]
        public int MachineId { get; set; }
        public int MediaId { get; set; }

        public string CreatedBy { get; set; }

        public string Created { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? Modified { get; set; }

    }
}
