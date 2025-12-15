import { Modal } from '@/shared/components/ui/Modal';
import { Button } from '@/shared/components/ui/Button';

export type PosterSize = 'small' | 'medium' | 'large';

interface AuthorOptionsModalProps {
  isOpen: boolean;
  onClose: () => void;
  posterSize: PosterSize;
  onPosterSizeChange: (size: PosterSize) => void;
}

export function AuthorOptionsModal({ isOpen, onClose, posterSize, onPosterSizeChange }: AuthorOptionsModalProps) {
  return (
    <Modal isOpen={isOpen} onClose={onClose} title="Options">
      <div className="space-y-4">
        <div>
          <label className="block text-sm font-medium text-zinc-700 dark:text-zinc-300 mb-2">
            Poster Size
          </label>
          <div className="flex gap-2">
            {(['small', 'medium', 'large'] as PosterSize[]).map((size) => (
              <Button
                key={size}
                variant={posterSize === size ? 'primary' : 'outline'}
                onClick={() => onPosterSizeChange(size)}
                className="capitalize"
              >
                {size}
              </Button>
            ))}
          </div>
        </div>
      </div>
      <div className="mt-6 flex justify-end">
        <Button onClick={onClose}>Close</Button>
      </div>
    </Modal>
  );
}
