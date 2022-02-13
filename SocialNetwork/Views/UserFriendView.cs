﻿using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Views
{
    public class UserFriendView
    {
        public void Show(IEnumerable<User> friends)
        {
            Console.WriteLine("Мои друзья");


            if (friends.Count() == 0)
            {
                Console.WriteLine("У вас нет друзей");
                return;
            }

            friends.ToList().ForEach(friend =>
            {
                Console.WriteLine("Почтовый адрес друга: {0}. Имя друга: {1}. Фамилия друга: {2}", friend.Email, friend.FirstName, friend.LastName);
            });

        }
    }
}
