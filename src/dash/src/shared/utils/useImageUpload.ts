import React, { useState } from "react";
import type {
  FieldValues,
  Path,
  PathValue,
  UseFormSetValue,
} from "react-hook-form";

interface props<T extends FieldValues> {
  setValue: UseFormSetValue<T>;
  name: Path<T>;
}

const useImageUpload = <T extends FieldValues>({
  setValue,
  name,
}: props<T>) => {
  const [imagePreview, setImagePreview] = useState<string | null>(null);
  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0];
    if (file) {
      const reader = new FileReader();
      reader.onloadend = () => {
        setImagePreview(reader.result as string);
      };
      setValue(name, file as PathValue<T, Path<T>>);
      reader.readAsDataURL(file);
    }
  };
  return { imagePreview, handleChange, setImagePreview };
};

export default useImageUpload;
