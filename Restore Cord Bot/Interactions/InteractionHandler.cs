using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using System.Reflection;

namespace DiscordBot_Boilerplate.Interactions
{
    internal class InteractionHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly InteractionService _commands;
        private readonly IServiceProvider _services;
        public InteractionHandler(DiscordSocketClient client, InteractionService commands, IServiceProvider services)
        {
            _client = client;
            _commands = commands;
            _services = services;
        }
        public async Task InitializeAsync()
        {
            // Add the public modules that inherit InteractionModuleBase<T> to the InteractionService
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);

            // Process the InteractionCreated payloads to execute Interactions commands
            _client.InteractionCreated += HandleInteraction;
        }

        private async Task HandleInteraction(SocketInteraction arg)
        {
            try
            {
                // Create an execution context that matches the generic type parameter of your InteractionModuleBase<T> modules
                IResult? result;
                if (arg is SocketMessageComponent component)
                {
                    var ctx = new SocketInteractionContext<SocketMessageComponent>(_client, component);
                    result = await _commands.ExecuteCommandAsync(ctx, _services).ConfigureAwait(false);
                }
                else if (arg is SocketSlashCommand command)
                {
                    var ctx = new SocketInteractionContext<SocketSlashCommand>(_client, command);
                    result = await _commands.ExecuteCommandAsync(ctx, _services).ConfigureAwait(false);
                }
                else
                {
                    // Or default out to the plain one.
                    var ctx = new SocketInteractionContext(_client, arg);
                    result = await _commands.ExecuteCommandAsync(ctx, _services).ConfigureAwait(false);
                    if (!result.IsSuccess && System.Diagnostics.Debugger.IsAttached)
                    {
                        System.Diagnostics.Debugger.Break();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                // If a Slash Command execution fails it is most likely that the original interaction acknowledgement will persist. It is a good idea to delete the original
                // response, or at least let the user know that something went wrong during the command execution.
                if (arg.Type == InteractionType.ApplicationCommand)
                    await arg.GetOriginalResponseAsync().ContinueWith(async (msg) => await msg?.Result?.DeleteAsync());
            }
        }
    }
}
