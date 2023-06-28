import React, { useState, useEffect, PropsWithChildren } from "react";
import { useSession, signOut, getSession, GetSessionParams } from "next-auth/react";
import classNames from "classnames";
import Sidebar from "./sidebar";
import { Bars3Icon } from "@heroicons/react/24/outline";

interface LayoutProps {
  children: React.ReactNode;
}

interface ApiDataItem {
  name: string;
}

export const Layout = ({ children }: LayoutProps) => {
  const [collapsed, setSidebarCollapsed] = useState(false);

  return (
    <div
      className={classNames({
        "grid min-h-screen": true,
        "grid-cols-sidebar": !collapsed,
        "grid-cols-sidebar-collapsed": collapsed,
        "transition-[grid-template-columns] duration-300 ease-in-out": true,
      })}
    >
      <Sidebar collapsed={collapsed} setCollapsed={setSidebarCollapsed} />
      <div className="">{children}</div>
    </div>
  );
};

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
    <Layout>
      <p>Hi, {session?.user?.name}</p>
      <p>Name from API: {apiData}</p>
      <button onClick={() => signOut()}>Sign out</button>
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
