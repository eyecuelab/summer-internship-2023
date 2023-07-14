import type { AppProps } from 'next/app'
import { SessionProvider } from 'next-auth/react'
import React, { useState } from "react";
import { NextUIProvider } from '@nextui-org/react'
import '../styles/globals.css'
import SelectedUserContext from './context/selectedUserContext';

function MyApp({ Component, pageProps, session}: AppProps & { session: any }) {
  const [selectedUser, setSelectedUser] = useState({ name: '', email: '' });
  return (
      <NextUIProvider>
      <SessionProvider session={session}>
      <SelectedUserContext.Provider value={{ selectedUser, setSelectedUser }}>
      <Component { ...pageProps} />
      </SelectedUserContext.Provider>
      </SessionProvider>
      </NextUIProvider>
    )
}

export default MyApp
