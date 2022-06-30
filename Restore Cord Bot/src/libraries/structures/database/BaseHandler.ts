import { LatteClient } from "../LatteClient";

export class BaseHandler {
    /**
     * @description The Latte client.
     * @type {LatteClient}
     */
    public client: LatteClient;
    
    constructor(client: LatteClient) {
        this.client = client;
    }

    get() {
        // TODO: Implement this.
    }

    set() {
        // TODO: Implement this.
    }

    remove() {
        // TODO: Implement this.
    }

}
