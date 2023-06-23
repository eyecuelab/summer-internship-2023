import React, { useState, useEffect } from "react";
import { useSession, signOut, getSession, GetSessionParams } from "next-auth/react";

const Restricted = () => {
  const { data: session, status } = useSession({required: true});
  const [apiData, setApiData] = useState(null);

  useEffect(() => {
    if (status === "authenticated") {
      console.log('User is authenticated, making API call...');
      fetch("insert your API URL here")
        .then(response => {
          console.log('Received response from API:', response);
          if (!response.ok) {
            throw new Error('HTTP error, status = ' + response.status);
          }
          return response.json(); 
        })
        .then(json => {
          console.log('Parsed JSON from API:', json);
          const name = json.map((item: { name: any; }) => item.name).join(', ');
          console.log('Name from API:', name);
          setApiData(name);
        })
        .catch(error => {
          console.error('Error during fetch:', error);
        });
    }
  }, [status]);

  if (status === "authenticated") {
    return (
      <div>
        <p>Hi, {session?.user?.name}</p>
        <p>Name from API: {apiData}</p>
        <button onClick={() => signOut()}>Sign out</button>
      </div>
    );
  } else {
    return <div>loading...</div>;
  }
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
