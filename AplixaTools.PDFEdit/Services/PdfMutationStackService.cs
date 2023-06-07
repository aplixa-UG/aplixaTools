using AplixaTools.PDFEdit.Models;

namespace AplixaTools.PDFEdit.Services;

public class PdfMutationQueueService
{
    public List<PdfFile> Files = new();
    private Queue<IPdfMutation> _mutationQueue = new();

    public List<PreviewPage> Previews = new();
    public event EventHandler<MutationQueuedEventArgs> PreviewUpdated;

    public void QuequeMutation(IPdfMutation mutation)
    {
        Console.WriteLine($"Queueing {mutation}");
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
    }

    public List<PdfFile> ProcessMutations()
    {
        while (_mutationQueue.TryDequeue(out var mutation))
        {
            Files = mutation.Mutate(Files);
        }

        return Files;
    }
}
