import React, { useEffect, useState } from 'react';
import axios from 'axios';

type Sprint = {
  trelloSprintId: string;
  name: string;
  date: string;
  number: string;
};

type TrelloSprintProps = {
  setSelectedSprint: React.Dispatch<React.SetStateAction<{ startDate: string; endDate: string }>>;
};

export function formatDate(date: Date): string {
  const year = date.getFullYear();
  const month = ('0' + (date.getMonth() + 1)).slice(-2); // Months are 0 index based
  const day = ('0' + date.getDate()).slice(-2);

  return `${year}-${month}-${day}`;
}

const TrelloSprint: React.FC<TrelloSprintProps> = ({ setSelectedSprint }) => {
  const [sprints, setSprints] = useState<Sprint[]>([]);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchSprints = async () => {
      try {
        const response = await axios.get<Sprint[]>('https://localhost:7243/api/Trello/dbsprints');
        console.log('Fetched sprints: ', response.data);
        setSprints(response.data);
      } catch (err) {
        if (err instanceof Error) {
          setError(err.message);
        } else {
          setError('An error occurred');
        }
      }
    };

    fetchSprints();
  }, []);

  if (error) {
    return <div>Error: {error}</div>;
  }

  const handleSelectChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    const selectedSprint = sprints.find(
      (sprint) => sprint.trelloSprintId === event.target.value
    );

    if (selectedSprint) {
      const startDate = new Date(selectedSprint.date);
      const endDate = new Date(startDate.getTime() + 6 * 24 * 60 * 60 * 1000); // 6 days later

      console.log('Start date: ', formatDate(startDate), 'End date: ', formatDate(endDate));
      setSelectedSprint({
        startDate: formatDate(startDate),
        endDate: formatDate(endDate),
      });
    }
  };

  return (
    <div>
      <h2>Trello Sprints</h2>
      <select onChange={handleSelectChange}>
        <option>Select a Sprint</option>
        {sprints.map((sprint) => (
          <option key={sprint.trelloSprintId} value={sprint.trelloSprintId}>
            {sprint.number}: {sprint.name} Date: {new Date(sprint.date).toLocaleDateString()}
          </option>
        ))}
      </select>
    </div>
  );
};

export default TrelloSprint;