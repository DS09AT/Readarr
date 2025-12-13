import { AnimatePresence, motion } from 'framer-motion';
import { Link, useLocation } from 'react-router-dom';
import clsx from 'clsx';

import { Button } from '@/shared/components/ui';
import { remToPx } from '@/shared/lib/remToPx';
import { translate } from '@/shared/lib/i18n';

interface NavLink {
  title: string;
  href: string;
  onClick?: (e: React.MouseEvent) => void;
}

interface NavGroup {
  title: string;
  links: NavLink[];
}

function getNavigation(): NavGroup[] {
  return [
    {
      title: translate('Library'),
      links: [
        { title: translate('Authors'), href: '/authors' },
        { title: translate('Books'), href: '/books' },
        { title: translate('AddNew'), href: '/add/search' },
        { title: translate('Bookshelf'), href: '/shelf' },
        { title: translate('UnmappedFiles'), href: '/unmapped' },
      ],
    },
    {
      title: translate('Calendar'),
      links: [
        { title: translate('Calendar'), href: '/calendar' },
      ],
    },
    {
      title: translate('Activity'),
      links: [
        { title: translate('Queue'), href: '/activity/queue' },
        { title: translate('History'), href: '/activity/history' },
        { title: translate('Blocklist'), href: '/activity/blocklist' },
      ],
    },
    {
      title: translate('Wanted'),
      links: [
        { title: translate('Missing'), href: '/wanted/missing' },
        { title: translate('CutoffUnmet'), href: '/wanted/cutoffunmet' },
      ],
    },
    {
      title: translate('Settings'),
      links: [
        { title: translate('MediaManagement'), href: '/settings/mediamanagement' },
        { title: translate('Profiles'), href: '/settings/profiles' },
        { title: translate('Quality'), href: '/settings/quality' },
        { title: translate('CustomFormats'), href: '/settings/customformats' },
        { title: translate('Indexers'), href: '/settings/indexers' },
        { title: translate('DownloadClients'), href: '/settings/downloadclients' },
        { title: translate('ImportLists'), href: '/settings/importlists' },
        { title: translate('Connect'), href: '/settings/connect' },
        { title: translate('Metadata'), href: '/settings/metadata' },
        { title: translate('Tags'), href: '/settings/tags' },
        { title: translate('General'), href: '/settings/general' },
        { title: translate('Ui'), href: '/settings/ui' },
      ],
    },
    {
      title: translate('System'),
      links: [
        { title: translate('Status'), href: '/system/status' },
        { title: translate('Tasks'), href: '/system/tasks' },
        { title: translate('Backup'), href: '/system/backup' },
        { title: translate('Updates'), href: '/system/updates' },
        { title: translate('Events'), href: '/system/events' },
        { title: translate('LogFiles'), href: '/system/logs/files' },
      ],
    },
  ];
}

function ActivePageMarker({ activeIndex }: { activeIndex: number }) {
  const itemHeight = remToPx(2);
  const offset = remToPx(0.25);
  const top = offset + activeIndex * itemHeight;

  return (
    <motion.div
      layout
      className="absolute left-2 h-6 w-px bg-primary-500"
      initial={{ opacity: 0 }}
      animate={{ opacity: 1, transition: { delay: 0.2 } }}
      exit={{ opacity: 0 }}
      style={{ top }}
    />
  );
}

function VisibleSectionHighlight({ activeIndex }: { activeIndex: number }) {
  const itemHeight = remToPx(2);
  const top = activeIndex * itemHeight;

  return (
    <motion.div
      layout
      initial={{ opacity: 0 }}
      animate={{ opacity: 1, transition: { delay: 0.2 } }}
      exit={{ opacity: 0 }}
      className="absolute inset-x-0 top-0 bg-zinc-800/2.5 will-change-transform dark:bg-white/2.5"
      style={{ borderRadius: 8, height: itemHeight, top }}
    />
  );
}

interface NavLinkProps {
  href: string;
  children: React.ReactNode;
  onClick?: (e: React.MouseEvent) => void;
}

function NavLinkComponent({ href, children, onClick }: NavLinkProps) {
  const location = useLocation();
  const activeLink = location.pathname === href;

  return (
    <Link
      to={href}
      onClick={onClick}
      aria-current={activeLink ? 'page' : undefined}
      className={clsx(
        'flex justify-between gap-2 py-1 pl-4 pr-3 text-sm transition',
        activeLink
          ? 'text-zinc-900 dark:text-white'
          : 'text-zinc-600 hover:text-zinc-900 dark:text-zinc-400 dark:hover:text-white'
      )}
    >
      <span className="truncate">{children}</span>
    </Link>
  );
}

function NavigationGroup({
  group,
}: {
  group: NavGroup;
}) {
  const location = useLocation();
  const isActiveGroup = group.links.some((link) => link.href === location.pathname);
  const activeIndex = group.links.findIndex((link) => link.href === location.pathname);

  return (
    <li className="relative mt-6">
      <motion.h2
        layout="position"
        className="text-xs font-semibold text-zinc-900 dark:text-white"
      >
        {group.title}
      </motion.h2>
      <div className="relative mt-3 pl-2">
        <AnimatePresence initial={false}>
          {isActiveGroup && <VisibleSectionHighlight activeIndex={activeIndex} />}
        </AnimatePresence>
        <motion.div
          layout
          className="absolute inset-y-0 left-2 w-px bg-zinc-900/10 dark:bg-white/5"
        />
        <AnimatePresence initial={false}>
          {isActiveGroup && <ActivePageMarker activeIndex={activeIndex} />}
        </AnimatePresence>
        <ul role="list" className="border-l border-transparent">
          {group.links.map((link) => (
            <motion.li key={link.href} layout="position" className="relative">
              <NavLinkComponent
                href={link.href}
                onClick={() => {}}
              >
                {link.title}
              </NavLinkComponent>
            </motion.li>
          ))}
        </ul>
      </div>
    </li>
  );
}

export function Navigation({ className }: { className?: string }) {
  const navigation = getNavigation();

  return (
    <nav className={className}>
      <ul role="list">
        {navigation.map((group) => (
          <NavigationGroup
            key={group.title}
            group={group}
          />
        ))}
        <li className="sticky bottom-0 z-10 mt-6 min-[416px]:hidden">
          <Button href="#signin" variant="filled" className="w-full">
            {translate('SignIn')}
          </Button>
        </li>
      </ul>
    </nav>
  );
}
