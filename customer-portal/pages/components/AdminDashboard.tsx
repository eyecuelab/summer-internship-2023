import React, { useState, useEffect } from "react";
import { useSession, getSession } from "next-auth/react";
import AdminLayout from "./adminLayout";
import { Session } from "next-auth";
import { GetServerSidePropsContext } from "next";
import axios from "axios";
import AddEntityModule from "./AddEntityModule";
import AddProjectModal from "./AddProjectsModal";
import AddUserModule from "./AddUserModule";
import ResuableButton from "./ReusableButton";
import Link from "next/link";
import { useRouter } from "next/router";


type User = {
  email: string;
  isAdmin: boolean;
  entityId: number;
};

interface Entity {
  companyName: string;
  entityId: string;
}

interface Project {
  projectName: string;
  projectId: string;
  entityId: string;
}

interface ProjectAppUser {
  projectAppUserId: string;
  projectId: string;
  email: string;
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
  const [intialProject, setIntialProject] = useState<Array<Project>>([]);
  const [currentProject, setCurrentProject] = useState<Project | null>(null);
  const [showAddUserModule, setShowAddUserModule] = useState(false);
  const [selectedEmail, setSelectedEmail] = useState<string | null>(null);
  const [usersForProject, setUsersForProject] = useState<Array<ProjectAppUser>>(
    []
  );
  const currentUser = session?.user?.email;

  console.log("Intial Projects on page load ", intialProject);

  const handleClick = (email: any) => {
    // Fetching user role from server and update local storage
    fetch(`https://localhost:7243/api/Users/VerifyUser?email=${email}`)
      .then((response) => response.text())
      .then((roleResponse) => {
        localStorage.setItem(
          "isAdmin",
          roleResponse === "admin" ? "true" : "false"
        );
      })
      .catch((error) => console.error(error));
  };

  const handleSelectedEntity = (selectedEntity: Entity | null) => {
    setCurrentEntity(selectedEntity);
  };

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

  //FETCHING ENTITES FOR INTIAL STATE AND SETTING IT TO [0]
  useEffect(() => {
    const fetchAllEntities = async () => {
      try {
        const response = await fetch(`https://localhost:7243/api/Entities`);

        const data = await response.json();

        if (data.length > 0) {
          const [firstEntity] = data;
          setIntialEntity(firstEntity);
          setCurrentEntity(firstEntity);
          console.log("default entity ", firstEntity);
        }
      } catch (error) {
        console.error("Failed to transmit user data:", error);
      }
    };

    fetchAllEntities();
  }, []);

  // FETCHING ALL PROJECTS ASSOCIATED WITH INTIAL ENTITY
  useEffect(() => {
    const fetchAllProjectsforEntity = async () => {
      try {
        const response = await fetch(
          `https://localhost:7243/api/projects/projectsbyentity/${currentEntity?.entityId}`
        );

        const projectData = await response.json();

        if (projectData.length > 0) {
          setIntialProject(projectData);
          console.log("default projects for intial entity", projectData);
        } else {
          return console.log("no projects for this entity");
        }

        console.log("default projects for intial entity", projectData);
      } catch (error) {
        console.error("Failed to transmit user data:", error);
      }
    };

    fetchAllProjectsforEntity();
  }, [currentEntity]);

  //FETCHING USER INFO FROM PROJECTAPPUSER ENDPOINT TO DISPLAY UNDER EACH PROJECT
  useEffect(() => {
    const fetchUsersForProjects = async () => {
      try {
        const promises = intialProject.map(async (projectData) => {
          const response = await fetch(
            `https://localhost:7243/api/projectappuser/getusers/${projectData.projectId}`
          );
          const projectAppUserData = await response.json();

          return {
            projectId: projectData.projectId,
            projectAppUsers: projectAppUserData,
          };
        });

        const projectUserResponses = await Promise.all(promises);

        const updatedUsersForProjects = projectUserResponses.reduce(
          (
            acc: ProjectAppUser[],
            projectResponse: {
              projectId: string;
              projectAppUsers: any;
            }
          ) => {
            const { projectId, projectAppUsers } = projectResponse;
            if (projectAppUsers.length > 0) {
              return [
                ...acc,
                ...projectAppUsers.map((user: ProjectAppUser) => ({
                  ...user,
                  projectId,
                })),
              ];
            } else {
              return acc;
            }
          },
          []
        );

        setUsersForProject(updatedUsersForProjects);
        console.log("usersForProject data:", updatedUsersForProjects);
      } catch (error) {
        console.error("Failed to transmit user data:", error);
      }
    };

    fetchUsersForProjects();
  }, [intialProject]);

  //FETCHING USER INFO FROM PROJECTAPPUSER ENDPOINT TO DISPLAY UNDER EACH PROJECT
  useEffect(() => {
    const fetchUsersForProjects = async () => {
      try {
        const promises = intialProject.map(async (projectData) => {
          const response = await fetch(
            `https://localhost:7243/api/projectappuser/getusers/${projectData.projectId}`
          );
          const projectAppUserData = await response.json();

          return {
            projectId: projectData.projectId,
            projectAppUsers: projectAppUserData,
          };
        });

        const projectUserResponses = await Promise.all(promises);

        const updatedUsersForProjects = projectUserResponses.reduce(
          (
            acc: ProjectAppUser[],
            projectResponse: { projectId: string; projectAppUsers: any }
          ) => {
            const { projectId, projectAppUsers } = projectResponse;
            if (projectAppUsers.length > 0) {
              return [
                ...acc,
                ...projectAppUsers.map((user: ProjectAppUser) => ({
                  ...user,
                  projectId,
                })),
              ];
            } else {
              return acc;
            }
          },
          []
        );

        setUsersForProject(updatedUsersForProjects);
        console.log("usersForProject data:", updatedUsersForProjects);
      } catch (error) {
        console.error("Failed to transmit user data:", error);
      }
    };

    fetchUsersForProjects();
  }, [intialProject]);

  const dashStyle = {
    fontFamily: "Rasa",
    fontWeight: 600,
    fontSize: "36px",
    lineHeight: "67.2px",
    color: "#404040",
    textDecoration: "underline",
  };

  const headerStyle = {
    ...dashStyle,
    fontWeight: 400,
    fontSize: "48px",
    textDecoration: "none",
  }

  const userListStyle = {
    ...dashStyle,
    fontFamily: "Rasa",
    fontWeight: 400,
    fontSize: "22px",
    lineHeight: "40.8px",
    color: "#0000EE",
    textDecoration: "underline",
  }

  return status === "authenticated" ? (
    <AdminLayout
      username={session?.user?.name}
      currentEntity={currentEntity}
      onSelectedEntity={handleSelectedEntity} // Pass the callback function as a prop
    >
      <br></br>
      <p style={headerStyle}>Admin Portal </p>
      <br></br>
      <p style={dashStyle}>Current Projects</p>


      {/* <AddProjectModal
        currentEntity={currentEntity}
        onSelectedEntity={handleSelectedEntity}
      /> */}
      <br></br>
      <div>
      {intialProject.map((projectData) => (
  <div key={projectData.projectId} className="mb-8">
    <div className="bg-white rounded-lg shadow-md p-6">
      <p style={{ fontFamily: "Rasa", fontSize: "30px" }}>
        <span style={{ fontWeight: "bold" }}>Project Name:</span>{" "}
        {projectData.projectName}
      </p>

      <p style={{ fontFamily: "Rasa", fontSize: "28px", textDecoration: "underline" }}>Users</p>
      {usersForProject
        .filter((user) => user.projectId === projectData.projectId)
        .map((user) => (
          <p style={userListStyle} key={user.projectAppUserId}>
            <Link
              href={`/AdminProfile/${user.projectAppUserId
                }?email=${encodeURIComponent(user.email)}`}
              as={`/AdminProfile/${user.projectAppUserId
                }?email=${encodeURIComponent(user.email)}`}
            >
              {user.email}
            </Link>
          </p>
        ))}
      <br />

      <ResuableButton
        onPress={() => {
          setCurrentProject(projectData); // Set the current project
          setShowAddUserModule(true); // Show the Add User module
        }}
        className="flex gap-4 items-center h-11 overflow-hidden bg-gray-200 hover:bg-gray-400 rounded-full mb-4 pl-3"
      >
        Add User to {projectData.projectName}
      </ResuableButton>
      <br />
    </div>
  </div>
))}

      </div>
      {showAddUserModule && (
        <AddUserModule
          currentEntity={currentEntity}
          onSelectedEntity={handleSelectedEntity}
          currentProject={currentProject}
          setCurrentProject={setCurrentProject}
          showAddUserModule={showAddUserModule}
          setShowAddUserModule={setShowAddUserModule}
        />
      )}
      <AddProjectModal
        currentEntity={currentEntity}
        onSelectedEntity={handleSelectedEntity}
      />
    </AdminLayout>
  ) : (
    <div>loading...</div>
  );
};

export default AdminDashboard;

export async function getServerSideProps(context: GetServerSidePropsContext) {
  const session = await getSession(context);
  console.log("Server Side Props Session:", session);
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
