import TrelloCard  from "../utility/TrelloCard"

export default async function Home() {
  const res = await fetch("https://api.trello.com/1/cards/64823e0ae015b3e2013c7fe8/attachments?key=fe91479f8115fc056c49911580effd95&token=ATTA6cff2e9c9ca4b4b103bb93ed6180651b0cb9a138113d3e73da4fc9f2bf646d7c9B79F36B",   { cache : 'no-store'}
  );
  const data = await res.json();
  console.log(data)
  return (
    <main className="flex min-h-screen flex-col items-center justify-between p-24">
      <h1>Hello world</h1>
      <h2>{data[0].name}</h2>
    </main>
  )
}