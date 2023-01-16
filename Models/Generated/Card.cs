using System;
using System.Collections.Generic;

namespace Anki.Models;

public partial class Card
{
    public long Id { get; set; }

    public long DeckId { get; set; }

    public string? FrontContent { get; set; }

    public string? BackContent { get; set; }

    public string? TimeToShow { get; set; }

    public long? LastPeriodRepeat { get; set; }

    public virtual Deck Deck { get; set; } = null!;
}
