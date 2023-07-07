import React, { useState, useEffect, PropsWithChildren } from "react";
import {
  useSession,
  signOut,
  getSession,
  GetSessionParams,
} from "next-auth/react";
import { useRouter } from 'next/router';
import Layout from "./layout";
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

type User = {
  email: string;
  isAdmin: boolean;
  entityId: number;
};

async function register(session: Session | null) {
    try {
        await axios.post("https://localhost:7243/api/Users/register", session?.user);
        console.log("session user:", session?.user);
    } catch (error) {
        console.error("Failed to transmit user data:", error);
    }
}

const AdminDashboard = () => {
  const { data: session, status } = useSession({ required: true });
  const [isAdmin, setIsAdmin] = useState<boolean>(false);
  const [users, setUsers] = useState<User[]>([]);
  const currentUser = session?.user?.email;

  useEffect(() => {
    const fetchCurrentRole = async () => {
      try {
        const response = await fetch(`https://localhost:7243/api/Users/VerifyUser?email=${currentUser}`);
        if (!response.ok) {
          throw new Error("HTTP error, status = " + response.status);
        }
        const roleResponse = await response.text();
        setIsAdmin(roleResponse === "true");
      } catch (error) {
        console.error(error);
      }
    };

    if (currentUser) {
      fetchCurrentRole();
    }
  }, [currentUser]);

  const router = useRouter();
  
  useEffect(() => {
    if (!isAdmin) {
      router.push('/components/Dashboard'); // Your regular dashboard route here
    }
  }, [isAdmin, router]);

  useEffect(() => {
    fetch(`https://localhost:7243/api/Users`)
      .then(response => {
        if (!response.ok) {
          throw new Error(`${response.status}: ${response.statusText}`);
        }
        return response.json();
      })
      .then(data => setUsers(data))
      .catch(error => console.error('Error:', error));
  }, []);

  useEffect(() => {
    if (status === "authenticated") {
      register(session);
      console.log("session:", session);
    }
  }, [status]);

  return status === "authenticated" ? (
    <Layout username={session?.user?.name}>
      <p>Current Clients:</p>
      <div>
      {users.map((user, index) => (
        <div key={index}>
          <p>Email: {user.email}</p>
          <p>Is Admin: {user.isAdmin ? 'Yes' : 'No'}</p>
          <p>Entity ID: {user.entityId}</p>
        </div>
      ))}
    </div>
    </Layout>
  ) : (
    <div>loading...</div>
  );
};

export default AdminDashboard;

export async function getServerSideProps(context) {
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