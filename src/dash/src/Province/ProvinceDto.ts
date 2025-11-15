import axiosInstance from "@/shared/utils/axiosInstance";
import imageUploadEndpoint from "@/shared/utils/imageUploadEndpoint";
import z from "zod";
export const EditProvinceSchema = z.object({
  name: z.string({ error: "Name is required" }).min(1).max(100),
  arName: z.string({ error: "Arabic Name is required" }).min(1).max(100),
  description: z.string().max(500).optional(),
  arDescription: z.string().max(500).optional(),
  image: z
    .union([z.string(), z.instanceof(File, { error: "Invalid file" })])
    .optional(),
  population: z.number().min(0).optional(),
  area: z.number().min(0).optional(),
});
export type EditProvinceDto = z.infer<typeof EditProvinceSchema>;
export interface EditProvinceRequestType {
  provinceId: number;
  data: EditProvinceDto;
}
export const EditProvinceRequest = async ({
  provinceId,
  data,
}: EditProvinceRequestType) => {
  try {
    if (data.image && data.image instanceof File) {
      const imageRes = await imageUploadEndpoint(data.image);
      data.image = imageRes.fileName;
    }
    const refinedData = {
      name: data.name,
      arName: data.arName,
      description: data.description,
      arDescription: data.arDescription,
      imageUrl: data.image,
      population: data.population,
      area: data.area,
    };

    const res = await axiosInstance.put(`/province/${provinceId}`, refinedData);
    return res.data;
  } catch (error) {
    return Promise.reject(error);
  }
};
