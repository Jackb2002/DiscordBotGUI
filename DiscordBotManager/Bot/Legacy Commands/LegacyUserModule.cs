using Discord.Commands;

namespace DiscordBotManager.Bot.Commands
{
    [Group]
    public class LegacyUserModule : ModuleBase<SocketCommandContext>
    {
        public static bool enabled = true;

    }
}
