import React, { useContext, useState, useEffect } from "react";
import { useSession } from "next-auth/react";
import Layout from "./layout";
import AdminDashboard from "./AdminDashboard";
import axios from "axios";
import Image from "next/image";
import Graphs from "../../public/img/Mask group.png";
import ProfileSidebar from "./ProfileSidebar";
import SelectedUserContext from "../context/selectedUserContext";
import ReleaseNotes from "./ReleaseNotes";
import SprintReleaseNotes from "./SprintReleaseNotes";
import classNames from "classnames";
import { signOut } from "next-auth/react";
import Link from "next/link";
// import { registerUser, verifyUser, getCommits } from '../../pages/api/apiService';

interface Commit {
    message: string;
    date: string;
    author: {
        name: string;
        email: string;
        date: string;
    };
}


async function register(session: any) {
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
    const [apiCommitData, setApiCommitData] = useState<Commit[]>([]);
    const [selectedDate, setSelectedDate] = useState<string>("");
    const currentUser: any = session?.user?.email;
    const [isAdmin, setIsAdmin] = useState<string>("false");
    const { selectedUser, setSelectedUser } = useContext(SelectedUserContext);
    const [selectedAuthor, setSelectedAuthor] = useState<string>("");
    const [latestCommits, setLatestCommits] = useState<Commit[]>([]);
    const [currentRegistration, setCurrentRegistration] = useState<string>("true")

    const updateLatestCommits = (commits: React.SetStateAction<Commit[]>) => {
        setLatestCommits(commits);
      };

    useEffect(() => {
        if (status === "authenticated") {
            const fetchCurrentRole = async () => {
                try {
                    const response = await fetch(
                        `https://localhost:7243/api/Users/VerifyUser?email=${currentUser}`
                    );
                    if (!response.ok) {
                        throw new Error(
                            "HTTP error, status = " + response.status
                        );
                    }
                    const roleResponse = await response.text();

                    if (roleResponse === "Not Registered") {
                        register(session);
                        setCurrentRegistration("false")
                    } else {
                        setIsAdmin(roleResponse);
                        setCurrentRegistration("true")
                    }
                } catch (error) {
                    console.error(error);
                }
            };
            if (currentUser) {
                fetchCurrentRole();
            }
        }
    }, [currentUser, status, session]);

    useEffect(() => {
        if (isAdmin) {
            localStorage.setItem("isAdmin", isAdmin);
        }
    }, [isAdmin]);

    useEffect(() => {
        if (isAdmin === "false") {
            fetch("https://localhost:7243/api/GitHub/dbcommits")
                .then((response) => {
                    if (!response.ok) {
                        throw new Error(
                            "HTTP error, status = " + response.status
                        );
                    }
                    return response.json();
                })
                .then((json: Commit[]) => {
                    const commits = json.map((commit) => ({
                        message: commit.message,
                        date: commit.date,
                        releaseNotes: "",
                        author: {
                            name: commit.author.name,
                            email: commit.author.email,
                            date: commit.author.date,
                        },
                    }));

                    setApiCommitData(commits);
                })
                .catch((error) => console.error("Error during fetch:", error));
        }
    }, [isAdmin, latestCommits]);

    useEffect(() => {
        if (apiCommitData.length > 0) {
            setSelectedUser({
                name: apiCommitData[0].author.name,
                email: apiCommitData[0].author.email,
            });
        }
    }, [apiCommitData]);

    // Adding a function to get author by date
    const getAuthorByDate = (date: string): any => {
        const commit = apiCommitData.find(
            (commit) => formatDate(commit.date) === date
        );
        return commit
            ? {
                  name: commit.author.name,
              }
            : { name: "", email: "" };
    };

    //Bandaid fix for a typescript overload function thing? Talk to Erin About it
    const formatDate = (dateString: string): string => {
        const options: Intl.DateTimeFormatOptions = {
            month: "long",
            day: "numeric",
            year: "numeric",
        };
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

    const userStyle = {
        ...dateStyle,
        fontWeight: 400,
        fontSize: "48px",
        lineHeight: "67.2px",
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

    const handleDateChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        setSelectedDate(event.target.value);
        setSelectedUser(getAuthorByDate(event.target.value)); // set the selected author's name
    };

    const uniqueDates = Array.from(
        new Set(apiCommitData.map((commit) => formatDate(commit.date)))
    );

    const filteredData = selectedDate
        ? apiCommitData.filter(
              (commit) => selectedDate === formatDate(commit.date)
          )
        : apiCommitData;

    const renderCommits = (commits: Commit[]) => {
        return commits.map((commit, index) => (
            <div key={index}>
                <p style={nameStyle}>{commit.author.name}</p>
                <p style={messageStyle}>{commit.message}</p>{" "}
                {/* Display summarized commit message */}
                <br />
            </div>
        ));
    };

    return isAdmin === "true" ? (
        <AdminDashboard></AdminDashboard>
    ) : currentRegistration === "true" ? (
        <Layout username={session?.user?.name}>
            <p style={userStyle}>{selectedUser.name || "Default User Name"}</p>
            <p style={titleStyle}>Project Contributor</p>
            <Image alt="user picture" src={Graphs} width={890} height={147} />
            <br />
            <br />
            <div className="mt-5">
                <SprintReleaseNotes></SprintReleaseNotes>
            </div>
            <select
                value={selectedDate}
                onChange={handleDateChange}
                style={{
                marginLeft: "auto",
                fontFamily: "Open Sans",
                float: "right",
                fontWeight: 600,
                fontSize: "16px",
                lineHeight: "25.6px",
                color: "#404040",
                backgroundColor: "#F7F7F8",
                padding: "5px 10px",
                border: "1px solid black", // Add black border here
                outline: "none",
                boxShadow: "none",
                width: "254px",
                height: "35px",
                }}
            >
                <option value="">All Dates</option>
                {uniqueDates.map((date, index) => (
                <option key={index} value={date}>
                    {date}
                </option>
                ))}
            </select>
            {selectedDate && (
                <div>
                    <p style={dateStyle}>{formatDate(selectedDate)}</p>
                    {renderCommits(filteredData)}
                </div>
            )}
            {!selectedDate &&
                uniqueDates.map((date, index) => (
                    <div key={index}>
                        <p style={dateStyle}>{date}</p>
                        {renderCommits(
                            apiCommitData.filter(
                                (commit) => formatDate(commit.date) === date
                            )
                        )}
                    </div>
                ))}
        </Layout>
    ) : (
        <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}>
    <div style={{ textAlign: 'center' }}>
      <h1 className="text-3xl font-semibold">You are not registered</h1>
      <p>Please contact your <button onClick={() => signOut()}><span className="text-red-700">administrator</span></button> for access.</p>
    </div>
</div>
       
    );
};

export default Dashboard;
function fetchCurrentRole() {
    throw new Error("Function not implemented.");
}