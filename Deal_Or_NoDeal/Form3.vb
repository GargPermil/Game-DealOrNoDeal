Public Class Form3

    Dim _gameobj As Game_Engine

    Public WriteOnly Property Game_Obj As Game_Engine
        Set(ByVal value As Game_Engine)
            _gameobj = value
        End Set
    End Property

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        render_picturebox()
    End Sub

    Private Sub render_picturebox()
        Dim path As String = Application.StartupPath & "\images\Orange.png"
        Dim img_deal_amount As New Bitmap(350, 84)
        Dim tmp_img As New Bitmap(path)
        Dim g As Graphics = Graphics.FromImage(tmp_img)
        Dim fo As Font = New Font("Arial", 8)
        Dim sf As StringFormat = New StringFormat()
        sf.Alignment = StringAlignment.Far
        sf.LineAlignment = StringAlignment.Center
        g.DrawString(_gameobj.get_Banker_offer, fo, Brushes.White, 235, 30, sf)
        g.Save()
        g.Dispose()
        sf.Dispose()
        g = Graphics.FromImage(img_deal_amount)
        g.DrawImage(tmp_img, 0, 0, 350, 84)
        g.Dispose()
        PictureBox1.Image = img_deal_amount
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DialogResult = Windows.Forms.DialogResult.Yes
        Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        DialogResult = Windows.Forms.DialogResult.No
        Close()
    End Sub
End Class