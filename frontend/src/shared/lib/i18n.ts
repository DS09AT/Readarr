import { getTranslations } from '@/features/localization/services/localizationService';

let translations: Record<string, string> = {};

export const initI18n = async () => {
  try {
    const data = await getTranslations();
    translations = data.Strings;
  } catch (e) {
    console.warn('Failed to load translations', e);
  }
};

export function translate(key: string, tokens: Record<string, string | number | boolean> = {}): string {
  const translation = translations[key] || key;

  // Add default tokens
  tokens.appName = 'Shelvance';

  return translation.replace(/\{([a-z0-9]+?)\}/gi, (match, tokenMatch) =>
    String(tokens[tokenMatch] ?? match)
  );
}
