using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
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
            try
            {
                SocketGuildUser guildUser = (SocketGuildUser)command.Data.Options.First().Value;
                string roles = string.Join("\n", guildUser.Roles.Where(x => !x.IsEveryone).Select(x => x.Mention));

                EmbedBuilder embedBuilder = new EmbedBuilder()
                    .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
                    .WithTitle("Roles")
                    .WithDescription(roles)
                    .WithColor(Color.Green)
                    .WithCurrentTimestamp();
                await command.RespondAsync(embed: embedBuilder.Build(), ephemeral: true);
            }
            catch (Exception error)
            {
                await command.RespondAsync("Error: " + error.Message, ephemeral: true);
            }
        }

        internal static async Task get_avatar_url(SocketSlashCommand command)
        {
            try
            {
                SocketGuildUser guildUser = (SocketGuildUser)command.Data.Options.First().Value;
                string avatar_url = guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl();
                EmbedBuilder embedBuilder = new EmbedBuilder()
                    .WithAuthor(guildUser.ToString(), avatar_url)
                    .WithTitle("Avatar URL")
                    .WithDescription(avatar_url)
                    .WithColor(Color.Blue)
                    .WithCurrentTimestamp();
                await command.RespondAsync(embed: embedBuilder.Build(), ephemeral: true);
            }
            catch (Exception error)
            {
                await command.RespondAsync("Error: " + error.Message, ephemeral: true);
            }
        }

        internal static async Task prune_messages(SocketSlashCommand command)
        {
            try
            {
                ISocketMessageChannel channel = command.Channel;
                IEnumerable<IMessage> messages = await channel.GetMessagesAsync(1000).FlattenAsync();

                List<SocketSlashCommandDataOption> args = command.Data.Options.ToList();
                SocketGuildUser user = args.FirstOrDefault(x => x.Name == "user").Value as SocketGuildUser;
                SocketSlashCommandDataOption hours = args.FirstOrDefault(x => x.Name == "hours");

                IEnumerable<IMessage> messagesToDelete = hours != default
                    ? messages.Where
                    (x => (DateTimeOffset.UtcNow - x.Timestamp).TotalHours > (int)hours.Value
                    && x.Author.Id == user.Id)
                    : messages.Where(x => x.Author.Id == user.Id);
                foreach (IMessage message in messagesToDelete)
                {
                    await channel.DeleteMessageAsync(message);
                }

                await command.RespondAsync("Pruned " + messagesToDelete.Count() + " messages", ephemeral: true);
            }
            catch (Exception error)
            {
                await command.RespondAsync("Error: " + error.Message, ephemeral: true);
            }
        }

        internal static async Task kick_player(SocketSlashCommand command)
        {
            try
            {
                List<SocketSlashCommandDataOption> args = command.Data.Options.ToList();
                SocketGuildUser user = args.FirstOrDefault(x => x.Name == "user").Value as SocketGuildUser;
                if (!(args.FirstOrDefault(x => x.Name == "reason").Value is string reason))
                {
                    reason = "No reason provided";
                }

                await user.KickAsync(reason);
                await command.RespondAsync("Kicked " + user.Username, ephemeral: true);
            }
            catch (Exception error)
            {
                await command.RespondAsync("Error: " + error.Message, ephemeral: true);
            }
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
                    "Length in time in hours to go back and delete, Default all time", isRequired: false);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        internal static SlashCommandBuilder GenerateKickCommand()
        {
            try
            {
                return new SlashCommandBuilder()
                .WithName("kick_user")
                .WithDescription("Kick a user from the server")
                .AddOption("user", ApplicationCommandOptionType.User,
                                   "The user you want to kick", isRequired: true)
                .AddOption("reason", ApplicationCommandOptionType.String,
                "The reason for kicking the user", isRequired: false);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}
