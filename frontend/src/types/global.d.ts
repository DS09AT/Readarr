export {};

declare global {
  interface Window {
    Shelvance: {
      urlBase: string;
      apiRoot: string;
      apiKey: string;
      instanceName?: string;
      [key: string]: any;
    };
  }
}
