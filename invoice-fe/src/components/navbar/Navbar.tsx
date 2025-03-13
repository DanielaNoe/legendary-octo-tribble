import { useState } from "react";
import { Link, useLocation, useNavigate } from "react-router";

const navItems = [
    { path: "/", label: "Home" },
    { path: "/invoices", label: "Invoices" },
    { path: "/orders", label: "Orders" }
  ];
  
function Navbar() {
  const currentLocation = useLocation();
  const [activePath, setActivePath] = useState(currentLocation.pathname);

  const navigate = useNavigate();

  const selectItem = (path: string) => {
    navigate(path);
    setActivePath(path);
    window.location.reload();
  };

  return (
    <nav className="nav flex-column">
        <h4><div className="nav-link text-light">Navigation</div></h4>
        <hr className="mt-0 text-light" />
        
        {navItems.map((item) => (
        <div key={item.path} className="mb-2">
            {(activePath === item.path || (item.label === "Invoices" && activePath.startsWith("/invoices/"))) ? (
                <button className="btn btn-primary w-100 text-start ps-3" type="button" onClick={() => selectItem(item.path)}>{item.label}</button> 
            ) : (
                <button className="btn w-100 text-start ps-3 text-light bg-none" type="button" onClick={() => selectItem(item.path)}>{item.label}</button>
            )}
        </div>
      ))}
    </nav>
  );
};

export default Navbar;