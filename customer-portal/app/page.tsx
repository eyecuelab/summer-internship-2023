import TrelloCard  from "../utility/TrelloCard"
import ParseBoard from "@/utility/ParseBoard";
import Login from './Login'

export default async function Home() {

  // const res = await fetch("",   { cache : 'no-store'}
  // );
  // const data = await res.json();
  // console.log(data)
  return (
    <main className="flex min-h-screen flex-col items-center justify-between p-24">
      <h1>Hello world</h1>
      <Login />
    </main>
  )
}