import { Link } from 'react-router-dom';
import clsx from 'clsx';
import { Author } from '../types';
import { Tag } from '@/shared/components/ui/Tag';

interface AuthorCardProps {
  author: Author;
  isEditorActive?: boolean;
  isSelected?: boolean;
  onToggleSelect?: (id: number) => void;
}

export function AuthorCard({ author, isEditorActive, isSelected, onToggleSelect }: AuthorCardProps) {
  const poster = author.images.find(img => img.coverType === 'poster') || author.images[0];
  const posterUrl = poster ? poster.url : undefined;

  const handleClick = (e: React.MouseEvent) => {
    if (isEditorActive && onToggleSelect) {
      e.preventDefault();
      onToggleSelect(author.id);
    }
  };

  return (
    <div 
      className={clsx(
        "group relative flex flex-col overflow-hidden rounded-lg bg-zinc-50 shadow-xs ring-1 transition hover:shadow-md dark:bg-zinc-900",
        isSelected ? "ring-2 ring-primary-500" : "ring-zinc-900/5 dark:ring-white/10"
      )}
      onClick={isEditorActive ? handleClick : undefined}
    >
      <div className="aspect-[2/3] w-full overflow-hidden bg-zinc-100 dark:bg-zinc-800 relative">
        {posterUrl ? (
          <img
            src={posterUrl}
            alt={author.authorName}
            className="h-full w-full object-cover transition duration-300 group-hover:scale-105"
            loading="lazy"
          />
        ) : (
          <div className="flex h-full w-full items-center justify-center text-zinc-400">
            <span className="text-4xl font-bold opacity-20">{author.authorName.charAt(0)}</span>
          </div>
        )}
        
        {isEditorActive && (
          <div className="absolute top-2 left-2 z-10">
            <input
              type="checkbox"
              checked={isSelected}
              onChange={() => {}}
              className="h-5 w-5 rounded-sm border-zinc-300 text-primary-600 focus:ring-primary-500"
            />
          </div>
        )}

        <div className="absolute top-2 right-2 flex gap-1">
          <Tag variant="small" color={author.status === 'continuing' ? 'primary' : 'zinc'}>
            {author.status}
          </Tag>
        </div>
      </div>

      <div className="flex flex-1 flex-col p-4">
        <h3 className="text-base font-semibold text-zinc-900 dark:text-white">
          <Link 
            to={`/author/${author.titleSlug}`} 
            className="hover:underline focus:outline-hidden"
            onClick={handleClick}
          >
            <span className="absolute inset-0" aria-hidden="true" />
            {author.authorName}
          </Link>
        </h3>
        <p className="mt-1 text-sm text-zinc-500 dark:text-zinc-400">
          {author.statistics?.bookCount ?? 0} books
        </p>
      </div>
    </div>
  );
}