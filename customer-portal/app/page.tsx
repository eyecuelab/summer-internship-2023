import TrelloCard  from "../utility/TrelloCard"
import ParseBoard from "@/utility/ParseBoard";

export default async function Home() {
  const trelloApiKey = process.env.TRELLO_API_KEY
  const trelloToken = process.env.TRELLO_TOKEN
  const res = await fetch(`https://api.trello.com/1/boards/Chv88IiH/cards?key=${trelloApiKey}&token=${trelloToken}&attachments=true`,{ cache : 'no-store'});
  const data = await res.json();
  const sortTrelloCommits = ParseBoard(data);
  console.log(sortTrelloCommits)
  return (
    <main className="flex min-h-screen flex-col items-center justify-between p-24">
      {sortTrelloCommits.map((title, index) => (
        <h1 key={index}>{title}</h1>
      ))}
      <h1>Hello world</h1>
    </main>
  )
}