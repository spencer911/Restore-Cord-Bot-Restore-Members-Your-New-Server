using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DiscordBot_Boilerplate;
using DiscordBot_Boilerplate.Commands;
using DiscordBot_Boilerplate.Interactions;
using Discord.Interactions;

var cancellationTokenSource = new CancellationTokenSource();
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
#if DEBUG
    .AddJsonFile("appsettings.Development.json")
#else
    .AddJsonFile("appsettings.Production.json", optional:true)
#endif
    .Build();

var services = new ServiceCollection()
    .AddSingleton<IConfiguration>(configuration)
    .AddSingleton(cancellationTokenSource)
    .AddDiscordBot()
    .BuildServiceProvider();

var client = services.GetRequiredService<DiscordSocketClient>();
client.GuildAvailable += async (guild) =>
{
    var commands = services.GetRequiredService<InteractionService>();
    // You should NOT do this in production.
    await commands.RegisterCommandsToGuildAsync(guild.Id).ConfigureAwait(false);
};

await client.LoginAsync(TokenType.Bot, configuration.GetSection("Token").Get<string>()).ConfigureAwait(false);
await client.StartAsync().ConfigureAwait(false);

var cancellationToken = services.GetRequiredService<CancellationTokenSource>();
await services.GetRequiredService<InteractionHandler>().InitializeAsync().ConfigureAwait(false);
await services.GetRequiredService<CommandHandler>().InitializeAsync().ConfigureAwait(false);

try
{
    await Task.Delay(Timeout.Infinite, cancellationToken.Token).ConfigureAwait(false);
}
catch (OperationCanceledException)
{
    await client.LogoutAsync().ConfigureAwait(false);
    await client.StopAsync().ConfigureAwait(false);
}
catch (Exception)
{
    throw;
}
finally
{
    client.Dispose();
}