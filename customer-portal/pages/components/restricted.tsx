import React, { useState, useEffect, PropsWithChildren } from "react";
import { useSession, signOut, getSession, GetSessionParams } from "next-auth/react";
import classNames from "classnames";
import Sidebar from "./sidebar";
import { Bars3Icon } from "@heroicons/react/24/outline";
import Layout from "./layout";

interface ApiDataItem {
  name: string;
}

const Restricted = () => {
  const { data: session, status } = useSession({ required: true });
  const [apiData, setApiData] = useState<string | null>(null);

  useEffect(() => {
    if (status === "authenticated") {
      fetch("insert your API URL here")
        .then(response => {
          if (!response.ok) {
            throw new Error('HTTP error, status = ' + response.status);
          }
          return response.json();
        })
        .then((json: ApiDataItem[]) => {
          const name = json.map(item => item.name).join(', ');
          setApiData(name);
        })
        .catch(error => console.error('Error during fetch:', error));
    }
  }, [status]);

  return status === "authenticated" ? (
    <Layout username={session?.user?.name}>
      {/* <p>Hi, {session?.user?.name}</p> */}
      <p>List of all Commit Messages will go here: {apiData}</p>
      {/* <button onClick={() => signOut()}>Sign out</button> */}
    </Layout>
  ) : (
    <div>loading...</div>
  );
};

export default Restricted;

export async function getServerSideProps(context: GetSessionParams | undefined) {
  const session = await getSession(context);
  if (!session) {
    return {
      redirect: {
        destination: "/components/login",
        permanent: false,
      },
    };
  }
  return {
    props: { session },
  };
}
