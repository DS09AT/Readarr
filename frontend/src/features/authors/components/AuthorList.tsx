import { Author } from '../types';
import { AuthorCard } from './AuthorCard';
import { PosterSize } from './AuthorOptionsModal';
import clsx from 'clsx';

interface AuthorListProps {
  authors: Author[];
  isEditorActive?: boolean;
  selectedIds?: number[];
  onToggleSelect?: (id: number) => void;
  posterSize?: PosterSize;
}

export function AuthorList({ authors, isEditorActive, selectedIds = [], onToggleSelect, posterSize = 'medium' }: AuthorListProps) {
  const gridClasses = clsx(
    "grid gap-6",
    {
      'small': "grid-cols-3 sm:grid-cols-4 md:grid-cols-5 lg:grid-cols-6 xl:grid-cols-8",
      'medium': "grid-cols-2 sm:grid-cols-3 md:grid-cols-4 lg:grid-cols-5 xl:grid-cols-6",
      'large': "grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 xl:grid-cols-5",
    }[posterSize]
  );

  return (
    <div className={gridClasses}>
      {authors.map((author) => (
        <AuthorCard 
          key={author.id} 
          author={author} 
          isEditorActive={isEditorActive}
          isSelected={selectedIds.includes(author.id)}
          onToggleSelect={onToggleSelect}
        />
      ))}
    </div>
  );
}
