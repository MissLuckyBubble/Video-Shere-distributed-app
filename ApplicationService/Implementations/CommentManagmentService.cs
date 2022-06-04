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
                        Owner = new UserDTO
                        {
                            Id = item.Owner.Id,
                            Age = item.Owner.Age,
                            Country = item.Owner.Country,
                            CreateDate = item.Owner.CreateDate,
                            DateOfBirth = item.Owner.DateOfBirth,
                            Description = item.Owner.Description,
                            Gender = item.Owner.Gender,
                            Password = item.Owner.Password,
                            ProfilePictureLink = item.Owner.ProfilePictureLink,
                            UpdateDate = item.Owner.UpdateDate,
                            Username = item.Owner.Username
                        },
                        Video = new VideoDTO
                        {
                        Id = item.Video.Id,
                        CreateDate = item.Video.CreateDate,
                        Description = item.Video.Description,
                        UpdateDate = item.Video.UpdateDate,
                        OwnerId = item.Video.OwnerId,
                        Dislikes = item.Video.Dislikes,
                        Likes = item.Video.Likes,
                        Title = item.Video.Title,
                        VideoLink = item.Video.VideoLink
                    }
                });
                }
                return comments;
            }
        }

        public CommentDTO GetById(int id)
        {
            Video video = new Video();
            User owner = new User();

            CommentDTO commentToReturn = new CommentDTO();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {

                Comment comment = unitOfWork.CommentRepository.GetByID(id);

                video = unitOfWork.VideoRepository.GetByID(comment.VideoId);
                owner = unitOfWork.UserRepository.GetByID(comment.OwnerId);
                
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
                    commentToReturn.Owner = new UserDTO
                    {
                        Id = owner.Id,
                        Age = owner.Age,
                        Country = owner.Country,
                        CreateDate = owner.CreateDate,
                        DateOfBirth = owner.DateOfBirth,
                        Description = owner.Description,
                        Gender = owner.Gender,
                        Password = owner.Password,
                        ProfilePictureLink = owner.ProfilePictureLink,
                        UpdateDate = owner.UpdateDate,
                        Username = owner.Username
                    };
                    commentToReturn.Video = new VideoDTO
                    {
                        Id = video.Id,
                        CreateDate = video.CreateDate,
                        Description = video.Description,
                        UpdateDate = video.UpdateDate,
                        OwnerId = video.OwnerId,
                        Owner = new UserDTO
                        {
                            Id = video.Owner.Id,
                            Age = video.Owner.Age,
                            Country = video.Owner.Country,
                            CreateDate = video.Owner.CreateDate,
                            DateOfBirth = video.Owner.DateOfBirth,
                            Description = video.Owner.Description,
                            Gender = video.Owner.Gender,
                            Password = video.Owner.Password,
                            ProfilePictureLink = video.Owner.ProfilePictureLink,
                            UpdateDate = video.Owner.UpdateDate,
                            Username = video.Owner.Username
                        },
                        Dislikes = video.Dislikes,
                        Likes = video.Likes,
                        Title = video.Title,
                        VideoLink = video.VideoLink
                    };
                }
            }

            return commentToReturn;
        }

        public bool Save(CommentDTO commentDTO)
        {


            using (UnitOfWork unitOfWork = new UnitOfWork())
                {

                Video video = unitOfWork.VideoRepository.GetByID(commentDTO.VideoId);
                User owner = unitOfWork.UserRepository.GetByID(commentDTO.OwnerId);

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
                    Owner = owner,
                    Video = video,
                };
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
          
           
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Video video = unitOfWork.VideoRepository.GetByID(commentDTO.VideoId);
                    User owner = unitOfWork.UserRepository.GetByID(commentDTO.OwnerId);

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
                        Owner = owner,
                        Video = video,
                       
                    };

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