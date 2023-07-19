import React, { useState, useEffect } from "react";
import axios from "axios";
import ReactMarkdown from 'react-markdown';
import { formatDate } from "./TrelloSprint";

type ReleaseNotesProps = {
  startDate: string;
  endDate: string;
};

const ReleaseNotes: React.FC<ReleaseNotesProps> = ({ startDate, endDate }) => {
  const [sections, setSections] = useState<Array<string>>([]);

  useEffect(() => {
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

    if (startDate !== "" && endDate !== "") {
      handleReleaseNotesFetch();
    }
  }, [startDate, endDate]);

  console.log("Sections: ", sections);
  console.log("Sections length: ", sections.length);

  return (
    <div className="text-gray-500">
      <h2 className="text-xl font-semibold text-gray-600" style={{ fontFamily: 'Rasa, sans-serif' }}>Release Notes</h2>
      <div className="prose max-w-none mt-4">
        {sections.length > 0 ? (
          sections.map((section, index) => (
            <ReactMarkdown key={index} children={section} />
          ))
        ) : (
          <p>No release notes for the selected dates.</p>
        )}
      </div>
    </div>
  );
};

export default ReleaseNotes;
