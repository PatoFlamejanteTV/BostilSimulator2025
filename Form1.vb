Public Class MENU
    Private WithEvents backgroundWorker As New System.ComponentModel.BackgroundWorker
    Private currentColorIndex As Integer = 0

    Private Sub MENU_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        backgroundWorker.WorkerReportsProgress = False
        AddHandler backgroundWorker.DoWork, AddressOf BackgroundWorker_DoWork
        AddHandler backgroundWorker.RunWorkerCompleted, AddressOf BackgroundWorker_RunWorkerCompleted
        backgroundWorker.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim rainbowColors As Color() = {
            Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Indigo, Color.Violet
        }

        Do
            For I As Integer = 200 To 255
                ' Calculate color components based on the current rainbow color
                Dim currentColor As Color = rainbowColors(currentColorIndex)
                Dim red As Integer = currentColor.R * I / 255
                Dim green As Integer = currentColor.G * I / 255
                Dim blue As Integer = currentColor.B * I / 255

                ' Simulate work to make the effect smoother
                System.Threading.Thread.Sleep(1)

                ' Update the UI control on the main thread using Invoke
                Me.Invoke(Sub()
                              LOGOTITLE.ForeColor = Color.FromArgb(red, green, blue)
                          End Sub)
            Next

            ' Move to the next color in the rainbow
            currentColorIndex = (currentColorIndex + 1) Mod rainbowColors.Length

        Loop
    End Sub

    Private Sub BackgroundWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
        ' Optional: Handle completion (e.g., enable controls)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For i As Integer = 100 To 0 Step -1 ' Decrement i from 100 to 0
            System.Threading.Thread.Sleep(10)
            Me.Invoke(Sub()
                          Me.Opacity = i / 100.0
                      End Sub)
        Next
    End Sub
End Class