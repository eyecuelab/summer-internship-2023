import React, { useEffect, useState, useContext } from "react";
import cn from "classnames";
import {
  ChevronDoubleLeftIcon,
  ChevronDoubleRightIcon,
} from "@heroicons/react/24/outline";
import Image from "next/image";
import Link from "next/link";
import { useRouter } from "next/router";
import ProfileSidebar from "./ProfileSidebar";
import SelectedUserContext from "../context/selectedUserContext";

// 👇 props to get and set the collapsed state from parent component
type Props = {
  collapsed: boolean;
  setCollapsed: React.Dispatch<React.SetStateAction<boolean>>;
};
const Sidebar = ({ collapsed, setCollapsed }: Props) => {
  const [authors, setAuthors] = useState<any[]>([]);
  const router = useRouter();
  const [currentPage, setCurrentPage] = useState<string>("");
  const selectedUserContext = useContext(SelectedUserContext);
  const { setSelectedUser } = selectedUserContext;

  useEffect(() => {
    setCurrentPage(router.pathname);
  }, [router.pathname]);

  useEffect(() => {
    const fetchCommits = async () => {
      try {
        const response = await fetch(
          "https://localhost:7243/api/GitHub/commits/eyecuelab/summer-internship-2023"
        );
        const data = await response.json();
        // Extracting unique authors
        const authorArray = data.map((commit: any) => ({
          name: commit.commit.author.name,
          email: commit.commit.author.email,
        }));
        const uniqueAuthors = authorArray.filter(
          (author, index, self) =>
            index ===
            self.findIndex(
              (a) => a.name === author.name && a.email === author.email
            )
        );
        setAuthors(uniqueAuthors);
      } catch (error) {
        console.error("Failed to fetch commits:", error);
      }
    };
    fetchCommits();
  }, []);

  const handleAuthorClick = (author) => {
    setSelectedUser({
      name: author.name,
      email: author.email,
    });
    router.push(`/Profile/${author.name}`);
  };
  
  const handleToggleUserClick = (user) => {
    router.push(`/profile/${user.id}`);
  }
  
  const Icon = collapsed ? ChevronDoubleRightIcon : ChevronDoubleLeftIcon;

  return (
    <div className={cn({ "bg-gray-100 text-black-50 z-20": true })}>
      <div className={cn({ "flex flex-col justify-between": true })}>
        <div
          className={cn({
            "flex items-center border-b border-b-gray-500": true,
            "p-4 justify-between": !collapsed,
            "py-4 justify-center": collapsed,
          })}
        >
          {!collapsed && <span className="whitespace-nowrap">My Portal</span>}
          <button
            className={cn({
              "grid place-content-center": true, // position
              "hover:bg-gray-300 ": true, // colors
              "w-10 h-10 rounded-full": true, // shape
            })}
            onClick={() => setCollapsed(!collapsed)}
          >
            <Icon className="w-5 h-5" />
          </button>
        </div>
      </div>
      <div className={cn({ "grid place-content-stretch p-4 ": true })}>
        {currentPage.startsWith("/Profile") ? (
          <ProfileSidebar
            collapsed={collapsed}
            setCollapsed={setCollapsed}
            user={""}
          />
        ) : (
          authors.map((author, index) => (
            <div
              key={index}
              className="flex gap-4 items-center h-11 overflow-hidden bg-gray-200 hover:bg-gray-400 rounded-full mb-4 pl-3"
              onClick={() => handleAuthorClick(author)} // replaced handleToggleUserClick with handleAuthorClick
            >
              {!collapsed && (
                <div className="flex flex-col">
                  <div className="flex flex-col space-y-1 items-start">
                  <Link
                    href={`/Profile/${author.name}`} // Pass the author name to the profile route
                    className="text-slate-500 text-sm text-right"
                  >
                    {author.name}
                  </Link>
                  <span className="text-slate-500 text-sm">
                    {author.email}
                  </span>
                </div>
                </div>
              )}
            </div>
          ))
        )}
      </div>
    </div>
  );
};

export default Sidebar;