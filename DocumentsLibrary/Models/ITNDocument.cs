using DocumentsLibrary.Interfaces;

namespace DocumentsLibrary.Models;

public class ITNDocument : Document, ITax, IQRCheck, IBarcodeCheck
{
    public ulong TaxIdentifier { get; private set; }
    public DateTime? TaxCheckedOn { get; private set; }
    
    public ITNDocument(ulong taxId, string firstname, string lastname, DateTime? taxChecked,
        string? surname = null) : base(taxId.ToString(), firstname, lastname, surname)
    {
        DocumentName = "Картка платника податків";
        TaxIdentifier = taxId;
        TaxCheckedOn = taxChecked;
    }

    public override string GetRunningTex()
    {
        var text = $"• Документ оновлено о {LoadedAt:t} | {LoadedAt:d} • ";
        if (TaxCheckedOn is null)
            text += "Не підтверджено";
        else
            text += "Перевірено";
        return text + " Державною податковою службою";
    }
    
    public Uri GetQR()
    {
        // Generate verification link (TAX WebService)
        return new Uri("https://google.com/");
    }

    public int GetBarcode()
    {
        // Generate verification code (TAX WebService)
        return Random.Shared.Next();
    }

    public override string ToString() =>
        $"{DocumentName}: {Number}\n\tРНОКПП\n\t{Lastname}\n\t{Firstname}{(Surname is null ? "" : $"\n\t{Surname}")}";
}
