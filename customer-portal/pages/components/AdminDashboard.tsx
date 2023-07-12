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
    const [currentProject, setCurrentProject] = useState<Array<Project>>([]);
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
                    setCurrentProject(projectData);
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
            <AddUserModule
                currentEntity={currentEntity}
                onSelectedEntity={handleSelectedEntity}
            />
            <p>Current Clients:</p>
            <div>
                {currentProject.map((projectData, index) => (
                    <div key={index}>
                        <p>Project Name: {projectData.projectName}</p>
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
