import React, { useState, useEffect } from "react";
import { useRouter } from "next/router";
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

const AdminProfile = () => {
  const router = useRouter();
  const { id } = router.query;
  const { data: session, status } = useSession({ required: true });
  const [user, setUser] = useState(null);
  const [apiData, setApiData] = useState<Commit[] | null>(null);
  let currentUser: any = session?.user?.email;
  const [role, setRole] = useState<string>("");
  const [isAdmin, setIsAdmin] = useState<string>("false");
  const [username, setUsername] = useState<string | null>(null);
  const [activeTab, setActiveTab] = useState("details");

  useEffect(() => {
    // Ensure id exists and is not an array
    if (id && typeof id === "string") {
      // Fetch the data for this user
      fetch(`https://localhost:7243/api/Users/${id}`)
        .then((response) => response.json())
        .then((data) => {
          setUser(data);
          setUsername(data.userName);
        })
        .catch((err) => console.error(err));
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
    const options = { month: "long", day: "numeric", year: "numeric" };
    const date = new Date(dateString);
    return date.toLocaleDateString("en-US", options);
  };

  const dateStyle = {
    fontFamily: "Rasa",
    fontWeight: 600,
    fontSize: "24px",
    lineHeight: "40.8px",
    color: "#404040",
  };

  const messageStyle = {
    fontFamily: "Open Sans",
    fontWeight: 400,
    fontSize: "16px",
    lineHeight: "27.2px",
    color: "#888888",
  };

  const nameStyle = {
    ...messageStyle,
    fontStyle: "italic",
    color: "#CECECE",
  };

  const titleStyle = {
    ...messageStyle,
    fontSize: "16px",
    lineHeight: "25.6px",
    color: "#404040",
  };

  const renderActiveTab = () => {
    switch (activeTab) {
      case "details":
        return (
          <>
            <br />
            <p className="profile-header-font">Personal Bio</p>
            <p style={messageStyle}>
              Aliqua laboris culpa dolor irure ipsum enim dolore deserunt quis.
              Adipisicing veniam ea commodo qui culpa enim. Pariatur veniam non
              ullamco occaecat deserunt aliqua officia. Quis id non eiusmod
              laborum enim cupidatat fugiat sint cillum fugiat exercitation
              irure.Mollit tempor veniam nisi nulla quis reprehenderit deserunt
              dolor commodo sint non. Duis sit veniam occaecat duis excepteur
              pariatur magna occaecat culpa ipsum. Officia eu ipsum ipsum ex
              cupidatat aliquip irure consequat ipsum.
            </p>
            <br />
            <p className="profile-header-font">Strengths & Responsibilities</p>
            <br />
            <p style={messageStyle}>Frontend Development</p>
            <p style={messageStyle}>Backend Development</p>
            <p style={messageStyle}>Fullstack Development</p>
            <br />
          </>
        );
      case "permissions":
        return (
          <>
            <p>Permissions content goes here</p>
          </>
        );
      case "privacy":
        return (
          <>
            <p>Privacy Settings content goes here</p>
          </>
        );
      default:
        return null;
    }
  };

  return isAdmin === "true" ? (
    <AdminDashboard></AdminDashboard>
  ) : (
    <Layout username={session?.user?.name}>
      <p className="profile-header-font">{username}</p>
      <br />
      <div style={messageStyle}>
        <button
          className="profile-button-details"
          onClick={() => setActiveTab("details")}
        >
          Details |{" "}
        </button>
        <button
          className="profile-button-details"
          onClick={() => setActiveTab("permissions")}
        >
          Permissions |{" "}
        </button>
        <button
          className="profile-button-details"
          onClick={() => setActiveTab("privacy")}
        >
          Privacy Settings
        </button>
        <br />
      </div>

      {renderActiveTab()}

      <p className="profile-header-font">Project Commit History</p>
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

export default AdminProfile;

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
