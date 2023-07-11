// components/Sidebar.tsx
import React, {  useEffect, useState } from "react";
import cn from "classnames";
import {
  ChevronDoubleLeftIcon,
  ChevronDoubleRightIcon,
} from "@heroicons/react/24/outline";
import Image from "next/image";
import Link from "next/link";
import { useRouter } from 'next/router';
import ProfileSidebar from "./ProfileSidebar";

// 👇 props to get and set the collapsed state from parent component
type Props = {
  collapsed: boolean;
  setCollapsed: React.Dispatch<React.SetStateAction<boolean>>;
  setSelectedUser: React.Dispatch<React.SetStateAction<string | null>>;
};
const Sidebar = ({ collapsed, setCollapsed, setSelectedUser }: Props) => {
  const [users, setUsers] = useState<any[]>([]);
  const [currentPage, setCurrentPage] = useState<string>(''); // Track the current page
  const router = useRouter();

  useEffect(() => {
    setCurrentPage(router.pathname); // Set the current page on initial load and on route changes
  }, [router.pathname]);

      // Function to fetch users
  useEffect(() => {
    const fetchUsers = async () => {
      try {
        const response = await fetch("https://localhost:7243/api/Users"); 
        const data = await response.json();
        setUsers(data);
      } catch (error) {
        console.error('Failed to fetch users:', error);
      }
    };

    fetchUsers();
  }, []);

    // 👇 use the correct icon depending on the state.
  const Icon = collapsed ? ChevronDoubleRightIcon : ChevronDoubleLeftIcon;
  return (
    <div className={cn({"bg-gray-100 text-black-50 z-20": true})}>
      <div className={cn({"flex flex-col justify-between": true})}>
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
      {currentPage.startsWith('/Profile') ? ( // Check if the current page starts with '/Profile'
        <ProfileSidebar collapsed={collapsed} setCollapsed={setCollapsed} />
      ) : (
        users.map((user) => (
            <div key={user.id} className="flex gap-4 items-center h-11 overflow-hidden bg-gray-200 hover:bg-gray-400 rounded-full">
              <Image
                src={user.image}
                height={36}
                width={36}
                alt="profile image"
                className="rounded-full"
              />
              {!collapsed && (
                <div className="flex flex-col">
                  <Link
                    href={`/Profile/${user.id}`} // Pass the user ID to the profile route
                    className="text-slate-500 text-sm"
                  >
                    {user.email}
                  </Link>
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





