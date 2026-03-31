# maui-carouselview-accessibility-issue
A minimal .NET MAUI reproduction sample demonstrating a bug where CarouselView content does not update correctly when Accessibility (TalkBack/VoiceOver) is enabled. The IndicatorView updates its position, but the CarouselView content remains stuck, causing a desynchronization issue that does not occur when accessibility is disabled.
