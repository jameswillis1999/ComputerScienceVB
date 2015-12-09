' Game I made as a challenge in class.
' 3 Stacks of randomly generated numbers (sticks)
' Player & computer goes in turn to pick one stack at a time and remove a specified number of sticks

Public Class Form1

    'Declarations
    Dim bytPileOne As Byte
    Dim bytPileTwo As Byte
    Dim bytPileThree As Byte

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Disable the options which you use when playing the game
        rbPileOne.Enabled = False
        rbPileTwo.Enabled = False
        rbPileThree.Enabled = False
        btnMakeChoice.Enabled = False
        Randomize()
        lblOutput.Text = " "
    End Sub

    Public Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        'Disable the start buton
        btnStart.Enabled = False

        'Enable the controls for the game.
        rbPileOne.Enabled = True
        rbPileTwo.Enabled = True
        rbPileThree.Enabled = True
        btnMakeChoice.Enabled = True

        'Set a random number of matches
        bytPileOne = Int(Rnd() * 200)
        bytPileTwo = Int(Rnd() * 200)
        bytPileThree = Int(Rnd() * 200)

        'Display this number of matches
        lblPileOne.Text = bytPileOne.ToString
        lblPileTwo.Text = bytPileTwo.ToString
        lblPileThree.Text = bytPileThree.ToString

        'Reset the output to nothing
        lblOutput.Text = " "

    End Sub

    Private Sub btnMakeChoice_Click(sender As Object, e As EventArgs) Handles btnMakeChoice.Click

        'Declarations
        Dim intUserChoice As Integer
        Dim strLastPlayer As String
        Dim booGame As Boolean

        If rbPileOne.Checked = True Or rbPileTwo.Checked = True Or rbPileThree.Checked = True Then


            'Check if the game is over.
            If booGame = False Then

                'User picking the matches
                intUserChoice = txtUserChoice.Text

                If rbPileOne.Checked = True Then
                    If intUserChoice > bytPileOne Then
                        MsgBox("Miss a turn")
                    Else
                        bytPileOne = bytPileOne - intUserChoice
                        lblPileOne.Text = bytPileOne.ToString
                        rbPileOne.Checked = False
                        If bytPileOne = 0 Then
                            rbPileOne.Enabled = False
                        End If
                    End If

                End If

                If rbPileTwo.Checked = True Then
                    If intUserChoice > bytPileTwo Then
                        MsgBox("Miss a turn")
                    Else
                        bytPileTwo = bytPileTwo - intUserChoice
                        lblPileTwo.Text = bytPileTwo.ToString
                        rbPileTwo.Checked = False
                        If bytPileTwo = 0 Then
                            rbPileTwo.Enabled = False
                        End If
                    End If

                End If

                If rbPileThree.Checked = True Then
                    If intUserChoice > bytPileThree Then
                        MsgBox("Miss a turn")
                    Else
                        bytPileThree = bytPileThree - intUserChoice
                        lblPileThree.Text = bytPileThree.ToString
                        rbPileThree.Checked = False
                        If bytPileThree = 0 Then
                            rbPileThree.Enabled = False
                        End If
                    End If

                End If

                'if this is the last round then the computer is the winner
                strLastPlayer = "Computer"


                'End of the game script
                If bytPileOne = 0 Then
                    If bytPileTwo = 0 Then
                        If bytPileThree = 0 Then
                            lblOutput.Text = strLastPlayer.ToString + " is the winner"
                            btnMakeChoice.Enabled = False
                            btnStart.Enabled = True
                            booGame = True
                        End If
                    End If
                End If

            End If

            'Check if the game has ended.
            If booGame = False Then

                'Computers Turn
                Dim bytCmpPile As Byte
                Dim bytComputerChoice As Byte
                bytCmpPile = Int(Rnd() * 3 + 1)

                'Selecting the pile which the computer picks from.
                Select Case bytCmpPile
                    Case 1
                        If bytPileOne = 0 Then
                            rbPileOne.Enabled = False
                            If bytPileTwo = 0 Then
                                'pile three

                                bytComputerChoice = Int(Rnd() * bytPileThree + 1)
                                bytPileThree = bytPileThree - bytComputerChoice
                                lblPileThree.Text = bytPileThree.ToString
                            ElseIf bytPileThree = 0 Then
                                'Pile Two

                                bytComputerChoice = Int(Rnd() * bytPileTwo + 1)
                                bytPileTwo = bytPileTwo - bytComputerChoice
                                lblPileTwo.Text = bytPileTwo.ToString
                            End If

                        Else
                            bytComputerChoice = Int(Rnd() * bytPileOne + 1)
                            bytPileOne = bytPileOne - bytComputerChoice
                            lblPileOne.Text = bytPileOne.ToString
                        End If

                    Case 2
                        If bytPileTwo = 0 Then
                            rbPileTwo.Enabled = False

                            If bytPileOne = 0 Then

                                'Pile Three

                                bytComputerChoice = Int(Rnd() * bytPileThree + 1)
                                bytPileThree = bytPileThree - bytComputerChoice
                                lblPileThree.Text = bytPileThree.ToString
                            ElseIf bytPileThree = 0 Then
                                'Pile one
                                bytComputerChoice = Int(Rnd() * bytPileOne + 1)
                                bytPileOne = bytPileOne - bytComputerChoice
                                lblPileOne.Text = bytPileOne.ToString
                            End If


                        Else
                            bytComputerChoice = Int(Rnd() * bytPileTwo + 1)
                            bytPileTwo = bytPileTwo - bytComputerChoice
                            lblPileTwo.Text = bytPileTwo.ToString
                        End If

                    Case 3
                        If bytPileThree = 0 Then
                            rbPileThree.Enabled = False

                            If bytPileTwo = 0 Then
                                'Pile one

                                bytComputerChoice = Int(Rnd() * bytPileOne + 1)
                                bytPileOne = bytPileOne - bytComputerChoice
                                lblPileOne.Text = bytPileOne.ToString

                            ElseIf bytPileOne = 0 Then
                                'Pile Two

                                bytComputerChoice = Int(Rnd() * bytPileTwo + 1)
                                bytPileTwo = bytPileTwo - bytComputerChoice
                                lblPileTwo.Text = bytPileTwo.ToString
                            End If

                        Else
                            bytComputerChoice = Int(Rnd() * bytPileThree + 1)
                            bytPileThree = bytPileThree - bytComputerChoice
                            lblPileThree.Text = bytPileThree.ToString
                        End If
                End Select

                'Disable the piles which have 0 on.
                If bytPileOne = 0 Then
                    rbPileOne.Enabled = False
                ElseIf bytPileTwo = 0 Then
                    rbPileTwo.Enabled = False
                ElseIf bytPileThree = 0 Then
                    rbPileThree.Enabled = False
                End If

                'If this is the last round then the player if the looser.
                strLastPlayer = "Player"

                lblPileOne.Text = bytPileOne.ToString
                lblPileTwo.Text = bytPileTwo.ToString
                lblPileThree.Text = bytPileThree.ToString

                'End Game script
                If bytPileOne = 0 Then
                    If bytPileTwo = 0 Then
                        If bytPileThree = 0 Then
                            lblOutput.Text = strLastPlayer.ToString + " is the winner"
                            btnMakeChoice.Enabled = False
                            btnStart.Enabled = True


                        End If
                    End If
                End If
            End If
        Else
            MsgBox("Please choose a pile.")
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        End
    End Sub
End Class
