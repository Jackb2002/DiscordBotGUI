using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace DiscordBotManager.Bot.Commands
{
    [Group]
    [RequireBotPermission(Discord.GuildPermission.Administrator)]
    public class AdminModule : ModuleBase<SocketCommandContext>
    {
        public static bool enabled = true;
        [Command("kick")]
        [RequireUserPermission(GuildPermission.KickMembers)]
        public async Task Kick(IGuildUser user, [Remainder]string reason)
        {
            if (!enabled)
            {
                await ReplyAsync("Module Disabled");
                return;
            }
            await user.KickAsync(reason);
            await ReplyAsync("Kicking user");
        }

        [Command("ban")]
        [RequireUserPermission(GuildPermission.BanMembers)]
        public async Task Ban(IGuildUser user, [Remainder]string reason)
        {
            if (!enabled)
            {
                await ReplyAsync("Module Disabled");
                return;
            }
            await user.BanAsync(reason: reason);
            await ReplyAsync("Banning user");
        }
    }
}
