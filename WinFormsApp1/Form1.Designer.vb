<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RST
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        HScrollBar1 = New HScrollBar()
        ProgressBar1 = New ProgressBar()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(31, 523)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 0
        Button1.Text = "ON 1"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(128, 523)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 23)
        Button2.TabIndex = 1
        Button2.Text = "OFF 1"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(300, 523)
        Button3.Name = "Button3"
        Button3.Size = New Size(75, 23)
        Button3.TabIndex = 2
        Button3.Text = "ON 2"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(398, 523)
        Button4.Name = "Button4"
        Button4.Size = New Size(75, 23)
        Button4.TabIndex = 3
        Button4.Text = "OFF 2"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' HScrollBar1
        ' 
        HScrollBar1.Location = New Point(566, 523)
        HScrollBar1.Name = "HScrollBar1"
        HScrollBar1.Size = New Size(198, 23)
        HScrollBar1.TabIndex = 4
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Location = New Point(31, 27)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(100, 23)
        ProgressBar1.Style = ProgressBarStyle.Continuous
        ProgressBar1.TabIndex = 5
        ' 
        ' RST
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 581)
        Controls.Add(ProgressBar1)
        Controls.Add(HScrollBar1)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Name = "RST"
        Text = "Form1"
        ResumeLayout(False)
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents HScrollBar1 As HScrollBar
    Friend WithEvents ProgressBar1 As ProgressBar

End Class
