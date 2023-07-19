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
        const response = await fetch('https://localhost:7243/api/Trello/dbsprints');
        const data = await response.json();
        // Sort the sprints based on start dates
        data.sort((a: Sprint, b: Sprint) => {
          const dateA = new Date(a.startDate);
          const dateB = new Date(b.startDate);
          return dateA.getTime() - dateB.getTime();
        });
        setSprints(data);
      } catch (error) {
        console.error('Error fetching sprints:', error);
      }
    }
    fetchSprints();
  }, []);

  // Format the date string to "Month Day" format (e.g., "May 2")
  const formatDate = (dateString: string) => {
    const date = new Date(dateString);
    return date.toLocaleDateString(undefined, { month: 'long', day: 'numeric' });
  };

  const handleOptionChange = (event: ChangeEvent<HTMLSelectElement>) => {
    setSelectedOption(event.target.value);
    console.log('Selected option:', event.target.value);

    const selectedSprint = sprints.find((sprint) => sprint.trelloSprintId === event.target.value);
    if (selectedSprint) {
      // Make the API request with the selected start and end dates
      onGetSprints(selectedSprint.startDate, selectedSprint.endDate);
    }
  };

  return (
    <div>
      <label htmlFor="dateRange">Select a Date Range:</label>
      <select id="dateRange" onChange={handleOptionChange} value={selectedOption || ''}>
        <option value="">Select a sprint...</option>
        {sprints.map((sprint) => (
          <option key={sprint.trelloSprintId} value={sprint.trelloSprintId}>
            {`Sprint-${sprint.number} (${formatDate(sprint.startDate)} ~ ${formatDate(sprint.endDate)})`}
          </option>
        ))}
      </select>
    </div>
  );
};

export default SprintDateDropdown;