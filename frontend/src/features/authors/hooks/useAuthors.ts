import { useState, useEffect } from 'react';
import { Author } from '../types';
import { getAuthors } from '../services/authorService';

export function useAuthors() {
  const [authors, setAuthors] = useState<Author[]>([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState<Error | null>(null);

  useEffect(() => {
    const fetchAuthors = async () => {
      try {
        setIsLoading(true);
        const data = await getAuthors();
        setAuthors(data);
      } catch (err) {
        setError(err instanceof Error ? err : new Error('Failed to fetch authors'));
      } finally {
        setIsLoading(false);
      }
    };

    fetchAuthors();
  }, []);

  return { authors, isLoading, error };
}
