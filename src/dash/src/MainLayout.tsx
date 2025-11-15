import { Toaster } from "sonner";
import Topbar from "./shared/components/Topbar";
import { Outlet } from "react-router";

function MainLayout() {
  return (
    <div className="min-h-svh relative flex flex-col ">
      <Topbar />
      <Outlet />
      <Toaster position="top-center" richColors />
    </div>
  );
}

export default MainLayout;
