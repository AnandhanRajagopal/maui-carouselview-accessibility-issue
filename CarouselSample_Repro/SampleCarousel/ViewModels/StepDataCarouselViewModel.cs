using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SampleCarousel.Models;

namespace SampleCarousel.ViewModels;

/// <summary>
/// Abstract base VM — mirrors StepDataCarouselViewModel from XCApp.Easyfit.
/// Uses only BCL types: no CommunityToolkit.Mvvm, no custom Command packages.
/// </summary>
public abstract class StepDataCarouselViewModel : INotifyPropertyChanged
{
    // ----------------------------------------------------------------
    // INotifyPropertyChanged
    // ----------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return;
        field = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // ----------------------------------------------------------------
    // Commands
    // ----------------------------------------------------------------
    public ICommand LeftArrowCommand { get; }
    public ICommand RightArrowCommand { get; }

    // ----------------------------------------------------------------
    // Backing fields
    // ----------------------------------------------------------------
    private List<StepData>? _carouselItemsSource;
    private StepData? _currentItem;
    private int _itemPosition;
    private bool _isNextButtonVisible = true;
    private bool _isPrevButtonVisible;
    private double _calculatedWidth = 20;

    private const double WidthMultiplier = 10;
    private const double DefaultIndicatorWidth = 20;

    // ----------------------------------------------------------------
    // Properties
    // ----------------------------------------------------------------
    public List<StepData>? CarouselItemsSource
    {
        get => _carouselItemsSource;
        protected set
        {
            SetField(ref _carouselItemsSource, value);
            CalculatedWidth = value?.Count > 0
                ? value.Count * WidthMultiplier
                : DefaultIndicatorWidth;
            // Reset position to first item when the source changes
            ItemPosition = 0;
        }
    }

    public double CalculatedWidth
    {
        get => _calculatedWidth;
        private set => SetField(ref _calculatedWidth, value);
    }

    public int ItemPosition
    {
        get => _itemPosition;
        set
        {
            IsNextButtonVisible = value != ((CarouselItemsSource?.Count ?? 0) - 1);
            IsPrevButtonVisible = value != 0;
            SetField(ref _itemPosition, value);
            // Keep CurrentItem in sync with the position
            CurrentItem = (CarouselItemsSource != null && value >= 0 && value < CarouselItemsSource.Count)
                ? CarouselItemsSource[value]
                : null;
        }
    }

    public StepData? CurrentItem
    {
        get => _currentItem;
        set => SetField(ref _currentItem, value);
    }

    public bool IsNextButtonVisible
    {
        get => _isNextButtonVisible;
        private set => SetField(ref _isNextButtonVisible, value);
    }

    public bool IsPrevButtonVisible
    {
        get => _isPrevButtonVisible;
        private set => SetField(ref _isPrevButtonVisible, value);
    }

    // ----------------------------------------------------------------
    // Constructor
    // ----------------------------------------------------------------
    protected StepDataCarouselViewModel()
    {
        RightArrowCommand = new Command(_ =>
        {
            if (ItemPosition < (CarouselItemsSource?.Count ?? 0) - 1)
                ItemPosition++;
        });

        LeftArrowCommand = new Command(_ =>
        {
            if (ItemPosition > 0)
                ItemPosition--;
        });

        IsNextButtonVisible = true;
    }
}
