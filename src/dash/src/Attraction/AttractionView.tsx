import useAttraction from "./useAttraction";
import useProvince from "@/Province/useProvince";
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
} from "@/components/ui/dialog";
import {
  Form,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { Textarea } from "@/components/ui/textarea";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { Button } from "@/components/ui/button";
import { Plus, Edit, Trash } from "lucide-react";
import {
  Card,
  CardAction,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import ImageInput from "@/shared/components/ImageInput";
import { baseURL } from "@/shared/utils/axiosInstance";

function AttractionView() {
  const {
    attractions,
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
    setOpenCreateModal,
    setOpenEditModal,
    setOpenDeleteModal,
    createImagePreview,
    editImagePreview,
    handleCreateImageChange,
    handleEditImageChange,
  } = useAttraction();

  const { provinces } = useProvince();

  if (isError) {
    return <div>Error loading attractions.</div>;
  }

  return (
    <div className="flex flex-col gap-4 px-20 py-10">
      {/* Create Modal */}
      <Dialog open={openCreateModal} onOpenChange={setOpenCreateModal}>
        <DialogContent className="max-w-2xl max-h-[90vh] overflow-y-auto">
          <DialogHeader>
            <DialogTitle>Create Attraction</DialogTitle>
          </DialogHeader>
          <Form {...createForm}>
            <form
              onSubmit={createForm.handleSubmit(onCreateSubmit)}
              className="flex flex-wrap gap-4"
            >
              <FormField
                name="name"
                control={createForm.control}
                render={({ field }) => (
                  <FormItem className="flex-1 min-w-[200px]">
                    <FormLabel>Name</FormLabel>
                    <Input placeholder="Name" {...field} />
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                name="arName"
                control={createForm.control}
                render={({ field }) => (
                  <FormItem className="flex-1 min-w-[200px]">
                    <FormLabel>Arabic Name</FormLabel>
                    <Input placeholder="Arabic Name" {...field} />
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                name="description"
                control={createForm.control}
                render={({ field }) => (
                  <FormItem className="w-full">
                    <FormLabel>Description</FormLabel>
                    <Textarea placeholder="Description" {...field} />
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                name="arDescription"
                control={createForm.control}
                render={({ field }) => (
                  <FormItem className="w-full">
                    <FormLabel>Arabic Description</FormLabel>
                    <Textarea placeholder="Arabic Description" {...field} />
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                name="location"
                control={createForm.control}
                render={({ field }) => (
                  <FormItem className="flex-1 min-w-[200px]">
                    <FormLabel>Location</FormLabel>
                    <Input placeholder="Location" {...field} />
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                name="provinceId"
                control={createForm.control}
                render={({ field }) => (
                  <FormItem className="flex-1 min-w-[200px]">
                    <FormLabel>Province</FormLabel>
                    <Select
                      name={field.name}
                      value={field.value ? String(field.value) : ""}
                      onValueChange={(val) => {
                        field.onChange(Number(val));
                      }}
                    >
                      <SelectTrigger className="w-full">
                        <SelectValue placeholder="Select Province" />
                      </SelectTrigger>
                      <SelectContent position="item-aligned">
                        {provinces?.map((province) => (
                          <SelectItem
                            key={province.id}
                            value={String(province.id)}
                          >
                            {province.name}
                          </SelectItem>
                        ))}
                      </SelectContent>
                    </Select>
                    <FormMessage />
                  </FormItem>
                )}
              />
              <div className="w-full">
                <ImageInput
                  imagePreview={createImagePreview}
                  handleImageChange={handleCreateImageChange}
                  errors={createForm.formState.errors}
                  name="image"
                />
              </div>
              <div className="flex items-end w-full gap-2">
                <Button
                  type="button"
                  variant="destructive"
                  onClick={handleCloseModals}
                >
                  Cancel
                </Button>
                <Button type="submit">Create</Button>
              </div>
            </form>
          </Form>
        </DialogContent>
      </Dialog>

      {/* Edit Modal */}
      <Dialog open={openEditModal} onOpenChange={setOpenEditModal}>
        <DialogContent className="max-w-2xl max-h-[90vh] overflow-y-auto">
          <DialogHeader>
            <DialogTitle>Edit Attraction</DialogTitle>
          </DialogHeader>
          <Form {...editForm}>
            <form
              onSubmit={editForm.handleSubmit(onEditSubmit)}
              className="flex flex-wrap gap-4"
            >
              <FormField
                name="name"
                control={editForm.control}
                render={({ field }) => (
                  <FormItem className="flex-1 min-w-[200px]">
                    <FormLabel>Name</FormLabel>
                    <Input placeholder="Name" {...field} />
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                name="arName"
                control={editForm.control}
                render={({ field }) => (
                  <FormItem className="flex-1 min-w-[200px]">
                    <FormLabel>Arabic Name</FormLabel>
                    <Input placeholder="Arabic Name" {...field} />
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                name="description"
                control={editForm.control}
                render={({ field }) => (
                  <FormItem className="w-full">
                    <FormLabel>Description</FormLabel>
                    <Textarea placeholder="Description" {...field} />
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                name="arDescription"
                control={editForm.control}
                render={({ field }) => (
                  <FormItem className="w-full">
                    <FormLabel>Arabic Description</FormLabel>
                    <Textarea placeholder="Arabic Description" {...field} />
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                name="location"
                control={editForm.control}
                render={({ field }) => (
                  <FormItem className="flex-1 min-w-[200px]">
                    <FormLabel>Location</FormLabel>
                    <Input placeholder="Location" {...field} />
                    <FormMessage />
                  </FormItem>
                )}
              />
              <div className="w-full">
                <ImageInput
                  imagePreview={editImagePreview}
                  handleImageChange={handleEditImageChange}
                  errors={editForm.formState.errors}
                  name="image"
                />
              </div>
              <div className="flex items-end w-full gap-2">
                <Button
                  type="button"
                  variant="destructive"
                  onClick={handleCloseModals}
                >
                  Cancel
                </Button>
                <Button type="submit">Save Changes</Button>
              </div>
            </form>
          </Form>
        </DialogContent>
      </Dialog>

      {/* Delete Confirmation Dialog */}
      <Dialog open={openDeleteModal} onOpenChange={setOpenDeleteModal}>
        <DialogContent>
          <DialogHeader>
            <DialogTitle>Are you sure?</DialogTitle>
          </DialogHeader>
          <div className="py-4">
            <p className="text-sm text-muted-foreground">
              This action cannot be undone. This will permanently delete the
              attraction.
            </p>
          </div>
          <div className="flex justify-end gap-2">
            <Button variant="outline" onClick={handleCloseModals}>
              Cancel
            </Button>
            <Button variant="destructive" onClick={onDeleteConfirm}>
              Delete
            </Button>
          </div>
        </DialogContent>
      </Dialog>

      {/* Add Button */}
      <Button
        className="self-start"
        variant="outline"
        onClick={handleOpenCreateModal}
      >
        <Plus className="me-2" />
        Add Attraction
      </Button>

      {/* Attractions Grid */}
      <div className="grid grid-cols-1 md:grid-cols-2 gap-4 lg:grid-cols-3">
        {attractions?.map((attraction) => (
          <Card key={attraction.id}>
            <CardHeader className="mb-auto">
              <CardTitle>
                {attraction.name} | {attraction.arName}
              </CardTitle>
              <CardDescription>{attraction.description}</CardDescription>
              <CardDescription className="text-xs text-muted-foreground">
                Location: {attraction.location}
              </CardDescription>
              <CardAction className="flex gap-2">
                <Button
                  variant="outline"
                  size="sm"
                  onClick={() => handleOpenEditModal(attraction.id)}
                >
                  <Edit className="h-4 w-4 me-1" />
                  Edit
                </Button>
                <Button
                  variant="destructive"
                  size="sm"
                  onClick={() => handleOpenDeleteModal(attraction.id)}
                >
                  <Trash className="h-4 w-4 me-1" />
                  Delete
                </Button>
              </CardAction>
            </CardHeader>
            <CardContent>
              <div className="relative w-full h-48 mt-auto rounded-md overflow-hidden bg-gray-200">
                {attraction.imageUrl && (
                  <img
                    src={`${baseURL}/${attraction.imageUrl}`}
                    alt={attraction.name}
                    className="w-full h-full object-cover"
                  />
                )}
              </div>
            </CardContent>
          </Card>
        ))}
      </div>
    </div>
  );
}

export default AttractionView;
