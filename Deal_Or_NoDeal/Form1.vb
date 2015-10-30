Public Class Form1

    Dim GameEng As Game_Engine
    Dim img_money_board As New Bitmap(350, 600)
    Dim img_money(26) As Bitmap

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Width = Screen.PrimaryScreen.Bounds.Width
        Me.Height = Screen.PrimaryScreen.Bounds.Height
        Me.Top = 0
        Me.Left = 0
        Label1.Left = (Me.Width - Label1.Width) / 2
        Label1.Top = 10
        MoneyBoard1.Top = (Me.Height - MoneyBoard1.Height - 30) / 2
        GameEng = New Game_Engine("hello", 4)
        initialize_moneyboard()
        MoneyBoard1.Image = img_money_board
        initialize_round()
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
    End Sub

    Private Sub initialize_moneyboard()
        initialize_money()
        Dim g As Graphics = Graphics.FromImage(img_money_board)
        g.Clear(Color.Black)
        Dim x, y As Integer
        x = 0
        y = 0
        For i As Integer = 0 To 25
            g.DrawImage(img_money(i), x, y, 170, 41)
            y += 46
            If i = 12 Then
                x = 175
                y = 0
            End If
        Next
    End Sub

    Private Sub initialize_money()
        Dim path As String = ""
        For i As Integer = 0 To 25
            If GameEng.moneyboard(i).type = 0 Then
                path = Application.StartupPath & "\images\green.png"
            ElseIf GameEng.moneyboard(i).type = 1 Then
                path = Application.StartupPath & "\images\Orange.png"
            ElseIf GameEng.moneyboard(i).type = 2 Then
                path = Application.StartupPath & "\images\red.png"
            End If
            img_money(i) = New Bitmap(path)
            Dim g As Graphics = Graphics.FromImage(img_money(i))
            Dim fo As Font = New Font("Arial", 8)
            Dim sf As StringFormat = New StringFormat()
            sf.Alignment = StringAlignment.Far
            sf.LineAlignment = StringAlignment.Center
            g.DrawString(GameEng.moneyboard(i).amount.ToString(), fo, Brushes.White, 235, 30, sf)
            If GameEng.moneyboard(i).Active = False Then
                Dim transparent_brush As New SolidBrush(Color.FromArgb(200, Color.Black))
                g.FillRectangle(transparent_brush, 0, 0, 250, 60)
            End If
            g.Save()
            g.Dispose()
            sf.Dispose()
        Next
    End Sub

    Private Sub initialize_round()
        Dim img_round As New Bitmap(460, 55)
        Dim img_briefcase As New Bitmap(Application.StartupPath & "\images\bag.png")
        Dim g As Graphics = Graphics.FromImage(img_round)
        For i As Integer = 0 To GameEng.getroundremaining()
            g.DrawImage(img_briefcase, 75 * (i - 1), 10, 65, 50)
        Next
        g.Save()
        g.Dispose()
        PictureBox2.Image = img_round
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox(GameEng.openbag(TextBox1.Text))
        initialize_moneyboard()
        MoneyBoard1.Image = img_money_board
        initialize_round()
    End Sub
End Class
