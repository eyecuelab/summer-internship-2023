import React, { useState, useEffect, PropsWithChildren } from "react";
import { useSession, signOut, getSession, GetSessionParams } from "next-auth/react";
import classNames from "classnames";
import Sidebar from "./sidebar";
import { Bars3Icon } from "@heroicons/react/24/outline";
import Layout from "./layout";

interface ApiDataItem {
  name: string;
  message: string;
  date: string;
}

const Restricted = () => {
  const { data: session, status } = useSession({ required: true });
  const [apiData, setApiData] = useState<Array<ApiDataItem> | null>(null);

  useEffect(() => {
    if (status === "authenticated") {
      fetch("/api/GitHub/commits/eyecuelab/summer-internship-2023") // Modify the URL to the new endpoint
        .then(response => {
          if (!response.ok) {
            throw new Error('HTTP error, status = ' + response.status);
          }
          return response.json();
        })
        .then((json: any[]) => { // Modify the type of 'json' to 'any[]'
          const commitsData = json.map(item => {
            return {
              message: item.commit.message,
              name: item.commit.author.name,
              date: item.commit.author.date
            };
          });
  
          setApiData(commitsData);
        })
        .catch(error => console.error('Error during fetch:', error));
    }
  }, [status]);

  return status === "authenticated" ? (
    <Layout username={session?.user?.name}>
      {apiData?.map((data, index) => (
        <div key={index}>
          <h2>Commit {index + 1}</h2>
          <p>Message: {data.message}</p>
          <p>Name: {data.name}</p>
          <p>Date: {data.date}</p>
        </div>
      ))}
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
        destination: "/",
        permanent: false,
      },
    };
  }
  return {
    props: { session },
  };
}
