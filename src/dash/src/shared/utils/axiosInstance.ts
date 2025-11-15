import axios from "axios";
export const baseURL =
  (import.meta.env.VITE_API_BASE_URL as string) || "http://localhost:5233";
const axiosInstance = axios.create({
  baseURL: baseURL,
  headers: {
    "Content-Type": "application/json",
  },
});
export default axiosInstance;
