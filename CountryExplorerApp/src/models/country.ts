export class Country {
    name?: Name;
    currency?: Record<string, Currency> = {};
    capital?: string[];
    region?: string;
    image?: string;
    mapLink?: string;
    language?: Record<string, string> = {};
}

export class Name {
    common?: string;
    official?: string;
}

export class Currency {
    name?: string;
    symbol?: string;
}