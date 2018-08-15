Public Class anmation
    Private WithEvents Timer1 As New System.Windows.Forms.Timer With {.Interval = 30}
    Private yfactors(1000) As Single

    Private Sub Form10_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.BackgroundImageLayout = ImageLayout.None
        Me.DoubleBuffered = True

        For d = 0 To 1000
            yfactors(d) = 2 * Math.Cos(d / 26)
        Next

        Timer1.Start()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        Dim bmp As Bitmap = New Bitmap(Me.ClientSize.Width, Me.ClientSize.Height)
        Dim theText As String = "Here is my example."
        Static x As Integer = -(theText.Length * 15 + 20)
        Dim y, xx As Integer

        x += 3
        If x > Me.ClientSize.Width Then x = -(theText.Length * 15 + 20)

        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.Black)
            For i = 1 To theText.Length
                xx = x + (i * 15)
                y = 100 + (10 * yfactors(xx + 300))
                g.DrawString(Mid(theText, i, 1), New Font("Arial", 16), Brushes.Red, xx, y)
            Next
            Me.BackgroundImage = bmp
        End Using
    End Sub
End Class
