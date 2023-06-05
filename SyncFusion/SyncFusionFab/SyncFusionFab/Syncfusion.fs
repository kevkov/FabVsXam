namespace TherapyPal.Widgets

open System
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open Syncfusion.XForms.Border
open Syncfusion.XForms.Buttons
open Xamarin.Forms

type ISfBorder =
    inherit IContentView
    
module SfBorder =
    let WidgetKey = Widgets.register<SfBorder> ()
    let BackgroundColour = Attributes.defineBindableAppThemeColor SfBorder.BackgroundColorProperty
    let BorderColour = Attributes.defineBindableAppThemeColor SfBorder.BorderColorProperty
    let BorderThickness = Attributes.defineBindableWithEquality SfBorder.BorderThicknessProperty
    let CornerRadius = Attributes.defineBindableWithEquality SfBorder.CornerRadiusProperty
    let HasShadow = Attributes.defineBindableBool SfBorder.HasShadowProperty

    
[<AutoOpen>]
module SfBorderBuilders =
    type Fabulous.XamarinForms.View with
        static member inline SfBorder<'msg, 'marker when 'marker :> IView>(content: WidgetBuilder<'msg, 'marker>) =
            WidgetHelpers.buildWidgets<'msg, ISfBorder>
                SfBorder.WidgetKey
                [| ContentView.Content.WithValue(content.Compile()) |]
                
 [<Extension>]
type SfBorderModifiers =
    /// <summary>Link a ViewRef to access the direct ContentView control instance</summary>
    [<Extension>]
    static member inline borderColour(this: WidgetBuilder<'msg, #ISfBorder>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(SfBorder.BorderColour.WithValue(AppTheme.create light dark))
        
    [<Extension>]
    static member inline borderThickness(this: WidgetBuilder<'msg, #ISfBorder>, value: Thickness) =
        this.AddScalar(SfBorder.BorderThickness.WithValue(value))
       
    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #ISfBorder>, value: Thickness) =
        this.AddScalar(SfBorder.CornerRadius.WithValue(value))
       
    [<Extension>]
    static member inline hasShadow(this: WidgetBuilder<'msg, #ISfBorder>, value: bool) =
        this.AddScalar(SfBorder.HasShadow.WithValue(value))
        
type ISfButton =
    inherit ISfBorder

module SfButton =
    let WidgetKey = Widgets.register<SfButton> ()

    let Text = Attributes.defineBindableWithEquality<string> SfButton.TextProperty
    let Content = Attributes.defineBindableWidget SfButton.ContentProperty
    let ImageSource =
        Attributes.defineBindableAppTheme<ImageSource> SfButton.ImageSourceProperty
    let ShowIcon = Attributes.defineBindableBool SfButton.ShowIconProperty
    let BackgroundColour = Attributes.defineBindableAppThemeColor SfButton.BackgroundColorProperty
    let ImageAlignment = Attributes.defineBindableWithEquality<Alignment> SfButton.ImageAlignmentProperty
    let TextColour = Attributes.defineBindableAppThemeColor SfButton.TextColorProperty
    let FontAttributes = Attributes.defineBindableWithEquality<FontAttributes> SfButton.FontAttributesProperty
    let Clicked = Attributes.defineEvent<EventArgs> "Button_Clicked" (fun target -> (target :?> SfButton).Clicked)
    


[<AutoOpen>]
module SfButtonBuilders =
    type Fabulous.XamarinForms.View with

        static member inline SfButton<'msg>(text: string, onClicked: 'msg) =
            WidgetBuilder<'msg, ISfButton>(
                SfButton.WidgetKey,
                SfButton.Text.WithValue(text),
                SfButton.Clicked.WithValue(fun _ -> onClicked |> box))
            
        static member inline SfButton<'msg>(text: string) =
            WidgetBuilder<'msg, ISfButton>(
                SfButton.WidgetKey,
                SfButton.Text.WithValue(text))
            
        static member inline SfButton<'msg>(text: string, onClicked: 'msg, light: ImageSource, dark: ImageSource option) =
            let wb = WidgetBuilder<'msg, ISfButton>(
                SfButton.WidgetKey,
                SfButton.Text.WithValue(text),
                SfButton.ImageSource.WithValue(AppTheme.create light (Some light)),
                SfButton.Clicked.WithValue(fun _ -> onClicked |> box)
            )
            wb.AddScalar(SfButton.ShowIcon.WithValue(true))
                .AddScalar(SfButton.ImageAlignment.WithValue(Alignment.Right))

        static member inline SfButton<'msg, 'marker when 'marker :> IView>(content: WidgetBuilder<'msg, 'marker>) =
            WidgetHelpers.buildWidgets<'msg, ISfButton>
                ContentView.WidgetKey
                [| ContentView.Content.WithValue(content.Compile()) |]

[<Extension>]
type SfButtonModifiers =
    /// <summary>Link a ViewRef to access the direct ContentView control instance</summary>
    [<Extension>]
    static member inline backgroundColour(this: WidgetBuilder<'msg, #ISfButton>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(SfButton.BackgroundColour.WithValue(AppTheme.create light dark))
        
    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #ISfButton>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(SfButton.TextColour.WithValue(AppTheme.create light dark))
        
    [<Extension>]
    static member inline fontAttributes(this: WidgetBuilder<'msg, #ISfButton>, value: FontAttributes) =
        this.AddScalar(SfButton.FontAttributes.WithValue(value))