import { useSession, signIn, signOut } from "next-auth/react";
import { Session } from "next-auth";
import Link from "next/link"; // Import Session type from 'next-auth'

export default function Login() {
    const { data: session } = useSession();
    if (session) {
        return (
            <>
                Signed in as {session.user?.email} <br />
                Hello {session.user?.name} <br />
                {/* Your Profile Icon is: {session.user?.image && <img src={session.user?.image} width={50} />} <br /> */}
                <br />
                <Link href="/components/restricted"></Link>
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
