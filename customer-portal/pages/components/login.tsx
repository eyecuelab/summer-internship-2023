import { useSession, signIn, signOut } from "next-auth/react"
import { Session } from "next-auth"; // Import Session type from 'next-auth'

export default function Login() {
  const { data: session } = useSession()
  if (session) {
    return (
      <>
        Signed in as {session.user?.email} <br />
        Check out the <a href="/components/restricted">examples API route</a> <br />
        <button onClick={() => signOut()}>Sign out</button>
      </>
    )
  }
  return (
    <>
      Not signed in <br />
      <button onClick={() => signIn()}>Sign in</button>
    </>
  )
}
