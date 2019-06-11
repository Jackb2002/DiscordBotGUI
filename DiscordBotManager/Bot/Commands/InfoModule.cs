using Discord.Commands;

namespace DiscordBotManager.Bot.Commands
{
    [Group]
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        public static bool enabled = true;
    }
}
