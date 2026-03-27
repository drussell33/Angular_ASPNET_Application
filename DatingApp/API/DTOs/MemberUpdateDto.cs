using System;

namespace API.DTOs;

public class MemberUpdateDto
{
    public String? DisplayName { get; set; }
    public String? Description { get; set; }
    public String? City { get; set; }
    public String? Country { get; set; }
}
