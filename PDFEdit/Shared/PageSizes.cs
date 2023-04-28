﻿using iTextSharp.text;

namespace PDFEdit.Shared;

public static class PageSizes
{
    public static readonly Dictionary<string, Rectangle> Sizes = new()
    {
        { "A0", PageSize.A0 },
        { "A1", PageSize.A1 },
        { "A2", PageSize.A2 },
        { "A3", PageSize.A3 },
        { "A4", PageSize.A4 },
        { "A5", PageSize.A5 },
        { "A6", PageSize.A6 },
        { "A7", PageSize.A7 },
        { "A8", PageSize.A8 },
        { "A9", PageSize.A9 },
        { "A10", PageSize.A10 },
        { "ArchA", PageSize.ArchA },
        { "ArchB", PageSize.ArchB },
        { "ArchC", PageSize.ArchC },
        { "ArchD", PageSize.ArchD },
        { "ArchE", PageSize.ArchE },
        { "B0", PageSize.B0 },
        { "B1", PageSize.B1 },
        { "B10", PageSize.B10 },
        { "B2", PageSize.B2 },
        { "B3", PageSize.B3 },
        { "B4", PageSize.B4 },
        { "B5", PageSize.B5 },
        { "B6", PageSize.B6 },
        { "B7", PageSize.B7 },
        { "B8", PageSize.B8 },
        { "B9", PageSize.B9 },
        { "CrownOctavo", PageSize.CrownOctavo },
        { "CrownQuarto", PageSize.CrownQuarto },
        { "DemyOctavo", PageSize.DemyOctavo },
        { "DemyQuarto", PageSize.DemyQuarto },
        { "Executive", PageSize.Executive },
        { "Flsa", PageSize.Flsa },
        { "Flse", PageSize.Flse },
        { "Halfletter", PageSize.Halfletter },
        { "Id1", PageSize.Id1 },
        { "Id2", PageSize.Id2 },
        { "Id3", PageSize.Id3 },
        { "LargeCrownOctavo", PageSize.LargeCrownOctavo },
        { "LargeCrownQuarto", PageSize.LargeCrownQuarto },
        { "Ledger", PageSize.Ledger },
        { "Legal", PageSize.Legal },
        { "Letter", PageSize.Letter },
        { "Note", PageSize.Note },
        { "PenguinLargePaperback", PageSize.PenguinLargePaperback },
        { "PenguinSmallPaperback", PageSize.PenguinSmallPaperback },
        { "Postcard", PageSize.Postcard },
        { "RoyalOctavo", PageSize.RoyalOctavo },
        { "RoyalQuarto", PageSize.RoyalQuarto },
        { "SmallPaperback", PageSize.SmallPaperback },
        { "Tabloid", PageSize.Tabloid }
    };
}
