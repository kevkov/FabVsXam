namespace SyncFusionFab

open TherapyPal.Widgets
open Xamarin.Forms
open Fabulous.XamarinForms

open type View

module App =
    type Model = { Count: int }

    type Msg =
        | Increment
        | Decrement

    let init () = { Count = 0 }

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + 1 }
        | Decrement -> { model with Count = model.Count - 1 }

    let view model =
        Application(
            ContentPage(
                "SyncFusionFab",
                (VStack() {
                    SfBorder(
                        VStack() {
                            Label("Hello from Fabulous v2!")
                                .font(namedSize = NamedSize.Title)
                                .centerTextHorizontal ()

                            SfButton("Hello")
                                .backgroundColour(Color.White.ToFabColor())
                                .textColor(Color.Black.ToFabColor())
                                .horizontalOptions(LayoutOptions.Center)
                        }
                    )
                        .hasShadow(true)
                        .borderThickness(Thickness(1.))
                        .borderColour(Color.LightGray.ToFabColor())
                        .cornerRadius(5.)
                })
                    .padding (Thickness(20.))
            )
        )

    let program = Program.stateful init update view
