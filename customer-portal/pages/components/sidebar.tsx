import React from "react";
import cn from "classnames";
import { ChevronDoubleLeftIcon, ChevronDoubleRightIcon } from "@heroicons/react/24/outline";
import Image from "next/image";
import Link from "next/link";
import { useSession } from "next-auth/react";

type Props = {
  collapsed: boolean;
  setCollapsed(collapsed: boolean): void;
};

const Sidebar = ({ collapsed, setCollapsed }: Props) => {
  const { data: session, status } = useSession();
  const loading = status === "loading";

  const Icon = collapsed ? ChevronDoubleRightIcon : ChevronDoubleLeftIcon;

  if (loading) {
    return <div>Loading...</div>; // Optional loading message
  }

  return (
    <div className={cn({"bg-gray-100 text-black-50 z-20": true,})}>
      <div className={cn({"flex flex-col justify-between": true,})}>
        <div className={cn({"flex items-center border-b border-b-gray-500": true,
                            "p-4 justify-between": !collapsed,
                            "py-4 justify-center": collapsed,
        })}>
          {!collapsed && <span className="whitespace-nowrap">My Portal</span>}
          <button className={cn({"grid place-content-center": true,
                                  "hover:bg-gray-300 ": true,
                                  "w-10 h-10 rounded-full": true,
            })}
                  onClick={() => setCollapsed(!collapsed)}
          >
            <Icon className="w-5 h-5" />
          </button>
        </div>
      </div>
      <div className={cn({"grid place-content-stretch p-4 ": true,})}>
        <div className="flex gap-4 items-center h-11 overflow-hidden bg-gray-200 hover:bg-gray-400 rounded-full">
          {session && 
            <>
              <Image
                src={session.user?.image || ""}
                height={36}
                width={36}
                alt="profile image"
                className="rounded-full"
              />
              {!collapsed && (
                <div className="flex flex-col">
                  <Link href="#" className="text-slate-500 text-sm">
                    {session.user?.name || ""}
                  </Link>
                </div>
              )}
            </>
          }
        </div>
      </div>
    </div>
  );
};
export default Sidebar;