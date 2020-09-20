using System;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace Bot
{
    public class Program
    {
        private DiscordSocketClient _client;
        private CommandHandler _handler;

        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();
        
        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _handler = new CommandHandler(_client);

            _client.Log += Log;
            var token = File.ReadAllText("token.txt");
            await _client.LoginAsync(TokenType.Bot, token); //Environment.GetEnvironmentVariable("DiscordToken")
            await _client.StartAsync();


            _client.MessageUpdated += MessageUpdated;
            _client.Ready += () => { Console.WriteLine("Bot connected!"); return Task.CompletedTask; };

            await Task.Delay(-1);

        }
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        
        private async Task MessageUpdated(Cacheable<IMessage,ulong> before, SocketMessage after, ISocketMessageChannel channel)
        {
            var message = await before.GetOrDownloadAsync();
            Console.WriteLine($"{message} -> {after}");
        }
        
        
    }
}
