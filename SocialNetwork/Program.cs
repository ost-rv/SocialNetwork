using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.Views;
using System;

namespace SocialNetwork
{
    internal class Program
    {
        static MessageService messageService;
        static UserService userService;
        public static MainView MainView;
        public static RegistrationView RegistrationView;
        public static AuthenticationView AuthenticationView;
        public static UserMenuView UserMenuView;
        public static UserInfoView UserInfoView;
        public static UserDataUpdateView UserDataUpdateView;
        public static MessageSendingView MessageSendingView;
        public static UserIncomingMessageView UserIncomingMessageView;
        public static UserOutcomingMessageView UserOutcomingMessageView;
        public static AddingFriendView AddingFriendView;
        public static UserFriendView UserFriendView;

        static void Main(string[] args)
        {
            userService = new UserService();
            messageService = new MessageService();

            MainView = new MainView();
            RegistrationView = new RegistrationView(userService);
            AuthenticationView = new AuthenticationView(userService);
            UserMenuView = new UserMenuView(userService);
            UserInfoView = new UserInfoView();
            UserDataUpdateView = new UserDataUpdateView(userService);
            MessageSendingView = new MessageSendingView(messageService, userService);
            UserIncomingMessageView = new UserIncomingMessageView();
            UserOutcomingMessageView = new UserOutcomingMessageView();
            AddingFriendView = new AddingFriendView(userService);
            UserFriendView = new UserFriendView();

            while (true)
            {
                MainView.Show();
            }
        }
    }
}
