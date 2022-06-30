import "@sapphire/plugin-logger/register";

import "dotenv/config";
import { LatteClient } from "./libraries/structures/LatteClient";

const main = (): void => {
    if (!process.env.DISCORD_TOKEN) {
        throw new TypeError(
            `Environment variable 'DISCORD_TOKEN' should be type string. Got type ${typeof process.env
                .DISCORD_TOKEN} instead.`
        );
    }

    void new LatteClient().__init();
};

main();
