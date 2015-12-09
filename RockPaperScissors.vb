' A simple rock paper scissors game.
' Has a system where you can bet on if you win.

Public Class Form1

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        End
    End Sub

    Public Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click



        Dim intMoney As Integer = Val(lblMoney.Text)
        Dim intBet As Integer

        Dim playerChoice, cmpChoice As Byte

        


        intBet = nudBet.Value
        lblMoney.Text = lblMoney.Text - intBet

        If rbRock.Checked = True Then
            playerChoice = 1
        End If
        If rbPaper.Checked = True Then
            playerChoice = 2
        End If
        If rbScissors.Checked = True Then
            playerChoice = 3
        End If


        'Computers Choice
        cmpChoice = Int(Rnd() * 3 + 1)
        lblCmp.Text = cmpChoice.ToString


        'Processing

        If cmpChoice = playerChoice Then
            lbltest.Text = "Draw"
        End If


        'Computer chose Rock
        If cmpChoice = 1 And playerChoice = 3 Then
            lbltest.Text = "Lose"
        ElseIf cmpChoice = 1 And playerChoice = 2 Then
            lbltest.Text = "Win"
        End If

        'Computer chose Paper
        If cmpChoice = 2 And playerChoice = 1 Then
            lbltest.Text = "Lose"
        ElseIf cmpChoice = 2 And playerChoice = 3 Then
            lbltest.Text = "Win"
        End If

        'Computer chose Scissors
        If cmpChoice = 3 And playerChoice = 1 Then
            lbltest.Text = "Win"
        ElseIf cmpChoice = 3 And playerChoice = 2 Then
            lbltest.Text = "Lose"
        End If



        If lbltest.Text = "Win" Then
            lblMoney.Text = intMoney + (intBet * 2)
        End If




    End Sub

    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblMoney.Text = 10
        Randomize()

    End Sub
End Class
