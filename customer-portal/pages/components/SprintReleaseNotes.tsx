import React, { useState, useEffect } from 'react';
import TrelloSprint from './TrelloSprint';
import ReleaseNotes from './ReleaseNotes';

type SprintDates = {
    startDate: string;
    endDate: string;
};

const SprintReleaseNotes: React.FC = () => {
  const [selectedSprint, setSelectedSprint] = useState<SprintDates>({
    startDate: "",
    endDate: ""
  });

  useEffect(() => {
    console.log("Selected Sprint Dates:", selectedSprint.startDate, selectedSprint.endDate);
  }, [selectedSprint]);

  return (
    <div>
      <TrelloSprint setSelectedSprint={setSelectedSprint} />
      <ReleaseNotes startDate={selectedSprint.startDate} endDate={selectedSprint.endDate} />
    </div>
  );
};

export default SprintReleaseNotes;