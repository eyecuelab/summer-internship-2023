import { useRouter } from "next/router";
import { useEffect, useState, useContext } from "react";
import Profile from "../components/profile";
import AdminProfile from "../components/adminProfile";
import SelectedUserContext from "../context/selectedUserContext";

interface Author {
  name: string;
  email: string;
}

interface NestedCommit {
  author: Author;
  message: string;
  date: string;
}

interface Commit {
  commit: NestedCommit;
}

interface CommitsByAuthor extends Record<string, Commit[]> {}

const AdminProfilePage = () => {
  const router = useRouter();
  const { email } = router.query;
  const [user, setUser] = useState(null);
  // const [isAdmin, setIsAdmin] = useState<string>("false");
  const [isAdmin, setIsAdmin] = useState<string | null>(null);
  const selectedUserContext = useContext(SelectedUserContext);
  const { selectedUser, setSelectedUser } = selectedUserContext;
  const [lastEmail, setLastEmail] = useState(null);

  useEffect(() => {
    setLastEmail(email);
  }, [email]);

  useEffect(() => {
    const storedIsAdmin = localStorage.getItem("isAdmin");
    if (storedIsAdmin) {
      setIsAdmin(storedIsAdmin);
    }
    setLastEmail(email);
  }, [email]);


  useEffect(() => {
    if (email && typeof email === "string") {
      fetch(`https://localhost:7243/api/ProjectAppUser/getprojs/${email}`)
        .then((response) => response.json())
        .then((data) => setUser(data))
        .catch((err) => console.error(err));
    }
  }, [email]);// Re-run this effect if email changes

  return isAdmin === "true" ? (
    <AdminProfile selectedUser={selectedUser}/>
  ) : (
    <Profile selectedUser={selectedUser} />
  );
};

export default AdminProfilePage;
