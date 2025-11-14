import { cn } from "@/lib/utils";
import React from "react";
import { NavLink } from "react-router";

function Topbar() {
  return (
    <div className="sticky font-family-vt32 top-0 text-primary-foreground md:px-36 flex items-center justify-center">
      <div className="bg-foreground p-4 rounded-b-lg w-full flex items-center justify-between">
        <h1 className="text-4xl font-bold ">ProjectRFID</h1>
        <div className="flex items-center gap-2">
          <Link to="/provinces">Provinces</Link>
          <Link to="/cities">Cities</Link>
          <Link to="/attractions">Attractions</Link>
          <Link to="/cards">Cards</Link>
        </div>
      </div>
    </div>
  );
}
function Link({
  to,
  children,
  className,
}: {
  to: string;
  children?: React.ReactNode;
  className?: string;
}) {
  return (
    <NavLink
      to={to}
      className={({ isActive }) =>
        cn(
          "flex items-center transition-all text-2xl duration-300 ease-in-out gap-2 p-2 rounded-2xl",
          isActive && "bg-primary",
          className
        )
      }
    >
      {children}
    </NavLink>
  );
}
export default Topbar;
