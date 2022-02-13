using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace SocialNetwork.BLL.Tests
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void AddFriend_SuccessAddingFriend()
        {
            // Arrange
            UserAddingFriendData userAddingFriendData = new UserAddingFriendData() { UserId = 1, FriendEmail = "gmail@gmail.com" };

            UserEntity userEntity = new UserEntity()
            {
                id = 2,
                firstname = "Иван",
                lastname = "Иванов",
                password = "1010101010",
                email = "gmail@gmail.com",
                photo = null,
                favorite_movie = null,
                favorite_book = null
            };
            
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(p => p.FindByEmail(userAddingFriendData.FriendEmail)).Returns(userEntity);

            var mockFriendRepository = new Mock<IFriendRepository>();
            mockFriendRepository.Setup(p => p.Create(It.IsAny<FriendEntity>())).Returns(1);

            UserService userService = new UserService(mockUserRepository.Object, mockFriendRepository.Object);
            
            // Act => Assert
            try
            {
                userService.AddFriend(userAddingFriendData);
            }
            catch (Exception ex)
            {
                Assert.Fail("Ошибка добавления друга: " + ex.Message);
            }
        }


        [TestMethod]
        public void AddFriend_UserNotFound_ThrowsUserNotFoundException()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(p => p.FindByEmail("gmail@gmail.com")).Returns((UserEntity)null);

            var mockFriendRepository = new Mock<IFriendRepository>();

            UserService userService = new UserService(mockUserRepository.Object, mockFriendRepository.Object);
            UserAddingFriendData userAddingFriendData = new UserAddingFriendData() { UserId = 0, FriendEmail = "g@g.com" };

            // Act => Assert
            Assert.ThrowsException<UserNotFoundException>(() => userService.AddFriend(userAddingFriendData));
        }

        [TestMethod]
        public void AddFriend_ErrorAddingFriend_ThrowsException()
        {
            // Arrange
            UserAddingFriendData userAddingFriendData = new UserAddingFriendData() { UserId = 1, FriendEmail = "gmail@gmail.com" };

            UserEntity userEntity = new UserEntity()
            {
                id = 2,
                firstname = "Иван",
                lastname = "Иванов",
                password = "1010101010",
                email = "gmail@gmail.com",
                photo = null,
                favorite_movie = null,
                favorite_book = null
            };

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(p => p.FindByEmail(userAddingFriendData.FriendEmail)).Returns(userEntity);

            var mockFriendRepository = new Mock<IFriendRepository>();
            mockFriendRepository.Setup(p => p.Create(It.IsAny<FriendEntity>())).Returns(0);

            UserService userService = new UserService(mockUserRepository.Object, mockFriendRepository.Object);
            
            // Act => Assert
            Assert.ThrowsException<Exception>(() => userService.AddFriend(userAddingFriendData));
        }
    }
}
