Imports System.IO.Ports
Imports System.IO

Public Class Form1
    Dim receivedData As String = ""
    Dim csvFilePath As String = Path.Combine(Application.StartupPath, "received_data.csv")
    Dim headersWritten As Boolean = False

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub AGauge7_ValueInRangeChanged(sender As Object, e As ValueInRangeChangedEventArgs) Handles AGauge7.ValueInRangeChanged

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub AGauge10_ValueInRangeChanged(sender As Object, e As ValueInRangeChangedEventArgs) Handles AGauge10.ValueInRangeChanged

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub AGauge4_ValueInRangeChanged(sender As Object, e As ValueInRangeChangedEventArgs) Handles AGauge4.ValueInRangeChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub AGauge3_ValueInRangeChanged(sender As Object, e As ValueInRangeChangedEventArgs) Handles AGauge3.ValueInRangeChanged

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SerialPort1.PortName = "COM3"
        SerialPort1.BaudRate = 9600
        SerialPort1.Open()
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Dim receivedData As String = SerialPort1.ReadLine()
        Dim data() As String = receivedData.Split(","c)

        ' Pastikan array data memiliki elemen yang cukup untuk diakses
        If data.Length >= 16 Then
            ' Panggil fungsi Invoke untuk memastikan pembaruan kontrol UI dilakukan di UI thread
            Invoke(Sub()
                       SetAGaugeValue(AGauge1, data(0)) ' VR1
                       SetAGaugeValue(AGauge12, data(1)) ' VR2
                       SetAGaugeValue(AGauge2, data(2)) ' VS1
                       SetAGaugeValue(AGauge11, data(3)) ' VS2
                       SetAGaugeValue(AGauge3, data(4)) ' VT1
                       SetAGaugeValue(AGauge10, data(5)) ' VT2
                       SetAGaugeValue(AGauge6, data(6)) ' CR1
                       SetAGaugeValue(AGauge9, data(7)) ' CR2
                       SetAGaugeValue(AGauge5, data(8)) ' CS1
                       SetAGaugeValue(AGauge8, data(9)) ' CS2
                       SetAGaugeValue(AGauge4, data(10)) ' CT1
                       SetAGaugeValue(AGauge7, data(11)) ' CT2
                       Label20.Text = data(12) ' TF1
                       Label23.Text = data(13) ' TF2
                       Label21.Text = data(14) ' F1
                       Label22.Text = data(15) ' F2
                   End Sub)

            Try
                If Not headersWritten Then
                    Using writer As New StreamWriter(csvFilePath, False)
                        writer.WriteLine("VR1,VR2,VS1,VS2,VT1,VT2,CR1,CR2,CS1,CS2,CT1,CT2,TF1,TF2,F1,F2")
                    End Using
                    headersWritten = True
                End If

                Using writer As New StreamWriter(csvFilePath, True)
                    writer.WriteLine(
                        $"{data(0)},{data(1)},{data(2)},{data(3)},{data(4)},{data(5)},{data(6)},{data(7)}," &
                        $"{data(8)},{data(9)},{data(10)},{data(11)},{data(12)},{data(13)},{data(14)},{data(15)}")
                End Using
            Catch ex As Exception
                MessageBox.Show("Failed to save data to CSV file: " & ex.Message)
            End Try
        Else
            ' Handle case where data array is empty or has no elements
            MessageBox.Show("Received data is invalid or empty.")
        End If


    End Sub
    Private Sub SetAGaugeValue(gauge As AGauge, dataValue As String)
        Dim value As Single
        If Single.TryParse(dataValue, value) Then
            ' Gunakan Invoke jika kontrol UI perlu diakses dari luar UI thread
            If gauge.InvokeRequired Then
                gauge.Invoke(Sub() gauge.Value = value)
            Else
                gauge.Value = value
            End If
        Else
            ' Handle case where parsing fails, if needed
            ' gauge.Value = SomeDefaultValue
        End If
    End Sub

    Private Sub AGauge1_ValueInRangeChanged(sender As Object, e As ValueInRangeChangedEventArgs) Handles AGauge1.ValueInRangeChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SerialPort1.Write("a")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        SerialPort1.Write("b")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SerialPort1.Write("c")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        SerialPort1.Write("d")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SerialPort1.Write("e")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SerialPort1.Write("f")
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        ' Mengambil nilai dari TrackBar
        Dim trackBarValue As Integer = TrackBar1.Value

        ' Menampilkan nilai di Label13
        Label24.Text = trackBarValue.ToString() + "#"

        Try
            Dim command As String = trackBarValue.ToString() ' Konversi nilai Slider ke String
            SerialPort1.Write(command) ' Mengirim perintah ke perangkat melalui SerialPort
        Catch ex As Exception
            MessageBox.Show("Gagal mengirim data melalui SerialPort: " & ex.Message)
        End Try

    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click

    End Sub
End Class
