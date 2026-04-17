namespace SampleCarousel.Controls;

/// <summary>
/// Code-behind for StepDataCarouselView.
/// Mirrors the debounce scroll-snap logic from the original XCApp.Easyfit control.
/// </summary>
public partial class StepDataCarouselView : ContentView, IDisposable
{
    private CancellationTokenSource? _debounceCancellation;
    private const int DebounceDelayMs = 200;

    public StepDataCarouselView()
    {
        InitializeComponent();

        StepDataCarousel.CurrentItemChanged += (s, e) =>
        {
            if (BindingContext is ViewModels.StepDataCarouselViewModel vm)
                vm.ItemPosition = StepDataCarousel.Position;
        };
    }

    /// <summary>
    /// After the user swipes, wait for the scroll to settle then snap the carousel
    /// to the item whose centre is closest to the viewport centre.
    /// </summary>
    private void StepDataCarousel_Scrolled(object? sender, ItemsViewScrolledEventArgs e)
    {
        _debounceCancellation?.Cancel();
        _debounceCancellation = new CancellationTokenSource();

        Task.Delay(DebounceDelayMs, _debounceCancellation.Token).ContinueWith(t =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                if (!t.IsCanceled && sender is CarouselView carousel)
                    carousel.ScrollTo(e.CenterItemIndex);
            });
        });
    }

    public void Dispose()
    {
        _debounceCancellation?.Dispose();
        GC.SuppressFinalize(this);
    }
}
