import { useRouter } from "next/router";
import { useEffect, useState } from "react";
import Profile from "../components/profile";
import AdminProfile from "../components/AdminProfile";

const UserProfilePage = () => {
  const router = useRouter();
  const { id } = router.query;
  const [user, setUser] = useState(null);
  const [isAdmin, setIsAdmin] = useState<string>("false");

  useEffect(() => {
    const storedIsAdmin = localStorage.getItem('isAdmin');
    if (storedIsAdmin) {
      setIsAdmin(storedIsAdmin);
    }
  }, []);

  useEffect(() => {
    // Ensure id exists and is not an array
    if (id && typeof id === "string") {
      // Fetch the data for this user
      fetch(`https://localhost:7243/api/Users/${id}`)
        .then((response) => response.json())
        .then((data) => setUser(data))
        .catch((err) => console.error(err));
    }
  }, [id]); // Re-run this effect if id changes

  // While the user data is being fetched, show a loading message
  if (!user) {
    return <div>Loading...</div>;
  }

  return isAdmin === "true" ? <AdminProfile /> : <Profile />;
};

export default UserProfilePage;
