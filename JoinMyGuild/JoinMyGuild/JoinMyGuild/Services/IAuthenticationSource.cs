using System;

namespace JoinMyGuild.Services
{
    public interface IAuthenticationSource
    {
        event EventHandler<AuthenticatedUserResponseEventArgs> OnAuthenticationCompleted;
        void Login();
    }
}
