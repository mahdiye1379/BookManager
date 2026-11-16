const offlinePage = `<!doctype html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Offline | BookManager</title>
    <style>
        body {
            margin: 0;
            padding: 24px;
            background: #f8f8fc;
            color: #191735;
            font-family: system-ui, sans-serif;
        }
        main {
            max-width: 480px;
            margin: 12vh auto 0;
            padding: 28px;
            border: 1px solid #e7e4f0;
            border-radius: 20px;
            background: white;
        }
        h1 { margin-top: 0; }
        a {
            display: inline-block;
            padding: 12px 16px;
            border-radius: 10px;
            background: #4f46e5;
            color: white;
            text-decoration: none;
        }
    </style>
</head>
<body>
    <main>
        <h1>You're offline</h1>
        <p>Reconnect to open BookManager and access your library.</p>
        <a href="/">Try again</a>
    </main>
</body>
</html>`;

self.addEventListener('activate', event => {
    event.waitUntil(self.clients.claim());
});

self.addEventListener('fetch', event => {
    const request = event.request;
    const url = new URL(request.url);

    if (request.method !== 'GET' ||
        request.mode !== 'navigate' ||
        url.origin !== self.location.origin ||
        url.pathname.startsWith('/api/')) {
        return;
    }

    event.respondWith(
        fetch(request).catch(() => new Response(offlinePage, {
            status: 503,
            headers: { 'Content-Type': 'text/html; charset=utf-8' }
        }))
    );
});