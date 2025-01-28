// Nu Game Engine.
// Copyright (C) Bryan Edds.

namespace Nu
open System
open System.Numerics
open Prime
open Nu

/// An anonymouse static sprite definition.
type StaticSprite =
    { Absolute : bool
      Position : Vector2
      Size : Vector2
      Rotation : single
      Elevation : single
      Enabled : bool
      Color : Color
      Blend : Blend
      Emission : Color
      Flip : Flip
      StaticImage : Image AssetTag }

    static member value =
        { Absolute = false
          Position = v2Zero
          Size = Constants.Engine.EntityGuiSizeDefault.V2
          Rotation = 0.0f
          Elevation = 0.0f
          Enabled = true
          Color = colorOne
          Blend = Additive
          Emission = colorZero
          Flip = FlipNone
          StaticImage = Assets.Default.Image }

/// An anonymouse button definition.
type Button =
    { Absolute : bool
      Position : Vector2
      Size : Vector2
      Elevation : single
      Enabled : bool
      Color : Color
      ColorDisabled : Color
      Text : string
      TextColor : Color
      TextShift : single
      Justification : Justification
      Font : Font AssetTag
      FontSizing : int option
      FontStyling : FontStyle Set
      SliceMargin : Vector2
      UpImage : Image AssetTag
      DownImage : Image AssetTag }

    static member value =
        { Absolute = true
          Position = v2Zero
          Size = Constants.Engine.EntityGuiSizeDefault.V2
          Elevation = 0.0f
          Enabled = true
          Color = colorOne
          ColorDisabled = Constants.Gui.ColorDisabledDefault
          Text = ""
          TextColor = colorOne
          TextShift = Constants.Gui.TextShiftDefault
          Justification = Justified (JustifyCenter, JustifyMiddle)
          Font = Assets.Default.Font
          FontSizing = None
          FontStyling = Set.empty
          SliceMargin = Constants.Gui.SliceMarginDefault
          UpImage = Assets.Default.ButtonUp
          DownImage = Assets.Default.ButtonDown }

[<AutoOpen>]
module WorldAnon =

    type World with

        /// Declare an anonymous static sprite.
        static member anonStaticSprite (sprite : StaticSprite) world =
            let mutable transform = Transform.makeIntuitive sprite.Absolute sprite.Position.V3 v3One v3Zero sprite.Size.V3 (v3 0.0f 0.0f sprite.Rotation) sprite.Elevation
            let mutable insetOpt = ValueNone
            let mutable clipOpt = ValueNone
            World.renderLayeredSpriteFast (sprite.Elevation, transform.Horizon, sprite.StaticImage, &transform, &insetOpt, &clipOpt, sprite.StaticImage, &sprite.Color, sprite.Blend, &sprite.Emission, sprite.Flip, world)
            world

        /// Declare an anonymous button.
        static member anonButton (button : Button) world =
            let mousePosition = World.getMousePostion2dWorld button.Absolute world
            let perimeter = box2 (button.Position - button.Size * 0.5f) button.Size
            let inside = perimeter.Contains mousePosition <> ContainmentType.Disjoint
            let down = button.Enabled && inside && World.isMouseButtonDown MouseLeft world
            let clicked = button.Enabled && World.isMouseButtonClicked MouseLeft world
            let image = if down then button.DownImage else button.UpImage
            let color = if button.Enabled then button.Color else button.ColorDisabled
            let shift = if down then button.TextShift else 0.0f
            World.renderGuiSpriteSliced button.Absolute perimeter.Box3 button.SliceMargin image v3Zero button.Elevation color world
            World.renderGuiText button.Absolute perimeter.Box3 v3Zero button.Elevation shift (ValueSome perimeter) button.Justification None v3Zero button.TextColor button.Font button.FontSizing button.FontStyling button.Text world
            (inside && clicked, world)