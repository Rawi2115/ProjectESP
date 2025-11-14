import { createBrowserRouter, RouterProvider } from "react-router";
import MainLayout from "./MainLayout";
import Home from "./Home";
import ProvinceView from "./Province/ProvinceView";

const router = createBrowserRouter([
  {
    path: "/",
    element: <MainLayout />,
    children: [
      {
        path: "/",
        element: <Home />,
      },
      {
        path: "/provinces",
        element: <ProvinceView />,
      },
    ],
  },
]);
function App() {
  return <RouterProvider router={router} />;
}

export default App;
