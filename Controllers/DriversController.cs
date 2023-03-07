using Microsoft.AspNetCore.Mvc;
using FormulaApi.Models;
using FormulaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DriversController : ControllerBase
{
    private readonly ApiDbContext _context;

    public DriversController(ApiDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _context.Drivers.ToListAsync());
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<IActionResult> Get(int id)
    {
        var driver = await _context.Drivers.FirstOrDefaultAsync(Driver => Driver.Id == id);

        if (driver == null) return NotFound();
        return Ok(driver);
    }

    [HttpPost]
    [Route("AddDriver")]
    public async Task<IActionResult> AddDriver(Driver driver)
    {
        _context.Drivers.Add(driver);

        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("DeleteDriver")]
    public async Task<IActionResult> DeleteDriver(int id)
    {
        var driver = await _context.Drivers.FirstOrDefaultAsync(Driver => Driver.Id == id);

        if (driver == null) return NotFound();

        _context.Drivers.Remove(driver);
        await _context.SaveChangesAsync();
        return NoContent();

    }


    [HttpPatch]
    [Route("UpdateDriver")]
    public async Task<IActionResult> UpdateDriver(Driver driver)
    {
        var existdriver = await _context.Drivers.FirstOrDefaultAsync(Driver => Driver.Id == driver.Id);

        if (existdriver == null) return NotFound();

        existdriver.Name = driver.Name;
        existdriver.Team = driver.Team;
        existdriver.DriverNumber = driver.DriverNumber;

        await _context.SaveChangesAsync();

        return NoContent();

    }
}
