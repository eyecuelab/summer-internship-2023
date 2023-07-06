import React, { useState, useEffect, PropsWithChildren } from "react";
import {
    useSession,
    signOut,
    getSession,
    GetSessionParams,
} from "next-auth/react";
import classNames from "classnames";
import Sidebar from "./Sidebar";
import { Bars3Icon } from "@heroicons/react/24/outline";
import Layout from "./Layout";
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
        await axios.post("https://localhost:7243/api/Users/register", session?.user);
        console.log("session user:", session?.user);
    } catch (error) {
        console.error("Failed to transmit user data:", error);
    }
}

const Dashboard = () => {
    const { data: session, status } = useSession({ required: true });
    const [apiData, setApiData] = useState<Commit[] | null>(null);

    useEffect(() => {
        if (status === "authenticated") {

            register(session);
            console.log("session:", session);
            fetch("https://localhost:7243/api/commits")
                .then((response) => {
                    if (!response.ok) {
                        throw new Error(
                            "HTTP error, status = " + response.status
                        );
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
    }, [status]);

    return status === "authenticated" ? (
        <Layout username={session?.user?.name}>
            <p>Commit Messages:</p>
            {apiData &&
                apiData.map((commit, index) => (
                    <div key={index}>
                        <p>Name: {commit.name}</p>
                        <p>Message: {commit.message}</p>
                        <p>Date: {commit.date}</p>
                    </div>
                ))}
        </Layout>
    ) : (
        <div>loading...</div>
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
