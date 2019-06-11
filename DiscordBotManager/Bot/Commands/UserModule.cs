using Discord.Commands;

namespace DiscordBotManager.Bot.Commands
{
    [Group]
    public class UserModule : ModuleBase<SocketCommandContext>
    {
        public static bool enabled = true;

    }
}
