import { PrismaClient } from "@prisma/client";
import { LatteClient } from "../structures/LatteClient";

export class Database {
    /**
     * @description The Prisma client.
     * @type {PrismaClient}
     */
    public prisma: PrismaClient;

    /**
     * @description The Latte client.
     * @type {LatteClient}
     */
    public client: LatteClient;

    /**
     * @constructor
     * @description The database constructor.
     * @param {PrismaClient} [prisma] - The Prisma client.
     * @param {LatteClient} [client] - The Latte client.
     */
    public constructor(prisma: PrismaClient, client: LatteClient) {
        this.prisma = prisma;
        this.client = client;
    }
}
