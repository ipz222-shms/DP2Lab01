using System.Text;
using DocumentsLibrary.Models;

namespace DocumentsLibrary;

public class DocumentsContainer
{
    private readonly List<Document> _documents = new();

    public List<Document> Documents => new(_documents);

    public void Add(Document doc)
    {
        if (!_documents.Contains(doc))
            _documents.Add(doc);
    }

    public void Remove(Document doc)
    {
        if (_documents.Contains(doc))
            _documents.Remove(doc);
    }

    public void Move(Document doc, int position)
    {
        position--;
        if (position < 0 || position >= _documents.Count)
            return;
        if (!_documents.Contains(doc))
            return;
        _documents.Remove(doc);
        _documents.Insert(position, doc);
    }

    public override string ToString()
    {
        StringBuilder result = new("Документи:");
        for (var i = 1; i <= _documents.Count; i++)
            result.Append($"\n\t{i}. {_documents[i-1].DocumentName}");
        return result.ToString();
    }
}
