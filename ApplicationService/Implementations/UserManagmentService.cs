using ApplicationService.DTOs;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationService.Implementations
{
    public class UserManagmentService
    {

        public List<UserDTO> Get()
        {
            List<UserDTO> users = new List<UserDTO>();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.UserRepository.Get())
                {
                    users.Add(new UserDTO
                    {
                        Id = item.Id,
                        CreateDate = item.CreateDate,
                        UpdateDate = item?.UpdateDate,
                        Username = item.Username,
                        Password = item.Password,
                        Country = item.Country,
                        Description = item.Description,
                        Age = item.Age,
                        DateOfBirth = item.DateOfBirth,
                        Gender = item.Gender,
                        ProfilePictureLink = item.ProfilePictureLink
                    });
                }
            }
            return users;
        }
        public UserDTO GetById(int id)
        {
            UserDTO userToReturn = new UserDTO();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                User user = unitOfWork.UserRepository.GetByID(id);
                if (user != null)
                {
                    userToReturn.Id = user.Id;
                    userToReturn.CreateDate = user.CreateDate;
                    userToReturn.UpdateDate = user?.UpdateDate;
                    userToReturn.Username = user.Username;
                    userToReturn.Password = user.Password;
                    userToReturn.Country = user.Country;
                    userToReturn.Description = user.Description;
                    userToReturn.Age = user.Age;
                    userToReturn.DateOfBirth = user.DateOfBirth;
                    userToReturn.Gender = user.Gender;
                    userToReturn.ProfilePictureLink = user.ProfilePictureLink;
                }
            }

            return userToReturn;
        }

        public bool Save(UserDTO userDTO)
        {
            User user = new User
            {
                Id = userDTO.Id,
                CreateDate = DateTime.Now,
                Username = userDTO.Username,
                Password = userDTO.Password,
                Country = userDTO.Country,
                Description = userDTO.Description,
                DateOfBirth = userDTO.DateOfBirth,
                Age = (int)((DateTime.Today - userDTO.DateOfBirth).Days / 365),
                Gender = userDTO.Gender,
                ProfilePictureLink = userDTO.ProfilePictureLink,
                UpdateDate = DateTime.Now
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.UserRepository.Insert(user);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.UserRepository.Delete(id);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(UserDTO userDTO)
        {
            User user = new User
            {
                Id = userDTO.Id,
                CreateDate = userDTO.CreateDate,
                UpdateDate = DateTime.Now,
                Username = userDTO.Username,
                Password = userDTO.Password,
                Country = userDTO.Country,
                Description = userDTO.Description,
                DateOfBirth = userDTO.DateOfBirth,
                Age = (int)((DateTime.Today - userDTO.DateOfBirth).Days / 365),
                Gender = userDTO.Gender,
                ProfilePictureLink = userDTO.ProfilePictureLink
            };
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.UserRepository.Update(user);
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
