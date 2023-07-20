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

        // Sort the sprints by date before setting the state
        const sortedSprints = response.data.sort((a, b) => {
          const dateA = new Date(a.date).getTime();
          const dateB = new Date(b.date).getTime();
          return dateA - dateB;
        });

        console.log('Fetched sprints: ', sortedSprints);
        setSprints(sortedSprints);
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

  const formatDateRange = (startDate: Date, endDate: Date): string => {
    const startMonth = startDate.toLocaleString('default', { month: 'short' });
    const startDay = startDate.getDate();
    const endMonth = endDate.toLocaleString('default', { month: 'short' });
    const endDay = endDate.getDate();

    return `${startMonth} ${startDay} ~ ${endMonth} ${endDay}`;
  };

  const handleSelectChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    const selectedSprint = sprints.find(
      (sprint) => sprint.trelloSprintId === event.target.value
    );

    if (selectedSprint) {
      const startDate = new Date(selectedSprint.date);
      const endDate = new Date(startDate.getTime() + 6 * 24 * 60 * 60 * 1000); // 6 days later

      const formattedDateRange = formatDateRange(startDate, endDate);
      console.log('Sprint:', selectedSprint.number, '(', formattedDateRange, ')');

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
        {sprints.map((sprint) => {
          const startDate = new Date(sprint.date);
          const endDate = new Date(startDate.getTime() + 6 * 24 * 60 * 60 * 1000); // 6 days later
          const formattedDateRange = formatDateRange(startDate, endDate);

          return (
            <option key={sprint.trelloSprintId} value={sprint.trelloSprintId}>
              Sprint-{sprint.number} ({formattedDateRange})
            </option>
          );
        })}
      </select>
    </div>
  );
};

export default TrelloSprint;
