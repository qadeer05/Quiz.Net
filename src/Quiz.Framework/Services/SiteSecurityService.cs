﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Quiz.Data.Context.EntityFramework;
using Quiz.Data.Infrastructure.UnitOfWork;
using Quiz.Domain;
using WebMatrix.WebData;

namespace Quiz.Framework.Services
{
    public static class SiteSecurityService 
    {
        public static UserProfile GetUser(string username)
        {
            UserUnitOfWork uow = new UserUnitOfWork();
            return uow.UserProfileRepository.Get(u => u.UserName == username).SingleOrDefault();
        }

        public static void UpdateUser(UserProfile user)
        {
            using (UserUnitOfWork uow = new UserUnitOfWork())
            {
                uow.UserProfileRepository.Update(user);
                uow.Save();
            }
        }

        public static UserProfile GetCurrentUser()
        {
            return GetUser(CurrentUserName);
        }

        public static void CreateUser(UserProfile user)
        {
            UserProfile dbUser = GetUser(user.UserName);
            if (dbUser != null)
                throw new Exception("User with that username already exists.");
            UserUnitOfWork uow = new UserUnitOfWork();
            uow.UserProfileRepository.Insert(user);
            uow.Save();
        }

        public static bool FoundUser(string username)
        {
            UserUnitOfWork uow = new UserUnitOfWork();
            UserProfile user = uow.UserProfileRepository.Get(u => u.UserName == username).SingleOrDefault();
            return user != null;
        }

        public static string GetEmail(string username)
        {
            string email = null;
            UserUnitOfWork uow = new UserUnitOfWork();
            UserProfile user = uow.UserProfileRepository.Get(u => u.UserName == username).SingleOrDefault();
            if (user != null)
                email = user.Email;
            return email;
        }

        public static void Register(string connectionString)
        {
            var quizDbContext = new QuizDbContext(connectionString);
            quizDbContext.Database.Initialize(true);
            if (!WebSecurity.Initialized)
            {
                var userDbContext = new UserDbContext(connectionString);
                userDbContext.Database.Initialize(true);

                // The parameters being passed below should match with what has been specified in the UserProfile model class
                WebSecurity.InitializeDatabaseConnection(connectionString, "webpages_UserProfile", "UserId", "UserName",
                                                         autoCreateTables: true);
            }
        }

        public static bool ValidateUser(string userName, string password)
        {
            var membership = (WebMatrix.WebData.SimpleMembershipProvider)Membership.Provider;
            return membership.ValidateUser(userName, password);

        }

        public static bool Login(string userName, string password, bool persistCookie = false)
        {
            return WebMatrix.WebData.WebSecurity.Login(userName, password, persistCookie);
        }

        public static bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            return WebMatrix.WebData.WebSecurity.ChangePassword(userName, oldPassword, newPassword);
        }

        public static bool ConfirmAccount(string accountConfirmationToken)
        {
            return WebMatrix.WebData.WebSecurity.ConfirmAccount(accountConfirmationToken);
        }

        public static void CreateAccount(string userName, string password, bool requireConfirmationToken = false)
        {
            WebMatrix.WebData.WebSecurity.CreateAccount(userName, password, requireConfirmationToken);
        }

        public static string CreateUserAndAccount(string userName, string password, string email, bool requireConfirmationToken = false)
        {
            return WebMatrix.WebData.WebSecurity.CreateUserAndAccount(userName, password, new { Email = email }, requireConfirmationToken);
        }

        public static int GetUserId(string userName)
        {
            return WebMatrix.WebData.WebSecurity.GetUserId(userName);
        }

        public static void Logout()
        {
            WebMatrix.WebData.WebSecurity.Logout();
        }

        public static bool IsAuthenticated { get { return WebMatrix.WebData.WebSecurity.IsAuthenticated; } }

        public static bool IsConfirmed(string username)
        {
            return WebMatrix.WebData.WebSecurity.IsConfirmed(username);
        }

        public static string CurrentUserName { get { return WebMatrix.WebData.WebSecurity.CurrentUserName; } }

        public static int GetCurrentUserId { get { return WebMatrix.WebData.WebSecurity.CurrentUserId; } }

        public static bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            var roleProvider = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;
            if (deleteAllRelatedData)
            {
                string[] roles = roleProvider.GetRolesForUser(username);
                if (roles.Length > 0)
                {
                    string[] users = { username };
                    roleProvider.RemoveUsersFromRoles(users, roles);
                }
                membership.DeleteAccount(username);
            }
            bool wasDeleted = membership.DeleteUser(username, true);
            return wasDeleted;
        }

        public static string GeneratePasswordResetToken(string userName, int tokenExpirationInMinutesFromNow = 1440)
        {
            return WebMatrix.WebData.WebSecurity.GeneratePasswordResetToken(userName, tokenExpirationInMinutesFromNow);
        }

        public static bool ResetPassword(string passwordResetToken, string newPassword)
        {
            return WebMatrix.WebData.WebSecurity.ResetPassword(passwordResetToken, newPassword);
        }

        public static string GetConfirmationToken(string userName)
        {
            UserUnitOfWork uow = new UserUnitOfWork();
            int userId = uow.UserProfileRepository.Get(u => u.UserName == userName).Select(x => x.UserId).SingleOrDefault();
            string token = uow.MembershipRepository.GetConfirmationToken(userId);
            return token;
        }
    }
}
