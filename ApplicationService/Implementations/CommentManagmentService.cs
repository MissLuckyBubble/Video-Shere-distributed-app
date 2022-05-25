using ApplicationService.DTOs;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ApplicationService.Implementations
{
    public class CommentManagmentService
    {
        public List<CommentDTO> Get()
        {
            List<CommentDTO> comments = new List<CommentDTO>();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.CommentRepository.Get())
                {
                    comments.Add(new CommentDTO
                    {
                        Id = item.Id,
                        CreateDate = item.CreateDate,
                        UpdateDate = item?.UpdateDate,
                        Text = item.Text,
                        Likes = item.Likes,
                        Dislikes = item.Dislikes,
                        OwnerId = item.OwnerId,
                        VideoId = item.VideoId,
                        ParentCommentId = item.ParentCommentId,
                    });
                }
                return comments;
            }
        }

        public CommentDTO GetById(int id)
        {
            CommentDTO commentToReturn = new CommentDTO();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Comment comment = unitOfWork.CommentRepository.GetByID(id);
                if (comment != null)
                {
                    commentToReturn.Id = comment.Id;
                    commentToReturn.CreateDate = comment.CreateDate;
                    commentToReturn.UpdateDate = comment?.UpdateDate;
                    commentToReturn.Text = comment.Text;
                    commentToReturn.Likes = comment.Likes;
                    commentToReturn.Dislikes = comment.Dislikes;
                    commentToReturn.OwnerId = comment.OwnerId;
                    commentToReturn.VideoId = comment.VideoId;
                    commentToReturn.ParentCommentId = comment.ParentCommentId;
                }
            }

            return commentToReturn;
        }

        public bool Save(CommentDTO commentDTO)
        {
            Video video = new Video();
            User owner = new User();
            Comment parentC = new Comment();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                video = unitOfWork.VideoRepository.GetByID(commentDTO.VideoId);
                owner = unitOfWork.UserRepository.GetByID(commentDTO.OwnerId);
               parentC = unitOfWork.CommentRepository.GetByID(commentDTO.ParentCommentId);

                try { unitOfWork.Save(); }
                catch { Debug.WriteLine("error"); }
            }
            Comment comment = new Comment
            {
                Id = commentDTO.Id,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Text = commentDTO.Text,
                Likes = 0,
                Dislikes = 0,
                OwnerId = commentDTO.OwnerId,
                VideoId = commentDTO.VideoId,
                ParentCommentId = commentDTO.ParentCommentId,
                Owner = owner,
                Video = video,
                ParentComment = parentC
            };
            using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    try
                    {
                        unitOfWork.CommentRepository.Insert(comment);
                        unitOfWork.Save();

                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            
        }


        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.CommentRepository.Delete(id);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(CommentDTO commentDTO)
        {
            Comment comment = new Comment
            {
                Id = commentDTO.Id,
                CreateDate = commentDTO.CreateDate,
                UpdateDate = DateTime.Now,
                Text = commentDTO.Text,
                Likes = commentDTO.Likes,
                Dislikes = commentDTO.Dislikes,
                OwnerId = commentDTO.OwnerId,
                VideoId = commentDTO.VideoId,
                ParentCommentId = commentDTO.ParentCommentId,

            };
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.CommentRepository.Update(comment);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}