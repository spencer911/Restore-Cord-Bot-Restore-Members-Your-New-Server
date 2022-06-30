using Discord;
using Discord.Commands;

namespace DiscordBot_Boilerplate.Commands
{
    public class PublicModule : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        public async Task Ping()
        {
            await Context.Message.ReplyAsync("pong").ConfigureAwait(false);
        }
        [Command("echo")]
        public async Task Echo(string text)
        {
            await Context.Message.ReplyAsync(text).ConfigureAwait(false);
        }
        [Command("spawn")]
        public async Task Spawn()
        {
            var selectMenu = new SelectMenuBuilder()
                .WithPlaceholder("Option 1")
                .WithCustomId("select")
                .AddOption("Option 1", "value1")
                .AddOption("Option 2", "value2");
            var component = new ComponentBuilder()
                .WithButton("Click me!", "btn:click")
                .WithButton("Don't click me!", "btn:dontclick")
                .WithSelectMenu(selectMenu)
                .Build();
            await ReplyAsync("Click the button.", components: component).ConfigureAwait(false);
        }
    }
}
