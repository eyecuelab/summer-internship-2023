// components/Sidebar.tsx
import React, { useState, useEffect, PropsWithChildren } from "react";
import cn from "classnames";
import {
  ChevronDoubleLeftIcon,
  ChevronDoubleRightIcon,
} from "@heroicons/react/24/outline";
import Image from "next/image";
import Link from "next/link";

// 👇 props to get and set the collapsed state from parent component
type Props = {
  collapsed: boolean;
  setCollapsed(collapsed: boolean): void;
  currentEntity: Entity | null;
};

interface Entity {
  companyName: string;
  entityId: string;
}

const AdminSidebar = ({ collapsed, setCollapsed}: Props) => {
  // 👇 use the correct icon depending on the state.
  const [entityList, setEntityList] = useState<Entity[] | null>(null);
  const Icon = collapsed ? ChevronDoubleRightIcon : ChevronDoubleLeftIcon;
  const [currentEntity, setCurrentEntity] = useState<Entity | null>(null);

  const handleEntityClick = (entity: Entity) => {
    console.log(entity)
    setCurrentEntity(entity); 
    console.log("setting current entity", entity)
  };

  useEffect(() => {
    const fetchAllEntities = async () => {
      try {
        const response = await fetch(`https://localhost:7243/api/Entities`);

        const data = await response.json();
        setEntityList(data);
        console.log("Entity List:", entityList)
      } catch (error) {
        console.error("Failed to transmit user data:", error);
      }
    };

    fetchAllEntities();
  }, []);

  const addNewCompany = (newCompany: Entity) => {
    setEntityList((prevEntityList: any) => [...prevEntityList, newCompany]);
  };

  return (
    <div className={cn({ "bg-gray-100 text-black-50 z-20": true })}>
      <div className={cn({ "flex flex-col justify-between": true })}>
        {/* logo and collapse button */}
        <div
          className={cn({
            "flex items-center border-b border-b-gray-500": true,
            "p-4 justify-between": !collapsed,
            "py-4 justify-center": collapsed,
          })}
        >
          {!collapsed && <span className="whitespace-nowrap">Parent Companies</span>}
          <button
            className={cn({
              "grid place-content-center": true, // position
              "hover:bg-gray-300 ": true, // colors
              "w-10 h-10 rounded-full": true, // shape
            })}
            // set the collapsed state on click
            onClick={() => setCollapsed(!collapsed)}
          >
            <Icon className="w-5 h-5" />
          </button>
        </div>
      </div>
      <div className={cn({ "grid place-content-stretch p-4 ": true })}>
        {/* Map over the entityList array to render dynamic items */}
        {entityList?.map((item, index) => (
          <div 
            key={index}
            className="flex gap-4 items-center h-11 overflow-hidden bg-gray-200 hover:bg-gray-400 rounded-full"
            onClick={() => handleEntityClick(item)}
          >
            <div className="flex flex-col">
              <Link href="#" className="text-slate-500 text-sm">
                {item.companyName}
              </Link>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};
export default AdminSidebar;
