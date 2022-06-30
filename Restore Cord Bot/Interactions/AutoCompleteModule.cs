using Discord;
using Discord.Interactions;

namespace DiscordBot_Boilerplate.Interactions
{
    public class AutoCompleteModule : AutocompleteHandler
    {
        private static readonly List<string> _locations = new() { "Amsterdam", "London", "Paris", "New York" };

        public override async Task<AutocompletionResult> GenerateSuggestionsAsync(IInteractionContext context, IAutocompleteInteraction autocompleteInteraction, IParameterInfo parameter, IServiceProvider services)
        {
            var currentValue = autocompleteInteraction.Data.Current.Value.ToString();
            IEnumerable<string> suggestions;
            // In Discord, when you start writing an argument which has an autocomplete,
            // Discord will ask for the initial value.
            if (string.IsNullOrWhiteSpace(currentValue))
            {
                suggestions = _locations;
            }
            else
            {
                suggestions = _locations.Where(l => l.StartsWith(currentValue, StringComparison.OrdinalIgnoreCase));
            }

            var result = suggestions
                .OrderBy(s => s)
                .Select(s => new AutocompleteResult(s, s))
                .ToList();
            return await Task.FromResult(AutocompletionResult.FromSuccess(result)).ConfigureAwait(false);
        }
    }
}