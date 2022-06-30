using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;
using DiscordBot_Boilerplate.Commands;
using DiscordBot_Boilerplate.Interactions;
using Microsoft.Extensions.DependencyInjection;

namespace DiscordBot_Boilerplate
{
    public static class IServiceCollectionExtensions
    {
        internal static IServiceCollection AddDiscordBot(this IServiceCollection services) =>
            services
                .AddSingleton(new DiscordSocketClient())
                .AddSingleton<InteractionService>()
                .AddSingleton<CommandService>()
                .AddSingleton<InteractionHandler>()
                .AddSingleton<CommandHandler>();
    }
}