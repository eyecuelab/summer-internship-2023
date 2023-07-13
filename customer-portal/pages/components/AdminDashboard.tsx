import React, { useState, useEffect } from "react";
import { useSession, getSession } from "next-auth/react";
import { useRouter } from "next/router";
import AdminLayout from "./adminLayout";
import { Session } from "next-auth";
import { GetServerSidePropsContext } from "next";
import axios from "axios";
import AddEntityModule from "./AddEntityModule";
import AddProjectModal from "./AddProjectsModal";
import AddUserModule from "./AddUserModule";
import ResuableButton from "./ReusableButton";

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
    const [usersForProject, setUsersForProject] = useState<
        Array<ProjectAppUser>
    >([]);
    const currentUser = session?.user?.email;

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
                    throw new Error(
                        `${response.status}: ${response.statusText}`
                    );
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
                const response = await fetch(
                    `https://localhost:7243/api/Entities`
                );

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
                    console.log(
                        "default projects for intial entity",
                        projectData
                    );
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

    useEffect(() => {
        const fetchAllUsersForProject = async () => {
            try {
                const response = await fetch(
                    `https://localhost:7243/api/projectappuser/getusers/${currentProject?.projectId}`
                );

                const projectAppUserData = await response.json();

                if (projectAppUserData.length > 0) {
                    setUsersForProject(projectAppUserData);
                    console.log("default projectAppUsers", projectAppUserData);
                } else {
                    return console.log("no projectAppUsers for this Project");
                }
            } catch (error) {
                console.error("Failed to transmit user data:", error);
            }
        };

        fetchAllUsersForProject();
    }, [intialProject]);

    return status === "authenticated" ? (
        <AdminLayout
            username={session?.user?.name}
            currentEntity={currentEntity}
            onSelectedEntity={handleSelectedEntity} // Pass the callback function as a prop
        >
            <AddEntityModule />
            <AddProjectModal
                currentEntity={currentEntity}
                onSelectedEntity={handleSelectedEntity}
            />
            <p>Current Projects:</p>
            <div>
                {intialProject.map((projectData) => (
                    <>
                        <div key={projectData.projectId}>
                            <p>Project Name: {projectData.projectName}</p>
                            <p>Current Users For Project:</p>
                            <div>
                                {usersForProject
                                    .filter(
                                        (user) =>
                                            user.projectId ===
                                            projectData.projectId
                                    )
                                    .map((user) => (
                                        <p key={user.projectAppUserId}>
                                            {user.email}
                                        </p>
                                    ))}
                            </div>
                        </div>
                        <br></br>

                        <br></br>

                        <ResuableButton
                            onPress={() => {
                                setCurrentProject(projectData); // Set the current project
                                setShowAddUserModule(true); // Show the Add User module
                            }}
                            className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded"
                        >
                            Add User to {projectData.projectName}
                        </ResuableButton>
                        <br />
                    </>
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
