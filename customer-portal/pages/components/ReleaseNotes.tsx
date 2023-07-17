import React, { useState } from "react";
import axios from "axios";

const ReleaseNotes: React.FC = () => {
  const [releaseNotes, setReleaseNotes] = useState<string>("");
  const [date, setDate] = useState<string>("");

  // Function to handle date input change
  const handleDateChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setDate(event.target.value);
  };

  // Function to handle button click
  const handleReleaseNotesClick = async () => {
    try {
      const response = await axios.post(`http://localhost:7243/api/OpenAI/SummarizeCommitsByDates/${date}/${date}`);
      setReleaseNotes(response.data);
    } catch (error) {
      console.error("Failed to fetch release notes:", error);
    }
  };

  return (
    <div>
      <h2>Release Notes</h2>
      <input type="date" value={date} onChange={handleDateChange} />
      <button onClick={handleReleaseNotesClick}>Get Release Notes</button>
      <p>{releaseNotes}</p>
    </div>
  );
};

export default ReleaseNotes;