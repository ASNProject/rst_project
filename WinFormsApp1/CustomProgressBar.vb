Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class CustomProgressBar
    Inherits ProgressBar

    Public Sub New()
        Me.SetStyle(ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        Dim progressBarBounds As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)

        ' Clear background
        g.Clear(SystemColors.Control)

        ' Draw background semicircle
        Dim path As GraphicsPath = New GraphicsPath()
        path.AddArc(progressBarBounds, -180, 180)

        Dim brush As Brush = New SolidBrush(Color.LightGray)
        g.FillPath(brush, path)

        ' Calculate progress bounds
        Dim progressWidth As Integer = CInt(progressBarBounds.Width * (Me.Value / Me.Maximum))
        Dim progressBounds As Rectangle = New Rectangle(progressBarBounds.X,
                                                        progressBarBounds.Y,
                                                        progressWidth,
                                                        progressBarBounds.Height)

        ' Draw progress
        If progressWidth > 0 Then
            brush = New SolidBrush(Me.ForeColor)
            g.FillRectangle(brush, progressBounds)
        End If
    End Sub
End Class
