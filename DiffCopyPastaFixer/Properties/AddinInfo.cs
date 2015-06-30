using System;
using Mono.Addins;
using Mono.Addins.Description;

[assembly:Addin (
	"DiffCopyPastaFixer", 
	Namespace = "DiffCopyPastaFixer",
	Version = "1.0"
)]

[assembly:AddinName ("DiffCopyPastaFixer")]
[assembly:AddinAuthor ("Marius Ungureanu")]
[assembly:AddinCategory ("Source Editor Extensions")]
[assembly:AddinUrl ("http://monodevelop.com")]
[assembly:AddinDescription ("Removes leading diff lines from text. Useful when manually applying patches.")]
[assembly:AddinAuthor ("Marius Ungureanu")]

