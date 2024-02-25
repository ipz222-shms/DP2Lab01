namespace DocumentsLibrary.Interfaces;

public interface ITax
{
    public ulong TaxIdentifier { get; }
    public DateTime? TaxCheckedOn { get; }
}
