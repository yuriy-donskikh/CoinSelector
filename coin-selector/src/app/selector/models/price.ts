export interface Price {
    userId: string;
    sell: string;
    buy: string;
    ask: number | null;
    bid: number | null;
    rate: number | null;
    spotRate: number | null;
    timestamp: Date | null;
}