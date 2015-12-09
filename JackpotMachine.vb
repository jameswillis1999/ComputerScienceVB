' Created this code recently for a project,
' it was a complete overhaul of the GameOfNim project
' It has Functions and While.


Public Class Form1

    'Declarations of all the variables
    Dim bytNumber As Byte
    Dim bytLeft As Byte
    Dim bytMid As Byte
    Dim bytRight As Byte
    Dim intMoney As Decimal
    Dim i As Byte

    Public Function pictureSelector()
        'This function uses the random numbers to assign a image to the picture box
        Select Case bytNumber
            Case 1
                Return My.Resources.cherry
            Case 2
                Return My.Resources.lemon
            Case 3
                Return My.Resources.orange
            Case 4
                Return My.Resources.melon
            Case 5
                Return My.Resources.bannana
            Case 6
                Return My.Resources.bigwin
        End Select
    End Function

    Public Function pictureNamer()
        'Sets the number related to the picture
        'so it can be compared later in the program.
        Select Case bytNumber
            Case 1
                Return 1 ' cherry
            Case 2
                Return 2 ' lemon
            Case 3
                Return 3 ' orange
            Case 4
                Return 4 ' melon
            Case 5
                Return 5 ' bannana
            Case 6
                Return 6 ' bigwin
        End Select
    End Function


    Public Function picturePicker()
        'This function is used 3 times
        'It selects the image and the name(number) of the picure 
        'is set so we can compare it later.
        Select Case i
            Case 1
                pbLeft1.Image = pictureSelector()
                bytLeft = pictureNamer()
            Case 2
                pbMid1.Image = pictureSelector()
                bytMid = pictureNamer()
            Case 3
                pbRight1.Image = pictureSelector()
                bytRight = pictureNamer()
        End Select
    End Function

    Public Function Game()

        'This is to make sure more than one message is not displayed in the output.
        Dim out As Boolean = False

        'Picks a random number 3 times and calls the Picture picker function to 
        'select which picture box the picture goes into.
        i = 1
        While i <= 3
            bytNumber = Int(Rnd() * 6 + 1)
            picturePicker()
            i = i + 1
        End While

        'Code below checks if the numbers are the same.
        'checks for all 3 the same for the jackpot and
        'any other symbol
        If (bytLeft = bytMid) Then
            If (bytLeft = bytRight) Then
                If (bytMid = bytRight) Then

                    If (bytLeft = 6) Then
                        'Checks if BIG WIN photo is on all 3
                        intMoney = intMoney + 5
                        MsgBox("JACKPOT YOU WIN £5!")
                        lblMoney.Text = FormatCurrency(intMoney)
                        out = True
                    End If

                    If out = False Then
                        'output if any 3 are the same.
                        intMoney = intMoney + 1
                        MsgBox("YOU WIN £1!")
                        lblMoney.Text = FormatCurrency(intMoney)
                        out = True
                    End If

                End If
            End If
        End If

        'All code below checks if two are the same.

        'Check if left and middle are the same
        If (bytLeft = bytMid) And (out = False) Then
            intMoney = intMoney + 0.2
            MsgBox("YOU WIN £0.20!")
            lblMoney.Text = FormatCurrency(intMoney)
            out = True
        End If

        'Check if left and right are the same
        If (bytLeft = bytRight) And (out = False) Then
            intMoney = intMoney + 0.2
            MsgBox("YOU WIN £0.20!")
            lblMoney.Text = FormatCurrency(intMoney)
            out = True
        End If

        'Check if middle and right are the same
        If (bytMid = bytRight) And (out = False) Then
            intMoney = intMoney + 0.2
            MsgBox("YOU WIN £0.20!")
            lblMoney.Text = FormatCurrency(intMoney)
            out = True
        End If

    End Function


    Public Sub btnSpin_Click(sender As Object, e As EventArgs) Handles btnSpin.Click

        If intMoney <= 0 Then ' If the player has run out of money
            MsgBox("You have run out of money, input £1 if you would like to play again.")
            btnSpin.Enabled = False
            btnInsert.Enabled = True
        Else 'If the player still has money left.

            'When the spin button is clicked remove 20p from total money.
            intMoney = intMoney - 0.2
            lblMoney.Text = FormatCurrency(intMoney)

            'To the game function
            Game()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'When the form loads randomise the numbers and disable the spin button.
        Randomize()
        btnSpin.Enabled = False
    End Sub

    Public Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        'When the player clicks the insert button they are given 
        '£1 credit and the spin button is enabled.
        intMoney = 1
        lblMoney.Text = FormatCurrency(intMoney)
        btnSpin.Enabled = True
        btnInsert.Enabled = False
    End Sub
End Class
