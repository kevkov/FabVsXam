﻿namespace SyncFusionFab.Android

open System

open Android.App
open Android.Content
open Android.Content.PM
open Android.Runtime
open Android.Views
open Android.Widget
open Android.OS

open Fabulous.XamarinForms
open SyncFusionFab
open Xamarin.Forms.Platform.Android

[<Activity(Label = "SyncFusionFab.Android",
           Icon = "@drawable/icon",
           Theme = "@style/MainTheme",
           MainLauncher = true,
           ConfigurationChanges = (ConfigChanges.ScreenSize ||| ConfigChanges.Orientation))>]
type MainActivity() =
    inherit FormsAppCompatActivity()

    do SyncFusionFab.Android.Resource.UpdateIdValues()

    override this.OnCreate(bundle: Bundle) =
        FormsAppCompatActivity.TabLayoutResource <- SyncFusionFab.Android.Resource.Layout.Tabbar
        FormsAppCompatActivity.ToolbarResource <- SyncFusionFab.Android.Resource.Layout.Toolbar

        base.OnCreate(bundle)
        Xamarin.Essentials.Platform.Init(this, bundle)
        Xamarin.Forms.Forms.Init(this, bundle)
        this.LoadApplication(Program.startApplication App.program)

    override this.OnRequestPermissionsResult(requestCode: int, permissions: string[], [<GeneratedEnum>] grantResults: Android.Content.PM.Permission[]) =
        Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults)
        base.OnRequestPermissionsResult(requestCode, permissions, grantResults)
