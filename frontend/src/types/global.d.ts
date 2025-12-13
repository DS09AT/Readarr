export {};

declare global {
  interface Window {
    Readarr: {
      urlBase: string;
      apiRoot: string;
      apiKey: string;
      instanceName?: string;
      [key: string]: any;
    };
  }
}
