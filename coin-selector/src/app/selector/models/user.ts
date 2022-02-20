import { Price } from "./price";

export interface User {
    id: string;
    userName: string;
    price: Price | null;
}