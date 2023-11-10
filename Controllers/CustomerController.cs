// CustomerController.cs
using CustomerManagementSystem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CustomerController(ApplicationDbContext context)
    {
        _context = context;
    }

    [Authorize(Roles = "Admin")] // Only Admins Can Access
    [HttpPost]
    public IActionResult AddCustomer(string name, string email)
    {
        var customer = new Customer
        {
            Name= name,
            Email= email
        };
        _context.Customers.Add(customer);
        _context.SaveChangesAsync();
        return Ok("Müşteri başarıyla eklendi.");
    }

    [HttpGet]
    public IActionResult GetCustomers()
    {
        var customers = _context.Customers.ToList();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public IActionResult GetCustomerById(int id)
    {
        var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
        return Ok(customer);
    }

    [Authorize(Roles = "Admin")] // Only Admins Can Access
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var customer = await _context.Customers.FindAsync(id);

        if (customer == null)
        {
            return NotFound();
        }

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
