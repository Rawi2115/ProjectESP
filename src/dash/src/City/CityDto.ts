import axiosInstance from "@/shared/utils/axiosInstance";
import z from "zod";

interface City {
  id: number;
  name: string;
  arName: string;
  provinceId: number;
}
export const CreateCitySchema = z.object({
  name: z.string().min(1, "Name is required"),
  arName: z.string().min(1, "Arabic Name is required"),
  provinceId: z
    .number()
    .int()
    .positive("Province ID must be a positive integer"),
});
export type CreateCityType = z.infer<typeof CreateCitySchema>;

export const createCityRequest = async (data: CreateCityType) => {
  try {
    const res = await axiosInstance.post<City>("/city", data);
    return res.data;
  } catch (error) {
    return Promise.reject(error);
  }
};
export const getCitiesRequest = async () => {
  try {
    const res = await axiosInstance.get<City[]>("/city");
    return res.data;
  } catch (error) {
    return Promise.reject(error);
  }
};
export const getCityByIdRequest = async (id: number) => {
  try {
    const res = await axiosInstance.get<City>(`/city/${id}`);
    return res.data;
  } catch (error) {
    return Promise.reject(error);
  }
};

export const deleteCityRequest = async (id: number) => {
  try {
    const res = await axiosInstance.delete<void>(`/city/${id}`);
    return res.data;
  } catch (error) {
    return Promise.reject(error);
  }
};

export type UpdateCityType = {
  id: number;
  citydata: CreateCityType;
};
export const updateCityRequest = async (data: UpdateCityType) => {
  try {
    const refinedData = {
      name: data.citydata.name,
      arName: data.citydata.arName,
      provinceId: data.citydata.provinceId,
    };
    const res = await axiosInstance.put<City>(`/city/${data.id}`, refinedData);
    return res.data;
  } catch (error) {
    return Promise.reject(error);
  }
};
