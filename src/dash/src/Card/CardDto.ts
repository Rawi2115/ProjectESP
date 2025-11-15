import type { Province } from "@/Province/useProvince";
import axiosInstance from "@/shared/utils/axiosInstance";

interface Card {
  uid: string;
  province?: Province;
}
export interface AssignProvinceToCard {
  uid: string;
  provinceId: number;
}
export const getCardsApi = async (): Promise<Card[]> => {
  try {
    const res = await axiosInstance.get<Card[]>("/cards");
    return res.data;
  } catch (error) {
    return Promise.reject(error);
  }
};
export const assignProvinceToCardApi = async (
  data: AssignProvinceToCard
): Promise<void> => {
  try {
    const res = await axiosInstance.post<void>("/cards/assign-province", data);
    return res.data;
  } catch (error) {
    return Promise.reject(error);
  }
};
