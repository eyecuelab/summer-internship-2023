export default async function TrelloCard(url: string) {
  try {
    const res = await fetch(url,   
      { cache : 'no-store' }
    );
    const data = await res.json();
    return data
  } catch (error) {
    console.error('Error fetching JSON object:', error);
    throw error;
  }
}