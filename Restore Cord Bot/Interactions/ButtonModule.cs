using Discord.Interactions;
using Discord.WebSocket;

namespace DiscordBot_Boilerplate.Interactions
{
    public class ButtonModule : InteractionModuleBase<SocketInteractionContext<SocketMessageComponent>>
    {
        [ComponentInteraction("btn:*")]
        public async Task ButtonClicked(string whichButton)
        {
            var response = whichButton switch
            {
                "click" => "Yay, you clicked me!",
                "dontclick" => "It said, DO NOT CLICK!!!",
                _ => "Realy don't know what button this is."
            };
            await RespondAsync(response).ConfigureAwait(false);
        }
    }
}
