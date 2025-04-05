import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [react()],
    server: {
        port: 51164,
        proxy: {
            '/api': {
                target: 'https://localhost:7068', 
                changeOrigin: true,
                secure: false, 
            }
        }
    }
});
