using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MediaWikiRaml.Models
{
    public class GetAnyOfResult
    {
        public Normalization Normalization { get; set; }

        public QueryResult QueryResult { get; set; }

        public RedirectsQuery RedirectsQuery { get; set; }

        public ExportQuery ExportQuery { get; set; }

        public PagesLists PagesLists { get; set; }
    }
}
