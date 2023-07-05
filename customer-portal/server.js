const express = require('express');
const next = require('next');
const https = require('https');

const dev = process.env.NODE_ENV !== 'production';
const nextApp = next({ dev });
const handle = nextApp.getRequestHandler();

const httpsAgent = new https.Agent({
  rejectUnauthorized: false,
});

nextApp.prepare().then(() => {
  const app = express();

  app.get('/api/GitHub/commits/:org/:repo', async (req, res) => {
    const url = `https://localhost:7243/api/GitHub/commits/${req.params.org}/${req.params.repo}`;
    try {
        const { default: fetch } = await import('node-fetch');
      const apiRes = await fetch(url, { agent: httpsAgent });
      const apiResJson = await apiRes.json();
      res.json(apiResJson);
    } catch (error) {
      console.error(error);
      res.status(500).json({ error: 'An error occurred while trying to fetch data from the API' });
    }
  });

  app.all('*', (req, res) => {
    return handle(req, res);
  });

  app.listen(3000, err => {
    if (err) throw err;
    console.log('Server ready on http://localhost:3000');
  });
});
