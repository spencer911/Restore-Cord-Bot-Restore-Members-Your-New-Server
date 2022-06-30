import { PrismaClient } from "@prisma/client";
import { SapphireClient } from "@sapphire/framework";
import { container } from "@sapphire/pieces";

import { CLIENT_OPTIONS } from "../../config";
import { Database } from "../database/Database";

export class LatteClient extends SapphireClient {
    /**
     * @constructor
     * @description The client constructor.
     */
    public constructor() {
        super(CLIENT_OPTIONS);

        container.database = new Database(new PrismaClient(), this);
    }

    /**
     * @description Initializes the client.
     * @param {string} [token] - The token to be used by the client.
     * @returns {Promise<string>}
     */
    public async __init(token?: string): Promise<string> {
        return super.login(token ?? process.env.DISCORD_TOKEN);
    }
}
