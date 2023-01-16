using System;
using System.Collections.Generic;

namespace Anki.Models;

public partial class Account
{
    public long Id { get; set; }

    public string Login { get; set; } = null!;

    public long PasswordHash { get; set; }

    public virtual ICollection<Deck> Decks { get; } = new List<Deck>();
}
