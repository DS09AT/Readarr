import { useState, useEffect } from 'react';
import { useAuthors } from './useAuthors'; // Reuse existing hook
import { Author } from '../types';

export function useAuthorBySlug(slug?: string) {
  const { authors, isLoading: isAuthorsLoading, error: authorsError } = useAuthors();
  const [author, setAuthor] = useState<Author | null>(null);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    if (isAuthorsLoading) return;

    if (slug && authors.length > 0) {
      const found = authors.find(a => a.titleSlug === slug);
      setAuthor(found || null);
    } else {
      setAuthor(null);
    }
    setIsLoading(false);
  }, [authors, slug, isAuthorsLoading]);

  return { author, isLoading, error: authorsError };
}
