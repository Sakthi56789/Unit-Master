using System.ComponentModel.DataAnnotations;

namespace UnitMasterSample.Domain.Models
{
    public class UnitMaster
    {
        [Key]
        public Guid UnitID { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(50,ErrorMessage ="Only allowed 50 characters")]
        public string? UnitName { get; set; }
        [MaxLength(20,ErrorMessage ="Only allowed 20 characters .")]
        public string? Abbreviation    { get; set; }    
        public string? Description { get; set; } 
        public bool IsBaseUnit { get; set; }
        [Required]
        public decimal ConversionFactor { get; set; } 
        public string? Status { get; set; }  
        public string? Notes { get; set; }
        public Guid? CompanyId { get; set; } = null;
        public Guid? BranchId { get; set; } =null;
        public Guid? CreatedBy { get; set; } = null;
        public DateTime CreatedDate { get; set; }
        public Guid? LastUpdatedBy { get; set; } = null;
        public DateTime LastUpdatedDate { get; set; }
        public int TenantId { get; set; } 
        public Guid? MetaUnitID { get; set; } = null;
        public Guid? BaseUnitID { get; set; } = null;



    }
}
