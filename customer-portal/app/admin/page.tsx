import Login from "@/components/Login"
import ShowTrello from "@/components/ShowTrello"
import { authConfig } from "@/lib/auth";
import { getServerSession } from "next-auth";

export default async function Admin() {
  const session = await getServerSession(authConfig);
  if(session) {
      return (
        <div>
          <h1>This should just work</h1>
          <ShowTrello/>
        </div>
      )
    } else {
      return (
        <div>
          <Login/>
        </div>
      )
    }
}