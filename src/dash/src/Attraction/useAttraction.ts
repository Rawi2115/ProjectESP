import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import {
  createAttractionRequest,
  CreateAttractionSchema,
  type CreateAttractionType,
  EditAttractionSchema,
  type EditAttractionType,
  getAttractionsRequest,
  updateAttractionRequest,
  deleteAttractionRequest,
} from "./AttractionDto";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { useState } from "react";
import { toast } from "sonner";
import axios from "axios";
import useImageUpload from "@/shared/utils/useImageUpload";
import { baseURL } from "@/shared/utils/axiosInstance";

export const getAttractionsQuery = () => {
  return useQuery({
    queryKey: ["attractions"],
    queryFn: getAttractionsRequest,
  });
};

const useAttraction = () => {
  const { data, isError } = getAttractionsQuery();
  const createForm = useForm<CreateAttractionType>({
    resolver: zodResolver(CreateAttractionSchema),
  });
  const editForm = useForm<EditAttractionType>({
    resolver: zodResolver(EditAttractionSchema),
  });

  const [selectedAttraction, setSelectedAttraction] = useState<number | null>(
    null
  );
  const [openCreateModal, setOpenCreateModal] = useState(false);
  const [openEditModal, setOpenEditModal] = useState(false);
  const [openDeleteModal, setOpenDeleteModal] = useState(false);

  const {
    imagePreview: createImagePreview,
    handleChange: handleCreateImageChange,
    setImagePreview: setCreateImagePreview,
  } = useImageUpload({
    setValue: createForm.setValue,
    name: "image",
  });

  const {
    imagePreview: editImagePreview,
    handleChange: handleEditImageChange,
    setImagePreview: setEditImagePreview,
  } = useImageUpload({
    setValue: editForm.setValue,
    name: "image",
  });

  const queryClient = useQueryClient();

  const handleOpenCreateModal = () => {
    createForm.reset({
      name: "",
      arName: "",
      description: "",
      arDescription: "",
      location: "",
      image: undefined,
      provinceId: undefined,
    });
    setCreateImagePreview(null);
    setOpenCreateModal(true);
  };

  const handleOpenEditModal = (id: number) => {
    const attraction = data?.find((attr) => attr.id === id);
    if (attraction) {
      editForm.reset({
        name: attraction.name,
        arName: attraction.arName,
        description: attraction.description,
        arDescription: attraction.arDescription,
        location: attraction.location,
        image: attraction.imageUrl,
      });
      if (attraction.imageUrl) {
        setEditImagePreview(`${baseURL}/${attraction.imageUrl}`);
      }
      setSelectedAttraction(id);
      setOpenEditModal(true);
    }
  };

  const handleOpenDeleteModal = (id: number) => {
    setSelectedAttraction(id);
    setOpenDeleteModal(true);
  };

  const handleCloseModals = () => {
    setSelectedAttraction(null);
    setOpenCreateModal(false);
    setOpenEditModal(false);
    setOpenDeleteModal(false);
    setCreateImagePreview(null);
    setEditImagePreview(null);
  };

  const createAttractionMutation = useMutation({
    mutationFn: (data: CreateAttractionType) => createAttractionRequest(data),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["attractions"] });
      handleCloseModals();
      toast.success("Attraction created successfully");
    },
    onError: (error) => {
      if (axios.isAxiosError(error)) {
        toast.error(
          error.response?.data.message || "Failed to create attraction"
        );
      } else {
        toast.error("Failed to create attraction");
      }
    },
  });

  const updateAttractionMutation = useMutation({
    mutationFn: (data: { id: number; data: EditAttractionType }) =>
      updateAttractionRequest(data),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["attractions"] });
      handleCloseModals();
      toast.success("Attraction updated successfully");
    },
    onError: (error) => {
      if (axios.isAxiosError(error)) {
        toast.error(
          error.response?.data.message || "Failed to update attraction"
        );
      } else {
        toast.error("Failed to update attraction");
      }
    },
  });

  const deleteAttractionMutation = useMutation({
    mutationFn: (id: number) => deleteAttractionRequest(id),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["attractions"] });
      handleCloseModals();
      toast.success("Attraction deleted successfully");
    },
    onError: (error) => {
      if (axios.isAxiosError(error)) {
        toast.error(
          error.response?.data.message || "Failed to delete attraction"
        );
      } else {
        toast.error("Failed to delete attraction");
      }
    },
  });

  const onCreateSubmit = (data: CreateAttractionType) => {
    createAttractionMutation.mutate(data);
  };

  const onEditSubmit = (data: EditAttractionType) => {
    if (selectedAttraction) {
      updateAttractionMutation.mutate({ id: selectedAttraction, data });
    }
  };

  const onDeleteConfirm = () => {
    if (selectedAttraction) {
      deleteAttractionMutation.mutate(selectedAttraction);
    }
  };

  return {
    attractions: data,
    isError,
    createForm,
    editForm,
    openCreateModal,
    openEditModal,
    openDeleteModal,
    handleOpenCreateModal,
    handleOpenEditModal,
    handleOpenDeleteModal,
    handleCloseModals,
    onCreateSubmit,
    onEditSubmit,
    onDeleteConfirm,
    createAttractionMutation,
    updateAttractionMutation,
    deleteAttractionMutation,
    selectedAttraction,
    setOpenCreateModal,
    setOpenEditModal,
    setOpenDeleteModal,
    createImagePreview,
    editImagePreview,
    handleCreateImageChange,
    handleEditImageChange,
  };
};

export default useAttraction;
