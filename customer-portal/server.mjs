import express from 'express';
import fetch from 'node-fetch';
import https from 'https';

const app = express();

const agent = new https.Agent({
  rejectUnauthorized: false
});

app.get('/', (req, res) => {
  res.send('Welcome to the customer portal!');
});

app.get('/api/commits', async (req, res) => {
  try {
    const response = await fetch('https://localhost:7243/api/GitHub/commits/eyecuelab/summer-internship-2023', { agent });
    const data = await response.json();
    res.json(data);
  } catch (error) {
    console.error('Error:', error);
    res.status(500).json({ message: error.message });
  }
});

app.listen(4000, () => {
  console.log('Server running on port 4000');
});
