using System;
using System.Collections.Generic;

namespace Anki.Models;

public partial class Deck
{
    public long Id { get; set; }

    public long AccountId { get; set; }

    public string Name { get; set; } = null!;

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<Card> Cards { get; } = new List<Card>();
}
