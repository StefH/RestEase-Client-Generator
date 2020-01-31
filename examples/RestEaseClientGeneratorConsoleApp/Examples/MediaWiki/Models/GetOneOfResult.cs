using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MediaWiki.Models
{
    public class GetOneOfResult
    {
        public Normalization Normalization { get; set; }

        public QueryResult QueryResult { get; set; }

        public RedirectsQuery RedirectsQuery { get; set; }

        public ExportQuery ExportQuery { get; set; }

        public PagesLists PagesLists { get; set; }
    }
}
