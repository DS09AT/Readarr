import { useParams } from 'react-router-dom';
import { useAuthorBySlug } from './hooks/useAuthorBySlug';
import { useBooks } from '@/features/books/hooks/useBooks';
import { AuthorHeader } from './components/AuthorHeader';
import { BookList } from '@/features/books/components/BookList';
import { Heading } from '@/shared/components/ui/Heading';
import { Breadcrumbs } from '@/shared/components/ui/Breadcrumbs';

export function AuthorDetailsPage() {
  const { titleSlug } = useParams<{ titleSlug: string }>();
  const { author, isLoading: isAuthorLoading, error: authorError } = useAuthorBySlug(titleSlug);
  const { books, isLoading: isBooksLoading, error: booksError } = useBooks(author?.id);

  if (isAuthorLoading) {
    return (
      <div className="flex h-96 items-center justify-center">
        <div className="text-zinc-500">Loading author...</div>
      </div>
    );
  }

  if (authorError || !author) {
    return (
      <div className="rounded-md bg-red-50 p-4 text-sm text-red-700 dark:bg-red-900/10 dark:text-red-400">
        Error loading author: {authorError?.message || 'Author not found'}
      </div>
    );
  }

  return (
    <div className="mx-auto max-w-5xl space-y-12 px-4 py-8 sm:px-6 lg:px-8 lg:py-16">
      <div className="-mb-8">
        <Breadcrumbs pages={[
          { name: 'Library', href: '/' },
          { name: 'Authors', href: '/authors' },
          { name: author.authorName, current: true }
        ]} />
      </div>

      <AuthorHeader author={author} />

      <section>
        <Heading level={2} className="mb-6">Books</Heading>
        {isBooksLoading ? (
          <div className="py-12 text-center text-zinc-500">Loading books...</div>
        ) : booksError ? (
          <div className="py-12 text-center text-red-500">Error loading books</div>
        ) : (
          <BookList books={books} />
        )}
      </section>
    </div>
  );
}
