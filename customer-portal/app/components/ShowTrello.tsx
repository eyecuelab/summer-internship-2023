import ParseBoard from "@/utility/ParseBoard";


export default async function ShowTrello() {
  const trelloApiKey = process.env.TRELLO_API_KEY
  const trelloToken = process.env.TRELLO_TOKEN
  const trelloBoardId = process.env.TRELLO_BOARD_ID
  const res = await fetch(`https://api.trello.com/1/boards/${trelloBoardId}/cards?key=${trelloApiKey}&token=${trelloToken}&attachments=true`,{ cache : 'no-store'});
  const data = await res.json();
  const sortTrelloCommits = ParseBoard(data);
  console.log(data)
    return (
      <main className="flex min-h-screen flex-col items-center justify-between p-24">
        {sortTrelloCommits.map((title, index) => (
        <h1 key={index}>{title}</h1>))}
      </main>
    )
}