using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Views
{
    public class UserMenuView
    {
        UserService userService;
        public UserMenuView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            while (true)
            {
                Console.WriteLine("Входящие сообщения: {0}", user.IncomingMessages.Count());
                Console.WriteLine("Исходящие сообщения: {0}", user.OutgoingMessages.Count());
                Console.WriteLine("Мои друзья: {0}", user.Friends.Count());

                Console.WriteLine("Просмотреть информацию о моём профиле (нажмите 1)");
                Console.WriteLine("Редактировать мой профиль (нажмите 2)");
                Console.WriteLine("Добавить в друзья (нажмите 3)");
                Console.WriteLine("Написать сообщение (нажмите 4)");
                Console.WriteLine("Просмотреть входящие сообщения (нажмите 5)");
                Console.WriteLine("Просмотреть исходящие сообщения (нажмите 6)");
                Console.WriteLine("Просмотреть моих друзей (нажмите 7)");
                Console.WriteLine("Выйти из профиля (нажмите 8)");

                string keyValue = Console.ReadLine();

                if (keyValue == "8") break;

                switch (keyValue)
                {
                    case "1":
                        {
                            Program.UserInfoView.Show(user);
                            break;
                        }
                    case "2":
                        {
                            Program.UserDataUpdateView.Show(user);
                            user = userService.FindById(user.Id);
                            break;
                        }

                    case "3":
                        {
                            Program.AddingFriendView.Show(user);
                            user = userService.FindById(user.Id);
                            break;
                        }

                    case "4":
                        {
                            Program.MessageSendingView.Show(user);
                            user = userService.FindById(user.Id);
                            break;
                        }

                    case "5":
                        {
                            Program.UserIncomingMessageView.Show(user.IncomingMessages);
                            break;
                        }

                    case "6":
                        {
                            Program.UserOutcomingMessageView.Show(user.OutgoingMessages);
                            break;
                        }

                    case "7":
                        {
                            Program.UserFriendView.Show(user.Friends);
                            break;
                        }
                }
            }

        }
    }
}
