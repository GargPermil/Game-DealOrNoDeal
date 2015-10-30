﻿Public Class Game_Engine
#Region "Declare"
    Public Structure Money
        Public amount As Integer
        Public Active As Boolean
        Public type As Integer
    End Structure

    Private Structure bag
        Friend open As Boolean
        Friend moneyidx As Integer
    End Structure

    Private Structure player
        Friend name As String
        Friend bag As Integer
    End Structure

    Private Structure round
        Friend remaining_bags As Integer
        Friend roundno As Integer
        Friend isactive As Boolean
        Friend Sub openbag()
            If remaining_bags > 1 Then
                remaining_bags -= 1
            Else
                remaining_bags -= 1
                isactive = False
            End If
        End Sub
        Friend Sub nextround()
            If roundno = 1 Then
                remaining_bags = 5
                roundno = 2
                isactive = True
            ElseIf roundno = 2 Then
                remaining_bags = 4
                roundno = 3
                isactive = True
            ElseIf roundno = 3 Then
                remaining_bags = 3
                roundno = 4
                isactive = True
            ElseIf roundno = 4 Then
                remaining_bags = 2
                roundno = 5
                isactive = True
            ElseIf roundno = 5 Then
                remaining_bags = 1
                roundno = 6
                isactive = True
            ElseIf roundno = 6 Then
                remaining_bags = 1
                roundno = 7
                isactive = True
            ElseIf roundno = 7 Then
                remaining_bags = 1
                roundno = 8
                isactive = True
            ElseIf roundno = 8 Then
                remaining_bags = 1
                roundno = 9
                isactive = True
            End If
        End Sub
    End Structure

    Public ReadOnly moneyboard(25) As Money
    Private bags(25) As bag
    Private cplayer As player
    Dim remainingbag As Integer = 26
    Public wonamount As Integer = 0
    Public _isrunning As Boolean = True
    Public bankeroffer As Integer
    Private _Round As round
#End Region

#Region "initialize"
    Sub New(ByVal pname As String, ByVal bagno As Integer)
        initialize_moneyboard()
        initialize_bags()
        cplayer.name = pname
        cplayer.bag = bagno
        _Round.roundno = 1
        _Round.isactive = True
        _Round.remaining_bags = 6
    End Sub

    Private Sub initialize_bags()
        bags(0).open = False
        bags(1).open = False
        bags(2).open = False
        bags(3).open = False
        bags(4).open = False
        bags(5).open = False
        bags(6).open = False
        bags(7).open = False
        bags(8).open = False
        bags(9).open = False
        bags(10).open = False
        bags(11).open = False
        bags(12).open = False
        bags(13).open = False
        bags(14).open = False
        bags(15).open = False
        bags(16).open = False
        bags(17).open = False
        bags(18).open = False
        bags(19).open = False
        bags(20).open = False
        bags(21).open = False
        bags(22).open = False
        bags(23).open = False
        bags(24).open = False
        bags(25).open = False

        Dim tmp(25), i, tmpidx As Integer

        For i = 0 To 25
            tmp(i) = i
        Next
        For i = 0 To 25
            tmpidx = GetRandom(i, 25)
            bags(i).moneyidx = tmp(tmpidx)
            tmp(tmpidx) = tmp(i)
        Next
    End Sub

    Private Sub initialize_moneyboard()
        moneyboard(1).Active = True
        moneyboard(2).Active = True
        moneyboard(3).Active = True
        moneyboard(4).Active = True
        moneyboard(5).Active = True
        moneyboard(6).Active = True
        moneyboard(7).Active = True
        moneyboard(8).Active = True
        moneyboard(9).Active = True
        moneyboard(10).Active = True
        moneyboard(11).Active = True
        moneyboard(12).Active = True
        moneyboard(13).Active = True
        moneyboard(14).Active = True
        moneyboard(15).Active = True
        moneyboard(16).Active = True
        moneyboard(17).Active = True
        moneyboard(18).Active = True
        moneyboard(19).Active = True
        moneyboard(20).Active = True
        moneyboard(21).Active = True
        moneyboard(22).Active = True
        moneyboard(23).Active = True
        moneyboard(24).Active = True
        moneyboard(25).Active = True
        moneyboard(0).amount = 0.25
        moneyboard(1).amount = 1
        moneyboard(2).amount = 10
        moneyboard(3).amount = 100
        moneyboard(4).amount = 250
        moneyboard(5).amount = 500
        moneyboard(6).amount = 1000
        moneyboard(7).amount = 2500
        moneyboard(8).amount = 5000
        moneyboard(9).amount = 10000
        moneyboard(10).amount = 25000
        moneyboard(11).amount = 50000
        moneyboard(12).amount = 75000
        moneyboard(13).amount = 100000
        moneyboard(14).amount = 150000
        moneyboard(15).amount = 200000
        moneyboard(16).amount = 300000
        moneyboard(17).amount = 400000
        moneyboard(18).amount = 500000
        moneyboard(19).amount = 750000
        moneyboard(20).amount = 1000000
        moneyboard(21).amount = 1500000
        moneyboard(22).amount = 2500000
        moneyboard(23).amount = 5000000
        moneyboard(24).amount = 7500000
        moneyboard(25).amount = 10000000
        moneyboard(0).type = 0
        moneyboard(1).type = 0
        moneyboard(2).type = 0
        moneyboard(3).type = 0
        moneyboard(4).type = 0
        moneyboard(5).type = 0
        moneyboard(6).type = 0
        moneyboard(7).type = 0
        moneyboard(8).type = 0
        moneyboard(9).type = 0
        moneyboard(10).type = 0
        moneyboard(11).type = 0
        moneyboard(12).type = 0
        moneyboard(13).type = 1
        moneyboard(15).type = 1
        moneyboard(16).type = 1
        moneyboard(17).type = 1
        moneyboard(18).type = 1
        moneyboard(19).type = 1
        moneyboard(20).type = 1
        moneyboard(21).type = 1
        moneyboard(22).type = 2
        moneyboard(23).type = 2
        moneyboard(24).type = 2
        moneyboard(25).type = 2
    End Sub
#End Region

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        ' by making Generator static, we preserve the same instance '
        ' (i.e., do not create new instances with the same seed over and over) '
        ' between calls '
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function

    Public Function openbag(ByVal bagno As Integer) As Integer
        Dim _bagno As Integer = bagno - 1
        If bagno > 0 And bagno < 27 And _Round.isactive = True Then
            If bags(_bagno).open = False And _bagno <> cplayer.bag Then
                bags(_bagno).open = True
                moneyboard(bags(_bagno).moneyidx).Active = False
                remainingbag -= 1
                _Round.openbag()
                Return moneyboard(bags(_bagno).moneyidx).amount
            End If
        ElseIf remainingbag = 2 Then
            bags(_bagno).open = True
            moneyboard(bags(_bagno).moneyidx).Active = False
            For i As Integer = 0 To 25
                If bags(i).open = False Then
                    wonamount = moneyboard(bags(i).moneyidx).amount
                    _isrunning = False
                End If
            Next
        End If
        If _Round.isactive = False Then
            makedealamount()
        End If
        Return 0
    End Function

    Public Sub DealOrNoDeal(ByVal deal As String)
        If deal = 0 Then
            wonamount = bankeroffer
            _isrunning = False
        Else
            _Round.nextround()
        End If
    End Sub

    Private Sub makedealamount()
        Dim total_amount = 0, average As Integer
        For i As Integer = 0 To 25
            If moneyboard(i).Active = True Then
                total_amount += moneyboard(i).amount
            End If
        Next
        average = total_amount / remainingbag
        average = Math.Round(average)
        bankeroffer = average
    End Sub
End Class
