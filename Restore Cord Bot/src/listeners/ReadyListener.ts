import { Listener } from "@sapphire/framework";
import { CLIENT_OPTIONS } from "../config";

export class ReadyListener extends Listener {
    public constructor(ctx: Listener.Context) {
        super(ctx, {
            event: "ready",
            name: "ready"
        });
    }

    public run(): void {
        this.container.logger.info(`Logged in as ${this.container.client.user?.tag}`);

        this.container.client.user?.setPresence({
            activities: [
                {
                    name: `${CLIENT_OPTIONS.defaultPrefix}help`,
                    type: "STREAMING",
                    url: "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
                }
            ],
            status: "dnd"
        });
    }
}
