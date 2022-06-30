using Discord.Commands;

namespace DiscordBot_Boilerplate.Commands
{
    public class AdministraionModule : ModuleBase<SocketCommandContext>
    {
        private readonly CancellationTokenSource _cancellationTokenSource;

        public AdministraionModule(CancellationTokenSource cancellationTokenSource)
        {
            _cancellationTokenSource = cancellationTokenSource;
        }
        [Command("stop")]
        [RequireOwner]
        public Task Stop()
        {
            _cancellationTokenSource.Cancel();
            return Task.CompletedTask;
        }
    }
}
