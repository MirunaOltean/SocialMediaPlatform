﻿
namespace SocialMediaPlatform.Models;

public partial class Post
{
    public int Id { get; set; }

    public string Content { get; set; } = null!;

    public DateOnly TimeStamp { get; set; }

    public int AuthorId { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();
}
