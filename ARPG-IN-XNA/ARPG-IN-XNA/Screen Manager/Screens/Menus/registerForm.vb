﻿Imports System.Windows.Forms
Public Class registerForm
    Inherits BaseScreen

    ' Buttons
    Private ovrCancel As Boolean = False
    Private ovrRegister As Boolean = False

    ' DOB
    Private ovrMonth As Boolean = False
    Private monthEmpty As Boolean = True
    Private monthActive As Boolean = False
    Private monthString As String = ""
    Private monthXCord As Integer = 265

    Private ovrDay As Boolean = False
    Private dayEmpty As Boolean = True
    Private dayActive As Boolean = False
    Private dayString As String = ""
    Private dayXCord As Integer

    Private ovrYear As Boolean = False
    Private yearEmpty As Boolean = True
    Private yearActive As Boolean = False
    Private yearString As String = ""
    Private yearXCord As Integer

    ' Email
    Private ovrEmail As Boolean = False
    Private emailActive As Boolean = False
    Private emailString As String = ""
    Private emailXCord As Integer = 265

    ' Password
    Private ovrPassword As Boolean = False
    Private passwordActive As Boolean = False
    Private passwordString As String = ""
    Private passwordXCord As Integer = 265

    ' Retype Password
    Private ovrRetype As Boolean = False
    Private retypeActive As Boolean = False
    Private retypeString As String = ""
    Private retypeXCord As Integer = 265

    ' Offers
    Private ovrOffers As Boolean = False
    Private offersClicked As Boolean = False

    ' Links
    Private ovrTerms As Boolean = False
    Private ovrPrivacy As Boolean = False
    Private ovrHere As Boolean = False

    ' Cursor Variables
    Private Timer As Integer = 0
    Private drawCur As Boolean = True

    ' Keyboard input
    Public Shared textString As String = ""



    Public Sub New()
        Name = "registerForm"
        State = ScreenState.Active
    End Sub

    Public Overrides Sub HandleInput()
        ' Handle Text input
        textString = getActiveString()
        textString = textHandler.stringMod(textString, getActiveMaxLength())
        setActiveString(textString)

        ' Handle Mouse input
        Dim x = Input.mMapX
        Dim y = Input.mMapY

        ' Cancel Button
        ovrCancel = False
        If x >= 360 And x <= 425 Then
            If y >= 505 And y <= 525 Then
                ovrCancel = True
            End If
        End If

        ' Register Button
        ovrRegister = False
        If x >= 460 And x <= 540 Then
            If y >= 505 And y <= 525 Then
                ovrRegister = True
            End If
        End If

        ' Email Form
        ovrEmail = False
        If x >= 260 And x <= 535 Then
            If y >= 123 And y <= 153 Then
                ovrEmail = True
            End If
        End If

        ' Password Form
        ovrPassword = False
        If x >= 260 And x <= 535 Then
            If y >= 191 And y <= 221 Then
                ovrPassword = True
            End If
        End If

        ' Retype Password Form
        ovrRetype = False
        If x >= 260 And x <= 535 Then
            If y >= 260 And y <= 290 Then
                ovrRetype = True
            End If
        End If

        ' Month Form
        ovrMonth = False
        If x >= 260 And x <= 295 Then
            If y >= 321 And y <= 351 Then
                ovrMonth = True
            End If
        End If

        ' Day Form
        ovrDay = False
        If x >= 318 And x <= 350 Then
            If y >= 321 And y <= 351 Then
                ovrDay = True
            End If
        End If

        ' Year Form
        ovrYear = False
        If x >= 372 And x <= 426 Then
            If y >= 321 And y <= 351 Then
                ovrYear = True
            End If
        End If

        ' Offers Box
        ovrOffers = False
        If x >= 260 And x <= 280 Then
            If y >= 360 And y <= 380 Then
                ovrOffers = True
            End If
        End If

        ' Terms of Use
        ovrTerms = False
        If x >= 445 And x <= 519 Then
            If y >= 430 And y <= 445 Then
                ovrTerms = True
            End If
        End If

        ' Privacy Policy
        ovrPrivacy = False
        If x >= 284 And x <= 364 Then
            If y >= 445 And y <= 460 Then
                ovrPrivacy = True
            End If
        End If

        ' Click Here
        ovrHere = False
        If x >= 374 And x <= 400 Then
            If y >= 475 And y <= 490 Then
                ovrHere = True
            End If
        End If

        ' Handle all clicks
        If Input.Click = True Then

            ' Register button
            If ovrRegister = True Then
                deactivateAll()
                ScreenManager.UnloadScreen("registerForm")
                TitleScreen.ovrForm = False

                ' Cancel Button
            ElseIf ovrCancel = True Then
                deactivateAll()
                ScreenManager.UnloadScreen("registerForm")
                TitleScreen.ovrForm = False

                ' Email Form
            ElseIf ovrEmail = True Then
                deactivateAll()
                emailActive = True

                ' Password Form
            ElseIf ovrPassword = True Then
                deactivateAll()
                passwordActive = True

                ' Retype Form
            ElseIf ovrRetype = True Then
                deactivateAll()
                retypeActive = True

                ' Offers
            ElseIf ovrOffers = True Then
                deactivateAll()
                offersClicked = Not (offersClicked)

                ' Month
            ElseIf ovrMonth = True Then
                deactivateAll()
                monthActive = True

                ' Day
            ElseIf ovrDay = True Then
                deactivateAll()
                dayActive = True

                ' Year
            ElseIf ovrYear = True Then
                deactivateAll()
                yearActive = True

                ' Terms of Use
            ElseIf ovrTerms = True Then
                deactivateAll()
                Process.Start("https://github.com/maat7043/ARPG-IN-XNA")

                ' Privacy Policy
            ElseIf ovrPrivacy = True Then
                deactivateAll()
                Process.Start("https://github.com/maat7043/ARPG-IN-XNA")

                ' Click Here
            ElseIf ovrHere = True Then
                deactivateAll()
                ScreenManager.UnloadScreen("registerForm")
                ScreenManager.AddScreen(New loginForm)

                ' Stray Click
            Else
                deactivateAll()
            End If
        End If
    End Sub
    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)

        ' Form Dimensions
        Dim X = Globals.GameSize.X / 2 - Textures.registerForm.Width / 2
        Dim Y = Globals.GameSize.Y / 2 - Textures.registerForm.Height / 2
        Dim Width = Textures.registerForm.Width
        Dim Height = Textures.registerForm.Height

        ' Main Form
        Globals.SpriteBatch.Draw(Textures.registerForm, New Rectangle(X, Y, Width, Height), Color.White)

        ' Animation for Text Cursor
        If Globals.GameTime.TotalGameTime.TotalMilliseconds > Timer Then
            Timer = Globals.GameTime.TotalGameTime.TotalMilliseconds + 500 ' Draw every half of a sec
            drawCur = Not (drawCur)
        End If

        ' Draw Cursor at active location
        If drawCur = True Then ' Toggle cursor on and off
            If emailActive = True Then
                Dim cursorLocation = textHandler.cursorLocation(emailString, Fonts.LargeROTMG, 0.9, 260, emailXCord)
                Globals.SpriteBatch.Draw(Textures.WhiteSquare, New Rectangle(cursorLocation, 130, 2, 18), Color.LightGray)
            End If
            If passwordActive = True Then
                Dim cursorLocation = passwordXCord + Fonts.LargeROTMG.MeasureString(passwordString).X * 0.9
                Globals.SpriteBatch.Draw(Textures.WhiteSquare, New Rectangle(cursorLocation, 198, 2, 18), Color.LightGray)
            End If
            If retypeActive = True Then
                Dim inputStr As String = textHandler.wordWrap(emailString, Fonts.LargeROTMG, 0.9, 100)
                Dim cursorLocation = retypeXCord + Fonts.LargeROTMG.MeasureString(retypeString).X * 0.9
                Globals.SpriteBatch.Draw(Textures.WhiteSquare, New Rectangle(cursorLocation, 265, 2, 18), Color.LightGray)
            End If
            If monthActive = True Then
                Dim cursorLocation = 264 + Fonts.SmallROTMG.MeasureString(monthString).X * 1.3
                Globals.SpriteBatch.Draw(Textures.WhiteSquare, New Rectangle(cursorLocation, 328, 2, 15), Color.LightGray)
            End If
            If dayActive = True Then
                Dim cursorLocation = 322 + Fonts.LargeROTMG.MeasureString(dayString).X * 1.3
                Globals.SpriteBatch.Draw(Textures.WhiteSquare, New Rectangle(cursorLocation, 328, 2, 15), Color.LightGray)
            End If
            If yearActive = True Then
                Dim cursorLocation = 375 + Fonts.LargeROTMG.MeasureString(yearString).X * 1.3
                Globals.SpriteBatch.Draw(Textures.WhiteSquare, New Rectangle(cursorLocation, 328, 2, 15), Color.LightGray)
            End If
        End If

        ' Cancel Button
        If ovrCancel = False Then
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Cancel", New Vector2(X + 0.4 * Width, Y + 0.9 * Height), Color.White, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        Else
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Cancel", New Vector2(X + 0.4 * Width, Y + 0.9 * Height), Color.LightGoldenrodYellow, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        End If

        ' Register Button
        If ovrRegister = False Then
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Register", New Vector2(X + 0.7 * Width, Y + 0.9 * Height), Color.White, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        Else
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Register", New Vector2(X + 0.7 * Width, Y + 0.9 * Height), Color.LightGoldenrodYellow, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        End If

        ' Day/Month/Year Place Holders
        If monthString = "" Then
            Globals.SpriteBatch.DrawString(Fonts.SmallROTMG, "MM", New Vector2(X + 25, Y + 280), Color.Gray, 0, New Vector2(0, 0), 1.3, SpriteEffects.None, 0)
        End If
        If dayString = "" Then
            Globals.SpriteBatch.DrawString(Fonts.SmallROTMG, "DD", New Vector2(X + 85, Y + 280), Color.Gray, 0, New Vector2(0, 0), 1.3, SpriteEffects.None, 0)
        End If
        If yearString = "" Then
            Globals.SpriteBatch.DrawString(Fonts.SmallROTMG, "YYYY", New Vector2(X + 140, Y + 280), Color.Gray, 0, New Vector2(0, 0), 1.3, SpriteEffects.None, 0)
        End If

        ' Offer Box
        If offersClicked = True Then
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "X", New Vector2(263, 354), Color.Gray, 0, New Vector2(0, 0), 1, SpriteEffects.None, 0)
        End If

        ' Email String
        Dim cutString As String = textHandler.wordWrap(emailString, Fonts.LargeROTMG, 0.9, 260)
        Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, cutString, New Vector2(emailXCord, 125), Color.Gray, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)

        ' Password String
        Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, passwordString, New Vector2(passwordXCord, 192), Color.Gray, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)

        ' Retype String
        Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, retypeString, New Vector2(retypeXCord, 260), Color.Gray, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)

        ' Month
        Globals.SpriteBatch.DrawString(Fonts.SmallROTMG, monthString, New Vector2(X + 25, Y + 280), Color.Gray, 0, New Vector2(0, 0), 1.3, SpriteEffects.None, 0)

        ' Day
        Globals.SpriteBatch.DrawString(Fonts.SmallROTMG, dayString, New Vector2(X + 85, Y + 280), Color.Gray, 0, New Vector2(0, 0), 1.3, SpriteEffects.None, 0)

        ' Year
        Globals.SpriteBatch.DrawString(Fonts.SmallROTMG, yearString, New Vector2(X + 140, Y + 280), Color.Gray, 0, New Vector2(0, 0), 1.3, SpriteEffects.None, 0)

        Globals.SpriteBatch.End()
    End Sub

    Public Overrides Sub Unload()
        MyBase.Unload()
    End Sub

    Private Sub deactivateAll()
        monthActive = False
        dayActive = False
        yearActive = False
        emailActive = False
        passwordActive = False
        retypeActive = False
    End Sub

    Private Function getActiveString() As String
        If monthActive = True Then
            Return monthString
        End If
        If dayActive = True Then
            Return dayString
        End If
        If yearActive = True Then
            Return yearString
        End If
        If emailActive = True Then
            Return emailString
        End If
        If passwordActive = True Then
            Return passwordString
        End If
        If retypeActive = True Then
            Return retypeString
        End If

        Return ""
    End Function
    Private Function getActiveMaxLength() As Integer
        If monthActive = True Then
            Return 2
        End If
        If dayActive = True Then
            Return 2
        End If
        If yearActive = True Then
            Return 4
        End If
        If emailActive = True Then
            Return Nothing
        End If
        If passwordActive = True Then
            Return Nothing
        End If
        If retypeActive = True Then
            Return Nothing
        End If

        Return Nothing
    End Function
    Private Sub setActiveString(keyboardInput As String)
        If monthActive = True Then
            monthString = keyboardInput
        End If
        If dayActive = True Then
            dayString = keyboardInput
        End If
        If yearActive = True Then
            yearString = keyboardInput
        End If
        If emailActive = True Then
            emailString = keyboardInput
        End If
        If passwordActive = True Then
            passwordString = keyboardInput
        End If
        If retypeActive = True Then
            retypeString = keyboardInput
        End If

    End Sub
End Class
