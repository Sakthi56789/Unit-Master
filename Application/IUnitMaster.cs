using UnitMasterSample.Domain.Models;

namespace UnitMasterSample.Application
{
    public interface IUnitMaster
    {
        Task<bool> UpdateAsync(Guid id, UnitMaster unitMaster);
    }

}
