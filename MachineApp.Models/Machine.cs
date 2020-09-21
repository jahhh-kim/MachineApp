using System;
using System.ComponentModel.DataAnnotations;

namespace MachineApp.Models
{
    /// <summary>
    /// [2]Model Class : Machine 모델 클래스 == Machines 테이블과 일대일로 매핑 Machie , MachineModel , MachineBase 
    /// </summary>
    class Machine
    {
        /// <summary>
        /// Serial Numder
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// HardWare Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        public string CreatedBy { get; set; }

        public string Created { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? Modified { get; set; }

    }
}
