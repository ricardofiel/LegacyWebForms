using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LegacyWebForms.Pages;

public class ContactModel : PageModel
{
    [BindProperty]
    public ContactInputModel ContactInput { get; set; } = new();

    public bool IsSubmitted { get; private set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        IsSubmitted = true;
        return Page();
    }
}

public class ContactInputModel
{
    public string From { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}
