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
// import { registerUser, verifyUser, getCommits } from '../../pages/api/apiService';

interface Commit {
    name: string;
    email: string;
    message: string;
    date: string;
    releaseNotes: string;
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
    const [apiData, setApiData] = useState<Commit[]>([]);
    const [selectedDate, setSelectedDate] = useState<string>("");
    const currentUser: any = session?.user?.email;
    const [isAdmin, setIsAdmin] = useState<string>("false");
    const { selectedUser, setSelectedUser } = useContext(SelectedUserContext);
    const [selectedAuthor, setSelectedAuthor] = useState<string>("");
    const [releaseNotes, setReleaseNotes] = useState<string>("");

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
        if (isAdmin) {
            localStorage.setItem("isAdmin", isAdmin);
        }
    }, [isAdmin]);

    useEffect(() => {
        if (isAdmin === "false") {
            fetch(
                "https://localhost:7243/api/GitHub/commits/eyecuelab/summer-internship-2023"
            )
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
                        releaseNotes: "",
                    }));

                    setApiData(commits);
                })
                .catch((error) => console.error("Error during fetch:", error));
        }
    }, [isAdmin]);

    useEffect(() => {
        if (apiData.length > 0) {
            setSelectedUser({
                name: apiData[0].name,
                email: apiData[0].email,
            });
        }
    }, [apiData]);

    // Adding a function to get author by date
    const getAuthorByDate = (date: string): any => {
        const commit = apiData.find(
            (commit) => formatDate(commit.date) === date
        );
        return commit
            ? {
                  name: commit.name,
                  email: commit.email,
              }
            : { name: "", email: "" };
    };

    useEffect(() => {
        const fetchReleaseNotes = async () => {
            try {
                const response = await axios.post(
                    `http://localhost:7243/api/OpenAI/SummarizeCommitsByDates/${selectedDate}/${selectedDate}`
                );
                setReleaseNotes(response.data);
            } catch (error) {
                console.error("Failed to fetch release notes:", error);
            }
        };

        if (selectedDate) {
            fetchReleaseNotes();
        }
    }, [selectedDate]);

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
        new Set(apiData.map((commit) => formatDate(commit.date)))
    );

    const filteredData = selectedDate
        ? apiData.filter((commit) => selectedDate === formatDate(commit.date))
        : apiData;

    const renderCommits = (commits: Commit[]) => {
        return commits.map((commit, index) => (
            <div key={index}>
                <p style={nameStyle}>{commit.name}</p>
                <p style={messageStyle}>{commit.message}</p>
                <p style={messageStyle}>
                    Release Notes: {commit.releaseNotes}
                </p>{" "}
                {/* Display summarized commit message */}
                <br />
            </div>
        ));
    };

    return isAdmin === "true" ? (
        <AdminDashboard></AdminDashboard>
    ) : (
        <Layout username={session?.user?.name}>
            <p style={userStyle}>{selectedUser.name || "Default User Name"}</p>
            <p style={titleStyle}>Project Contributor</p>
            <Image alt="user picture" src={Graphs} width={890} height={147} />
            <br />
            <br />

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
                    border: "none",
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
                    <ReleaseNotes
                        startDate={selectedDate}
                        endDate={selectedDate}
                    />
                </div>
            )}

            {!selectedDate &&
                uniqueDates.map((date, index) => (
                    <div key={index}>
                        <p style={dateStyle}>{date}</p>
                        {renderCommits(
                            apiData.filter(
                                (commit) => formatDate(commit.date) === date
                            )
                        )}
                    </div>
                ))}
        </Layout>
    );
};

export default Dashboard;
