import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import {
  createCityRequest,
  CreateCitySchema,
  type CreateCityType,
  getCitiesRequest,
  updateCityRequest,
} from "./CityDto";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { useState } from "react";
import { toast } from "sonner";
import axios from "axios";

export const getCitiesQuery = () => {
  return useQuery({
    queryKey: ["cities"],
    queryFn: getCitiesRequest,
  });
};
const resetValuesDefaults = {
  name: undefined,
  arName: undefined,
  provinceId: undefined,
};
const useCity = () => {
  const { data, isError } = getCitiesQuery();
  const form = useForm<CreateCityType>({
    resolver: zodResolver(CreateCitySchema),
  });
  const [selectedCity, setSelectedCity] = useState<number | null>(null);
  const [openDeleteModal, setOpenDeleteModal] = useState(false);
  const [openModal, setOpenModal] = useState(false);
  const queryClient = useQueryClient();
  const handleOpenEditModal = (id: number) => {
    const city = data?.find((city) => city.id === id);
    if (city) {
      form.reset({
        name: city.name,
        arName: city.arName,
        provinceId: city.provinceId,
      });
      setSelectedCity(id);
      setOpenModal(true);
    }
  };
  const handleOpenDeleteModal = (id: number) => {
    const city = data?.find((city) => city.id === id);
    if (city) {
      setSelectedCity(id);
      setOpenDeleteModal(true);
    }
  };
  const handleCloseModals = () => {
    setSelectedCity(null);
    setOpenDeleteModal(false);
    setOpenModal(false);
  };
  const handleOpenAddModal = () => {
    form.reset(resetValuesDefaults);
    setOpenModal(true);
  };
  const createCityMutation = useMutation({
    mutationFn: (data: CreateCityType) => createCityRequest(data),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["cities"] });
      handleCloseModals();
      toast.success("City created successfully");
    },
    onError: (error) => {
      if (axios.isAxiosError(error)) {
        toast.error(error.response?.data.message || "Failed to create city");
      } else {
        toast.error("Failed to create city");
      }
    },
  });
  const updateCityMutation = useMutation({
    mutationFn: (data: { id: number; citydata: CreateCityType }) =>
      updateCityRequest(data),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["cities"] });
      handleCloseModals();
      toast.success("City updated successfully");
    },
    onError: (error) => {
      if (axios.isAxiosError(error)) {
        toast.error(error.response?.data.message || "Failed to update city");
      } else {
        toast.error("Failed to update city");
      }
    },
  });
  const onSubmit = (data: CreateCityType) => {
    if (selectedCity) {
      updateCityMutation.mutate({ id: selectedCity, citydata: data });
    } else {
      createCityMutation.mutate(data);
    }
  };
  return {
    cities: data,
    isError,
    form,
    openDeleteModal,
    handleOpenEditModal,
    handleOpenDeleteModal,
    handleCloseModals,
    handleOpenAddModal,
    onSubmit,
    createCityMutation,
    updateCityMutation,
    setOpenDeleteModal,
    setOpenModal,
    openModal,
    selectedCity,
  };
};

export default useCity;
