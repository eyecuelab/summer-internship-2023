import React from "react";

interface SelectedUserContextType {
  selectedUser: { name: string; email: string; };
  setSelectedUser: React.Dispatch<React.SetStateAction<{ name: string; email: string; }>>;
}
const defaultContextValue: SelectedUserContextType = {
  selectedUser: { name: '', email: '' },
  setSelectedUser: () => {},
};

const SelectedUserContext = React.createContext<SelectedUserContextType>(defaultContextValue);

export default SelectedUserContext;