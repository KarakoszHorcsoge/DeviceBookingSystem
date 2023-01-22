using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.models.Cards;

public class CardAddUpdateResponse : BaseRequestResponse{
    public CardGetResponse CardGet { get; set; }
}