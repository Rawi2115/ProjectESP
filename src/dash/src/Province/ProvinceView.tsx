import {
  Card,
  CardAction,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import useProvince from "./useProvince";
import { Button } from "@/components/ui/button";
import { baseURL } from "@/shared/utils/axiosInstance";
import {
  Form,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Textarea } from "@/components/ui/textarea";
import ImageInput from "@/shared/components/ImageInput";
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
} from "@/components/ui/dialog";
import { Input } from "@/components/ui/input";

function ProvinceView() {
  const {
    provinces,
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
  } = useProvince();
  if (isError) {
    return <div>Error loading provinces.</div>;
  }
  return (
    <div className="grid grid-cols-1 p-4 gap-2 md:grid-cols-2 lg:grid-cols-3">
      {provinces.map((province) => (
        <Card key={province.id}>
          <CardHeader className="mb-auto">
            <CardTitle>
              {province.name} | {province.arName}
            </CardTitle>
            <CardDescription>
              {province.description} | {province.arDescription}
            </CardDescription>
            <CardAction>
              <Button
                variant={"outline"}
                onClick={() => handleEditProvince(province.id)}
              >
                Edit Province
              </Button>
            </CardAction>
          </CardHeader>
          <CardContent>
            <div className="relative w-full h-48 mt-auto rounded-md overflow-hidden bg-gray-200">
              <img
                src={`${baseURL}/${province.imageUrl}`}
                alt=""
                className="w-full h-full object-cover"
              />
            </div>
          </CardContent>
        </Card>
      ))}
      <Dialog open={openEditModal} onOpenChange={setOpenEditModal}>
        <DialogContent>
          <DialogHeader>
            <DialogTitle>Edit Province</DialogTitle>
          </DialogHeader>
          <Form {...form}>
            <form
              onSubmit={form.handleSubmit(onSubmit)}
              className="flex flex-wrap items-center gap-2"
            >
              <FormField
                control={form.control}
                name="name"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Province Name</FormLabel>
                    <Input {...field} />
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                control={form.control}
                name="arName"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Province Arabic Name</FormLabel>
                    <Input {...field} />
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                control={form.control}
                name="description"
                render={({ field, fieldState }) => (
                  <FormItem>
                    <FormLabel>Province Description</FormLabel>
                    <Textarea {...field} aria-invalid={fieldState.invalid} />
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                control={form.control}
                name="arDescription"
                render={({ field, fieldState }) => (
                  <FormItem>
                    <FormLabel>Province Arabic Description</FormLabel>
                    <Textarea {...field} aria-invalid={fieldState.invalid} />
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                control={form.control}
                name="population"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Population</FormLabel>
                    <Input type="number" {...field} />
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                control={form.control}
                name="area"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Area (sq km)</FormLabel>
                    <Input type="number" {...field} />
                    <FormMessage />
                  </FormItem>
                )}
              />
              <div className="flex-1">
                <ImageInput
                  imagePreview={imagePreview}
                  handleImageChange={handleChange}
                  errors={form.formState.errors}
                  name="image"
                />
              </div>

              <div className="flex items-end w-full gap-2">
                <Button variant="destructive" onClick={closeEditModal}>
                  Cancel
                </Button>
                <Button type="submit">Save Changes</Button>
              </div>
            </form>
          </Form>
        </DialogContent>
      </Dialog>
    </div>
  );
}

export default ProvinceView;
