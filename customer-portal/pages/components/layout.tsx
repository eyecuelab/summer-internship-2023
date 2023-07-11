import React, { PropsWithChildren, useState } from "react";
import classNames from "classnames";
import Sidebar from "./sidebar";
import ProfileSidebar from "./ProfileSidebar";
import { signOut } from "next-auth/react";

interface LayoutProps {
  username: string | undefined | null;
}

type Props = {
  user: string;
  collapsed: boolean;
  setCollapsed(collapsed: boolean): void;
};

const Layout: React.FC<LayoutProps & PropsWithChildren<{}>> = ({ username, children }) => {
  const [collapsed, setSidebarCollapsed] = useState(false);
  const [profileSidebar, setProfileSidebar] = useState(false);
  const [selectedUser, setSelectedUser] = useState(null);

  return (
    <>
    {/* navbar */}
    <nav className="fixed top-0 left-0 w-full h-10 flex justify-between items-center bg-black text-sm px-4 z-50">
      <h1></h1>
      <div className="text-slate-200">Welcome {username}!</div>
      <button className="text-slate-200" onClick={() => signOut()}>Sign out</button>
    </nav>

    <div
      className={classNames({
        // use grid layout
        "grid min-h-screen pt-10": true, // add padding-top to accommodate the navbar
        // create two rows for navbar and content, and two columns for sidebar and main content
        "grid-cols-sidebar-main": true,
        // toggle the width of the sidebar depending on the state
        "grid-cols-sidebar": !collapsed,
        "grid-cols-sidebar-collapsed": collapsed,
        // transition animation classes
        "transition-[grid-template-columns] duration-300 ease-in-out": true,
      })}
    >
      {/* sidebar */}
      {selectedUser ? <ProfileSidebar user={selectedUser} collapsed={collapsed} setCollapsed={setSidebarCollapsed} /> : <Sidebar collapsed={collapsed} setCollapsed={setSidebarCollapsed} setSelectedUser={setSelectedUser} />}

      {/* content */}
      <div className="row-start-1 col-start-2 p-10" style={{ backgroundColor: '#F7F7F8',marginTop: '-24px', zIndex: 100, maxWidth: '1165px' }}> {children}</div>
    </div>
    </>
  );
}


export default Layout;
