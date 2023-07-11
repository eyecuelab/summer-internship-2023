import React, { useState, useEffect, PropsWithChildren } from "react";
import {
  useSession,
  signOut,
  getSession,
  GetSessionParams,
} from "next-auth/react";
import Layout from "./layout";
import AdminDashboard from "./AdminDashboard";
import { Session } from "next-auth";
import axios from "axios";



interface Commit {
  name: string;
  message: string;
  date: string;
}

interface CommitResponse {
  commit: {
    author: {
      name: string;
      email: string;
      date: string;
    };
    message: string;
  };
}

async function register(session: Session | null) {
  try {
    await axios.post(
      "https://localhost:7243/api/Users/register",
      session?.user
    );
    console.log("session user:", session?.user);
  } catch (error) {
    console.error("Failed to transmit user data:", error);
  }
}

const Dashboard = () => {
  const { data: session, status } = useSession({ required: true });
  const [apiData, setApiData] = useState<Commit[] | null>(null);
  let currentUser: any = session?.user?.email;
  const [role, setRole] = useState<string>("");
  const [isAdmin, setIsAdmin] = useState<string>("false");

	useEffect(() => {
    if (status === "authenticated") {
      register(session);
      console.log("session:", session);
    }
  }, [status, session]);

  useEffect(() => {
    const fetchCurrentRole = async () => {
      try {
        const response = await fetch(
          `https://localhost:7243/api/Users/VerifyUser?email=${currentUser}`
        );
        if (!response.ok) {
          throw new Error("HTTP error, status = " + response.status);
        }
        const roleResponse = await response.text();
        setIsAdmin(roleResponse);
      } catch (error) {
        console.error(error);
      }
    };

    if (currentUser) {
      fetchCurrentRole();
    }
  }, [currentUser]);


  useEffect(() => {
    if (isAdmin === "false") {
      fetch(
        "https://localhost:7243/api/GitHub/commits/eyecuelab/summer-internship-2023"
      )
        .then((response) => {
          if (!response.ok) {
            throw new Error("HTTP error, status = " + response.status);
          }
          return response.json();
        })
        .then((json: CommitResponse[]) => {
          const commits = json.map((commit) => ({
            name: commit.commit.author.name,
            message: commit.commit.message,
            date: commit.commit.author.date,
          }));
          setApiData(commits);
        })
        .catch((error) => console.error("Error during fetch:", error));
    }
  }, [isAdmin]);

  const formatDate = (dateString: string): string => {
    const options: Intl.DateTimeFormatOptions = { month: 'long', day: 'numeric', year: 'numeric' };
    const date = new Date(dateString);
    return date.toLocaleDateString('en-US', options);
  }

  const dateStyle = {
    fontFamily: 'Rasa',
    fontWeight: 600,
    fontSize: '24px',
    lineHeight: '40.8px',
    color: '#404040'
  }

  const messageStyle = {
    fontFamily: 'Open Sans',
    fontWeight: 400,
    fontSize: '16px',
    lineHeight: '27.2px',
    color: '#888888'
  }

  const nameStyle = {
    ...messageStyle,
    fontStyle: 'italic',
    color: '#CECECE',
  }


  return isAdmin === "true" ? (
    <AdminDashboard></AdminDashboard>
  ) : (
    <Layout username={session?.user?.name}>
      
      <p>Project Commit History:</p>
      <br />
      {apiData &&
        apiData.map((commit, index) => (
          <div key={index}>
            <p style={dateStyle}>{formatDate(commit.date)}</p>
            <p style={nameStyle}>{commit.name}</p>
            <p style={messageStyle}>{commit.message}</p>
            <br />
          </div>
        ))}
    </Layout>
  );
};

export default Dashboard;

export async function getServerSideProps(
  context: GetSessionParams | undefined
) {
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