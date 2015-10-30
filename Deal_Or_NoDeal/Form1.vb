Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Width = Screen.PrimaryScreen.Bounds.Width
        Me.Height = Screen.PrimaryScreen.Bounds.Height
        Me.Top = 0
        Me.Left = 0
        Label1.Left = (Me.Width - Label1.Width) / 2
        Label1.Top = 35
        MoneyBoard1.Top = (Me.Height - MoneyBoard1.Height - 30) / 2
        MoneyBoard2.Top = (Me.Height - MoneyBoard2.Height - 30) / 2
    End Sub

    Private Sub Form1_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        Me.Top = 0
        Me.Left = 0
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Top = 0
        Me.Left = 0
        Label1.Left = (Me.Width - Label1.Width) / 2
        MoneyBoard1.Top = (Me.Height - MoneyBoard1.Height - 30) / 2
        MoneyBoard2.Top = (Me.Height - MoneyBoard2.Height - 30) / 2
    End Sub
End Class
