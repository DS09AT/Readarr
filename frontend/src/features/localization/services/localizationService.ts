import api from '@/shared/lib/api';

export const getTranslations = async () => {
  const response = await api.get<{ Strings: Record<string, string> }>('/localization');
  return response.data;
};
