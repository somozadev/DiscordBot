using System;
using System.Collections.Generic;
using System.Text;
using Discord.Commands;
using Discord.WebSocket;
using System.Reflection;
using System.Threading.Tasks;

namespace Bot
{
    public class CommandHandler
    {
        private DiscordSocketClient _client;
        private CommandService _commands;
        public CommandHandler(DiscordSocketClient client)
        {
            _client = client;
            _commands = new CommandService();
            _commands.AddModulesAsync(Assembly.GetEntryAssembly(), null);
            _client.MessageReceived += HandleCommandAsync;

        }

        private async Task HandleCommandAsync(SocketMessage s)
        {
            var msg = s as SocketUserMessage;
            if (msg == null) return;

            var context = new SocketCommandContext(_client, msg);
            int argPos = 0;

            if(msg.HasCharPrefix('!', ref argPos))
            {
                var result = await _commands.ExecuteAsync
                (
                    context: context,
                    argPos: argPos,
                    services: null

                );

                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand && msg.ToString() != "!maricon")
                {
                    await context.Channel.SendMessageAsync("No pat pat 4 you ");
                }
                if (!result.IsSuccess && msg.ToString() == "!maricon")
                {
                    await context.Channel.SendMessageAsync("menciona a alguien, subnormal :::>>> [!maricon @usuario]");
                }
                
            }

            

        }
    }
}
