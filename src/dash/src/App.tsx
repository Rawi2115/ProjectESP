import { createBrowserRouter, RouterProvider } from "react-router";
import MainLayout from "./MainLayout";
import Home from "./Home";
import ProvinceView from "./Province/ProvinceView";
import CityView from "./City/CityView";

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
      {
        path: "/cities",
        element: <CityView />,
      },
    ],
  },
]);
function App() {
  return <RouterProvider router={router} />;
}

export default App;
