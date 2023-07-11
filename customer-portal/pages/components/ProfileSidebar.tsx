// components/Sidebar.tsx
import React from "react";
import cn from "classnames";
import {
  ChevronDoubleLeftIcon,
  ChevronDoubleRightIcon,
} from "@heroicons/react/24/outline";
import Image from "next/image";
import Img25 from "../../public/img/image 25.png";
import Img26 from "../../public/img/image 26.png";
import Img27 from "../../public/img/image 27.png";
import Img28 from "../../public/img/image 28.png";
import Link from "next/link";

// 👇 props to get and set the collapsed state from parent component
type Props = {
  user: string;
  collapsed: boolean;
  setCollapsed(collapsed: boolean): void;
};
const ProfileSidebar = ({ collapsed, setCollapsed }: Props) => {
  // 👇 use the correct icon depending on the state.
  const Icon = collapsed ? ChevronDoubleRightIcon : ChevronDoubleLeftIcon;
  return (
    <div
      className={cn({
        "bg-gray-100 text-black-50 z-20": true,
      })}
    >
      <div
        className={cn({
          "flex flex-col justify-between": true,
        })}
      >
        {/* logo and collapse button */}
        <div
          className={cn({
            "flex items-center border-b border-b-gray-500": true,
            "p-4 justify-between": !collapsed,
            "py-4 justify-center": collapsed,
          })}
        >
          {!collapsed && <span className="whitespace-nowrap">User Details</span>}
          <button
            className={cn({
              "grid place-content-center": true, // position
              "hover:bg-gray-300 ": true, // colors
              "w-10 h-10 rounded-full": true, // shape
            })}
            // 👇 set the collapsed state on click
            onClick={() => setCollapsed(!collapsed)}
          >
            <Icon className="w-5 h-5" />
          </button>
        </div>
      </div>
      <div
          className={cn({
            "grid place-content-stretch p-4 ": true,
          })}
        >
          <div className="flex gap-4 items-center h-11 overflow-hidden bg-gray-200 hover:bg-gray-400 rounded-full">
            <Image
              src={Img25}
              height={36}
              width={36}
              alt="profile image"
              className="rounded-full"
            />
            {!collapsed && (
              <div className="flex flex-col">
                <Link href="#" className="text-slate-500 text-sm">
                  Profile
                </Link>
              </div>
            )}
          </div><br/>
          <div className="flex gap-4 items-center h-11 overflow-hidden  bg-gray-200 hover:bg-gray-400 rounded-full">
            <Image
              src={Img26}
              height={36}
              width={36}
              alt="profile image"
              className="rounded-full"
            />
            {!collapsed && (
              <div className="flex flex-col ">
                <Link href="#" className="text-slate-500 text-sm">
                  Teams
                </Link>
              </div>
            )}
          </div><br/>
          <div className="flex gap-4 items-center h-11 overflow-hidden  bg-gray-200 hover:bg-gray-400 rounded-full">
            <Image
              src={Img27}
              height={36}
              width={36}
              alt="profile image"
              className="rounded-full"
            />
            {!collapsed && (
              <div className="flex flex-col ">
                <Link href="#" className="text-slate-500 text-sm">
                  App Connections
                </Link>
                </div>
            )}
            </div><br/>
            <div className="flex gap-4 items-center h-11 overflow-hidden  bg-gray-200 hover:bg-gray-400 rounded-full">
            <Image
              src={Img28}
              height={36}
              width={36}
              alt="profile image"
              className="rounded-full"
            />
            {!collapsed && (
              <div className="flex flex-col ">
                <Link href="#" className="text-slate-500 text-sm">
                  Achievements
                </Link>
              </div>
            )}
          </div><br/>
          </div>
        </div>
  );
};
export default ProfileSidebar;

