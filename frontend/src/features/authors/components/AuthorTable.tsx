import { Link } from 'react-router-dom';
import { Author } from '../types';
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from '@/shared/components/ui/Table';
import { Tag } from '@/shared/components/ui/Tag';
import { Check, X } from 'lucide-react';

interface AuthorTableProps {
  authors: Author[];
  isEditorActive?: boolean;
  selectedIds?: number[];
  onToggleSelect?: (id: number) => void;
}

export function AuthorTable({ authors, isEditorActive, selectedIds = [], onToggleSelect }: AuthorTableProps) {
  return (
    <Table>
      <TableHead>
        <TableRow>
          {isEditorActive && (
            <TableHeader className="w-10">
              <span className="sr-only">Select</span>
            </TableHeader>
          )}
          <TableHeader>Author</TableHeader>
          <TableHeader>Status</TableHeader>
          <TableHeader>Monitored</TableHeader>
          <TableHeader>Books</TableHeader>
          <TableHeader>Added</TableHeader>
        </TableRow>
      </TableHead>
      <TableBody>
        {authors.map((author) => (
          <TableRow key={author.id}>
            {isEditorActive && (
              <TableCell>
                <input
                  type="checkbox"
                  checked={selectedIds.includes(author.id)}
                  onChange={() => onToggleSelect?.(author.id)}
                  className="h-4 w-4 rounded-sm border-zinc-300 text-primary-600 focus:ring-primary-500"
                />
              </TableCell>
            )}
            <TableCell>
              <Link to={`/author/${author.titleSlug}`} className="font-medium hover:underline">
                {author.authorName}
              </Link>
              <div className="text-xs text-zinc-500">{author.sortName}</div>
            </TableCell>
            <TableCell>
              <Tag color={author.status === 'continuing' ? 'primary' : 'zinc'} variant="small">
                {author.status}
              </Tag>
            </TableCell>
            <TableCell>
              {author.monitored ? (
                <Check className="h-4 w-4 text-green-500" />
              ) : (
                <X className="h-4 w-4 text-zinc-400" />
              )}
            </TableCell>
            <TableCell>
              {author.statistics?.bookCount ?? 0}
            </TableCell>
            <TableCell>
              {new Date(author.added).toLocaleDateString()}
            </TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
  );
}
