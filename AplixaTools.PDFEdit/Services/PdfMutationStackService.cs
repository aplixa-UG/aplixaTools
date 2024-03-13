using AplixaTools.PDFEdit.Models;

namespace AplixaTools.PDFEdit.Services;

public class PdfMutationQueueService
{
    public List<PdfFile> Files = new();
    private readonly Queue<IPdfMutation> _mutationQueue = new();

    public List<PreviewPage> Previews = new();

    public event EventHandler<MutationQueuedEventArgs> PreviewUpdated;
    public event EventHandler MergeUpdateRequested;
    public event EventHandler StartLoadingRequested;

    public void QueueMutation(IPdfMutation mutation)
    {
        Console.WriteLine("Mutation Queued");
        Previews = mutation.MutatePreview(Previews);
        PreviewUpdated?.Invoke(
            this,
            new MutationQueuedEventArgs
            {
                Mutation = mutation,
                ComputedPreviews = Previews
            }
        );
        _mutationQueue.Enqueue(mutation);
        RequestMergeUpdate();
    }

    public List<PdfFile> ProcessMutations()
    {
        while (_mutationQueue.TryDequeue(out var mutation))
        {
            Files = mutation.Mutate(Files);
        }

        return Files;
    }

    public void RequestMergeUpdate()
    {
        MergeUpdateRequested?.Invoke(this, EventArgs.Empty);
    }

    public void RequestStartLoading()
    {
        StartLoadingRequested?.Invoke(this, EventArgs.Empty);
    }
}
