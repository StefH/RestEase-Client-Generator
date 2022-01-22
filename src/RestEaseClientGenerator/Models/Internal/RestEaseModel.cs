namespace RestEaseClientGenerator.Models.Internal;

public class RestEaseModel
{
    public string Namespace { get; set; }

    public string ClassName { get; set; }

    public ICollection<string>? Properties { get; set; }

    public IList<string> Extends = new List<string>();
}