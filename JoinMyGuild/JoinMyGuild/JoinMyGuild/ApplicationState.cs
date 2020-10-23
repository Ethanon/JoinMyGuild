using JoinMyGuild.Services;

namespace JoinMyGuild
{
    public static class ApplicationState
    {
        public static AuthenticationManager Authentication { get; set; } = new AuthenticationManager();
    }
}
