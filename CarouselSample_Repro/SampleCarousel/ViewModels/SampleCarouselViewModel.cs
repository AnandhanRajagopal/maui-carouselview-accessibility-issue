using SampleCarousel.Models;

namespace SampleCarousel.ViewModels;

/// <summary>
/// Concrete VM — seeds static sample data (no services / DI required).
/// Mirrors the pattern where subclasses of StepDataCarouselViewModel
/// populate CarouselItemsSource (e.g. PrepareSmartPhoneViewModel).
/// </summary>
public class SampleCarouselViewModel : StepDataCarouselViewModel
{
    public SampleCarouselViewModel()
    {
        CarouselItemsSource =
        [
            new StepData
            {
                StepHeading  = "Step 1 — Open the app",
                Description  = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new StepData
            {
                StepHeading  = "Step 2 — Hold the device",
                Description  = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.",
                ImageSource  = "dotnet_bot.png"
            }
        ];
    }
}
