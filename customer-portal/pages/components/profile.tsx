import React, { useState, useEffect } from "react";
import { useRouter } from 'next/router';
import {
  useSession,
  signOut,
  getSession,
  GetSessionParams,
} from "next-auth/react";
import Layout from "./layout";
import AdminDashboard from "./AdminDashboard";

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

const Profile = () => {
  const router = useRouter();
  const { id } = router.query;
  const { data: session, status } = useSession({ required: true });
  const [user, setUser] = useState(null);
  const [apiData, setApiData] = useState<Commit[] | null>(null);
  let currentUser: any = session?.user?.email;
  const [role, setRole] = useState<string>("");
  const [isAdmin, setIsAdmin] = useState<string>("false");

  useEffect(() => {
    // Ensure id exists and is not an array
    if (id && typeof id === 'string') {
      // Fetch the data for this user
      fetch(`https://localhost:7243/api/Users/${id}`)
        .then(response => response.json())
        .then(data => setUser(data)) // NEW - Set user data
        .catch(err => console.error(err));
    }
  }, [id]);

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
    const options = { month: 'long', day: 'numeric', year: 'numeric' };
    const date = new Date(dateString);
    return date.toLocaleDateString('en-US', options);
  };

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

  const titleStyle = {
    ...messageStyle,
    fontSize: '16px',
    lineHeight: '25.6px',
    color: '#404040'
  };


  return isAdmin === "true" ? (
    <AdminDashboard></AdminDashboard>
  ) : (
    <Layout username={session?.user?.name}>
      {/* <ProfileSidebar></ProfileSidebar> */}
      <p className="profile-header-font">Personal Bio</p>
      <p style={messageStyle}>Aliqua laboris culpa dolor irure ipsum enim dolore deserunt quis. Adipisicing veniam ea commodo qui culpa enim. Pariatur veniam non ullamco occaecat deserunt aliqua officia. Quis id non eiusmod laborum enim cupidatat fugiat sint cillum fugiat exercitation irure.Mollit tempor veniam nisi nulla quis reprehenderit deserunt dolor commodo sint non. Duis sit veniam occaecat duis excepteur pariatur magna occaecat culpa ipsum. Officia eu ipsum ipsum ex cupidatat aliquip irure consequat ipsum. Cupidatat labore est irure enim fugiat nulla duis. Voluptate esse commodo non magna magna mollit. Cupidatat voluptate ea dolore do laborum enim amet reprehenderit tempor consectetur duis pariatur. Anim laboris laboris sunt veniam occaecat commodo exercitation laboris enim labore veniam do proident amet. </p>
      <br />
      <p className="profile-header-font">Project Commit History:</p>
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

export default Profile;

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