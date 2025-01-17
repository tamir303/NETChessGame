export interface ResponseProps {
    success: boolean;
    message: string;
    data: Record<string, any>;
}

export class ApiClient {
    private baseUrl: string;

    constructor(baseUrl: string) {
        this.baseUrl = baseUrl;
    }

    async get(url: string, params: Record<string, any> = {}): Promise<ResponseProps> {
        const queryString = new URLSearchParams(params).toString();
        const fullUrl = `${this.baseUrl}${url}?${queryString}`;

        try {
            const response = await fetch(fullUrl, { method: 'GET' });
            if (!response.ok) throw new Error(`HTTP error! status: ${response.status}`);
            console.log(response)
            const result = await response.json();
            return result.Value;
        } catch (error) {
            console.error("GET request error:", error);
            throw new Error("Failed to fetch data");
        }
    }

    async post(url: string, body: any): Promise<ResponseProps> {
        try {
            const response = await fetch(`${this.baseUrl}${url}`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(body),
            });
            if (!response.ok) throw new Error(`HTTP error! status: ${response.status}`);
            const result = await response.json();
            return result.Value;
        } catch (error) {
            console.error("POST request error:", error);
            throw new Error("Failed to post data");
        }
    }
}
