import axiosInstance from "@/shared/utils/axiosInstance";
import imageUploadEndpoint from "@/shared/utils/imageUploadEndpoint";
import z from "zod";

export interface Attraction {
  id: number;
  name: string;
  arName: string;
  description: string;
  arDescription: string;
  location?: string;
  imageUrl: string;
  provinceId: number;
}

export const CreateAttractionSchema = z.object({
  name: z.string().min(1, "Name is required").max(100),
  arName: z.string().min(1, "Arabic Name is required").max(100),
  description: z.string().min(1, "Description is required").max(500),
  arDescription: z.string().max(500).optional(),
  location: z.string().optional(),
  image: z
    .union([z.string(), z.instanceof(File, { message: "Invalid file" })])
    .optional(),
  provinceId: z
    .number()
    .int()
    .positive("Province ID must be a positive integer"),
});

export type CreateAttractionType = z.infer<typeof CreateAttractionSchema>;

export const EditAttractionSchema = z.object({
  name: z.string().min(1, "Name is required").max(100),
  arName: z.string().min(1, "Arabic Name is required").max(100),
  description: z.string().min(1, "Description is required").max(500),
  arDescription: z.string().max(500).optional(),
  location: z.string().optional(),
  image: z
    .union([z.string(), z.instanceof(File, { message: "Invalid file" })])
    .optional(),
});

export type EditAttractionType = z.infer<typeof EditAttractionSchema>;

export const createAttractionRequest = async (data: CreateAttractionType) => {
  try {
    let imageUrl = "";
    if (data.image && data.image instanceof File) {
      const imageRes = await imageUploadEndpoint(data.image);
      imageUrl = imageRes.fileName;
    }
    console.log("Data before refine", data);

    const refinedData = {
      name: data.name,
      arName: data.arName,
      description: data.description,
      arDescription: data.arDescription,
      location: data.location,
      imageUrl: imageUrl,
      provinceId: data.provinceId,
    };

    console.log("Refined data before sending", refinedData);
    const res = await axiosInstance.post<Attraction>(
      "/attraction",
      refinedData
    );
    return res.data;
  } catch (error) {
    return Promise.reject(error);
  }
};

export const getAttractionsRequest = async () => {
  try {
    const res = await axiosInstance.get<Attraction[]>("/attraction");
    return res.data;
  } catch (error) {
    return Promise.reject(error);
  }
};

export const getAttractionByIdRequest = async (id: number) => {
  try {
    const res = await axiosInstance.get<Attraction>(`/attraction/${id}`);
    return res.data;
  } catch (error) {
    return Promise.reject(error);
  }
};

export const deleteAttractionRequest = async (id: number) => {
  try {
    const res = await axiosInstance.delete<void>(`/attraction/${id}`);
    return res.data;
  } catch (error) {
    return Promise.reject(error);
  }
};

export interface UpdateAttractionRequestType {
  id: number;
  data: EditAttractionType;
}

export const updateAttractionRequest = async ({
  id,
  data,
}: UpdateAttractionRequestType) => {
  try {
    let imageUrl = typeof data.image === "string" ? data.image : "";
    if (data.image && data.image instanceof File) {
      const imageRes = await imageUploadEndpoint(data.image);
      imageUrl = imageRes.fileName;
    }

    const refinedData = {
      name: data.name,
      arName: data.arName,
      description: data.description,
      arDescription: data.arDescription,
      location: data.location,
      imageUrl: imageUrl,
    };

    const res = await axiosInstance.put<Attraction>(
      `/attraction/${id}`,
      refinedData
    );
    return res.data;
  } catch (error) {
    return Promise.reject(error);
  }
};
