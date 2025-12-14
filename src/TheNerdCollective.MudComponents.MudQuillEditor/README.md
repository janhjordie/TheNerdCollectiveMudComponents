# TheNerdCollective.MudComponents

A specialized package providing MudBlazor-compatible Blazor components. This package contains the MudQuillEditor component, a powerful rich-text editor wrapper around Quill 2.0.

## Overview

TheNerdCollective.MudComponents extends MudBlazor with additional specialized components designed to seamlessly integrate with MudBlazor's design system and theming.

## Quick Start

### Installation

```bash
dotnet add package TheNerdCollective.MudComponents
```

### Setup

1. **Add Script Reference** in `App.razor`:
```html
<head>
    <script src="_content/TheNerdCollective.MudComponents.MudQuillEditor/js/mudquilleditor.js"></script>
</head>
```

2. **Import in `_Imports.razor`**:
```csharp
@using TheNerdCollective.MudComponents.MudQuillEditor
```

### Basic Usage

```razor
<MudQuillEditor @bind-Value="HtmlContent" 
                MinHeight="300px" 
                MaxHeight="300px"
                Placeholder="Enter your content here..." />

@code {
    private string HtmlContent = "<p>Hello from MudQuillEditor</p>";
}
```

## MudQuillEditor Features

- **Two-way Data Binding** - Use `@bind-Value` for seamless data synchronization
- **Automatic Dark/Light Theme Support** - Adapts to MudBlazor theme changes
- **Customizable Height** - Configure MinHeight and MaxHeight
- **Configurable Toolbar** - Enable/disable formatting features dynamically
- **Placeholder Text** - Guide users with custom placeholder messages
- **Read-Only Mode** - Display content without editing capabilities
- **Auto-loads Quill from CDN** - No bundling needed, handles dependencies automatically
- **Full Async/Await Support** - Modern async APIs throughout

## Advanced Configuration

```razor
<MudQuillEditor @bind-Value="Content"
                ReadOnly="@IsReadOnly"
                Placeholder="@EditorPlaceholder"
                MinHeight="200px"
                MaxHeight="500px" />

@code {
    private string Content = "";
    private bool IsReadOnly = false;
    private string EditorPlaceholder = "Start typing...";
}
```

## Toolbar Customization

Control which formatting tools are available:

```razor
<MudQuillEditor @bind-Value="Content"
                EnableBold="true"
                EnableItalic="true"
                EnableUnderline="true"
                EnableLink="true" />
```

## Dependencies

- **MudBlazor** 8.15+
- **Quill** 2.0 (loaded from CDN)
- **.NET** 10.0+

## License

Apache License 2.0 - See LICENSE file for details

## Repository

[TheNerdCollective.Components on GitHub](https://github.com/janhjordie/TheNerdCollective.Components)
