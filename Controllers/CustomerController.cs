// CustomerController.cs
using CustomerManagementSystem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Admin")] // Sadece Admin yetkisi olanlar erişebilir.
[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CustomerController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddCustomer(string name, string email)
    {
        var customer = new Customer
        {
            Name= name,
            Email= email
        };
        _context.Customers.Add(customer);
        _context.SaveChanges();
        return Ok("Müşteri başarıyla eklendi.");
    }

    [HttpGet]
    public IActionResult GetCustomers()
    {
        var customers = _context.Customers.ToList();
        return Ok(customers);
    }
}
