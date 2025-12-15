import { Author } from '../types';
import { Tag } from '@/shared/components/ui/Tag';
import { Heading } from '@/shared/components/ui/Heading';

interface AuthorHeaderProps {
  author: Author;
}

export function AuthorHeader({ author }: AuthorHeaderProps) {
  const poster = author.images.find(img => img.coverType === 'poster') || author.images[0];
  const posterUrl = poster ? poster.url : undefined;

  return (
    <div className="flex flex-col gap-8 md:flex-row">
      <div className="w-full md:w-48 lg:w-56 flex-shrink-0">
        <div className="aspect-[2/3] w-full overflow-hidden rounded-lg bg-zinc-100 shadow-md dark:bg-zinc-800">
          {posterUrl ? (
            <img
              src={posterUrl}
              alt={author.authorName}
              className="h-full w-full object-cover"
            />
          ) : (
            <div className="flex h-full w-full items-center justify-center text-zinc-400">
              <span className="text-6xl font-bold opacity-20">{author.authorName.charAt(0)}</span>
            </div>
          )}
        </div>
      </div>

      <div className="flex-1 space-y-4">
        <div>
          <Heading level={1}>{author.authorName}</Heading>
          <div className="mt-2 flex flex-wrap gap-2">
            <Tag color={author.status === 'continuing' ? 'primary' : 'zinc'}>
              {author.status}
            </Tag>
            {author.monitored && <Tag color="primary">Monitored</Tag>}
            {author.genres?.map(genre => (
              <Tag key={genre} color="zinc" variant="small">{genre}</Tag>
            ))}
          </div>
        </div>

        <div className="prose dark:prose-invert max-w-none text-sm text-zinc-600 dark:text-zinc-400">
          <p>{author.overview}</p>
        </div>

        <div className="grid grid-cols-2 gap-4 sm:grid-cols-4">
          <div className="rounded-md bg-zinc-50 p-3 dark:bg-zinc-800/50">
            <div className="text-xs font-medium text-zinc-500 dark:text-zinc-400">Books</div>
            <div className="mt-1 text-lg font-semibold text-zinc-900 dark:text-white">
              {author.statistics?.bookCount ?? 0}
            </div>
          </div>
          <div className="rounded-md bg-zinc-50 p-3 dark:bg-zinc-800/50">
            <div className="text-xs font-medium text-zinc-500 dark:text-zinc-400">Path</div>
            <div className="mt-1 text-sm font-medium text-zinc-900 dark:text-white truncate" title={author.path}>
              {author.path}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
