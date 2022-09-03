using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotManager.Bot.Modules
{
    /// <summary>
    /// list-roles command handler
    /// </summary>
    internal class Moderation
    {
        internal static async Task list_roles(SocketSlashCommand command)
        {
            var guildUser = (SocketGuildUser)command.Data.Options.First().Value;
            var roles = string.Join("\n", guildUser.Roles.Where(x => !x.IsEveryone).Select(x => x.Mention));

            var embedBuilder = new EmbedBuilder()
                .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
                .WithTitle("Roles")
                .WithDescription(roles)
                .WithColor(Color.Green)
                .WithCurrentTimestamp();
            await command.RespondAsync(embed: embedBuilder.Build(), ephemeral:true);
        }
    }
}
