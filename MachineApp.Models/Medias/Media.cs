using MachineApp.Models.Common;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.ComponentModel.DataAnnotations;

namespace MachineApp.Models
{
    /// <summary>
    /// [2]Model Class : Media 모델 클래스 == Media 테이블과 일대일로 매핑 Media , Media , Media 
    /// </summary>
    public class Media : AuditableBase
    {
        /// <summary>
        /// Serial Numder
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// HardWare Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        public string CreatedBy { get; set; }

        public string Created { get; set; }

        public string ModifieBy { get; set; }

        public DateTime? Modified { get; set; }

    }
}
