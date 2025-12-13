import { StrictMode } from 'react';
import ReactDOM from 'react-dom/client';

import { Providers } from '@/shared/lib/Providers';

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
    // Proceed with rendering even if fetch fails
  }

  ReactDOM.createRoot(root).render(
    <StrictMode>
      <Providers>
        <App />
      </Providers>
    </StrictMode>,
  );
};

initialize();
