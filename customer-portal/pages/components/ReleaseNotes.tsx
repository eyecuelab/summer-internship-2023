import React, { useState } from "react";
import axios from "axios";

const ReleaseNotes: React.FC = () => {
  const [releaseNotes, setReleaseNotes] = useState<string>("");
  const [startDate, setStartDate] = useState<string>("");
  const [endDate, setEndDate] = useState<string>("");

  // Functions to handle date input changes
  const handleStartDateChange = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    setStartDate(event.target.value);
  };

  const handleEndDateChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setEndDate(event.target.value);
  };

  // Function to handle button click
  const handleReleaseNotesClick = async () => {
    if (startDate !== "" && endDate !== "") {
      try {
        const formattedStartDate = new Date(startDate)
          .toISOString()
          .split("T")[0];
        const formattedEndDate = new Date(endDate).toISOString().split("T")[0];

        const response = await axios.get(
          "https://localhost:7243/api/OpenAI/responses",
          {
            params: {
              startDate: formattedStartDate,
              endDate: formattedEndDate,
            },
          }
        );
        if (response.data && Array.isArray(response.data)) {
          const filteredResponse = response.data.find(
            (item: any) =>
              item.startDate.startsWith(formattedStartDate) &&
              item.endDate.startsWith(formattedEndDate)
          );
          if (filteredResponse) {
            setReleaseNotes(filteredResponse.responseText);
          } else {
            setReleaseNotes("No release notes found for the selected dates.");
          }
        }
      } catch (error) {
        console.log("Error fetching data:", error);
      }
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
