import Image from 'next/image'
import { Inter } from 'next/font/google'
import ButtonAppBar from './components/appbar'

const inter = Inter({ subsets: ['latin'] })

export default function Home() {
  return (

      <main
        className={`flex min-h-screen flex-col items-center justify-between p-24 ${inter.className}`}
      >
        <ButtonAppBar/>
        <h1 className="text-6xl font-bold">You are not Signed In</h1>
        <a href="/api/auth/signin"> Sign In</a>
      </main>
  )
}