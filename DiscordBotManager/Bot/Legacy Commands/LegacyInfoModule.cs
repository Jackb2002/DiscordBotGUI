using Discord.Commands;

namespace DiscordBotManager.Bot.Commands
{
    [Group]
    public class LegacyInfoModule : ModuleBase<SocketCommandContext>
    {
        public static bool enabled = true;
    }
}
