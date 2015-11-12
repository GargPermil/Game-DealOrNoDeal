Public Class Form2

    Dim _amt As String
    Dim _bagno As Integer

    Public WriteOnly Property Amount As String
        Set(ByVal value As String)
            _amt = value
        End Set
    End Property

    Public WriteOnly Property Bag_No As String
        Set(ByVal value As String)
            _bagno = value
        End Set
    End Property

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 4
        Dim tmp_img As Bitmap = New Bitmap(Application.StartupPath & "\images\bagopen.png")
        Dim g As Graphics = Graphics.FromImage(tmp_img)
        Dim font As Font = New Font("Arial", 35)
        Dim sf As StringFormat = New StringFormat()
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        g.FillRectangle(Brushes.Orange, 70, 113, 300, 75)
        g.DrawString(_amt, font, Brushes.White, 220, 153, sf)
        PictureBox1.Image = tmp_img
    End Sub

End Class