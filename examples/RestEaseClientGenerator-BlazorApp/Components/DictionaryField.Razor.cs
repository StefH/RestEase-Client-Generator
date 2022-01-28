using System;
using System.Linq;
using RestEaseClientGeneratorBlazorApp.Models;

namespace RestEaseClientGeneratorBlazorApp.Components;

public partial class DictionaryField
{
    void Add()
    {
        Value.Add(new DictionaryItem { Id = Guid.NewGuid(), Key = string.Empty, Value = string.Empty });
    }

    void Remove(Guid id)
    {
        var item = Value.FirstOrDefault(i => i.Id == id);
        if (item is not null)
        {
            Value.Remove(item);
        }
    }
}