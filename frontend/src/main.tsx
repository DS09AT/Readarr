import { StrictMode } from 'react';
import ReactDOM from 'react-dom/client';

import { Providers } from '@/shared/lib/Providers';
import { initI18n } from '@/shared/lib/i18n';

import { App } from './App';

import './styles/tailwind.css';

const root = document.getElementById('root');

if (!root) {
  throw new Error('Root element not found');
}

const initialize = async () => {
  if (window.Readarr.urlBase === '__URL_BASE__') {
    window.Readarr.urlBase = '';
  }

  const initializeUrl = `${window.Readarr.urlBase}/initialize.json?t=${Date.now()}`;
  
  try {
    const response = await fetch(initializeUrl);
    if (response.ok) {
      const data = await response.json();
      window.Readarr = {
        ...window.Readarr,
        ...data
      };
    }
  } catch (e) {
    // console.warn('Failed to load initialize.json', e);
  }

  // Initialize translations
  await initI18n();

  ReactDOM.createRoot(root).render(
    <StrictMode>
      <Providers>
        <App />
      </Providers>
    </StrictMode>,
  );
};

initialize();
