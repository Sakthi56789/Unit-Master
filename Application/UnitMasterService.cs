using UnitMasterSample.Domain.Models;
using UnitMasterSample.Infrastructure;

namespace UnitMasterSample.Application
{
    public class UnitMasterService : IUnitMaster
    {

        private readonly UnitMasterDbContext _dbcontext;

        public UnitMasterService(UnitMasterDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> UpdateAsync(Guid id, UnitMaster unitMaster)
        {
            var data = await _dbcontext.unitmaster.FindAsync(id);
            if (data == null)
            {
                return false;
            }
            data.UnitName = unitMaster.UnitName;
            data.Abbreviation = unitMaster.Abbreviation;
            data.Description = unitMaster.Description;
            data.IsBaseUnit = unitMaster.IsBaseUnit;
            data.ConversionFactor = unitMaster.ConversionFactor;
            data.Status = unitMaster.Status;
            data.Notes = unitMaster.Notes;
            data.LastUpdatedDate = unitMaster.LastUpdatedDate;
            data.TenantId = unitMaster.TenantId;

            await _dbcontext.SaveChangesAsync();
            return true;
        }




    }
}
