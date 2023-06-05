namespace ContentPagePaddingFab

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
                "ContentPagePaddingFab",
                Frame(
                    Label("Hello from Fabulous v2!")
                        .centerTextHorizontal()
                )
            )
                .padding(50.)
        )

    let program = Program.stateful init update view
