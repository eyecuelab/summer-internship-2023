import { useRouter } from 'next/router';
import { useEffect, useState } from 'react';
import Profile from '../components/Profile';

const UserProfilePage = () => {
  const router = useRouter();
  const { id } = router.query;
  const [user, setUser] = useState(null);

  useEffect(() => {
    // Ensure id exists and is not an array
    if (id && typeof id === 'string') {
      // Fetch the data for this user
      fetch(`https://localhost:7243/api/Users/${id}`)
        .then(response => response.json())
        .then(data => setUser(data))
        .catch(err => console.error(err));
    }
  }, [id]); // Re-run this effect if id changes

  // While the user data is being fetched, show a loading message
  if (!user) {
    return <div>Loading...</div>;
  }

  return <Profile />;
};

export default UserProfilePage;