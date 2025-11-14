public class CardDto
{
    public string Uid { get; set; } = null!;
    public ProvinceDto? Province { get; set; }

    public static CardDto FromEntity(Card card, Province? province = null)
    {
        return new CardDto
        {
            Uid = card.Uid,
            Province = province != null ? ProvinceDto.FromEntity(province) : null
        };
    }
    public static List<CardDto> FromEntities(List<Card> cards, List<Province> provinces)
    {
        return cards.Select(c => 
        {
            var province = provinces.FirstOrDefault(p => p.Id == c.ProvinceId);
            return FromEntity(c, province);
        }).ToList();
    }
}