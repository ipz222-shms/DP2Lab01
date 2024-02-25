using DocumentsLibrary.Models;

namespace DocumentsLibrary.Interfaces;

public interface IRecord
{
    public string RecordNumber { get; }

    public Document GetRecordDocument();
}
