import { Routes, Route, Navigate } from 'react-router-dom';
import { Layout } from '@/shared/components/layout';
import { Heading } from '@/shared/components/ui';
import { AuthorsPage } from '@/features/authors/AuthorsPage';

function Dashboard() {
  return (
    <>
      <Heading level={1}>Welcome to Readarr</Heading>
      <p className="mt-2 text-lg text-zinc-600 dark:text-zinc-400">
        Your automated book library manager
      </p>
    </>
  );
}

export function App() {
  return (
    <Layout>
      <Routes>
        <Route path="/" element={<Dashboard />} />
        <Route path="/authors" element={<AuthorsPage />} />
        {/* Redirect old routes or handle 404 */}
        <Route path="*" element={<Navigate to="/" replace />} />
      </Routes>
    </Layout>
  );
}