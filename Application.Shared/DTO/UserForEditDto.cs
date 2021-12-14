using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Application.Shared.DTO;
public class UserForEditDto
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string UserName { get; set; }

    [MinLength(6, ErrorMessage = "The Password field must be a minimum of 6 characters")]
    public string Password { get; set; }

    public UserForEditDto() { }

    public UserForEditDto(User user)
    {
        FirstName = user.FirstName;
        LastName = user.LastName;
        UserName = user.UserName;
    }
}