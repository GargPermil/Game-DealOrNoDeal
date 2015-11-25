Public Class Form4
    Dim _amt As String
    Dim _amtb As Boolean = False
    Dim _type As Integer
    Dim _typeb As Boolean = False
    Dim _player_bag_amt As String
    Dim _player_bag_amtb As Boolean = False


    Public WriteOnly Property amount As String
        Set(ByVal value As String)
            _amt = value
            _amtb = True
        End Set
    End Property

    Public WriteOnly Property type As Integer
        Set(ByVal value As Integer)
            _type = value
            _typeb = True
        End Set
    End Property

    Public WriteOnly Property Player_bag_amount As String
        Set(ByVal value As String)
            _player_bag_amt = value
            _player_bag_amtb = True
        End Set
    End Property

    Private Sub Form4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        End
    End Sub

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label3.Text = _amt
        Label7.Text = _player_bag_amt
        If _amtb = False And _typeb = False And _player_bag_amtb = False Then
            Me.Close()
        End If
        If _type = 0 Then
            Label4.Visible = True
            Label5.Visible = True
        ElseIf _type = 1 Then
            Label5.Visible = True
            Label5.Top = 241
            Label6.Visible = True
        ElseIf _type = 2 Then
            Label6.Visible = True
        End If
        Label3.Left = (Me.Width - Label3.Width) / 2
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
    End Sub
End Class