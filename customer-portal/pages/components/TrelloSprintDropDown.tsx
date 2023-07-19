import React, { useState, useEffect, ChangeEvent } from 'react';

interface Sprint {
  trelloSprintId: string;
  number: string;
  startDate: string;
  endDate: string;
  name: string;
}

interface SprintDateDropdownProps {
  onGetSprints: (startDate: string, endDate: string) => void;
}

const SprintDateDropdown: React.FC<SprintDateDropdownProps> = ({ onGetSprints }) => {
  const [sprints, setSprints] = useState<Sprint[]>([]);
  const [selectedOption, setSelectedOption] = useState<string | null>(null);

  useEffect(() => {
    // Fetch the sprint data from your API
    async function fetchSprints() {
      try {
        const response = await fetch('https://localhost:7243/api/Trello/sprints');
        const data = await response.json();
        setSprints(data);
      } catch (error) {
        console.error('Error fetching sprints:', error);
      }
    }
    fetchSprints();
  }, []);

  const handleOptionChange = (event: ChangeEvent<HTMLSelectElement>) => {
    setSelectedOption(event.target.value);
  };

  const handleGetSprints = () => {
    if (selectedOption) {
      const selectedSprint = sprints.find((sprint) => sprint.trelloSprintId === selectedOption);
      if (selectedSprint) {
        // Make the API request with the selected start and end dates
        onGetSprints(selectedSprint.startDate, selectedSprint.endDate);
      }
    }
  };

  // Format the date string to the format (Month day)
  const formatMonthDay = (dateString: string) => {
    const date = new Date(dateString);
    return date.toLocaleDateString(undefined, { month: 'long', day: 'numeric' });
  };

  return (
    <div>
      <label htmlFor="dateRange">Select a Date Range:</label>
      <select id="dateRange" onChange={handleOptionChange} value={selectedOption || ''}>
        <option value="">Select a sprint...</option>
        {sprints.map((sprint) => (
          <option key={sprint.trelloSprintId} value={sprint.trelloSprintId}>
            {`Sprint-${sprint.number} (${formatMonthDay(sprint.startDate)} ~ ${formatMonthDay(sprint.endDate)})`}
          </option>
        ))}
      </select>
      <button onClick={handleGetSprints}>Get Data</button>
    </div>
  );
};

export default SprintDateDropdown;