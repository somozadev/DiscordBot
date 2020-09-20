using Discord.Commands;
using System.Threading.Tasks;
using Discord;
using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using Discord.WebSocket;

namespace Bot.Modules
{
    public class Test : ModuleBase<SocketCommandContext>
    {
        Random rand = new Random();

        [Command("bruh")]
        public async Task BruhCommand() 
        {
            string bruh = "Brh";
            int aux = rand.Next(4, 100);
            for(int i=0; i< aux; i++)
            {
                if (i > 5)
                {
                    bruh = bruh.Insert(2, "u");
                }

            }

            await Context.Channel.SendMessageAsync(bruh);
        }

        [Command("patpat")]
        public async Task PatPatCommand(IGuildUser user)
        { 
            await Context.Channel.SendMessageAsync("Hey " + user.Mention + ", " + Context.Message.Author.Username + " pat pat you!");
        }

        [Command("maricon")]
        [Alias("marico")]
        public async Task MariconRouletteCommand(IGuildUser user)
        {
            var ember = new EmbedBuilder();
            var replies = new List<string>();

            replies.Add("Súper maricón");
            replies.Add("Maricón y peruano");
            replies.Add("Cero maricón, odia hasta su pito");
            replies.Add("Nada maricón");
            replies.Add("Maricón no, pero desayuna semen de vero");
            replies.Add("Amante de las cum burgers");

            ember.WithColor(new Color(255, 0, 255));
            
            string answer = replies[rand.Next(0, 5)];
           
            ember.Title = $"{user.Username} es : {answer}";
            await ReplyAsync(null, false, ember.Build());

        }

        [Command("insult")]
        public async Task InsultCommand()
        {
           
            List<string> todosInsultos = new List<string>();
            string insults = File.ReadAllText("Insultos.txt");
            Console.WriteLine(insults);
            foreach (string insulto in insults.Split('\n'))
            {
                todosInsultos.Add(insulto);
            }
            string result = todosInsultos[rand.Next(0, todosInsultos.Count)];


            await Context.Channel.SendMessageAsync(Context.User.Mention + ", " + result);
        }
      

    }
}
