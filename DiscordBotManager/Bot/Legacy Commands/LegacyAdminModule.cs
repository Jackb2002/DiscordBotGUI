using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace DiscordBotManager.Bot.Commands
{
    [Group]
    [RequireBotPermission(Discord.GuildPermission.Administrator)]
    public class LegacyAdminModule : ModuleBase<SocketCommandContext>
    {
        public static bool enabled = true;
        [Command("kick")]
        [RequireUserPermission(GuildPermission.KickMembers)]
        public async Task Kick(IGuildUser user, [Remainder] string reason)
        {
            if (!enabled)
            {
                _ = await ReplyAsync("Module Disabled");
                return;
            }
            await user.KickAsync(reason);
            _ = await ReplyAsync("Kicking user");
        }

        [Command("ban")]
        [RequireUserPermission(GuildPermission.BanMembers)]
        public async Task Ban(IGuildUser user, [Remainder] string reason)
        {
            if (!enabled)
            {
                _ = await ReplyAsync("Module Disabled");
                return;
            }
            await user.BanAsync(reason: reason);
            _ = await ReplyAsync("Banning user");
        }
    }
}
