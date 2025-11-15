import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import {
  assignProvinceToCardApi,
  getCardsApi,
  type AssignProvinceToCard,
} from "./CardDto";
import axios from "axios";
import { toast } from "sonner";

export const getCardsQuery = () => {
  return useQuery({
    queryKey: ["cards"],
    queryFn: getCardsApi,
  });
};

const useCards = () => {
  const { data, isError } = getCardsQuery();
  const queryClient = useQueryClient();
  const assignCardMutation = useMutation({
    mutationFn: async (data: AssignProvinceToCard) =>
      assignProvinceToCardApi(data),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["cards"] });
      toast.success("Province assigned to card successfully");
    },
    onError: (error) => {
      if (axios.isAxiosError(error)) {
        toast.error("Error occured while assigning province to card", {
          description: error.response?.data.message || error.message,
        });
      }
    },
  });
  return {
    cards: data,
    isError,
    assignCardMutation,
  };
};

export default useCards;
