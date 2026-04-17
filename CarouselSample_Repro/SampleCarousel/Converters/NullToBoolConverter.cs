using System.Globalization;

namespace SampleCarousel.Converters;

/// <summary>
/// Returns true when the value is non-null/non-empty, false otherwise.
/// Used to hide Image elements when no ImageSource is set.
/// </summary>
public class NullToBoolConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value is string s ? !string.IsNullOrEmpty(s) : value is not null;

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
