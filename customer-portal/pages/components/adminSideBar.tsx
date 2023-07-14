// AdminSidebar.tsx
import React, { useState, useEffect } from "react";
import cn from "classnames";
import {
  ChevronDoubleLeftIcon,
  ChevronDoubleRightIcon,
} from "@heroicons/react/24/outline";
import Link from "next/link";

type Props = {
  collapsed: boolean;
  setCollapsed(collapsed: boolean): void;
  currentEntity: Entity | null;
  onSelectedEntity(selectedEntity: Entity | null): void; // Corrected function name
};

interface Entity {
  companyName: string;
  entityId: string;
}

const AdminSidebar = ({ collapsed, setCollapsed, currentEntity, onSelectedEntity }: Props) => {
  const [entityList, setEntityList] = useState<Entity[] | null>(null);
  const Icon = collapsed ? ChevronDoubleRightIcon : ChevronDoubleLeftIcon;
  const [selectedEntity, setSelectedEntity] = useState<Entity | null>(null);


  const handleEntityClick = (entity: Entity) => {
    setSelectedEntity(entity);
    onSelectedEntity(entity); // Ensure this line is present

  };

  useEffect(() => {
    const fetchAllEntities = async () => {
      try {
        const response = await fetch(`https://localhost:7243/api/Entities`);
        const data = await response.json();
        setEntityList(data);
      } catch (error) {
        console.error("Failed to transmit user data:", error);
      }
    };

    fetchAllEntities();
  }, []);

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
          {!collapsed && (
            <span className="whitespace-nowrap">Parent Companies</span>
          )}
          <button
            className={cn({
              "grid place-content-center": true,
              "hover:bg-gray-300 ": true,
              "w-10 h-10 rounded-full": true,
            })}
            onClick={() => setCollapsed(!collapsed)}
          >
            <Icon className="w-5 h-5" />
          </button>
        </div>
      </div>

      <div className={cn({ "grid place-content-stretch p-4 ": true })}>
        {entityList?.map((item, index) => (
          <div key={index}>
            <div
              className="flex gap-4 items-center h-11 overflow-hidden bg-gray-200 hover:bg-gray-400 rounded-full"
              onClick={() => handleEntityClick(item)}
            >
              <br />
              <div className="flex flex-col">
                <Link href="#" className="text-slate-500 text-sm">
                  <p style={{ fontFamily: "Rasa", fontSize: "20px", margin: 0 }}>
                    {item.companyName}
                  </p>
                </Link>
              </div>
            </div>
            <br />
          </div>
        ))}
      </div>
    </div>
  );
};

export default AdminSidebar;
