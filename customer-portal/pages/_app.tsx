import type { AppProps } from 'next/app'
import { SessionProvider } from 'next-auth/react'
import { NextUIProvider } from '@nextui-org/react'

function MyApp({ Component, pageProps, session}: AppProps & { session: any }) {
  return (
      <NextUIProvider>
      <SessionProvider session={session}>
      <Component { ...pageProps} />
      </SessionProvider>
      </NextUIProvider>
    )
}

export default MyApp
