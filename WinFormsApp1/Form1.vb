Public Class RST
    Private Sub RST_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar1.Value = 75
    End Sub

    Private Sub ProgressBar1_Paint(sender As Object, e As PaintEventArgs) Handles ProgressBar1.Paint
        Dim progressBarRect As Rectangle = New Rectangle(0, 0, ProgressBar1.Width - 1, ProgressBar1.Height - 1) ' Mengurangi 1 piksel untuk menghindari overflow

        Dim path As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath()
        path.AddArc(progressBarRect, -180, 180) ' Menambahkan setengah lingkaran ke jalur
        path.CloseFigure()

        ProgressBar1.Region = New Region(path) ' Mengatur region ProgressBar sesuai dengan path

        ' Menggambar latar belakang ProgressBar (warna abu-abu)
        Using brush As New SolidBrush(Color.LightGray)
            e.Graphics.FillPath(brush, path)
        End Using

        ' Menggambar bagian progress (warna biru)
        Dim progressWidth As Integer = CInt(progressBarRect.Width * (ProgressBar1.Value / ProgressBar1.Maximum))
        Dim progressRect As New Rectangle(progressBarRect.X, progressBarRect.Y, progressWidth, progressBarRect.Height)
        Dim progressPath As New Drawing2D.GraphicsPath()
        progressPath.AddArc(progressBarRect, -180, 180) ' Menambahkan jalur yang sama untuk progress
        progressPath.CloseFigure()

        Using brush As New SolidBrush(Color.Blue)
            e.Graphics.FillPath(brush, progressPath) ' Mengisi progress dengan warna biru
        End Using
    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click
        ' Kosongkan handler click jika tidak digunakan saat ini
    End Sub
End Class
