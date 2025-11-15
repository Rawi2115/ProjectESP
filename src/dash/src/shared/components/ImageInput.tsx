import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Upload } from "lucide-react";
import React from "react";
import type { FieldErrors, FieldValues, Path } from "react-hook-form";
interface ImageInputProps<T extends FieldValues> {
  name: Path<T>;
  handleImageChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  imagePreview: string | null;
  errors: FieldErrors<T>;
}
function ImageInput<T extends FieldValues>({
  name,
  handleImageChange,
  imagePreview,
  errors,
}: ImageInputProps<T>) {
  return (
    <div className="space-y-2">
      <Label htmlFor={name} className="block text-sm font-medium text-gray-700">
        Image
      </Label>
      <div className="flex items-center">
        <Input
          type="file"
          accept="image/*"
          id={name}
          onChange={handleImageChange}
          name={name}
          className="hidden"
        />
        <Label
          htmlFor={name}
          className="cursor-pointer inline-flex items-center justify-center rounded-md text-sm font-medium ring-offset-background transition-colors focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-ring focus-visible:ring-offset-2 disabled:pointer-events-none disabled:opacity-50 bg-primary text-primary-foreground hover:bg-primary/90 h-10 px-4 py-2 "
        >
          <Upload className="ms-2 h-4 w-4" />
          Upload Image
        </Label>
        <span className="text-red-500 text-xs">
          {errors[name]?.message as string}
        </span>
      </div>
      {imagePreview && (
        <div className="mt-4">
          <Label>Preview:</Label>
          <div className="relative w-full h-48 mt-2 rounded-md overflow-hidden bg-gray-200">
            <img
              src={imagePreview}
              alt=""
              className="w-full h-full object-cover"
            />
          </div>
        </div>
      )}
    </div>
  );
}

export default ImageInput;
