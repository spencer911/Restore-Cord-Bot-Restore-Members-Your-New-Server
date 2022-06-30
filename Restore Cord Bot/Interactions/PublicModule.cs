using Discord.Interactions;
using Discord.WebSocket;

namespace DiscordBot_Boilerplate.Interactions
{
    public class PublicModule : InteractionModuleBase<SocketInteractionContext<SocketSlashCommand>>
    {
        [SlashCommand("example", "Just an example!")]
        public async Task Example(
            [Summary("name", "Name to print.")]
            string name,
            [Summary("location", "The location.")]
            [Autocomplete(typeof(AutoCompleteModule))]
            string location,
            [Summary("size", "The size of the location.")]
            Size size)
        {
            await RespondAsync($"Hi {name}, you're located in {location} which has a {size.ToString()} size.").ConfigureAwait(false);
        }
    }

    public enum Size
    {
        Large,
        Medium,
        Small
    }
}
