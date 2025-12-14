import { useState, useEffect, useMemo } from 'react';
import { useAuthors } from './hooks/useAuthors';
import { AuthorList } from './components/AuthorList';
import { AuthorTable } from './components/AuthorTable';
import { AuthorOverviewList } from './components/AuthorOverviewList';
import { Heading } from '@/shared/components/ui/Heading';
import { Button } from '@/shared/components/ui/Button';
import { Plus, RefreshCw, Rss, Wrench, Settings2, Eye, ArrowUpDown, Filter, Trash2, Edit, CheckSquare, FolderOutput, Tags } from 'lucide-react';
import { PageToolbar, PageToolbarSection, PageToolbarButton, PageToolbarSeparator, PageToolbarMenu, PageToolbarMenuItem } from '@/shared/components/ui/PageToolbar';
import { Breadcrumbs } from '@/shared/components/ui/Breadcrumbs';
import { sendCommand } from '@/features/system/services/commandService';
import { ConfirmationModal } from '@/shared/components/ui/Modal';
import { deleteAuthor } from './services/authorService';
import { AuthorMassEditModal } from './components/AuthorMassEditModal';
import { AuthorOptionsModal, PosterSize } from './components/AuthorOptionsModal';
import { signalRService } from '@/features/system/services/signalRService';
import clsx from 'clsx';

type SortKey = 'sortName' | 'added' | 'bookCount';
type FilterKey = 'all' | 'monitored' | 'unmonitored' | 'continuing' | 'ended' | 'missing';
type ViewType = 'posters' | 'table' | 'overview';

export function AuthorsPage() {
  const { authors, isLoading, error } = useAuthors();
  const [isRefreshing, setIsRefreshing] = useState(false);
  const [isRssSyncing, setIsRssSyncing] = useState(false);
  
  // View State
  const [view, setView] = useState<ViewType>('posters');
  const [sortKey, setSortKey] = useState<SortKey>('sortName');
  const [filterKey, setFilterKey] = useState<FilterKey>('all');
  const [posterSize, setPosterSize] = useState<PosterSize>('medium');
  const [isOptionsModalOpen, setIsOptionsModalOpen] = useState(false);

  // Editor State
  const [isEditorActive, setIsEditorActive] = useState(false);
  const [selectedIds, setSelectedIds] = useState<number[]>([]);
  const [isDeleteModalOpen, setIsDeleteModalOpen] = useState(false);
  const [isEditModalOpen, setIsEditModalOpen] = useState(false);

  // SignalR Listener for Updates
  useEffect(() => {
    const handleUpdate = (body: any) => {

      if (body.action === 'updated' || body.action === 'deleted' || body.action === 'added' || body.action === 'sync') {
         console.log('SignalR Author Update received', body);
      }
    };

    signalRService.on('Author', handleUpdate);
    return () => {
      signalRService.off('Author', handleUpdate);
    };
  }, []);

  // Filter & Sort Logic
  const filteredAuthors = useMemo(() => {
    let result = authors;

    // Filter
    if (filterKey === 'monitored') result = result.filter(a => a.monitored);
    if (filterKey === 'unmonitored') result = result.filter(a => !a.monitored);
    if (filterKey === 'continuing') result = result.filter(a => a.status === 'continuing');
    if (filterKey === 'ended') result = result.filter(a => a.status === 'ended');
    if (filterKey === 'missing') result = result.filter(a => (a.statistics?.bookCount ?? 0) > (a.statistics?.bookFileCount ?? 0));

    // Sort
    return [...result].sort((a, b) => {
      if (sortKey === 'added') return new Date(b.added).getTime() - new Date(a.added).getTime();
      if (sortKey === 'bookCount') return (b.statistics?.bookCount ?? 0) - (a.statistics?.bookCount ?? 0);
      return a.sortName.localeCompare(b.sortName);
    });
  }, [authors, filterKey, sortKey]);

  const handleRefresh = async () => {
    setIsRefreshing(true);
    try {
      await sendCommand('RefreshAuthor', isEditorActive && selectedIds.length > 0 ? { authorIds: selectedIds } : undefined);
    } finally {
      setTimeout(() => setIsRefreshing(false), 2000);
    }
  };

  const handleRssSync = async () => {
    setIsRssSyncing(true);
    try {
      await sendCommand('RssSync');
    } finally {
      setTimeout(() => setIsRssSyncing(false), 2000);
    }
  };

  const handleDeleteSelected = async () => {
    for (const id of selectedIds) {
      try {
        await deleteAuthor(id, true);
      } catch (e) {
        console.error(`Failed to delete author ${id}`, e);
      }
    }
    window.location.reload(); 
  };

  const handleRenameSelected = async () => {
    // Placeholder for rename logic
    alert("Rename functionality coming soon (requires preview modal).");
  };

  const handleRetagSelected = async () => {
    // Placeholder for retag logic
    alert("Retag functionality coming soon.");
  };

  const toggleEditor = () => {
    setIsEditorActive(!isEditorActive);
    setSelectedIds([]);
  };

  const handleToggleSelect = (id: number) => {
    setSelectedIds(prev => 
      prev.includes(id) ? prev.filter(i => i !== id) : [...prev, id]
    );
  };

  const handleSelectAll = () => {
    if (selectedIds.length === filteredAuthors.length) {
        setSelectedIds([]);
    } else {
        setSelectedIds(filteredAuthors.map(a => a.id));
    }
  };

  const selectedAuthors = useMemo(() => {
    return authors.filter(a => selectedIds.includes(a.id));
  }, [authors, selectedIds]);

  if (isLoading) {
    return (
      <div className="flex h-96 items-center justify-center">
        <div className="text-zinc-500">Loading authors...</div>
      </div>
    );
  }

  if (error) {
    return (
      <div className="rounded-md bg-red-50 p-4 text-sm text-red-700 dark:bg-red-900/10 dark:text-red-400">
        Error loading authors: {error.message}
      </div>
    );
  }

  const allSelected = selectedIds.length === filteredAuthors.length && filteredAuthors.length > 0;

  return (
    <div className="flex flex-col gap-4 px-4 py-8 sm:px-6 lg:px-8 lg:py-16">
      <Breadcrumbs pages={[{ name: 'Library', href: '/' }, { name: 'Authors', current: true }]} />
      <div className="flex items-center justify-between">
        <Heading>Authors</Heading>
        <Button href="/add/new">
          <Plus className="-ml-1 mr-2 h-4 w-4" />
          Add Author
        </Button>
      </div>

      <PageToolbar className="rounded-lg border border-zinc-200 dark:border-zinc-800">
        <PageToolbarSection>
          <PageToolbarButton 
            icon={RefreshCw} 
            label={isEditorActive && selectedIds.length > 0 ? "Update Selected" : "Update All"}
            onClick={handleRefresh} 
            className={clsx(isRefreshing && "animate-spin")}
            disabled={isRefreshing}
          />
          <PageToolbarButton 
            icon={Rss} 
            label="RSS Sync" 
            onClick={handleRssSync}
            className={clsx(isRssSyncing && "animate-pulse")}
            disabled={isRssSyncing}
          />
          <PageToolbarSeparator />
          <PageToolbarButton 
            icon={Wrench} 
            label="Author Editor" 
            active={isEditorActive}
            onClick={toggleEditor}
          />
          {isEditorActive && (
            <PageToolbarButton 
                icon={CheckSquare} 
                label={allSelected ? "Unselect All" : "Select All"} 
                onClick={handleSelectAll}
            />
          )}
        </PageToolbarSection>

        <PageToolbarSection>
          <PageToolbarButton 
            icon={Settings2} 
            label="Options" 
            onClick={() => setIsOptionsModalOpen(true)}
          />
          <PageToolbarSeparator />
          
          <PageToolbarMenu icon={Eye} label="View">
            <PageToolbarMenuItem onClick={() => setView('posters')} active={view === 'posters'}>Posters</PageToolbarMenuItem>
            <PageToolbarMenuItem onClick={() => setView('table')} active={view === 'table'}>Table</PageToolbarMenuItem>
            <PageToolbarMenuItem onClick={() => setView('overview')} active={view === 'overview'}>Overview</PageToolbarMenuItem>
          </PageToolbarMenu>

          <PageToolbarMenu icon={ArrowUpDown} label="Sort">
            <PageToolbarMenuItem onClick={() => setSortKey('sortName')} active={sortKey === 'sortName'}>Name</PageToolbarMenuItem>
            <PageToolbarMenuItem onClick={() => setSortKey('added')} active={sortKey === 'added'}>Added</PageToolbarMenuItem>
            <PageToolbarMenuItem onClick={() => setSortKey('bookCount')} active={sortKey === 'bookCount'}>Book Count</PageToolbarMenuItem>
          </PageToolbarMenu>

          <PageToolbarMenu icon={Filter} label="Filter">
            <PageToolbarMenuItem onClick={() => setFilterKey('all')} active={filterKey === 'all'}>All</PageToolbarMenuItem>
            <PageToolbarMenuItem onClick={() => setFilterKey('monitored')} active={filterKey === 'monitored'}>Monitored</PageToolbarMenuItem>
            <PageToolbarMenuItem onClick={() => setFilterKey('unmonitored')} active={filterKey === 'unmonitored'}>Unmonitored</PageToolbarMenuItem>
            <PageToolbarMenuItem onClick={() => setFilterKey('continuing')} active={filterKey === 'continuing'}>Continuing</PageToolbarMenuItem>
            <PageToolbarMenuItem onClick={() => setFilterKey('ended')} active={filterKey === 'ended'}>Ended</PageToolbarMenuItem>
            <PageToolbarMenuItem onClick={() => setFilterKey('missing')} active={filterKey === 'missing'}>Missing</PageToolbarMenuItem>
          </PageToolbarMenu>
        </PageToolbarSection>
      </PageToolbar>

      {view === 'table' ? (
        <AuthorTable 
          authors={filteredAuthors} 
          isEditorActive={isEditorActive}
          selectedIds={selectedIds}
          onToggleSelect={handleToggleSelect}
        />
      ) : view === 'overview' ? (
        <AuthorOverviewList 
          authors={filteredAuthors} 
          isEditorActive={isEditorActive}
          selectedIds={selectedIds}
          onToggleSelect={handleToggleSelect}
        />
      ) : (
        <AuthorList 
          authors={filteredAuthors} 
          isEditorActive={isEditorActive}
          selectedIds={selectedIds}
          onToggleSelect={handleToggleSelect}
          posterSize={posterSize}
        />
      )}
      
      {isEditorActive && (
        <div className="fixed bottom-0 left-0 right-0 z-20 border-t border-zinc-200 bg-white/70 p-4 shadow-lg backdrop-blur-sm lg:left-72 xl:left-80 dark:border-zinc-800 dark:bg-zinc-900/70">
            <div className="flex items-center justify-between max-w-5xl mx-auto">
                <div className="flex items-center gap-4">
                    <span className="text-sm font-medium text-zinc-900 dark:text-white">
                        {selectedIds.length} selected
                    </span>
                    <div className="h-4 w-px bg-zinc-300 dark:bg-zinc-700" />
                    <Button variant="secondary" onClick={() => setSelectedIds(filteredAuthors.map(a => a.id))}>Select All</Button>
                    <Button variant="secondary" onClick={() => setSelectedIds([])}>Select None</Button>
                </div>
                
                <div className="flex gap-2">
                    <Button 
                        variant="secondary" 
                        disabled={selectedIds.length === 0}
                        onClick={handleRefresh}
                    >
                        <RefreshCw className="h-4 w-4 mr-2" />
                        Update
                    </Button>
                    <Button 
                        variant="secondary" 
                        disabled={selectedIds.length === 0}
                        onClick={handleRenameSelected}
                    >
                        <FolderOutput className="h-4 w-4 mr-2" />
                        Rename
                    </Button>
                    <Button 
                        variant="secondary" 
                        disabled={selectedIds.length === 0}
                        onClick={handleRetagSelected}
                    >
                        <Tags className="h-4 w-4 mr-2" />
                        Retag
                    </Button>
                    <Button 
                        variant="secondary" 
                        disabled={selectedIds.length === 0}
                        onClick={() => setIsEditModalOpen(true)}
                    >
                        <Edit className="h-4 w-4 mr-2" />
                        Edit
                    </Button>
                    <Button 
                        variant="secondary" 
                        disabled={selectedIds.length === 0}
                        className="text-red-600 hover:bg-red-50 dark:hover:bg-red-900/20"
                        onClick={() => setIsDeleteModalOpen(true)}
                    >
                        <Trash2 className="h-4 w-4 mr-2" />
                        Delete
                    </Button>
                </div>
            </div>
        </div>
      )}

      <ConfirmationModal
        isOpen={isDeleteModalOpen}
        onClose={() => setIsDeleteModalOpen(false)}
        onConfirm={handleDeleteSelected}
        title="Delete Selected Authors?"
        message={`Are you sure you want to delete ${selectedIds.length} authors? This will also remove their files from disk.`}
        isDestructive
        confirmLabel="Delete"
      />

      <AuthorMassEditModal
        isOpen={isEditModalOpen}
        onClose={() => setIsEditModalOpen(false)}
        selectedAuthors={selectedAuthors}
        onSaveSuccess={() => {
          window.location.reload(); 
          setIsEditModalOpen(false);
        }}
      />

      <AuthorOptionsModal
        isOpen={isOptionsModalOpen}
        onClose={() => setIsOptionsModalOpen(false)}
        posterSize={posterSize}
        onPosterSizeChange={setPosterSize}
      />
    </div>
  );
}
