const express = require('express');
<<<<<<< HEAD
const next = require('next');
const fetch = require('node-fetch');
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
=======
const axios = require('axios');
const https = require('https');
const cors = require('cors');

const app = express();

app.use(cors());  // <-- This will enable CORS for all routes

const agent = new https.Agent({
  rejectUnauthorized: false
});

app.get('/api/commits', async (req, res) => {
  try {
    const response = await axios.get('https://localhost:7243/api/GitHub/commits/eyecuelab/summer-internship-2023', { httpsAgent: agent });
    const data = response.data;
    res.json(data);
  } catch (error) {
    console.error('Error:', error);
    res.status(500).json({ message: error.message });
  }
});

app.listen(4000, () => {
  console.log('Server running on port 4000');
});
>>>>>>> origin
