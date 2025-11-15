import axiosInstance from "./axiosInstance";

const imageUploadEndpoint = async (file: File) => {
  const formData = new FormData();
  formData.append("file", file);
  try {
    const res = await axiosInstance.post("/api/images/upload", formData, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });
    return res.data;
  } catch (error) {
    return Promise.reject(error);
  }
};

export default imageUploadEndpoint;
