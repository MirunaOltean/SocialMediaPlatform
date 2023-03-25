using System;
using System.Collections.Generic;

namespace SocialMediaPlatform.Models;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<Post> Posts { get; } = new List<Post>();
}
