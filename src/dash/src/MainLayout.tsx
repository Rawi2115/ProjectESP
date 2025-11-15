import { toast, Toaster } from "sonner";
import Topbar from "./shared/components/Topbar";
import { Outlet } from "react-router";
import { useEffect } from "react";
import * as signalR from "@microsoft/signalr";
import { useQueryClient } from "@tanstack/react-query";
export const SignalRProvider = () => {
  const queryClient = useQueryClient();
  useEffect(() => {
    const connection = new signalR.HubConnectionBuilder()
      .withUrl("http://localhost:5233/uidhub?type=dashboard", {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets,
      })
      .withAutomaticReconnect()
      .build();
    let isStarted = false;
    connection
      .start()
      .then(() => {
        console.log("SignalR Connected - Dashboard");
        isStarted = true;
      })
      .catch((err) => console.error("SignalR Connection Error: ", err));
    connection.on("ReceiveUid", (uid: string) => {
      console.log("Received UID via SignalR: ", uid);
      toast.success(`Card Scanned: ${uid}`, { duration: 3000 });
      queryClient.invalidateQueries({ queryKey: ["cards"] });
    });
    connection.on("UnAssignedCard", (uid: string) => {
      console.log("Unassigned Card UID via SignalR: ", uid);
      toast.error(`Card Unassigned: ${uid}`, { duration: 3000 });
      queryClient.invalidateQueries({ queryKey: ["cards"] });
    });
    return () => {
      if (
        isStarted &&
        connection.state == signalR.HubConnectionState.Connected
      ) {
        connection.stop();
      }
    };
  }, [queryClient]);
  return null;
};
function MainLayout() {
  return (
    <div className="min-h-svh relative flex flex-col ">
      <SignalRProvider />
      <Topbar />
      <Outlet />
      <Toaster position="top-center" richColors />
    </div>
  );
}

export default MainLayout;
