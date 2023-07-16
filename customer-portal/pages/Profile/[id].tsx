import { useRouter } from "next/router";
import { useEffect, useState, useContext } from "react";
import Profile from "../components/profile";
import AdminProfile from "../components/AdminProfile";
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

const UserProfilePage = () => {
  const router = useRouter();
  const { id } = router.query;
  const [user, setUser] = useState(null);
  // const [isAdmin, setIsAdmin] = useState<string>("false");
  const [isAdmin, setIsAdmin] = useState<string | null>(null);
  const [commitsByAuthor, setCommitsByAuthor] = useState<CommitsByAuthor>({});
  const selectedUserContext = useContext(SelectedUserContext);
  const { selectedUser, setSelectedUser } = selectedUserContext;
  const [lastId, setLastId] = useState(null);

  useEffect(() => {
    const storedIsAdmin = localStorage.getItem("isAdmin");
    if (storedIsAdmin) {
      setIsAdmin(storedIsAdmin);
    }
    setLastId(id);
  }, [id]);


  useEffect(() => {
    // Ensure id exists and is not an array
    if (id && typeof id === "string") {
      // Fetch the data for this user
      fetch(`https://localhost:7243/api/ProjectAppUser/getprojs/${id}`)
        .then((response) => response.json())
        .then((data) => setUser(data))
        .catch((err) => console.error(err));
    }
  }, [id]); // Re-run this effect if id changes

  useEffect(() => {
    fetch(
      "https://localhost:7243/api/GitHub/commits/eyecuelab/summer-internship-2023"
    )
      .then((response) => response.json())
      .then((json = []) => {
        const commitsByAuthorTemp: CommitsByAuthor = {};

        json.forEach((commit: Commit) => {
          const authorName = commit.commit.author.name;
          if (commitsByAuthorTemp[authorName]) {
            commitsByAuthorTemp[authorName].push(commit);
          } else {
            commitsByAuthorTemp[authorName] = [commit];
          }
        });

        setCommitsByAuthor(commitsByAuthorTemp);
      })
      .catch((err) => console.error(err));
  }, []);

  useEffect(() => {
    // Ensure id exists and is not an array
    if (id && typeof id === "string") {
      // Assuming the first commit of the selected user belongs to them
      const userCommits = commitsByAuthor[id];
      if (userCommits && userCommits.length > 0) {
        const firstCommit = userCommits[0];
        const userFromCommit = {
          name: firstCommit.commit.author.name,
          email: firstCommit.commit.author.email,
        };
        setSelectedUser(userFromCommit);
      }
    }
  }, [id, commitsByAuthor, setSelectedUser]);

  if (!user && isAdmin === null) {
    return <div>Loading...</div>;
  }

  return isAdmin === "true" ? (
    <AdminProfile selectedUser={selectedUser}/>
  ) : (
    <Profile selectedUser={selectedUser} />
  );
};

export default UserProfilePage;
