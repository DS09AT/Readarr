import { Modal, ModalBody, ModalFooter } from '@/shared/components/ui/Modal';
import { Button } from '@/shared/components/ui/Button';
import { Select } from '@/shared/components/ui/Form/Select';
import { TagSelect } from '@/shared/components/ui/Form/TagSelect';
import { useState } from 'react';
import { useRootFolders, useQualityProfiles, useMetadataProfiles } from '@/features/settings/hooks/useSettingsData';
import { useTags } from '@/features/settings/hooks/useTags';
import { updateAuthor } from '../services/authorService';
import { Author } from '../types';

interface AuthorMassEditModalProps {
  isOpen: boolean;
  onClose: () => void;
  selectedAuthors: Author[];
  onSaveSuccess: () => void;
}

export function AuthorMassEditModal({ isOpen, onClose, selectedAuthors, onSaveSuccess }: AuthorMassEditModalProps) {
  const { rootFolders, isLoading: isRootFoldersLoading } = useRootFolders();
  const { qualityProfiles, isLoading: isQualityProfilesLoading } = useQualityProfiles();
  const { metadataProfiles, isLoading: isMetadataProfilesLoading } = useMetadataProfiles();
  const { tags: allTags, isLoading: isTagsLoading } = useTags();
  
  const [isSaving, setIsSaving] = useState(false);

  const [formState, setFormState] = useState<{
    rootFolderId: string;
    monitored: string;
    qualityProfileId: string;
    metadataProfileId: string;
    moveFiles: boolean;
    tags: number[];
  }>({
    rootFolderId: '',
    monitored: '',
    qualityProfileId: '',
    metadataProfileId: '',
    moveFiles: false,
    tags: [],
  });

  const handleSave = async () => {
    setIsSaving(true);
    try {
      for (const author of selectedAuthors) {
        const updates: any = {};
        if (formState.rootFolderId) {
          updates.rootFolderPath = rootFolders.find(f => f.id === Number(formState.rootFolderId))?.path;
          if (formState.moveFiles) {
            updates.moveFiles = true;
          }
        }
        if (formState.monitored) {
          updates.monitored = formState.monitored === 'true';
        }
        if (formState.qualityProfileId) {
          updates.qualityProfileId = Number(formState.qualityProfileId);
        }
        if (formState.metadataProfileId) {
          updates.metadataProfileId = Number(formState.metadataProfileId);
        }
        
        if (formState.tags.length > 0) {
            const existingTags = author.tags || [];
            updates.tags = [...new Set([...existingTags, ...formState.tags])];
        }

        if (Object.keys(updates).length > 0) {
            await updateAuthor(author.id, updates);
        }
      }
      onSaveSuccess();
      onClose();
    } catch (e) {
      console.error('Failed to mass edit authors', e);
      // TODO: Show error notification
    } finally {
      setIsSaving(false);
    }
  };

  const rootFolderOptions = rootFolders.map(f => ({ value: f.id, label: f.path }));
  const qualityProfileOptions = qualityProfiles.map(p => ({ value: p.id, label: p.name }));
  const metadataProfileOptions = metadataProfiles.map(p => ({ value: p.id, label: p.name }));
  
  const monitoredOptions = [
    { value: 'true', label: 'Monitored' },
    { value: 'false', label: 'Unmonitored' },
  ];

  return (
    <Modal isOpen={isOpen} onClose={onClose} title={`Edit ${selectedAuthors.length} Authors`} size="lg">
      <ModalBody>
        <div className="space-y-4">
          <Select
            id="rootFolder"
            label="Root Folder"
            value={formState.rootFolderId}
            onChange={(e) => setFormState({ ...formState, rootFolderId: e.target.value })}
            options={[{ value: '', label: 'No Change', disabled: true }, ...rootFolderOptions]}
            disabled={isRootFoldersLoading || isSaving}
          />
          
          {formState.rootFolderId && (
            <div className="flex items-center gap-2">
              <input
                type="checkbox"
                id="moveFiles"
                checked={formState.moveFiles}
                onChange={(e) => setFormState({ ...formState, moveFiles: e.target.checked })}
                className="h-4 w-4 rounded-sm border-zinc-300 text-primary-600 focus:ring-primary-500"
              />
              <label htmlFor="moveFiles" className="text-sm font-medium text-zinc-700 dark:text-zinc-300">
                Move files to new location
              </label>
            </div>
          )}

          <Select
            id="monitored"
            label="Monitored"
            value={formState.monitored}
            onChange={(e) => setFormState({ ...formState, monitored: e.target.value })}
            options={[{ value: '', label: 'No Change', disabled: true }, ...monitoredOptions]}
            disabled={isSaving}
          />
          <Select
            id="qualityProfile"
            label="Quality Profile"
            value={formState.qualityProfileId}
            onChange={(e) => setFormState({ ...formState, qualityProfileId: e.target.value })}
            options={[{ value: '', label: 'No Change', disabled: true }, ...qualityProfileOptions]}
            disabled={isQualityProfilesLoading || isSaving}
          />
          <Select
            id="metadataProfile"
            label="Metadata Profile"
            value={formState.metadataProfileId}
            onChange={(e) => setFormState({ ...formState, metadataProfileId: e.target.value })}
            options={[{ value: '', label: 'No Change', disabled: true }, ...metadataProfileOptions]}
            disabled={isMetadataProfilesLoading || isSaving}
          />
          
          <TagSelect
            label="Tags (Add)"
            allTags={allTags}
            selectedTagIds={formState.tags}
            onChange={(tags) => setFormState({ ...formState, tags })}
            disabled={isTagsLoading || isSaving}
          />
        </div>
      </ModalBody>
      <ModalFooter>
        <Button onClick={onClose} variant="outline" disabled={isSaving}>Cancel</Button>
        <Button onClick={handleSave} isLoading={isSaving} disabled={isSaving || selectedAuthors.length === 0}>Save Changes</Button>
      </ModalFooter>
    </Modal>
  );
}