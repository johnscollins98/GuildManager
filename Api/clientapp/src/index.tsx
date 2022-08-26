import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './components/App';

import 'bootstrap/dist/css/bootstrap.min.css';
import { QueryClient, QueryClientProvider } from 'react-query';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

const queryClient = new QueryClient({
  defaultOptions: {
    queries: {
      retry: false,
      staleTime: 10000
    }
  }
});

root.render(
  <React.StrictMode>
    <QueryClientProvider client={queryClient}>
      <App />
    </QueryClientProvider>
  </React.StrictMode>
);
