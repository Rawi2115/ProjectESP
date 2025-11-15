import React from "react";
import useCity from "./useCity";
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
import useProvince from "@/Province/useProvince";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { Button } from "@/components/ui/button";
import { Plus } from "lucide-react";
import {
  Card,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";

function CityView() {
  const {
    cities: data,
    isError,
    form,
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
  } = useCity();
  const { provinces } = useProvince();
  if (isError) {
    return <div>Error loading cities.</div>;
  }
  return (
    <div className="flex flex-col gap-2 px-36 py-10">
      <Dialog open={openModal} onOpenChange={setOpenModal}>
        <DialogContent>
          <DialogHeader>
            <DialogTitle>{selectedCity ? "Edit City" : "Add City"}</DialogTitle>
          </DialogHeader>
          <Form {...form}>
            <form className="flex flex-wrap gap-2">
              <FormField
                name="name"
                control={form.control}
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Name</FormLabel>
                    <Input placeholder="Name" {...field} />
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                name="arName"
                control={form.control}
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Arabic Name</FormLabel>
                    <Input placeholder="Arabic Name" {...field} />
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                name="provinceId"
                control={form.control}
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Province ID</FormLabel>
                    <Select
                      name={field.name}
                      value={String(field.value)}
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
              <div className="flex-1 flex items-end gap-2">
                <Button
                  type="button"
                  variant="destructive"
                  onClick={() => handleCloseModals()}
                >
                  Cancel
                </Button>
                <Button type="submit">Submit</Button>
              </div>
            </form>
          </Form>
        </DialogContent>
      </Dialog>
      <Button
        className="self-start"
        variant={"outline"}
        onClick={handleOpenAddModal}
      >
        <Plus className="me-2" />
        Add City
      </Button>
      <div className="grid grid-cols-1 md:grid-cols-2 gap-3 lg:grid-cols-3">
        {data?.map((city) => (
          <Card key={city.id}>
            <CardHeader>
              <CardTitle>
                {city.name} ({city.arName})
              </CardTitle>
              <CardDescription>Province ID: {city.provinceId}</CardDescription>
            </CardHeader>
          </Card>
        ))}
      </div>
    </div>
  );
}

export default CityView;
