import React, { useState } from "react";
import classNames from "classnames";
import AdminSidebar from "./adminSideBar";
import { signOut } from "next-auth/react";

interface LayoutProps {
  username: string | undefined | null;
  currentEntity: Entity | null;
  children: React.ReactNode;
  onSelectedEntity: (selectedEntity: Entity | null) => void;
}

interface Entity {
  companyName: string;
  entityId: string;
}

const AdminLayout = ({
  username,
  currentEntity,
  children,
  onSelectedEntity, // Add the onSelectedEntity prop
}: LayoutProps) => {
  const [collapsed, setSidebarCollapsed] = useState(false);

  return (
    <>
      {/* Navbar */}
      <nav className="fixed top-0 left-0 w-full h-10 flex justify-between items-center bg-black text-sm px-4 z-50">
        <h1></h1>
        <div className="text-slate-200">Welcome {username}!</div>
        <button className="text-slate-200" onClick={() => signOut()}>
          Sign out
        </button>
      </nav>

      {/* Sidebar */}
      <div
        className={classNames({
          "grid min-h-screen pt-10": true,
          "grid-cols-sidebar-main": true,
          "grid-cols-sidebar": !collapsed,
          "grid-cols-sidebar-collapsed": collapsed,
          "transition-[grid-template-columns] duration-300 ease-in-out": true,
        })}
      >
        <AdminSidebar
          collapsed={collapsed}
          setCollapsed={setSidebarCollapsed}
          currentEntity={currentEntity}
          onSelectedEntity={onSelectedEntity} // Pass the callback prop to AdminSidebar
        />

        {/* Content */}
        <div
          className="row-start-1 col-start-2 p-10"
          style={{
            backgroundColor: "#F7F7F8",
            marginTop: "-24px",
            zIndex: 100,
            maxWidth: "1165px",
          }}
        >
          {children}
        </div>
      </div>
    </>
  );
};

export default AdminLayout;
