import { useRouter } from "next/router";
import { useEffect, useState, useContext } from "react";
import Profile from "../components/profile";
import AdminProfile from "../components/AdminProfile";
import SelectedUserContext from "../context/selectedUserContext";


const AdminProfilePage = () => {
  const router = useRouter();
  const { id } = router.query;
  // const userEmail = Array.isArray(email) ? email[0] : email || "";
  const [user, setUser] = useState(null);
  const [isAdmin, setIsAdmin] = useState<string | null>(null);
  const selectedUserContext = useContext(SelectedUserContext);
  const { selectedUser, setSelectedUser } = selectedUserContext;
  const [lastEmail, setLastEmail] = useState<string | null>(null);

  useEffect(() => {
    if (id) {
      setLastEmail(id);
    }
  }, [id]);

  useEffect(() => {
    const storedIsAdmin = localStorage.getItem("isAdmin");
    if (storedIsAdmin) {
      setIsAdmin(storedIsAdmin);
    }
    if (id) {
      setLastEmail(id);
    }
  }, [id]);

  useEffect(() => {
    if (id) {
      fetch(`https://localhost:7243/api/ProjectAppUser/getprojs/${id}`)
        .then((response) => response.json())
        .then((data) => {
          console.log('Data received:', data);
          setUser(data);
          setSelectedUser(data);
        })
        .catch((err) => console.error(err));
    }
  }, [id, setSelectedUser]);

  return isAdmin === "true" ? (
    <AdminProfile selectedUser={selectedUser} />
  ) : (
    <Profile selectedUser={selectedUser} />
  );
};

export default AdminProfilePage;