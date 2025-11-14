import Topbar from "./shared/components/Topbar";
import { Outlet } from "react-router";

function MainLayout() {
  return (
    <div className="min-h-svh relative flex flex-col ">
      <Topbar />
      <Outlet />
    </div>
  );
}

export default MainLayout;
