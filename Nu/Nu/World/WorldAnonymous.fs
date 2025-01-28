// Nu Game Engine.
// Copyright (C) Bryan Edds.

namespace Nu
open System
open System.Numerics
open Prime
open Nu

/// An anonymous static sprite definition.
type AnonStaticSprite =
    { Absolute : bool
      Position : Vector2
      Rotation : single
      Size : Vector2
      Elevation : single
      Color : Color
      Blend : Blend
      Emission : Color
      Flip : Flip
      StaticImage : Image AssetTag }

    static member args =
        { Absolute = false
          Position = v2Zero
          Rotation = 0.0f
          Size = Constants.Engine.EntityGuiSizeDefault.V2
          Elevation = 0.0f
          Color = colorOne
          Blend = Additive
          Emission = colorZero
          Flip = FlipNone
          StaticImage = Assets.Default.Image }

/// An anonymous 3D light probe definition.
type AnonLightProbe3d =
    { LightProbeId : uint64
      Enabled : bool
      Origin : Vector3
      AmbientColor : Color
      AmbientBrightness : single
      ProbeBounds : Box3 }

    static member args =
        { LightProbeId = 0UL
          Enabled = true
          Origin = v3Zero
          AmbientColor = colorOne
          AmbientBrightness = Constants.Render.BrightnessDefault
          ProbeBounds = box3 (v3Dup Constants.Render.LightProbeSizeDefault * -0.5f) (v3Dup Constants.Render.LightProbeSizeDefault) }

/// An anonymous 3D light definition.
type AnonLight3d =
    { LightId : uint64
      Origin : Vector3
      Rotation : Quaternion
      Color : Color
      Brightness : single
      AttenuationLinear : single
      AttenuationQuadratic : single
      LightCutoff : single
      LightType : LightType
      DesireShadows : bool }

    static member args =
        { LightId = 0UL
          Origin = v3Zero
          Rotation = quatIdentity
          Color = colorOne
          Brightness = Constants.Render.BrightnessDefault
          AttenuationLinear = Constants.Render.AttenuationLinearDefault
          AttenuationQuadratic = Constants.Render.AttenuationQuadraticDefault
          LightCutoff = Constants.Render.LightCutoffDefault
          LightType = PointLight
          DesireShadows = false }

/// An anonymous static model definition.
type AnonStaticModel =
    { Position : Vector3
      Rotation : Quaternion
      Scale : Vector3
      CastShadow : bool
      Presence : Presence
      InsetOpt : Box2 option
      MaterialProperties : MaterialProperties
      RenderStyle : RenderStyle
      StaticModel : StaticModel AssetTag }

    static member args =
        { Position = v3Zero
          Scale = v3One
          Rotation = quatIdentity
          CastShadow = true
          Presence = Exterior
          InsetOpt = None
          MaterialProperties = MaterialProperties.defaultProperties
          RenderStyle = Deferred
          StaticModel = Assets.Default.StaticModel }

/// An anonymous text definition.
type AnonText =
    { Absolute : bool
      Enabled : bool
      Position : Vector2
      Size : Vector2
      Elevation : single
      Color : Color
      ColorDisabled : Color
      Text : string
      TextColor : Color
      Justification : Justification
      Font : Font AssetTag
      FontSizing : int option
      FontStyling : FontStyle Set
      SliceMargin : Vector2
      BackdropImageOpt : Image AssetTag option }

    static member args =
        { Absolute = true
          Enabled = true
          Position = v2Zero
          Size = Constants.Engine.EntityGuiSizeDefault.V2
          Elevation = 0.0f
          Color = colorOne
          ColorDisabled = Constants.Gui.ColorDisabledDefault
          Text = ""
          TextColor = colorOne
          Justification = Justified (JustifyCenter, JustifyMiddle)
          Font = Assets.Default.Font
          FontSizing = None
          FontStyling = Set.empty
          SliceMargin = Constants.Gui.SliceMarginDefault
          BackdropImageOpt = Some Assets.Default.Label }

/// An anonymous text box definition.
type AnonTextBox =
    { Absolute : bool
      Enabled : bool
      Position : Vector2
      Size : Vector2
      Elevation : single
      Color : Color
      ColorDisabled : Color
      Text : string
      TextColor : Color
      TextShift : single
      TextCapacity : int
      Focused : bool
      Cursor : int
      Font : Font AssetTag
      FontSizing : int option
      FontStyling : FontStyle Set
      SliceMargin : Vector2
      BackdropImageOpt : Image AssetTag option }

    static member args text focused cursor =
        { Absolute = true
          Enabled = true
          Position = v2Zero
          Size = Constants.Engine.EntityGuiSizeDefault.V2
          Elevation = 0.0f
          Color = colorOne
          ColorDisabled = Constants.Gui.ColorDisabledDefault
          Text = text
          TextColor = colorOne
          TextShift = Constants.Gui.TextShiftDefault
          TextCapacity = 14
          Focused = focused
          Cursor = cursor
          Font = Assets.Default.Font
          FontSizing = None
          FontStyling = Set.empty
          SliceMargin = Constants.Gui.SliceMarginDefault
          BackdropImageOpt = Some Assets.Default.Label }

/// An anonymous label definition.
type AnonLabel =
    { Absolute : bool
      Enabled : bool
      Position : Vector2
      Size : Vector2
      Elevation : single
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
      BackdropImageOpt : Image AssetTag option }

    static member args =
        { Absolute = true
          Enabled = true
          Position = v2Zero
          Size = Constants.Engine.EntityGuiSizeDefault.V2
          Elevation = 0.0f
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
          BackdropImageOpt = Some Assets.Default.Label }

/// An anonymous button definition.
type AnonButton =
    { Absolute : bool
      Enabled : bool
      Position : Vector2
      Size : Vector2
      Elevation : single
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

    static member args =
        { Absolute = true
          Enabled = true
          Position = v2Zero
          Size = Constants.Engine.EntityGuiSizeDefault.V2
          Elevation = 0.0f
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
module WorldAnonymous =

    type World with

        /// Declare an anonymous static sprite.
        static member anonStaticSprite (sprite : AnonStaticSprite) world =
            let mutable transform = Transform.makeIntuitive sprite.Absolute sprite.Position.V3 v3One v3Zero sprite.Size.V3 (v3 0.0f 0.0f sprite.Rotation) sprite.Elevation
            let mutable insetOpt = ValueNone
            let mutable clipOpt = ValueNone
            World.renderLayeredSpriteFast (sprite.Elevation, transform.Horizon, sprite.StaticImage, &transform, &insetOpt, &clipOpt, sprite.StaticImage, &sprite.Color, sprite.Blend, &sprite.Emission, sprite.Flip, world)
            world

        /// Declare an anonymous 3D light probe.
        static member anonLightProbe3d (lightProbe : AnonLightProbe3d) renderPasses world =
            for (renderPass : RenderPass) in renderPasses do
                World.enqueueRenderMessage3d
                    (RenderLightProbe3d
                        { LightProbeId = lightProbe.LightProbeId
                          Enabled = lightProbe.Enabled
                          Origin = lightProbe.Origin
                          AmbientColor = lightProbe.AmbientColor
                          AmbientBrightness = lightProbe.AmbientBrightness
                          ProbeBounds = lightProbe.ProbeBounds
                          RenderPass = renderPass })
                    world

        /// Declare an anonymous 3D light.
        static member anonLight3d (light : AnonLight3d) renderPasses world =
            for (renderPass : RenderPass) in renderPasses do
                World.enqueueRenderMessage3d
                    (RenderLight3d
                        { LightId = light.LightId
                          Origin = light.Origin
                          Rotation = light.Rotation
                          Direction = light.Rotation.Down
                          Color = light.Color
                          Brightness = light.Brightness
                          AttenuationLinear = light.AttenuationLinear
                          AttenuationQuadratic = light.AttenuationQuadratic
                          LightCutoff = light.LightCutoff
                          LightType = light.LightType
                          DesireShadows = light.DesireShadows
                          RenderPass = renderPass })
                    world

        /// Declare an anonymous static model.
        static member anonStaticModel (model : AnonStaticModel) renderPasses world =
            for (renderPass : RenderPass) in renderPasses do
                if not renderPass.IsShadowPass || model.CastShadow then
                    let affineMatrix = Matrix4x4.CreateAffine (model.Position, model.Rotation, model.Scale)
                    let insetOpt = ValueOption.ofOption model.InsetOpt
                    let properties = model.MaterialProperties
                    let staticModel = model.StaticModel
                    let renderType =
                        match model.RenderStyle with
                        | Deferred -> DeferredRenderType
                        | Forward (subsort, sort) -> ForwardRenderType (subsort, sort)
                    World.renderStaticModelFast (&affineMatrix, model.CastShadow, model.Presence, insetOpt, &properties, staticModel, renderType, renderPass, world)
            world

        /// Declare an anonymous text control.
        static member anonText (text : AnonText) world =
            let perimeter = box2 (text.Position - text.Size * 0.5f) text.Size
            let color = if text.Enabled then text.Color else text.ColorDisabled
            match text.BackdropImageOpt with
            | Some backdropImage -> World.renderGuiSpriteSliced text.Absolute perimeter.Box3 text.SliceMargin backdropImage v3Zero text.Elevation color world
            | None -> ()
            World.renderGuiText text.Absolute perimeter.Box3 v3Zero text.Elevation 0.0f (ValueSome perimeter) text.Justification None v3Zero text.TextColor text.Font text.FontSizing text.FontStyling text.Text world
            world

        /// Declare an anonymous text box control.
        static member anonTextBox (textBox : AnonTextBox) textInputs (world : World) =
            let mousePosition = World.getMousePostion2dWorld textBox.Absolute world
            let perimeter = box2 (textBox.Position - textBox.Size * 0.5f) textBox.Size
            let inside = perimeter.Contains mousePosition <> ContainmentType.Disjoint
            let down = textBox.Enabled && inside && World.isMouseButtonDown MouseLeft world
            let color = if textBox.Enabled then textBox.Color else textBox.ColorDisabled
            let shift = if down then textBox.TextShift else 0.0f
            let mutable text = textBox.Text
            let focused = textBox.Enabled && (textBox.Focused || inside && down)
            let mutable cursor = textBox.Cursor
            if focused then
                for (textInput : char) in textInputs do
                    if world.Advancing && text.Length < textBox.TextCapacity then
                        text <-
                            if cursor < 0 || cursor >= text.Length
                            then text + string textInput
                            else String.take cursor text + string textInput + String.skip cursor text
                        cursor <- inc cursor
                // TODO: P0: add cursor nav.
            match textBox.BackdropImageOpt with
            | Some backdropImage -> World.renderGuiSpriteSliced textBox.Absolute perimeter.Box3 textBox.SliceMargin backdropImage v3Zero textBox.Elevation color world
            | None -> ()
            World.renderGuiText textBox.Absolute perimeter.Box3 v3Zero textBox.Elevation shift (ValueSome perimeter) (Justified (JustifyCenter, JustifyMiddle)) None v3Zero textBox.TextColor textBox.Font textBox.FontSizing textBox.FontStyling textBox.Text world
            (text, focused, cursor, world)

        /// Declare an anonymous label.
        static member anonLabel (label : AnonLabel) world =
            let mousePosition = World.getMousePostion2dWorld label.Absolute world
            let perimeter = box2 (label.Position - label.Size * 0.5f) label.Size
            let inside = perimeter.Contains mousePosition <> ContainmentType.Disjoint
            let down = label.Enabled && inside && World.isMouseButtonDown MouseLeft world
            let clicked = label.Enabled && World.isMouseButtonClicked MouseLeft world
            let color = if label.Enabled then label.Color else label.ColorDisabled
            let shift = if down then label.TextShift else 0.0f
            match label.BackdropImageOpt with
            | Some backdropImage -> World.renderGuiSpriteSliced label.Absolute perimeter.Box3 label.SliceMargin backdropImage v3Zero label.Elevation color world
            | None -> ()
            World.renderGuiText label.Absolute perimeter.Box3 v3Zero label.Elevation shift (ValueSome perimeter) label.Justification None v3Zero label.TextColor label.Font label.FontSizing label.FontStyling label.Text world
            (inside && clicked, world)

        /// Declare an anonymous button.
        static member anonButton (button : AnonButton) world =
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