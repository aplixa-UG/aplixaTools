namespace AplixaTools.PDFEdit.Models;

public class MutationQueuedEventArgs : EventArgs
{
    public IPdfMutation Mutation { get; set; }
    public IEnumerable<PreviewPage> ComputedPreviews { get; set; }
}
