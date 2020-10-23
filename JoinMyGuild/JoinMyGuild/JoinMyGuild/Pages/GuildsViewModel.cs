using JoinMyGuild.Models;
using System.Collections.Generic;

namespace JoinMyGuild.Pages
{
    public class GuildsViewModel : AuthenticatedViewModel
    {
        public GuildsViewModel() : base()
        {
            Guilds = new List<Guild>()
            {
                new Guild() { Name = "Reign Storm" },
                new Guild() { Name = "Old School" }
            };
        }

        public List<Guild> Guilds { get; set; }
    }
}
