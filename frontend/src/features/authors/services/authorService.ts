import api from '@/shared/lib/api';
import { Author } from '../types';

export const getAuthors = async (): Promise<Author[]> => {
  const response = await api.get<Author[]>('/author');
  return response.data;
};

export const getAuthor = async (id: number): Promise<Author> => {
  const response = await api.get<Author>(`/author/${id}`);
  return response.data;
};

export const deleteAuthor = async (id: number, deleteFiles = false): Promise<void> => {
  await api.delete(`/author/${id}`, { params: { deleteFiles } });
};

export const updateAuthor = async (id: number, updates: Partial<Author>): Promise<Author> => {
  const response = await api.put<Author>(`/author/${id}`, updates);
  return response.data;
};
