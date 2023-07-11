import React, { useState, useEffect } from "react";
import { useSession, getSession } from "next-auth/react";
import { useRouter } from "next/router";
import AdminLayout from "./adminLayout";
import { Session } from "next-auth";
import { GetServerSidePropsContext } from "next";
import axios from "axios";
import AddEntityModule from "./AddEntityModule";
import AddProjectModal from "./AddProjectsModal";

type User = {
  email: string;
  isAdmin: boolean;
  entityId: number;
};

interface Entity {
  companyName: string;
  entityId: string;
}


type Props = {
  currentEntity(entity: Entity): void;
};


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

const AdminDashboard = () => {
  const { data: session, status } = useSession({ required: true });
  const [isAdmin, setIsAdmin] = useState<boolean>(false);
  const [users, setUsers] = useState<User[]>([]);
  const [currentEntity, setCurrentEntity] = useState<Entity | null>(null);
  const [intialEntity, setIntialEntity] = useState<Entity | null>(null);
  const currentUser = session?.user?.email;

  console.log("intial data", intialEntity);
  console.log("current entity in dashboard", currentEntity);
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
      router.push("/components/Dashboard"); // Your regular dashboard route here
    }
  }, [isAdmin, router]);

  useEffect(() => {
    fetch(`https://localhost:7243/api/Users`)
      .then((response) => {
        if (!response.ok) {
          throw new Error(`${response.status}: ${response.statusText}`);
        }
        return response.json();
      })
      .then((data) => setUsers(data))
      .catch((error) => console.error("Error:", error));
  }, []);

  useEffect(() => {
    if (status === "authenticated") {
      register(session);
      console.log("session:", session);
    }
  }, [status, session]);

  useEffect(() => {
    const fetchAllEntities = async () => {
      try {
        const response = await fetch(`https://localhost:7243/api/Entities`);

        const data = await response.json();

        if (data.length > 0) {
          setIntialEntity(data);
        }

        console.log("default entity " , data);
      } catch (error) {
        console.error("Failed to transmit user data:", error);
      }
    };
  
    fetchAllEntities();
    
  }, []);


  return status === "authenticated" ? (
    
    <AdminLayout username={session?.user?.name} currentEntity={currentEntity}>
      <AddEntityModule />
      <AddProjectModal />
      <p>Current Clients:</p>
      <div>
        {users.map((user, index) => (
          <div key={index}>
            <p>Email: {user.email}</p>
            <p>Is Admin: {user.isAdmin ? "Yes" : "No"}</p>
            <p>Entity ID: {user.entityId}</p>
          
          </div>
        ))}
      </div>
    </AdminLayout>
  ) : (
    <div>loading...</div>
  );
};

export default AdminDashboard;

export async function getServerSideProps(context: GetServerSidePropsContext) {
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
