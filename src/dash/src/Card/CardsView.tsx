import useCards from "./useCards";
import { Card, CardHeader, CardTitle, CardAction } from "@/components/ui/card";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import useProvince from "@/Province/useProvince";
import { cn } from "@/lib/utils";
function CardsView() {
  const { cards, isError, assignCardMutation } = useCards();
  const { provinces } = useProvince();
  return (
    <div className="py-10 px-36">
      {isError && <div>Error loading cards.</div>}
      <div
        className={cn(
          "grid ",
          cards?.length === 0 && "justify-items-center",
          cards &&
            cards?.length > 0 &&
            "grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4"
        )}
      >
        {cards?.length === 0 && <div>No cards available.</div>}
        {cards?.map((card) => (
          <Card key={card.uid} className="shadow-md">
            <CardHeader className="items-center flex">
              <CardTitle>Card:{card.uid}</CardTitle>
              <CardAction>
                <div className="flex items-center gap-2">
                  Province:{" "}
                  <Select
                    defaultValue="No province"
                    value={card.province ? String(card.province.id) : ""}
                    onValueChange={(value) => {
                      assignCardMutation.mutate({
                        uid: card.uid,
                        provinceId: Number(value),
                      });
                    }}
                  >
                    <SelectTrigger>
                      <SelectValue placeholder="Province"></SelectValue>
                    </SelectTrigger>
                    <SelectContent>
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
                </div>
              </CardAction>
            </CardHeader>
          </Card>
        ))}
      </div>
    </div>
  );
}

export default CardsView;
