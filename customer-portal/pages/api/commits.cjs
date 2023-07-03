import fetch from 'node-fetch';
import https from 'https';

export default async function handler(req, res) {
  const agent = new https.Agent({
    rejectUnauthorized: false
  });

  try {
    const response = await fetch('https://localhost:7243/api/GitHub/commits/eyecuelab/summer-internship-2023', { agent });
    const data = await response.json();
    res.status(200).json(data);
  } catch (error) {
    console.error('Error:', error);
    res.status(500).json({ message: error.message });
  }
}
