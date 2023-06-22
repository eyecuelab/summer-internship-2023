import { signIn } from "next-auth/react";

export function GoogleSignInButton() {
  const handleClick = () => {
    signIn("google");
  }

  return (
    <button onClick={handleClick}>
      <span className="">Continue With Google</span>
    </button>
  )
}