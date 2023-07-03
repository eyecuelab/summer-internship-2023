const express = require('express');
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
