
import Login from "@/components/Login"
import Link from "next/link"
import ShowTrello from "@/components/ShowTrello"

export default function LoginPage() {
  return (
    <div>
      <ShowTrello/>
      <Login />
      <Link href="http://localhost:3000/">Back to home screen</Link>
    </div>
  )
}