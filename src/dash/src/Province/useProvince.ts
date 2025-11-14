import axiosInstance from "@/shared/utils/axiosInstance";
import { useQuery } from "@tanstack/react-query";
interface City {
  id: number;
  name: string;
  arName: string;
}
interface Attraction {
  id: number;
  name: string;
  arName: string;
  description: string;
  arDescription: string;
  imageUrl: string;
}
interface Province {
  id: number;
  name: string;
  arName: string;
  area: number;
  description: string;
  arDescription: string;
  imageUrl: string;
  population: number;
  cities: City[];
  attractions: Attraction[];
}
export const getProvincesQuery = () => {
  return useQuery({
    queryKey: ["provinces"],
    queryFn: async () => {
      try {
        const res = await axiosInstance.get<Province[]>("/province");
        return res.data;
      } catch (error) {
        return Promise.reject(error);
      }
    },
  });
};

const useProvince = () => {
  const { data } = getProvincesQuery();
  return {
    provinces: data || [],
  };
};

export default useProvince;
