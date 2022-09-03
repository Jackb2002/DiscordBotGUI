﻿using Discord;
using Discord.Commands;
using Discord.Net;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DiscordBotManager.Bot
{
    public class BotInstance
    {
        internal DiscordSocketClient _client { get; private set; }
        public static ulong GUILD_SNOWFLAKE { get; private set; }

        public BotInstance(string Custom_Guild_Snowflake)
        { 
            _client = new Discord.WebSocket.DiscordSocketClient();
            _client.Ready += BotReady;
            _client.SlashCommandExecuted += SlashCommandHandler;

            if (Custom_Guild_Snowflake != "")
            {
                GUILD_SNOWFLAKE = Convert.ToUInt64(Custom_Guild_Snowflake);
            }    
        }

        /// <summary>
        /// Run when bot is logged out 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public Task BotDisconnected(Exception arg)
        {
            Program.MainWindow.DisableConnectedOnlyControls();
            return Task.CompletedTask;
        }

        /// <summary>
        /// Login the websocket client with a key
        /// </summary>
        /// <param name="key">The key to use</param>
        /// <returns></returns>
        public async Task Login(string key)
        {
            // Tokens should be considered secret data, and never hard-coded.

            await _client.LoginAsync(TokenType.Bot, key);

            await _client.StartAsync();

            // Block the program until it is closed.

            await Task.Delay(-1);

        }

        /// <summary>
        /// Executed when bot is ready to use
        /// </summary>
        /// <returns></returns>
        public async Task BotReady()
        {
            if (_client.ConnectionState == ConnectionState.Connected)
            {
                Output("Bot Is Ready!");
                SetupSnowflake();

                SlashCommandBuilder guildCommand = new SlashCommandBuilder()
                    .WithName("list-roles")
                    .WithDescription("Lists all roles of a user.")
                    .AddOption("user", ApplicationCommandOptionType.User, 
                    "The users whos roles you want to be listed", isRequired: true);
                
                try
                {
                    await _client.Rest.CreateGuildCommand(guildCommand.Build(), GUILD_SNOWFLAKE);
                }
                catch (HttpException exception)
                {
                    var json = JsonConvert.SerializeObject(exception.Errors, Formatting.Indented);
                    Console.WriteLine(json);
                }

            }
            else
            {
                Output("Bot signaled ready but connection not established!");
            }
            return;
        }

        private void SetupSnowflake()
        {
            if (_client.Guilds.Count == 1)
            // if only in one guild, assume snowflake is for that 
            {
                GUILD_SNOWFLAKE = _client.Guilds.First().Id;
                Output("Bot in one server, assuming snowflake of " + GUILD_SNOWFLAKE.ToString());
            }
            else if (GUILD_SNOWFLAKE == default)
            {
                Output("Bot in multiple servers with no custom snowflake");
                _client.LogoutAsync();
            }
            else
            {
                Output("Custom snowflake set " + GUILD_SNOWFLAKE);
            }
        }

        private async Task SlashCommandHandler(SocketSlashCommand command)
        {
            await command.RespondAsync("Executing " + command.Data.Name);
        }

        /// <summary>
        /// Log to console bot messages
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public Task BotLog(LogMessage arg)
        {
            Output("Bot Logged : " + arg.Message);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Wrapper For UI Write Method
        /// </summary>
        /// <param name="Message"></param>
        private void Output(string Message, bool DebugOnly = false)
        {
            if (Program._DEBUG)
            {
                Debug.WriteLine(Message);
            }
            if (DebugOnly)
            {
                return;
            }

            Program.MainWindow.Output(Message);
        }

        internal async Task Logout()
        {
            await _client.LogoutAsync();
        }
    }
}

