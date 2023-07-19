import React, { useState } from "react";
import axios from "axios";
import ReactMarkdown from 'react-markdown';

const ReleaseNotes: React.FC = () => {
  const [sections, setSections] = useState<Array<string>>([]);
  const [startDate, setStartDate] = useState<string>("");
  const [endDate, setEndDate] = useState<string>("");

  const handleStartDateChange = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    setStartDate(event.target.value);
  };

  const handleEndDateChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setEndDate(event.target.value);
  };

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
            const sections = filteredResponse.responseText.split('\n\n');
            setSections(sections);
          } else {
            setSections([]);
          }
        }
      } catch (error) {
        console.log("Error fetching data:", error);
      }
    }
  };

  return (
    <div className=" text-gray-500">
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
        onClick={handleReleaseNotesClick}
        className="py-2 px-4 mt-2 ml-2 bg-gray-200 hover:bg-gray-400  text-slate-500 rounded-lg focus:outline-none"
      >
        Get Release Notes
      </button>
      <div className="prose max-w-none mt-4">
        {sections.length > 0 ? sections.map((section, index) => (
          <ReactMarkdown key={index} children={section} />
        )) : <p></p>
        }
      </div>
    </div>
  );
};

export default ReleaseNotes;