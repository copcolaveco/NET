Public Class FormGraficaGrasaProteina
#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


    End Sub

#End Region
    Private Sub graficar()
        Chart1.Titles.Clear()
        Chart2.Titles.Clear()
        Dim cgp As New dControlGrasaProteina
        Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecd As String
        Dim fech As String
        fecd = Format(fechadesde, "yyyy-MM-dd")
        fech = Format(fechahasta, "yyyy-MM-dd")
        Dim lista As New ArrayList
        Chart1.Titles.Add("Grasa")
        Chart2.Titles.Add("Proteína")
        lista = cgp.listarporfecha(fecd, fech)
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart2.Series(0).Points.Clear()
        Chart2.Series(1).Points.Clear()
        Chart2.Series(2).Points.Clear()
        Chart2.Series(3).Points.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each cgp In lista
                    If cgp.BENTLEYG <> -1 Then
                        Chart1.Series(0).Points.AddXY(cgp.FECHA, cgp.BENTLEYG)
                    End If
                    If cgp.DELTAG <> -1 Then
                        Chart1.Series(1).Points.AddXY(cgp.FECHA, cgp.DELTAG)
                    End If
                    If cgp.ROSEGOTTLIEBG <> -1 Then
                        Chart1.Series(2).Points.AddXY(cgp.FECHA, cgp.ROSEGOTTLIEBG)
                    End If
                    If cgp.GERBERG <> -1 Then
                        Chart1.Series(3).Points.AddXY(cgp.FECHA, cgp.GERBERG)
                    End If
                    If cgp.BENTLEYP <> -1 Then
                        Chart2.Series(0).Points.AddXY(cgp.FECHA, cgp.BENTLEYP)
                    End If
                    If cgp.DELTAP <> -1 Then
                        Chart2.Series(1).Points.AddXY(cgp.FECHA, cgp.DELTAP)
                    End If
                    If cgp.DUMASP <> -1 Then
                        Chart2.Series(2).Points.AddXY(cgp.FECHA, cgp.DUMASP)
                    End If
                    If cgp.KJELDAHP <> -1 Then
                        Chart2.Series(3).Points.AddXY(cgp.FECHA, cgp.KJELDAHP)
                    End If
                Next
            End If
        End If
        cgp = Nothing
        lista = Nothing
    End Sub
   
    Private Sub ButtonGraficar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGraficar.Click
        graficar()
    End Sub
End Class