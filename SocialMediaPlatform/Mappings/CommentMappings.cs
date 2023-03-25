﻿using SocialMediaPlatform.DTOs;
using SocialMediaPlatform.Models;


namespace SocialMediaPlatform.Mappings
{
    public static class CommentMappings
    {
        public static List<CommentDTO> ToCommentsDTO(this List<Comment> comments)
        {
            return comments.Select(e => e.ToCommentDTO()).ToList();
        }

        public static CommentDTO ToCommentDTO(this Comment comment)
        {
            if (comment == null) return new CommentDTO();

            return new CommentDTO
            {
                TimeStamp = comment.TimeStamp,
                Content = comment.Content,
                Author = comment.Author,
                Post = comment.Post
            };
        }
    }

}
