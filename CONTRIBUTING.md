# Contributing Guidelines

## Overview
This file documents project-wide conventions and the initial design token (color) palette to be used across the application. Follow these rules when adding or updating UI resources so the application appearance remains consistent.

## Standards
- Keep UI color values centralized in a resource dictionary located at `Styles/Colors.xaml`.
- Use resource keys (brushes and colors) rather than literal hex values in XAML and code-behind.
- Prefer semantic names for colors (e.g., `PrimaryBrush`, `SecondaryBrush`, `TextBrush`, `AccentBrush`) rather than naming by hex.
- When adding new tokens, document them here and update `Styles/Colors.xaml`.

## Color Palette (initial)
- Primary color: `#212529` (use as `PrimaryBrush` / `PrimaryColor`)
- Secondary color: `#272B2F` (use as `SecondaryBrush` / `SecondaryColor`)
- Text color: `#DBDBDB` (use as `TextBrush` / `TextColor`)
- Accent/Text Block color: `#CED565` (use as `AccentBrush` / `AccentColor`)

## XAML usage
1. Add the centralized color resource dictionary: `Styles/Colors.xaml` (example below).

```xml
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Color x:Key="PrimaryColor">#FF212529</Color>
    <Color x:Key="SecondaryColor">#FF272B2F</Color>
    <Color x:Key="TextColor">#FFDBDBDB</Color>
    <Color x:Key="AccentColor">#FFCED565</Color>

    <SolidColorBrush x:Key="PrimaryBrush" Color="{StaticResource PrimaryColor}"/>
    <SolidColorBrush x:Key="SecondaryBrush" Color="{StaticResource SecondaryColor}"/>
    <SolidColorBrush x:Key="TextBrush" Color="{StaticResource TextColor}"/>
    <SolidColorBrush x:Key="AccentBrush" Color="{StaticResource AccentColor}"/>
</ResourceDictionary>
```

2. Merge the dictionary in `App.xaml` under `Application.Resources` so keys are available globally:

```xml
<ResourceDictionary.MergedDictionaries>
    <ResourceDictionary Source="Styles/Colors.xaml"/>
    <!-- existing dictionaries -->
</ResourceDictionary.MergedDictionaries>
```

3. Use resources in XAML rather than literal colors:

```xml
<Grid Background="{StaticResource PrimaryBrush}">
    <TextBlock Foreground="{StaticResource TextBrush}" />
    <Button Background="{StaticResource SecondaryBrush}" />
</Grid>
```

## Naming and contribution process
- When changing the palette, update this document with the reason for change and any new keys.
- Add unit or UI tests as needed to verify critical UI flows remain readable with new colors.
- Submit PRs with screenshots of affected screens.

## Notes
- Use 8-digit hex (`#AARRGGBB`) when specifying colors in `Color` resources to explicitly set alpha; examples above use full opacity `FF` prefix.
- Avoid hardcoding colors in controls; always prefer the resource keys.