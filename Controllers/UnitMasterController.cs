using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnitMasterSample.Application;
using UnitMasterSample.Domain.Models;
using UnitMasterSample.Infrastructure;

namespace UnitMasterSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitMasterController : ControllerBase
    {
       private readonly UnitMasterDbContext _dbcontext;
        private readonly IUnitMaster _unitMasterService;
        public UnitMasterController (IUnitMaster unitMasterService)
        {
            _unitMasterService = unitMasterService;
        }
        public UnitMasterController  (UnitMasterDbContext dbcontext)
        {
            _dbcontext = dbcontext; 
        }
        


        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var _data = await _dbcontext.unitmaster.ToListAsync();
            return Ok(_data);
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var data = await _dbcontext.unitmaster.FindAsync(Id);
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateUnitMaster(UnitMaster unitMaster)
        {
            var u1 = await _dbcontext.unitmaster.AddAsync(unitMaster);
            await _dbcontext.SaveChangesAsync();
            return Ok("Created Sucessfully ...!"); 
           
        }


        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateUnitMaster(Guid id,UnitMaster unitMaster)
        {
            var updated = await _unitMasterService.UpdateAsync(id, unitMaster);
            if (!updated)
                return NotFound("Unit Master not found");

            return Ok("Updated Successfully");
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> RemoveUnitMaster(Guid id)
        {
            var data = await _dbcontext.unitmaster.FindAsync(id);
            if (data == null)
            {
                return NotFound ();

            }
            _dbcontext.unitmaster.Remove(data);
            await _dbcontext.SaveChangesAsync();
            return Ok("Deleted Suceefully....!");
        }


    }
}
