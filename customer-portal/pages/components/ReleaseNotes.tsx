import React, { useState, useEffect } from "react";
import axios from "axios";
import ReactMarkdown from "react-markdown";
import { formatDate } from "./TrelloSprint";

type ReleaseNote = {
    endDate: string;
    responseId: string;
    responseText: string;
    startDate: string;
};

interface Commit {
    message: string;
    date: string;
    author: {
        name: any;
        email: string;
        date: string;
    };
}

interface ReleaseNotesProps {
    latestCommits: Commit[];
    setLatestCommits: (commits: Commit[]) => void;
    startDate: string;
    endDate: string;
}

const ReleaseNotes: React.FC<ReleaseNotesProps> = ({
    startDate,
    endDate,
    latestCommits,
    setLatestCommits,
}) => {
    const [sections, setSections] = useState<string[]>([]);

    const handleGetLatestCommits = async () => {
        try {
            const response = await fetch(
                "https://localhost:7243/api/GitHub/commits/eyecuelab/summer-internship-2023"
            );
            if (!response.ok) {
                throw new Error("HTTP error, status = " + response.status);
            }
            const json = await response.json();
            const commits = json.map(
                (commit: {
                    message: any;
                    date: any;
                    author: { name: any; email: any; date: any };
                }) => ({
                    message: commit.message,
                    date: commit.date,
                    releaseNotes: "",
                    author: {
                        name: commit?.author?.name || "",
                        email: commit?.author?.email || "",
                        date: commit?.author?.date || "",
                    },
                })
            );

            setLatestCommits(commits);
        } catch (error) {
            console.error("Error during fetch:", error);
        }
    };

    useEffect(() => {
        const handleReleaseNotesFetch = async () => {
            try {
                setSections([]); // Clear previous sections array
        
                const response = await axios.get<ReleaseNote[]>(
                    "https://localhost:7243/api/OpenAI/responses",
                    {
                        params: {
                            startDate: new Date(startDate)
                                .toISOString()
                                .split("T")[0], // Format start date
                            endDate: new Date(endDate)
                                .toISOString()
                                .split("T")[0], // Format end date
                        },
                    }
                );
        
                console.log("Fetched release notes: ", response.data);
        
                if (response.data && response.data.length > 0) {
                    const filteredResponses = response.data.filter(
                        (note) =>
                            new Date(startDate) >= new Date(note.startDate) &&
                            new Date(endDate) <= new Date(note.endDate)
                    );
        
                    if (filteredResponses.length > 0) {
                        const sections = filteredResponses.map((note) => {
                            // Remove the unwanted text
                            const noteText = note.responseText.replace("Release Notes:", "")
                            .replace("Based on the commit messages provided, here is a categorized and summarized version of the release notes:", "");
        
                            // Remove double asterisks
                            const removedAsterisks = noteText.replace(/\*\*/g, "");
                            
                            // Split the note text by "\n\n" and filter out the first element if it's empty
                            const splitText = removedAsterisks.split("\n\n").filter((text) => text.trim() !== "");

        
                            // Remove leading dash from the titles
                    const sanitizedText = splitText.map(text => {
                        if (text.startsWith('- ')) {
                            return text.replace('- ', '');
                        }
                        return text;
                    });

                    return sanitizedText.join("\n\n");
                });
                setSections(sections);
            }
        }
            } catch (error) {
                console.log("Error fetching data:", error);
            }
        };
      
        if (startDate !== "" && endDate !== "") {
          handleReleaseNotesFetch();
        }
      }, [startDate, endDate]);

    return (
        <div className="text-gray-500">
        <div className="prose max-w-none mt-4">
          {sections.length > 0 ? (
            sections.map((section, index) => {
              const lines = section.split("\n");
              return (
                <div key={index}>
                  {lines.map((line, i) => (
                    line.endsWith(":") ? 
                    <h1 className="note-title" key={i}>{line}</h1> : 
                    <p key={i}>{line}</p>
                  ))}
                </div>
              );
            })
          ) : (
            <p>No release notes for the selected dates.</p>
          )}
        </div>
      </div>
    );
};

export default ReleaseNotes;
