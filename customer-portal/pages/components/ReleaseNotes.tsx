import React, { useState, useEffect } from 'react';
import axios from 'axios';
import ReactMarkdown from 'react-markdown';

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
}

const ReleaseNotes: React.FC<ReleaseNotesProps> = ({ startDate, endDate, latestCommits, setLatestCommits }) => {
  const [sections, setSections] = useState<string[]>([]);

  const handleStartDateChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setStartDate(event.target.value);
  };

  const handleEndDateChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setEndDate(event.target.value);
  };

  const handleGetLatestCommits = async () => {
    try {
      const response = await fetch("https://localhost:7243/api/GitHub/commits/eyecuelab/summer-internship-2023");
      if (!response.ok) {
        throw new Error("HTTP error, status = " + response.status);
      }
      const json = await response.json();
      const commits = json.map((commit: { message: any; date: any; author: { name: any; email: any; date: any; }; }) => ({
        message: commit.message,
        date: commit.date,
        releaseNotes: "",
        author: {
          name: commit?.author?.name || "",
          email: commit?.author?.email || "",
          date: commit?.author?.date || "",
        },
      }));

      setLatestCommits(commits);
    } catch (error) {
      console.error("Error during fetch:", error);
    }
  };

  const handleReleaseNotesFetch = async () => {
    try {
      const formattedStartDate = startDate ? formatDate(new Date(startDate)) : '';
      const formattedEndDate = endDate ? formatDate(new Date(endDate)) : '';

      const response = await axios.get(
        "https://localhost:7243/api/OpenAI/responses",
        {
          params: {
            startDate: formattedStartDate,
            endDate: formattedEndDate,
          },
        }
      );

      console.log("Fetched release notes: ", response.data);

      if (response.data && response.data.length > 0) {
        const filteredResponse = response.data[0];
        if (filteredResponse) {
          const sections = filteredResponse.responseText.split('\n\n');
          setSections(sections);
        } else {
          setSections([]);
        }
      } else {
        setSections([]);
      }
    } catch (error) {
      console.log("Error fetching data:", error);
    }
  };

  useEffect(() => {
    if (startDate !== "" && endDate !== "") {
      handleReleaseNotesFetch();
    }
  }, [startDate, endDate]);

  return (
    <div className="text-gray-500">
      <h2 className="text-xl font-semibold text-gray-600" style={{ fontFamily: 'Rasa, sans-serif' }}>Release Notes</h2>

      <input
        type="date"
        value={startDate}
        onChange={handleStartDateChange}
        className="py-2 px-4 mt-2 rounded-lg border border-gray-200 focus:outline-none focus:border-blue-400"
      />
      <input
        type="date"
        value={endDate}
        onChange={handleEndDateChange}
        className="py-2 px-4 mt-2 ml-2 rounded-lg border border-gray-200 focus:outline-none focus:border-blue-400"
      />
      <button
        onClick={handleReleaseNotesFetch}
        className="py-2 px-4 mt-2 ml-2 bg-gray-200 hover:bg-gray-400 text-slate-500 rounded-lg focus:outline-none"
      >
        Get Release Notes
      </button>
      <button
        onClick={handleGetLatestCommits}
        className="py-2 px-4 mt-2 ml-2 bg-gray-200 hover:bg-gray-400 text-slate-500 rounded-lg focus:outline-none"
      >
        Get Latest Commits
      </button>

      <div className="prose max-w-none mt-4">
        {sections.length > 0 ? (
          sections.map((section, index) => <ReactMarkdown key={index} children={section} />)
        ) : (
          <p>No release notes for the selected dates.</p>
        )}
      </div>
    </div>
  );
};

export default ReleaseNotes;