import { ClientOptions, IntentsString } from "discord.js";

/**
 * @description The main prefix that will be used for commands.
 * @type {string}
 */
const PREFIX: string = ",";

/**
 * @description The priveledged intents to be used by the bot.
 * @type {Array<IntentsString>}
 */
const INTENTS: IntentsString[] = [
    "GUILDS",
    "GUILD_MEMBERS",
    "GUILD_MESSAGES",
    "GUILD_MESSAGE_REACTIONS",
    "GUILD_EMOJIS_AND_STICKERS",
    "DIRECT_MESSAGES",
    "DIRECT_MESSAGE_REACTIONS"
];

/**
 * @description The default client options.
 * @type {ClientOptions}
 */
export const CLIENT_OPTIONS: ClientOptions = {
    partials: ["MESSAGE", "CHANNEL", "REACTION"],
    allowedMentions: { parse: ["users", "roles"], repliedUser: true },
    defaultCooldown: { delay: 3000 },
    defaultPrefix: PREFIX,
    intents: INTENTS,
    enableLoaderTraceLoggings: false
};
