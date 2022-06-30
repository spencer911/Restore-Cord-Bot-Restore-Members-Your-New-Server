using Discord.WebSocket;
using Discord.Interactions;

namespace DiscordBot_Boilerplate.Interactions
{
    public class SelectMenuModule : InteractionModuleBase<SocketInteractionContext<SocketMessageComponent>>
    {
        [ComponentInteraction("select")]
        public async Task ButtonClicked(string[] selectedValues)
        {
            await RespondAsync($"You've selected {string.Join(", ", selectedValues)}").ConfigureAwait(false);
        }
    }
}
