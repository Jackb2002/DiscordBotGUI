using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;

namespace DiscordBotManager.Bot
{
    public class BotInstance
    {
        public DiscordSocketClient _client { get; private set; }
        public CommandService _commands;
        public IServiceProvider _services;
        CommandServiceConfig _CommandServiceConfig = new CommandServiceConfig();
        char prefix = '!';
        public BotInstance()
        {
            _client = new Discord.WebSocket.DiscordSocketClient();
            _client.Log += BotLog;
            _client.Ready += BotReady;
            _client.Disconnected += BotDisconnected;

            _CommandServiceConfig.CaseSensitiveCommands = false;
            _CommandServiceConfig.DefaultRunMode = RunMode.Async;
            _CommandServiceConfig.IgnoreExtraArgs = true;
            _CommandServiceConfig.LogLevel = LogSeverity.Warning;

            ConfigureBot();
            RegisterCommandsAsync().GetAwaiter();
        }

        public void UpdateCommandConfig(CommandServiceConfig csc)
        {
            _ = _client.LogoutAsync().GetAwaiter();
            _CommandServiceConfig = csc;
            ConfigureBot();
            RegisterCommandsAsync().GetAwaiter();
            _ = Login(Program.MainWindow._KEY).GetAwaiter();
        }

        /// <summary>
        /// Builds service provider and command service is created
        /// </summary>
        private void ConfigureBot()
        {
            _commands = new CommandService(_CommandServiceConfig);

            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();

            Program.MainWindow.Output("Created new bot profile...");
        }

        /// <summary>
        /// Register Commands And Add Msg Handler
        /// </summary>
        /// <returns></returns>
        public async Task RegisterCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        /// <summary>
        /// Handle a user message event
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var msg = arg as SocketUserMessage;

            if (msg is null || msg.Author.IsBot) return;

            int argPos = 0;

            if (msg.HasStringPrefix(prefix.ToString(), ref argPos)
                || msg.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var context = new SocketCommandContext(_client, msg);

                Debug.WriteLine(context.Message);
                Debug.WriteLine(context.ToString());

                IResult result = await _commands.ExecuteAsync(context, argPos, _services);

                if (result.IsSuccess == false)
                {
                    Program.MainWindow.Output(result.ErrorReason);
                    await msg.Channel.SendMessageAsync(result.ErrorReason);
                }
            }
        }

        /// <summary>
        /// Run when bot is logged out 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private Task BotDisconnected(Exception arg)
        {
            Program.MainWindow.DisableControls();
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
        private Task BotReady()
        {
            Output("Bot Is Ready!");
            if (_client.ConnectionState == ConnectionState.Connected)
            {
                Program.MainWindow.EnableControls();
            }
            return Task.CompletedTask;
        }

        /// <summary>
        /// Log to console bot messages
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private Task BotLog(LogMessage arg)
        {
            Output("Bot Logged : " + arg.Message);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Wrapper For UI Write Method
        /// </summary>
        /// <param name="Message"></param>
        void Output(string Message, bool DebugOnly = false)
        {
            if (Program._DEBUG)
            {
                System.Diagnostics.Debug.WriteLine(Message);
            }
            if (DebugOnly) return;
            Program.MainWindow.Output(Message);
        }

        internal void Logout() => _client.LogoutAsync();
    }
}
