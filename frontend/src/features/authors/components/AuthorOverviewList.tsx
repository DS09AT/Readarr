import { Link } from 'react-router-dom';
import { Author } from '../types';
import { Tag } from '@/shared/components/ui/Tag';
import { Check, X } from 'lucide-react';
import clsx from 'clsx';

interface AuthorOverviewListProps {
  authors: Author[];
  isEditorActive?: boolean;
  selectedIds?: number[];
  onToggleSelect?: (id: number) => void;
}

export function AuthorOverviewList({ authors, isEditorActive, selectedIds = [], onToggleSelect }: AuthorOverviewListProps) {
  return (
    <div className="space-y-4">
      {authors.map((author) => {
        const poster = author.images.find(img => img.coverType === 'poster') || author.images[0];
        const posterUrl = poster ? poster.url : undefined;

        return (
          <div 
            key={author.id}
            className={clsx(
              "flex gap-4 rounded-lg border bg-white p-4 shadow-sm transition hover:shadow-md dark:bg-zinc-900",
              selectedIds.includes(author.id) ? "border-primary-500 ring-1 ring-primary-500" : "border-zinc-200 dark:border-zinc-800"
            )}
            onClick={isEditorActive && onToggleSelect ? () => onToggleSelect(author.id) : undefined}
          >
            {/* Editor Checkbox */}
            {isEditorActive && (
              <div className="flex items-center">
                <input
                  type="checkbox"
                  checked={selectedIds.includes(author.id)}
                  onChange={() => {}} 
                  className="h-5 w-5 rounded-sm border-zinc-300 text-primary-600 focus:ring-primary-500"
                />
              </div>
            )}

            {/* Poster */}
            <div className="h-32 w-24 flex-shrink-0 overflow-hidden rounded-md bg-zinc-100 dark:bg-zinc-800">
              {posterUrl ? (
                <img
                  src={posterUrl}
                  alt={author.authorName}
                  className="h-full w-full object-cover"
                  loading="lazy"
                />
              ) : (
                <div className="flex h-full w-full items-center justify-center text-zinc-400">
                  <span className="text-2xl font-bold opacity-20">{author.authorName.charAt(0)}</span>
                </div>
              )}
            </div>

            {/* Info */}
            <div className="flex flex-1 flex-col justify-between">
              <div>
                <div className="flex items-start justify-between">
                  <div>
                    <h3 className="text-lg font-semibold text-zinc-900 dark:text-white">
                      <Link 
                        to={isEditorActive ? '#' : `/author/${author.titleSlug}`} 
                        className={clsx("hover:underline", isEditorActive && "pointer-events-none")}
                      >
                        {author.authorName}
                      </Link>
                    </h3>
                    <div className="text-sm text-zinc-500 dark:text-zinc-400">{author.sortName}</div>
                  </div>
                  <div className="flex gap-2">
                    <Tag color={author.status === 'continuing' ? 'primary' : 'zinc'} variant="small">
                      {author.status}
                    </Tag>
                    {author.monitored ? (
                      <Tag variant="small" color="primary" className="flex items-center gap-1">
                        <Check className="h-3 w-3" /> Monitored
                      </Tag>
                    ) : (
                      <Tag variant="small" color="zinc" className="flex items-center gap-1">
                        <X className="h-3 w-3" /> Unmonitored
                      </Tag>
                    )}
                  </div>
                </div>
                
                <p className="mt-2 text-sm text-zinc-600 dark:text-zinc-300 line-clamp-2">
                  {author.overview}
                </p>
              </div>

              <div className="mt-4 flex items-center gap-6 text-sm text-zinc-500 dark:text-zinc-400">
                <div>
                  <span className="font-medium text-zinc-900 dark:text-white">{author.statistics?.bookCount ?? 0}</span> Books
                </div>
                <div>
                  <span className="font-medium text-zinc-900 dark:text-white">{author.statistics?.bookFileCount ?? 0}</span> Files
                </div>
                <div>
                  <span className="font-medium text-zinc-900 dark:text-white">{new Date(author.added).toLocaleDateString()}</span> Added
                </div>
                <div className="ml-auto text-xs truncate max-w-xs" title={author.path}>
                  {author.path}
                </div>
              </div>
            </div>
          </div>
        );
      })}
    </div>
  );
}
