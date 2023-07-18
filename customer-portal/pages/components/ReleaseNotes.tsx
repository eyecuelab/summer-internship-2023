import React, { useState } from "react";
import axios from "axios";

const ReleaseNotes: React.FC = () => {
  const [releaseNotes, setReleaseNotes] = useState<string>("");
  const [startDate, setStartDate] = useState<string>("");
  const [endDate, setEndDate] = useState<string>("");
  const [date, setDate] = useState<string>("");


  // Functions to handle date input changes
  const handleStartDateChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setStartDate(event.target.value);
  };

  const handleEndDateChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setEndDate(event.target.value);
    console.log(event.target.value);
  };

  // Function to handle button click
  const handleReleaseNotesClick = async () => {
    console.log(startDate, endDate);
    if (startDate !== "" && endDate !== "") {
      try {
        const response = await axios.get(`http://localhost:7243/api/OpenAI/SummarizeCommitsByDates`, { params: { startDate: startDate, endDate: endDate } });
        setReleaseNotes(response.data);
      } catch (error) {
        console.error("Failed to fetch release notes:", error);
      }
    } else {
      console.error("Start date or end date is not set");
    }
  };
  

  return (
    <div>
      <h2>Release Notes</h2>
      <input type="date" value={startDate} onChange={handleStartDateChange} />
      <input type="date" value={endDate} onChange={handleEndDateChange} />
      <button onClick={handleReleaseNotesClick}>Get Release Notes</button>
      <p>{releaseNotes}</p>
    </div>
  );
};

export default ReleaseNotes;