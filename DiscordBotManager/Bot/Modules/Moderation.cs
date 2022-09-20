using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
            await command.RespondAsync(embed: embedBuilder.Build(), ephemeral: true);
        }

        internal static async Task get_avatar_url(SocketSlashCommand command)
        {
            var guildUser = (SocketGuildUser)command.Data.Options.First().Value;
            string avatar_url = guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl();
            var embedBuilder = new EmbedBuilder()
                .WithAuthor(guildUser.ToString(), avatar_url)
                .WithTitle("Avatar URL")
                .WithDescription(avatar_url)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await command.RespondAsync(embed: embedBuilder.Build(), ephemeral: true);
        }

        internal static async Task prune_messages(SocketSlashCommand command)
        {
            var user = (SocketGuildUser)command.Data.Options.First().Value;
            var channel = command.Channel;
            var hours = double.MaxValue;

            foreach (var item in command.Data.Options.ToList())
            {
                if (item.Name == "hours") hours = (double)item.Value;
                if (item.Name == "channel") channel = (ISocketMessageChannel)item.Value;
            }

            string avatar_url = user.GetAvatarUrl() ?? user.GetDefaultAvatarUrl();

            string timeString = hours == double.MaxValue ? "All Time" : (hours + " Hours");

            var embedBuilder = new EmbedBuilder()
                .WithAuthor(user.ToString(), avatar_url)
                .WithTitle("Messages Pruned")
                .WithDescription("Messages Pruned\n" +
                $"Channel:{MentionUtils.MentionChannel(channel.Id)}\n" + 
                $"Time:{timeString}")
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();


            try
            {
                var messages = channel.GetMessagesAsync(limit: 10000).FlattenAsync().Result.Where(x => x.Author == user);
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            await command.RespondAsync(embed: embedBuilder.Build(), ephemeral: true);
        }

        internal static SlashCommandBuilder GenerateListRolesCommand()
        {
            return new SlashCommandBuilder()
                                    .WithName("list-roles")
                                    .WithDescription("Lists all roles of a user.")
                                    .AddOption("user", ApplicationCommandOptionType.User,
                                    "The users whos roles you want to be listed", isRequired: true);
        }

        internal static SlashCommandBuilder GenerateAvatarUrlCommand()
        {
            return new SlashCommandBuilder()
                                .WithName("get_avatar_url")
                                .WithDescription("Get a URL for the Players avatar picture")
                                .AddOption("user", ApplicationCommandOptionType.User,
                                "The user whos avatar you want to fetch", isRequired: true);
        }

        internal static SlashCommandBuilder GeneratePruneCommand()
        {
            try
            {
                return new SlashCommandBuilder()
                .WithName("prune_messages")
                .WithDescription("Prune messages of a player in a channel")
                .AddOption("user", ApplicationCommandOptionType.User,
                    "The user whos messages you want to prune", isRequired: true)
                .AddOption("hours", ApplicationCommandOptionType.Number,
                    "Length in time in hours to go back and delete, Default all time", isRequired: false)
                .AddOption("channel", ApplicationCommandOptionType.Channel,
                    "The channel for which the prune messages from, Default current channel", isRequired: false);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}
