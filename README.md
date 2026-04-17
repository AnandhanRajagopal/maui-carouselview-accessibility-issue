# maui-carouselview-accessibility-issue
A minimal .NET MAUI reproduction sample demonstrating a bug where CarouselView content does not update correctly when Accessibility (VoiceOver) is enabled. The IndicatorView updates its position, but the CarouselView content remains stuck, causing a desynchronization issue that does not occur when accessibility is disabled.

## Video Reference

|Without Accessibility | With Accessibility|
|--|--|
|https://github.com/user-attachments/assets/cca194c2-bf1e-40ce-8c54-0c2296715de6|https://github.com/user-attachments/assets/c6bcff0f-07c9-442a-8b85-55a86df4e4e9|



