using ApplicationService.DTOs;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationService.Implementations
{
    public class VideoManagmentService
    {
        public List<VideoDTO> Get()
        {
            List<VideoDTO> videos = new List<VideoDTO>();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                UserManagmentService ums = new UserManagmentService();
                foreach (var item in unitOfWork.VideoRepository.Get())
                {
                    videos.Add(new VideoDTO
                    {
                        Id = item.Id,
                        CreateDate = item.CreateDate,
                        UpdateDate = item?.UpdateDate,
                        Title = item.Title,
                        VideoLink = item.VideoLink,
                        Likes = item.Likes,
                        Dislikes = item.Dislikes,
                        Description = item.Description,
                        OwnerId = item.OwnerId,
                        Owner = new UserDTO
                        {
                            Id = item.Owner.Id,
                            Username = item.Owner.Username,
                            Age = item.Owner.Age,
                            Country = item.Owner.Country,
                            CreateDate = item.Owner.CreateDate,
                            DateOfBirth = item.Owner.DateOfBirth,
                            Description = item.Owner.Description,
                            Gender = item.Owner.Gender,
                            Password = item.Owner.Password,
                            ProfilePictureLink = item.Owner.ProfilePictureLink,
                            UpdateDate = item.Owner.UpdateDate
                        }
                    });
                }
            }
            return videos;
        }
        public VideoDTO GetById(int id)
        {
            VideoDTO videoToReturn = new VideoDTO();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Video video = unitOfWork.VideoRepository.GetByID(id);
                if (video != null)
                {
                    videoToReturn.Id = video.Id;
                    videoToReturn.CreateDate = video.CreateDate;
                    videoToReturn.UpdateDate = video?.UpdateDate;
                    videoToReturn.Title = video.Title;
                    videoToReturn.VideoLink = video.VideoLink;
                    videoToReturn.Likes = video.Likes;
                    videoToReturn.Dislikes = video.Dislikes;
                    videoToReturn.Description = video.Description;
                    videoToReturn.OwnerId = video.OwnerId;
                }
            }

            return videoToReturn;
        }

        public bool Save(VideoDTO VideoDTO)
        {

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
               User owner = unitOfWork.UserRepository.GetByID(VideoDTO.OwnerId);
               Video video = new Video
                {
                    Id = VideoDTO.Id,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    Title = VideoDTO.Title,
                    VideoLink = VideoDTO.VideoLink,
                    Likes = 0,
                    Dislikes = 0,
                    Description = VideoDTO.Description,
                    OwnerId = VideoDTO.OwnerId,
                    Owner = owner
                };

                try
                {
                    unitOfWork.VideoRepository.Insert(video);
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
                    unitOfWork.VideoRepository.Delete(id);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(VideoDTO VideoDTO)
        {
           
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    User owner = unitOfWork.UserRepository.GetByID(VideoDTO.OwnerId);
                    Video video = new Video
                    {
                        Id = VideoDTO.Id,
                        CreateDate = VideoDTO.CreateDate,
                        UpdateDate = DateTime.Now,
                        Title = VideoDTO.Title,
                        VideoLink = VideoDTO.VideoLink,
                        Likes = VideoDTO.Likes,
                        Dislikes = VideoDTO.Dislikes,
                        Description = VideoDTO.Description,
                        OwnerId = VideoDTO.OwnerId,
                        Owner = owner
                    };

                    unitOfWork.VideoRepository.Update(video);
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