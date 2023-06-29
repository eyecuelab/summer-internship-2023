import { useSession, signIn, signOut } from "next-auth/react";
import { Session } from "next-auth";
import Link from 'next/link'; // Import Session type from 'next-auth'

export default function Login() {
  const { data: session } = useSession();
  if (session) {
    return (
      <>
        Signed in as {session.user?.email} <br />
        Check out the <Link href="/components/restricted">
          examples API route
        </Link>{" "}
        <br />
        <button onClick={() => signOut()}>Sign out</button>
      </>
    );
  }
  return (
    <>
      Not signed in <br />
      <button onClick={() => signIn()}>Sign in</button>
    </>
  );
}
