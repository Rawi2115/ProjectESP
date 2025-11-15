import axiosInstance, { baseURL } from "@/shared/utils/axiosInstance";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { useForm } from "react-hook-form";
import {
  type EditProvinceDto,
  EditProvinceRequest,
  type EditProvinceRequestType,
  EditProvinceSchema,
} from "./ProvinceDto";
import { zodResolver } from "@hookform/resolvers/zod";
import { useState } from "react";
import axios from "axios";
import { toast } from "sonner";
import useImageUpload from "@/shared/utils/useImageUpload";
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
  const form = useForm<EditProvinceDto>({
    resolver: zodResolver(EditProvinceSchema),
  });
  const [selectedProvince, setSelectedProvince] = useState<number | null>(null);
  const { imagePreview, setImagePreview, handleChange } = useImageUpload({
    setValue: form.setValue,
    name: "image",
  });
  const [openEditModal, setOpenEditModal] = useState(false);
  const queryClient = useQueryClient();
  const mutateEditProvince = useMutation({
    mutationFn: async (data: EditProvinceRequestType) =>
      EditProvinceRequest(data),
    onSuccess: () => {
      setOpenEditModal(false);
      setSelectedProvince(null);
      queryClient.invalidateQueries({ queryKey: ["provinces"] });
    },
    onError: (error) => {
      console.error("Error editing province:", error);
      if (axios.isAxiosError(error)) {
        toast.error("Error editing province", {
          description: error.response?.data?.message || error.message,
        });
      }
    },
  });

  const { data, isError } = getProvincesQuery();
  const handleEditProvince = (provinceId: number) => {
    const province = data?.find((p) => p.id === provinceId) || null;
    if (province) {
      if (typeof province.imageUrl === "string") {
        setImagePreview(`${baseURL}${province.imageUrl}`);
      }
      form.reset({
        name: province.name,
        arName: province.arName,
        description: province.description,
        arDescription: province.arDescription,
        image: province.imageUrl,
        population: province.population,
        area: province.area,
      });
      setSelectedProvince(provinceId);
      setOpenEditModal(true);
    }
  };
  const closeEditModal = () => {
    setOpenEditModal(false);
    setSelectedProvince(null);
    setImagePreview(null);
  };
  const onSubmit = (data: EditProvinceDto) => {
    if (!selectedProvince) return;
    mutateEditProvince.mutate({
      provinceId: selectedProvince,
      data,
    });
  };

  return {
    provinces: data || [],
    form,
    selectedProvince,
    setSelectedProvince,
    openEditModal,
    setOpenEditModal,
    onSubmit,
    imagePreview,
    handleChange,
    setImagePreview,
    isError,
    handleEditProvince,
    closeEditModal,
  };
};

export default useProvince;
