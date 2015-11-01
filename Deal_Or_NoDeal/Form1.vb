Public Class Form1

    Dim GameEng As Game_Engine
    Dim img_money_board As New Bitmap(350, 600)
    Dim img_money(26) As Bitmap
    Dim WithEvents gameevents As Game_Engine

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Width = Screen.PrimaryScreen.Bounds.Width
        Me.Height = Screen.PrimaryScreen.Bounds.Height
        Me.Top = 0
        Me.Left = 0
        Label1.Left = (Me.Width - Label1.Width) / 2
        Label1.Top = 10
        MoneyBoard1.Top = (Me.Height - MoneyBoard1.Height - 30) / 2
        Panel1.Left = (Me.Width - Panel1.Width) / 2
        Panel1.Top = (Me.Height - Panel1.Height) / 2
        Panel2.Left = (Me.Width - Panel2.Width) / 2
        Panel3.Left = (Me.Width - Panel3.Width) / 2
        Panel3.Top = (Me.Height - Panel3.Height) / 2
        Panel2.Visible = False
        initialize_start_panel()
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

    Private Sub initialize_previous_deal_panel()
        Dim y As Integer = 0
        Dim img_previous_deal_panel As New Bitmap(250, 530)
        Dim g_panel As Graphics = Graphics.FromImage(img_previous_deal_panel)
        Dim path As String = Application.StartupPath & "\images\Orange.png"
        Dim fo As Font = New Font("Arial", 8)
        Dim sf As StringFormat = New StringFormat()
        sf.Alignment = StringAlignment.Far
        sf.LineAlignment = StringAlignment.Center
        For i As Integer = 0 To GameEng.PreviousBankerOffer.Count - 1
            Dim tmp_img As Bitmap = New Bitmap(path)
            Dim g As Graphics = Graphics.FromImage(tmp_img)
            g.DrawString(GameEng.PreviousBankerOffer(i).ToString, fo, Brushes.White, 235, 30, sf)
            g.Save()
            g.Dispose()
            g_panel.DrawImage(tmp_img, 0, y, 250, 60)
            y += 65
        Next
        sf.Dispose()
        Previous_deal_board.Image = img_previous_deal_panel
    End Sub

    Private Sub initialize_deal_panel()
        Dim path As String = Application.StartupPath & "\images\Orange.png"
        Dim img_deal_amount As New Bitmap(350, 84)
        Dim tmp_img As New Bitmap(path)
        Dim g As Graphics = Graphics.FromImage(tmp_img)
        Dim fo As Font = New Font("Arial", 8)
        Dim sf As StringFormat = New StringFormat()
        sf.Alignment = StringAlignment.Far
        sf.LineAlignment = StringAlignment.Center
        g.DrawString(GameEng.get_Banker_offer, fo, Brushes.White, 235, 30, sf)
        g.Save()
        g.Dispose()
        sf.Dispose()
        g = Graphics.FromImage(img_deal_amount)
        g.DrawImage(tmp_img, 0, 0, 350, 84)
        g.Dispose()
        PictureBox1.Image = img_deal_amount
    End Sub

    Private Sub Reqtoopenbag(ByVal bagno As Integer)
        GameEng.openbag(bagno)
        initialize_moneyboard()
        MoneyBoard1.Image = img_money_board
        initialize_round()
    End Sub

    Private Sub gameevents_DealOrNoDealEvent()
        initialize_deal_panel()
        initialize_previous_deal_panel()
        Panel1.Visible = True
        Previous_deal_board.Visible = True
    End Sub

    Private Sub initialize_bag()
        Dim bags(24) As Integer
        For i As Integer = 0 To 24
            If i < GameEng.get_player_bag - 1 Then
                bags(i) = i + 1
            Else
                bags(i) = i + 2
            End If
        Next
        Button4.Text = bags(0)
        Button5.Text = bags(1)
        Button6.Text = bags(2)
        Button7.Text = bags(3)
        Button8.Text = bags(4)
        Button9.Text = bags(5)
        Button10.Text = bags(6)
        Button11.Text = bags(7)
        Button12.Text = bags(8)
        Button13.Text = bags(9)
        Button14.Text = bags(10)
        Button15.Text = bags(11)
        Button16.Text = bags(12)
        Button17.Text = bags(13)
        Button18.Text = bags(14)
        Button19.Text = bags(15)
        Button20.Text = bags(16)
        Button21.Text = bags(17)
        Button22.Text = bags(18)
        Button23.Text = bags(19)
        Button24.Text = bags(20)
        Button25.Text = bags(21)
        Button26.Text = bags(22)
        Button27.Text = bags(23)
        Button28.Text = bags(24)
    End Sub

    Private Sub initialize_userspace()
        Dim path As String = Application.StartupPath & "\images\bag.png"
        Dim img_user_space As New Bitmap(350, 70)
        Dim tmp_img As New Bitmap(path)
        Dim g As Graphics = Graphics.FromImage(img_user_space)
        Dim fo As Font = New Font("Arial", 30)
        Dim sf As StringFormat = New StringFormat()
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        g.DrawImage(tmp_img, 0, 0, 90, 70)
        g.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.OrangeRed)), 4, 10, 82, 57)
        path = Application.StartupPath & "\images\user.png"
        tmp_img = New Bitmap(path)
        g.DrawImage(tmp_img, 105, 0, 70, 70)
        g.DrawString(GameEng.get_player_bag, fo, Brushes.Black, 45, 41, sf)
        sf.Alignment = StringAlignment.Near
        g.DrawString(GameEng.get_player_name, fo, Brushes.DarkOrange, 190, 35, sf)
        g.Save()
        g.Dispose()
        sf.Dispose()
        PictureBox3.Image = img_user_space
    End Sub

    Private Sub initialize_start_panel()
        Dim path As String = Application.StartupPath & "\images\bag.png"
        Dim fo As Font = New Font("Arial", 150)
        Dim sf As StringFormat = New StringFormat()
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        For i As Integer = 1 To 26
            Dim img_bag As New Bitmap(path)
            Dim g As Graphics = Graphics.FromImage(img_bag)
            g.DrawString(i, fo, Brushes.Black, 176, 160, sf)
            g.Save()
            g.Dispose()
            ImageList1.Images.Add(img_bag)
        Next

        ListView1.Items.Add(" 1", 0)
        ListView1.Items.Add(" 2", 1)
        ListView1.Items.Add(" 3", 2)
        ListView1.Items.Add("4", 3)
        ListView1.Items.Add("5", 4)
        ListView1.Items.Add("6", 5)
        ListView1.Items.Add("7", 6)
        ListView1.Items.Add("8", 7)
        ListView1.Items.Add("9", 8)
        ListView1.Items.Add("10", 9)
        ListView1.Items.Add("11", 10)
        ListView1.Items.Add("12", 11)
        ListView1.Items.Add("13", 12)
        ListView1.Items.Add("14", 13)
        ListView1.Items.Add("15", 14)
        ListView1.Items.Add("16", 15)
        ListView1.Items.Add("17", 16)
        ListView1.Items.Add("18", 17)
        ListView1.Items.Add("19", 18)
        ListView1.Items.Add("20", 19)
        ListView1.Items.Add("21", 20)
        ListView1.Items.Add("22", 21)
        ListView1.Items.Add("23", 22)
        ListView1.Items.Add("24", 23)
        ListView1.Items.Add("25", 24)
        ListView1.Items.Add("26", 25)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GameEng.DealOrNoDeal(0)
        Panel1.Visible = False
        initialize_round()
        Previous_deal_board.Visible = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        GameEng.DealOrNoDeal(1)
        Panel1.Visible = False
        initialize_round()
        Previous_deal_board.Visible = False
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Reqtoopenbag(Button13.Text)
        If GameEng.isbagopened(Button13.Text) = True Then
            Button13.Visible = False
            Button13.Enabled = False
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Reqtoopenbag(Button4.Text)
        If GameEng.isbagopened(Button4.Text) = True Then
            Button4.Visible = False
            Button4.Enabled = False
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Reqtoopenbag(Button5.Text)
        If GameEng.isbagopened(Button5.Text) = True Then
            Button5.Visible = False
            Button5.Enabled = False
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Reqtoopenbag(Button6.Text)
        If GameEng.isbagopened(Button6.Text) = True Then
            Button6.Visible = False
            Button6.Enabled = False
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Reqtoopenbag(Button7.Text)
        If GameEng.isbagopened(Button7.Text) = True Then
            Button7.Visible = False
            Button7.Enabled = False
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Reqtoopenbag(Button8.Text)
        If GameEng.isbagopened(Button8.Text) = True Then
            Button8.Visible = False
            Button8.Enabled = False
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Reqtoopenbag(Button9.Text)
        If GameEng.isbagopened(Button9.Text) = True Then
            Button9.Visible = False
            Button9.Enabled = False
        End If
    End Sub

    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click
        Reqtoopenbag(Button28.Text)
        If GameEng.isbagopened(Button28.Text) = True Then
            Button28.Visible = False
            Button28.Enabled = False
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Reqtoopenbag(Button10.Text)
        If GameEng.isbagopened(Button10.Text) = True Then
            Button10.Visible = False
            Button10.Enabled = False
        End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Reqtoopenbag(Button11.Text)
        If GameEng.isbagopened(Button11.Text) = True Then
            Button11.Visible = False
            Button11.Enabled = False
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Reqtoopenbag(Button12.Text)
        If GameEng.isbagopened(Button12.Text) = True Then
            Button12.Visible = False
            Button12.Enabled = False
        End If
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Reqtoopenbag(Button14.Text)
        If GameEng.isbagopened(Button14.Text) = True Then
            Button14.Visible = False
            Button14.Enabled = False
        End If
    End Sub

    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click
        Reqtoopenbag(Button27.Text)
        If GameEng.isbagopened(Button27.Text) = True Then
            Button27.Visible = False
            Button27.Enabled = False
        End If
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Reqtoopenbag(Button15.Text)
        If GameEng.isbagopened(Button15.Text) = True Then
            Button15.Visible = False
            Button15.Enabled = False
        End If
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Reqtoopenbag(Button16.Text)
        If GameEng.isbagopened(Button16.Text) = True Then
            Button16.Visible = False
            Button16.Enabled = False
        End If
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Reqtoopenbag(Button17.Text)
        If GameEng.isbagopened(Button17.Text) = True Then
            Button17.Visible = False
            Button17.Enabled = False
        End If
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Reqtoopenbag(Button18.Text)
        If GameEng.isbagopened(Button18.Text) = True Then
            Button18.Visible = False
            Button18.Enabled = False
        End If
    End Sub

    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
        Reqtoopenbag(Button26.Text)
        If GameEng.isbagopened(Button26.Text) = True Then
            Button26.Visible = False
            Button26.Enabled = False
        End If
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Reqtoopenbag(Button19.Text)
        If GameEng.isbagopened(Button19.Text) = True Then
            Button19.Visible = False
            Button19.Enabled = False
        End If
    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        Reqtoopenbag(Button20.Text)
        If GameEng.isbagopened(Button20.Text) = True Then
            Button20.Visible = False
            Button20.Enabled = False
        End If
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        Reqtoopenbag(Button21.Text)
        If GameEng.isbagopened(Button21.Text) = True Then
            Button21.Visible = False
            Button21.Enabled = False
        End If
    End Sub

    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        Reqtoopenbag(Button25.Text)
        If GameEng.isbagopened(Button25.Text) = True Then
            Button25.Visible = False
            Button25.Enabled = False
        End If
    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        Reqtoopenbag(Button22.Text)
        If GameEng.isbagopened(Button22.Text) = True Then
            Button22.Visible = False
            Button22.Enabled = False
        End If
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        Reqtoopenbag(Button23.Text)
        If GameEng.isbagopened(Button23.Text) <> 0 Then
            Button23.Visible = False
            Button23.Enabled = False
        End If
    End Sub

    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        Reqtoopenbag(Button24.Text)
        If GameEng.isbagopened(Button24.Text) <> 0 Then
            Button24.Visible = False
            Button24.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GameEng = New Game_Engine(TextBox1.Text, ListView1.SelectedItems(0).ImageIndex + 1)
        initialize_moneyboard()
        MoneyBoard1.Image = img_money_board
        initialize_round()
        initialize_bag()
        initialize_userspace()
        Panel3.Visible = False
        Panel2.Visible = True
        AddHandler GameEng.DealOrNoDealEvent, AddressOf Me.gameevents_DealOrNoDealEvent
    End Sub



    Private Sub gameevents_GameComplete() Handles gameevents.GameComplete

    End Sub
End Class
