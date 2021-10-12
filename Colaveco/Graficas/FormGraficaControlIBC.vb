Public Class FormGraficaControlIBC

    Private Sub ButtonGraficar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGraficar.Click
        graficarbajo()
        graficaralto()
    End Sub
    Private Sub graficarbajo()
        Chart1.Titles.Clear()
        Dim c As New dLecturasIbc
        Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecd As String
        Dim fech As String
        fecd = Format(fechadesde, "yyyy-MM-dd")
        fech = Format(fechahasta, "yyyy-MM-dd")
        Dim lista As New ArrayList
        Chart1.Titles.Add("Piloto de valores bajos")
        lista = c.listarporfecha(fecd, fech)
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()


        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    Chart1.Series(0).Points.AddXY(c.FECHA, c.B1)
                    Chart1.Series(1).Points.AddXY(c.FECHA, c.B1)
                Next
            End If
        End If
    End Sub
    Private Sub graficaralto()
        Chart2.Titles.Clear()
        Dim c As New dLecturasIbc
        Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecd As String
        Dim fech As String
        fecd = Format(fechadesde, "yyyy-MM-dd")
        fech = Format(fechahasta, "yyyy-MM-dd")
        Dim lista As New ArrayList
        Chart2.Titles.Add("Piloto de valores altos")
        lista = c.listarporfecha(fecd, fech)
        Chart2.Series(0).Points.Clear()
        Chart2.Series(1).Points.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    Chart2.Series(0).Points.AddXY(c.FECHA, c.A1)
                    Chart2.Series(1).Points.AddXY(c.FECHA, c.A1)
                Next
            End If
        End If
    End Sub

    Private Sub ButtonVerValores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonVerValores.Click
        Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecd As String
        Dim fech As String
        fecd = Format(fechadesde, "yyyy-MM-dd")
        fech = Format(fechahasta, "yyyy-MM-dd")
        Dim v As New FormVerValoresIBC(fecd, fech)
        v.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    
        Chart1.SaveImage("c:\" & "MRD" & ".jpg", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg)
        Chart2.SaveImage("c:\" & "TQM" & ".jpg", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg)
    End Sub
End Class