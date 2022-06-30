import { Database } from "../../database/Database";

export declare global {
    namespace NodeJS {
        interface ProcessEnv {
            NODE_ENV: "development" | "production";
            DISCORD_TOKEN: string;
        }
    }
}

declare module "@sapphire/pieces" {
    interface Container {
        database: Database;
    }
}
